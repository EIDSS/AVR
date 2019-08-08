namespace AUM.XPatch
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;


  internal abstract class SubTask
  {
    protected abstract bool InternalRun();


    internal SubTask()
    {
      LogStrings = new List<string>();
    }

    internal List<string> LogStrings { get; private set; }

    internal bool Run()
    {
      try
      {
        var result = InternalRun();
        AddInfoString("Success");
        return result;
      }
      catch (Exception ex)
      {
        AddErrorString(GetFullError(ex));
        return false;
      }
    }

    protected void AddInfoString(string infoString, params object[] args)
    {
      LogStrings.Add(string.Format(
        CultureInfo.InvariantCulture,
        "{0} {1}: {2}",
        GetType(),
        DateTime.Now.ToString(CultureInfo.InvariantCulture),
        string.Format(CultureInfo.InvariantCulture, infoString, args)));
    }

    protected void AddErrorString(string errorMessage)
    {
      LogStrings.Add(string.Format(
        CultureInfo.InvariantCulture,
        "{0}. {1} Error: {2}",
        GetType(),
        DateTime.Now.ToString(CultureInfo.InvariantCulture),
        errorMessage));
    }

    private static string GetFullError(Exception exception)
    {
      var msgError = string.Empty;

      var ex = exception;
      if (ex == null)
        return (msgError);

      msgError = string.Format("Exception: {0}", ex.Message);

      var i = 0;
      while (ex.InnerException != null)
      {
        ex = ex.InnerException;
        i = i + 1;
        msgError = string.Format(
          CultureInfo.InvariantCulture,
          "{0} \n {1} {2}: {3}",
          msgError,
          "Inner exception",
          i.ToString(CultureInfo.InvariantCulture),
          ex.Message);
      }

      return (msgError);
    }
  }
}