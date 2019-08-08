namespace CustomActions.Utils
{
  using System.Globalization;


  internal sealed class AvrInstanceSettings
  {
    internal string Value { get; set; }
    internal string Text { get; set; }
    internal string SqlServer { get; set; }
    internal string Database { get; set; }
    public override string ToString()
    {
      return string.Format(
        CultureInfo.InvariantCulture,
        "Text = \"{0}\"; Value=\"{1}\"; SQLServer=\"{2}\"; Database=\"{3}\"",
        Text,
        Value,
        SqlServer,
        Database);
    }
  }
}