namespace AUM.UpdateCreator
{
  using System;
  using System.IO;
  using Core;


  internal sealed class ExecuteOrderBuilder : FileOrderBuilder
  {
    public ExecuteOrderBuilder(string fileOrderConfig) : base(fileOrderConfig)
    {
    }

    protected override void AddFile(string file, bool isChecked)
    {
      if (Path.HasExtension(file) && HasExecutableExtension(file))
      {
        m_files.Add(new ExecuteData { FileName = file, Checked = isChecked, NeedWait = true });
      }
    }

    private static bool HasExecutableExtension(string file)
    {
      // ReSharper disable PossibleNullReferenceException
      return Path.GetExtension(file).Equals(".bat", StringComparison.OrdinalIgnoreCase) ||
             Path.GetExtension(file).Equals(".cmd", StringComparison.OrdinalIgnoreCase) ||
             Path.GetExtension(file).Equals(".exe", StringComparison.OrdinalIgnoreCase);
      // ReSharper restore PossibleNullReferenceException
    }
  }
}