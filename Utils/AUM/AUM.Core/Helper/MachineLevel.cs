namespace AUM.Core.Helper
{
  public static class MachineLevel
  {
    public static int AsInt(Level level)
    {
      return (int) level;
    }

    public static bool IsCdr(Level level)
    {
      return level == Level.Cdr;
    }

    public static bool IsSlvlNsslvl(Level level)
    {
      return level == Level.SlvlNsslvl;
    }
    public static bool IsTlvlNs(Level level)
    {
      return level == Level.TlvlNs;
    }

    public static bool IsClientWks(Level level)
    {
      return level == Level.ClientWks;
    }

    public static bool IsWeb(Level level)
    {
      return level == Level.Web;
    }

    public static bool IsWebWks(Level level)
    {
      return level == Level.WebWks;
    }

    #region Nested type: Levels

    public enum Level
    {
      Cdr = 1,
      SlvlNsslvl = 2,
      TlvlNs = 3,
      ClientWks = 4,
      Web = 5,
      WebWks = 6
    }

    #endregion
  }
}