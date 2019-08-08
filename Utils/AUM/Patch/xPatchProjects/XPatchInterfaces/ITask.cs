namespace AUM.XPatch
{
  using System;
  using System.Collections.Generic;


    public interface ITask
    {
        IEnumerable<string> GetLog();
        bool Execute();
        string GetName();
        Guid GetID();
    }
}
