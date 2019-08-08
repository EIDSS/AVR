namespace AUM.Core.Helper
{
  using System;


  public static class ProductHelper
  {
    public const string EidssProgramId = "e";
    public const string NsProgramId = "ns";
    public const string AumProgramId = "aum";
    public const string DbProgramId = "db";
    public const string DbaProgramId = "dba";
    public const string CustomTasksProgramId = "x";
    public const string AvrServiceProgramId = "avrs";
    public const string AvrServiceDbProgramId = "dbavr";

    public static bool IsAvrServiceProgram(string programId)
    {
      return programId.Equals(AvrServiceProgramId, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsAvrServiceDbProgram(string programId)
    {
      return programId.Equals(AvrServiceDbProgramId, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsEIDSSProgram(string programId)
    {
      return programId.Equals(EidssProgramId, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsAUMUpdate(string programId)
    {
      return programId.Equals(AumProgramId, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsExecuteUpdate(string programId)
    {
      return programId.Equals(CustomTasksProgramId, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsDBUpdate(string programId)
    {
      return programId.Equals(DbProgramId, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsDBaUpdate(string programId)
    {
      return programId.Equals(DbaProgramId, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsNSProgram(string programId)
    {
      return programId.Equals(NsProgramId, StringComparison.OrdinalIgnoreCase);
    }
  }
}