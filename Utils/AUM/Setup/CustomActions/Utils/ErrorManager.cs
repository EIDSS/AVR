namespace CustomActions.Utils
{
  using System.Collections.Generic;
  using System.Collections.ObjectModel;


  internal class ErrorManager
  {
    private readonly IList<string> m_erroMessages = new List<string>();

    internal void Add(string message)
    {
      if (!m_erroMessages.Contains(message))
      {
        m_erroMessages.Add(message);
      }
    }

    internal IEnumerable<string> Errors
    {
      get { return new ReadOnlyCollection<string>(m_erroMessages); }
    }
  }
}