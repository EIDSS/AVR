namespace CustomActions.Utils.PropertyContainers
{
  using System;
  using Microsoft.Deployment.WindowsInstaller;


  internal sealed class SessionWrapper : IPropertyContainer
  {
    private readonly Session m_session;

    internal SessionWrapper(Session session)
    {
      if (null == session)
      {
        throw new ArgumentNullException("session");
      }

      m_session = session;
    }

    public string this[string key]
    {
      get { return m_session[key]; }
      set { m_session[key] = m_session.Format(value); }
    }
  }
}