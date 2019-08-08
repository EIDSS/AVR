namespace AUM.XPatch
{
  using System;
  using Core.Helper;


  internal sealed class StopServiceSubTask : SubTask
  {
    protected override bool InternalRun()
    {
      //Let's stop Spooler service
      var errorMessage = ServiceHelper.ServiceChangeState("Spooler", false);
      if (!string.IsNullOrEmpty(errorMessage))
      {
        throw new InvalidOperationException(errorMessage);
      }
      return true;
    }
  }
}