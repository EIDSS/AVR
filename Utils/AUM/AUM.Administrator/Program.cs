namespace AUM.Administrator
{
  using System;
  using System.IO;
  using System.Windows.Forms;
  using Core;
  using Core.Helper;


  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Fmain(new ConfigSettings(Path.Combine(UpdHelper.AUMPath, FileHelper.BVUpdaterConfigFileName))));
    }
  }
}