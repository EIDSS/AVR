namespace AUM.UpdateCreator
{
  using System;
  using System.Windows.Forms;
  using CommandLine;


  internal static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static int Main(string[] args)
    {
      var options = new CommandLineOptions();
      if (Parser.Default.ParseArgumentsStrict(args, options))
      {
        return CreateUpdate(options);
      }
      Console.Error.Write(options.GetUsage());
      return Parser.DefaultExitCodeFail;
    }

    private static int CreateUpdate(CommandLineOptions options)
    {
      try
      {
        var updateCreator = UpdateCreatorFactory.GetUpdateCreator(options.IsQuiet);
        return updateCreator.CreatePackage(new PatchOptions(options));
      }
      catch (Exception exception)
      {
        ShowError(exception.Message, options.IsQuiet);
        return 2;
      }
    }

    private static void ShowError(string message, bool isQuiet)
    {
      if (isQuiet)
      {
        Console.Error.Write(message);
      }
      else
      {
        MessageBox.Show(message, "Something has gone wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}