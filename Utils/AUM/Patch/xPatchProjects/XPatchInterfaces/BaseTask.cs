namespace AUM.XPatch
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;


  public abstract class BaseTask : MarshalByRefObject, ITask
  {
    private List<string> LogStrings { get; set; }

    protected BaseTask()
    {
      LogStrings = new List<string>();
    }

    public IEnumerable<string> GetLog()
    {
      return LogStrings;
    }

    public bool Execute()
    {
      try
      {
        return ExecuteInternal();
      }
      catch (Exception ex)
      {
        AddErrorString(GetFullError(ex));
      }
      return false;
    }

    protected abstract bool ExecuteInternal();

    public abstract string GetName();

    public virtual Guid GetID()
    {
      return Guid.Empty;
    }

    protected void AddInfoString(string infoString, params object[] args)
    {
      LogStrings.Add(string.Format(
        CultureInfo.InvariantCulture,
        "{0} {1}: {2}",
        GetName(),
        DateTime.Now.ToString(CultureInfo.InvariantCulture),
        string.Format(CultureInfo.InvariantCulture, infoString, args)));
    }


    protected void AddErrorString(string errorMessage, params object[] args)
    {
      LogStrings.Add(string.Format(
        CultureInfo.InvariantCulture,
        "{0} {1}: {2}",
        GetName(),
        DateTime.Now.ToString(CultureInfo.InvariantCulture),
        string.Format(CultureInfo.InvariantCulture, errorMessage, args)));
    }

    protected static string GetFullError(Exception exception)
    {
      var msgError = string.Empty;

      var ex = exception;
      if (ex == null)
      {
        return (msgError);
      }

      msgError = string.Format("Exception: {0}", ex.Message);

      var i = 0;
      while (ex.InnerException != null)
      {
        ex = ex.InnerException;
        i = i + 1;
        msgError = string.Format(
          CultureInfo.InvariantCulture,
          "{0} {1} {2} {3}: {4}",
          msgError,
          Environment.NewLine,
          "Inner exception",
          i.ToString(CultureInfo.InvariantCulture),
          ex.Message);
      }

      return (msgError);
    }
  }
}
