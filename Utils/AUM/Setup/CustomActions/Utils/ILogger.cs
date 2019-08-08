namespace CustomActions.Utils
{
  internal interface ILogger
  {
    void Log(string format, params object[] args);
  }
}