namespace AUM.UpdateCreator
{
  using System;
  using System.Globalization;


  internal class CommandLineArgumentException : Exception
  {
    public CommandLineArgumentException(string format, params object[] args)
      : base(string.Format(CultureInfo.InvariantCulture, format, args))
    {
    }
  }
}