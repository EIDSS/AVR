namespace AUM.XPatch
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Reflection;
  using System.Runtime.InteropServices;
  using Core.Helper;


  internal class InstallFonts : BaseTask
  {
    private const string IdAutomationC128SFont = "IDAutomationC128S.ttf";
    private const string IdAutomationc128XsFont = "IDAutomationC128XS.ttf";

    protected override bool ExecuteInternal()
    {
      var fonts = new List<string> { IdAutomationC128SFont, IdAutomationc128XsFont };
      var fontFullPaths = new List<string>();
      // ReSharper disable AssignNullToNotNullAttribute
      foreach (var fp in fonts.Select(f => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), f)))
      // ReSharper restore AssignNullToNotNullAttribute
      {
        if (!File.Exists(fp))
        {
          AddInfoString("File {0} not found", fp);
          return false;
        }
        fontFullPaths.Add(fp);
      }

      //copy files into Windows Fonts special directory
      AddInfoString("Try to get the system's font directory...");
      var fontWinDir = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
      AddInfoString("Font Directory is {0}", fontWinDir);
      for (var index = 0; index < fontFullPaths.Count; index++)
      {
        var f = fontFullPaths[index];
        var f1 = fonts[index];
        AddInfoString("Copy font {0}...", f);
        var result = FileHelper.CopyFile(f, Path.Combine(fontWinDir, f1));
        if (result)
        {
          continue;
        }

        AddInfoString("Can't copy font {0} into Windows Fonts directory", f);
        return false;
      }

      //send message to all running applications
      AddInfoString("Send message about changed fonts to all running applications");

      // ReSharper disable InconsistentNaming
      var HWND_BROADCAST = new IntPtr(0xffff);
      const uint WM_FONTCHANGE = 0x001D;
      // ReSharper restore InconsistentNaming
      SendMessage(HWND_BROADCAST, WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero);


      //add system information about new fonts
      foreach (var fp in fonts.Select(f => Path.Combine(fontWinDir, f)))
      {
        AddInfoString("Registry font in system font table {0}...", fp);
        var result = AddFontResource(fp);
        if (result != 0)
        {
          continue;
        }
        AddInfoString("Can't registry font {0}...", fp);
        return false;
      }

      //add fonts into the Registry
      const string RegistryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts";
      try
      {
        foreach (var f in fonts)
        {
          var fp = Path.Combine(fontWinDir, f);
          AddInfoString("Registry font into Windows Registry {0}...", fp);
          RegistryHelper.WriteToRegistry(RegistryPath, Path.GetFileNameWithoutExtension(f), f);
        }
      }
      catch (Exception exc)
      {
        AddErrorString(exc.Message);
        return false;
      }
      AddInfoString("All fonts had been registered successfully!");

      return true;
    }


    [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int AddFontResource(string lpszFilename);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int SendMessage(IntPtr hWnd, uint wMsg, IntPtr wParam, IntPtr lParam);


    public override string GetName()
    {
      return "Install Fonts";
    }

    public override Guid GetID()
    {
      return Guid.Empty;
    }
  }
}
