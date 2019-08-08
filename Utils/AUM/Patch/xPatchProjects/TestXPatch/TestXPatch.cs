namespace AUM.XPatch
{
  using System;
  using System.Collections.Generic;


  internal sealed class TestXPatch : MarshalByRefObject, ITask
  {
    public TestXPatch()
    {
      LogStrings = new List<string>();
    }

    public IEnumerable<string> GetLog()
    {
      return LogStrings;
    }

    private List<string> LogStrings { get; set; }

    public bool Execute()
    {
      var success = true;
      var subTasks = new List<SubTask>
      {
        new RepalceFileSubTask(),
        new WrightRegistrySubTask(),
        new StopServiceSubTask()
      };
      foreach (var task in subTasks)
      {
        success &= task.Run();
        LogStrings.AddRange(task.LogStrings);
      }

      return success;
    }

    public string GetName()
    {
      return "TestXPatch for WebWks tests";
    }

      public Guid GetID()
      {
          return new Guid("094721E5-390F-4670-8917-51C154918F2E");
      }
  }
}