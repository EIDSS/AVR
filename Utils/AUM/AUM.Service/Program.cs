namespace AUM.Service
{
  using System;
  using System.Linq;
  using System.ServiceProcess;
  using Core;


  internal static class Program
  {
    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    private static void Main(string[] args)
    {
      AUMLog.WriteInLog("==========================");
      AUMLog.WriteInLog(args.Any() ? "No arguments" : "Arguments: {0}", string.Join(";", args));
      var sm = new ServiceMain();
      var servicesToRun = new ServiceBase[] { sm };
      if (args.Length > 0)
      {
        foreach (var arg in args.Where(arg => "/d".Equals(arg, StringComparison.OrdinalIgnoreCase)))
        {
          sm.TestStart();
        }
      }
      else
      {
        ServiceBase.Run(servicesToRun);
      }
    }
  }
}
