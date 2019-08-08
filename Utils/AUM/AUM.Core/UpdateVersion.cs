namespace AUM.Core
{
  using System;
  using Helper;


  /// <summary>
  /// Версия продуктового обновления
  /// </summary>
  public class UpdateVersion
  {
    public UpdateVersion()
    {
      VersionFrom = VersionTo = VersionFactory.EmptyVersion;
    }

    public string ProductID { get; private set; }
    public Version VersionFrom { get; set; }
    public Version VersionTo { get; set; }

    public bool ExtractFromString(string cortege)
    {
      var tokens = cortege.Split(new[] { "$" }, StringSplitOptions.RemoveEmptyEntries);
      if (tokens.Length <= 0)
      {
        return false;
      }
      if (tokens.Length < 1)
      {
        return false;
      }
      var product = tokens[0];
      if (!ProductHelper.IsAUMUpdate(product)
        && !ProductHelper.IsExecuteUpdate(product)
        && !ProductHelper.IsDBUpdate(product)
        && !ProductHelper.IsDBaUpdate(product)
        && !ProductHelper.IsAvrServiceDbProgram(product)
        && !ProductHelper.IsAvrServiceProgram(product)
        && !ProductHelper.IsNSProgram(product)
        && !ProductHelper.IsEIDSSProgram(product))
      {
        return false;
      }

      ProductID = product;
      if (tokens.Length < 2)
      {
        return false;
      }
      var vF = tokens[1];
      Version versionFrom;
      if (!Version.TryParse(vF, out versionFrom) || versionFrom == VersionFactory.EmptyVersion)
      {
        return false;
      }
      VersionFrom = versionFrom;
      if (tokens.Length < 3)
      {
        return true;
      }
      var vT = tokens[2];
      Version versionTo;
      if (Version.TryParse(vT, out versionTo) && versionTo != VersionFactory.EmptyVersion)
      {
        VersionTo = versionTo;
      }

      return true;
    }

    /// <summary>
    /// Проверяет, удовлетворяет ли текущая версия некого продукта условиям этого кортежа
    /// </summary>
    /// <param name="currentVersion"></param>
    /// <returns></returns>
    public bool IsValidVersion(Version currentVersion)
    {
      bool result;
      AUMLog.WriteInLog("current Version: {0}", currentVersion);
      AUMLog.WriteInLog("Version From: {0}", VersionFrom);
      AUMLog.WriteInLog("Version To: {0}", VersionTo);

      if (VersionTo == VersionFactory.EmptyVersion)
      {
        //нет интервала, равенство конкретной версии
        result = VersionFrom == currentVersion;
      }
      else
      {
        result = (VersionFrom <= currentVersion) && (currentVersion <= VersionTo);
      }
      AUMLog.WriteInLog("Cortege check result: {0}", result);

      return result;
    }
  }
}