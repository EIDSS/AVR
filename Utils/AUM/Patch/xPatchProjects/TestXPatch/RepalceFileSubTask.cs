namespace AUM.XPatch
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.IO;
  using System.Reflection;
  using System.Text;
  using Core;


  //Let's replace some xml file in subfolder of ProgramFiles
  //As a prerequisite there must exist the file "%ProgramFiles%\AUM.TestXPatch\FileToReplace.xml" 
  internal sealed class RepalceFileSubTask : SubTask
  {
    const string FileToReplace = @"AUM.TestXPatch\FileToReplace.xml";


    protected override bool InternalRun()
    {
      // ReSharper disable AssignNullToNotNullAttribute
      var fileToReplaceFullName = Path.Combine(Environment.GetEnvironmentVariable("ProgramFiles"), FileToReplace);
      // ReSharper restore AssignNullToNotNullAttribute

      if (!File.Exists(fileToReplaceFullName))
      {
        throw new FileNotFoundException(string.Format(
          CultureInfo.InvariantCulture,
          "File \"{0}\" must exist for xPatch testing!",
          fileToReplaceFullName));
      }

      RemoveReadOnly(fileToReplaceFullName);
      ReplaceFromResource(fileToReplaceFullName);

      return true;
    }

    private void ReplaceFromResource(string fileToReplaceFullName)
    {
#if DEBUG
      var resourceNames = GetManifestResourceNames();
#endif
      using (var fileToReplaceWithStream = GetManifestResourceStream("AUM.XPatch.FileToReplaceWith.xml"))
      {
        CopyStream(fileToReplaceWithStream, fileToReplaceFullName);
      }
    }

    private static void RemoveReadOnly(string file)
    {
      var currentFileAttributes = File.GetAttributes(file);
      File.SetAttributes(file, currentFileAttributes & ~FileAttributes.ReadOnly);
    }

    private void CopyStream(Stream input, string outputFileName)
    {
      AddInfoString("Trying to write new content to file");
      using (var fileStream = new FileStream(outputFileName, FileMode.Create))
      {
        AddInfoString("File stram opened. Writing new content");
        for (var i = 0; i < input.Length; i++)
        {
          fileStream.WriteByte((byte)input.ReadByte());
        }
        fileStream.Close();
      }

    }

    private static IEnumerable<string> GetManifestResourceNames()
    {
      return Assembly.GetExecutingAssembly().GetManifestResourceNames();
    }

    private static Stream GetManifestResourceStream(string resource)
    {
      return Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
    }
  }
}