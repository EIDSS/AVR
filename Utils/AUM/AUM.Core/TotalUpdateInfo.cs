namespace AUM.Core
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.IO;
  using System.Linq;
  using Enums;
  using Helper;


  public sealed class TotalUpdateInfo
  {
    public TotalUpdateInfo()
    {
      Updates = new List<UpdateInfo>();
      IsSmall = false;
      CRC = 0;
    }

    public List<UpdateInfo> Updates { get; private set; }

    public int ProductUpdateIndex(string alias)
    {
      for(var index = 0; index < Updates.Count; ++ index)
      {
        if (Updates[index].Alias.Equals(alias, StringComparison.OrdinalIgnoreCase))
        {
          return index;
        }
      }
      return -1;
    }

    public long CRC { get; set; }

    /// <summary>
    /// Версия всего патча
    /// </summary>
    public Version Version { get; set; }

    /// <summary>
    /// Является ли это атомарным апдейтом
    /// </summary>
    public bool IsSmall { get; set; }

    /// <summary>
    /// Литера, показывающая для какой страны этот апдейт. Если пуст, то для всех стран.
    /// </summary>
    public string Country { get; set; }

    public UpdateInfo GetProduct(string programId)
    {
      return Updates.FirstOrDefault(u => u.Alias == programId);
    }

    /// <summary>
    /// Собирает совокупный статус тотал-апдейта
    /// </summary>
    /// <returns></returns>
    public UpdateStatus GetTotalUpdateStatus()
    {
      //если есть хотя бы один проваленный апдейт, то весь тотал становится проваленным
      //если есть неизвестный -- то весь тотал неизвестный

      var result = UpdateStatus.Success;

      foreach (var updateInfo in Updates)
      {
        if (updateInfo.VersionFinish == VersionFactory.EmptyVersion) continue;

        if (updateInfo.Status == UpdateStatus.Error)
        {
          result = UpdateStatus.Error;
          break;
        }
        if (updateInfo.Status == UpdateStatus.Unknown)
        {
          result = UpdateStatus.Unknown;
        }
      }

      return result;
    }

    private string ToXml()
    {
      var aum = GetProduct(ProductHelper.AumProgramId);
      var db = GetProduct(ProductHelper.DbProgramId);
      var dba = GetProduct(ProductHelper.DbaProgramId);
      var e = GetProduct(ProductHelper.EidssProgramId);
      var ns = GetProduct(ProductHelper.NsProgramId);
      var x = GetProduct(ProductHelper.CustomTasksProgramId);
      var dbavr = GetProduct(ProductHelper.AvrServiceDbProgramId);
      var avrs = GetProduct(ProductHelper.AvrServiceProgramId);

      return
        string.Format(
          CultureInfo.InvariantCulture,
          "<update total='{0}' aum='{1}' db='{2}' dba='{3}' e='{4}' ns='{5}' x='{6}' dbavr='{7}' avrs='{8}' issmall='{9}' crc='{10}' />",
          Version,
          aum != null ? aum.VersionFinish : VersionFactory.EmptyVersion
          , db != null ? db.VersionFinish : VersionFactory.EmptyVersion
          , dba != null ? dba.VersionFinish : VersionFactory.EmptyVersion
          , e != null ? e.VersionFinish : VersionFactory.EmptyVersion
          , ns != null ? ns.VersionFinish : VersionFactory.EmptyVersion
          , x != null ? x.VersionFinish : VersionFactory.EmptyVersion
          , dbavr != null ? dbavr.VersionFinish : VersionFactory.EmptyVersion
          , avrs != null ? avrs.VersionFinish : VersionFactory.EmptyVersion
          , IsSmall ? "1" : "0"
          , CRC
          );
    }

    /// <summary>
    /// Сохранение настроек в файл
    /// </summary>
    /// <param name="updates"></param>
    /// <param name="filename">Полный путь к файлу updates.xml</param>
    public static void Save(IEnumerable<TotalUpdateInfo> updates, string filename)
    {
      using (var sw = new StreamWriter(filename))
      {
        sw.WriteLine("<updates>");
        foreach (var ui in updates)
        {
          sw.WriteLine(ui.ToXml());
        }
        sw.WriteLine("</updates>");
      }
    }
  }
}