namespace AUM.Administrator
{
  using System;


  internal sealed class BusyEventArgs : EventArgs
  {
    internal bool Busy { get; set; }
  }
}