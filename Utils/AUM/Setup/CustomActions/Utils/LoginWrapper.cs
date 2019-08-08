namespace CustomActions.Utils
{
  using System;
  using System.Linq;


  internal sealed class LoginWrapper
  {
    internal LoginWrapper(string user)
    {
      FullName = user;
      var splitted = user.Split(new[] { '\\' }, 2, StringSplitOptions.RemoveEmptyEntries);
      if (1 == splitted.Length)
      {
        Domain = string.Empty;
        User = splitted.First();
      }
      else
      {
        Domain = splitted.First();
        User = splitted.Last();
      }
    }

    internal LoginWrapper(string domain, string user)
    {
      Domain = domain;
      User = user;
      FullName = domain + @"\" + user;
    }

    internal string Domain { get; private set; }
    internal string User { get; private set; }
    internal string FullName { get; private set; }
  }
}