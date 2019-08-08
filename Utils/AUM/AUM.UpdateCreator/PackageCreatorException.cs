namespace AUM.UpdateCreator
{
  using System;
  using System.Globalization;


  internal class PackageCreatorException : Exception
  {
    public PackageCreatorException(string message)
      : base(message)
    {
    }

    public PackageCreatorException(string message, params object[] args)
      : base(string.Format(CultureInfo.InvariantCulture, message, args))
    {
    }
  }
}