namespace CustomActions.Utils
{
  using System;
  using Microsoft.Deployment.WindowsInstaller;


  internal class InstallerLogger : ILogger
  {
    private readonly Session m_session;

    internal InstallerLogger(Session session)
    {
      if (null == session)
      {
        throw new ArgumentNullException("session");
      }
      m_session = session;
    }

    public void Log(string format, params object[] args)
    {
      m_session.Log(format, args);
    }
  }
}