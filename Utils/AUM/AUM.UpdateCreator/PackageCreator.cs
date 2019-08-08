namespace AUM.UpdateCreator
{
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using Core;
  using Core.Enums;
  using Core.Helper;

  internal class PackageCreator
  {
    private readonly List<RunScriptData> m_SqlScriptsList = new List<RunScriptData>();
    private readonly List<ExecuteData> m_ExecuteDataList = new List<ExecuteData>();

    /// <summary>
    /// Информация из updates.xml (без снапшотов)
    /// </summary>
    private List<TotalUpdateInfo> UpdatesInfo { get; set; }
    private readonly CreatorSettings m_settings;


    internal PackageCreator(CreatorSettings settings)
    {
      m_settings = settings;
    }

    public void Create()
    {
      var updates = new List<string>();

      CreateAUMPatchFile(updates);
      CreateDBPatchFile(updates);
      CreateDBaPatchFile(updates);
      CreateEidssPatchFile(updates);
      CreateNSPatchFile(updates);
      CreateCustomTasksPatchFile(updates);

      FillAndSaveUpdateInfo();

      FillAndSaveOldUpdateInfo(updates);
      UpdateTotal = UpdHelper.CreateTotalArchive(m_settings.BuildPath, updates, m_settings.IsSmallUpdate, m_settings.TotalVersion);
    }

    private bool AllPatchesComplete()
    {
      var allPatchesComplete =
        m_settings.AUM.IsIncluded
        && m_settings.DB.IsIncluded
        && m_settings.DBa.IsIncluded
        && m_settings.Eidss.IsIncluded
        && m_settings.NS.IsIncluded
        && m_settings.CustomTasks.IsIncluded;
      return allPatchesComplete;
    }

    private void CreateCustomTasksPatchFile(ICollection<string> updates)
    {
      if (m_settings.CustomTasks.IsIncluded)
      {
        updates.Add(CreatePatchFile(ProductHelper.CustomTasksProgramId, m_settings.TotalVersion, m_settings.TotalVersion,
          m_settings.CustomTasks.Path, m_settings.IsSmallUpdate, string.Empty));
      }
    }

    private void CreateNSPatchFile(ICollection<string> updates)
    {
      if (m_settings.NS.IsIncluded)
      {
        updates.Add(CreatePatchFile(ProductHelper.NsProgramId, m_settings.NS.Version, m_settings.TotalVersion,
          m_settings.NS.Path, m_settings.IsSmallUpdate, m_settings.NS.Cortege));
      }
    }

    private void CreateEidssPatchFile(ICollection<string> updates)
    {
      if (m_settings.Eidss.IsIncluded)
      {
        updates.Add(CreatePatchFile(ProductHelper.EidssProgramId, m_settings.Eidss.Version, m_settings.TotalVersion,
          m_settings.Eidss.Path, m_settings.IsSmallUpdate, m_settings.Eidss.Cortege));
      }
    }

    private void CreateDBaPatchFile(ICollection<string> updates)
    {
      if (m_settings.DBa.IsIncluded)
      {
        updates.Add(CreatePatchFile(ProductHelper.DbaProgramId, m_settings.DBa.Version, m_settings.TotalVersion,
          m_settings.DBa.Path, m_settings.IsSmallUpdate, m_settings.DBa.Cortege));
      }
    }

    private void CreateDBPatchFile(ICollection<string> updates)
    {
      if (m_settings.DB.IsIncluded)
      {
        updates.Add(CreatePatchFile(ProductHelper.DbProgramId, m_settings.DB.Version, m_settings.TotalVersion,
          m_settings.DB.Path, m_settings.IsSmallUpdate, m_settings.DB.Cortege));
      }
    }

    private void CreateAUMPatchFile(ICollection<string> updates)
    {
      if (m_settings.AUM.IsIncluded)
      {
        updates.Add(CreatePatchFile(ProductHelper.AumProgramId, m_settings.AUM.Version, m_settings.TotalVersion,
          m_settings.AUM.Path, m_settings.IsSmallUpdate, m_settings.AUM.Cortege));
      }
    }

    internal string UpdateTotal { get; private set; }

    private void FillAndSaveUpdateInfo()
    {
      string errorString;
      UpdatesInfo =
        AdminHelper.GetTotalUpdateInfo(Path.Combine(m_settings.BuildPath, FileHelper.UpdatesInfoFileName), out errorString)
          .Where(u => !u.IsSnapshoot)
          .ToList();
      var tui = UpdatesInfo.FirstOrDefault(u => u.Version == m_settings.TotalVersion);
      var totalUpdateInfo = tui ?? new TotalUpdateInfo { Version = m_settings.TotalVersion };
      var emptyVersion = FileHelper.EmptyVersion.ToString();
      AddUpdateInfo(totalUpdateInfo, ProductHelper.AumProgramId, m_settings.AUM.IsIncluded ? m_settings.AUM.Version : emptyVersion);
      AddUpdateInfo(totalUpdateInfo, ProductHelper.DbProgramId, m_settings.DB.IsIncluded ? m_settings.DB.Version : emptyVersion);
      AddUpdateInfo(totalUpdateInfo, ProductHelper.DbaProgramId, m_settings.DBa.IsIncluded ? m_settings.DBa.Version : emptyVersion);
      AddUpdateInfo(totalUpdateInfo, ProductHelper.EidssProgramId, m_settings.Eidss.IsIncluded ? m_settings.Eidss.Version : emptyVersion);
      AddUpdateInfo(totalUpdateInfo, ProductHelper.NsProgramId, m_settings.NS.IsIncluded ? m_settings.NS.Version : emptyVersion);
      AddUpdateInfo(totalUpdateInfo, ProductHelper.CustomTasksProgramId, m_settings.CustomTasks.IsIncluded ? m_settings.TotalVersion : emptyVersion);
      totalUpdateInfo.IsSmall = m_settings.IsSmallUpdate;

      //TODO определиться, как задавать апдейты, специфичные для страны
      //totalUpdateInfo.Country = reader.GetAttribute("country") ?? string.Empty;
      //if (totalUpdateInfo.Country.Length > 0)
      //{
      //    //если задана страна, то этот тотал-архив нужно выводить, если только эта страна -- текущая
      //    if (!totalUpdateInfo.Country.Equals(AdminHelper.GetCurrentCountry())) continue;
      //}
      if (tui == null)
      {
        UpdatesInfo.Add(totalUpdateInfo);
      }
      TotalUpdateInfo.Save(UpdatesInfo, Path.Combine(m_settings.BuildPath, FileHelper.UpdatesInfoFileName));
    }

    private static void AddUpdateInfo(TotalUpdateInfo totalUpdateInfo, string programID, string version)
    {
      var v = FileHelper.GetCorrectVersion(version);
      var ui = totalUpdateInfo.Updates.FirstOrDefault(u => u.ProgramID.Equals(programID));
      if (ui == null)
      {
        totalUpdateInfo.Updates.Add(new UpdateInfo(programID, v.ToString(), UpdateStatus.Unknown));
      }
      else
      {
        ui.Version = v.ToString();
      }
    }

    private void AddOldUpdate(ICollection<string> updates, TotalUpdateInfo upgradeInfo, string programID)
    {
      var upgradeInfoProg = upgradeInfo.GetProduct(programID);
      if (upgradeInfoProg != null)
      {
        updates.Add(Path.Combine(m_settings.BuildPath, FileHelper.GetUpdateFileName(programID, upgradeInfoProg.Version)));
      }
    }

    private void FillAndSaveOldUpdateInfo(ICollection<string> updates)
    {
      if (m_settings.IsSmallUpdate || AllPatchesComplete())
      {
        return;
      }


      //собираем полный архив
      //если это кумулятивный апдейт, то в него обязательно должны входить все продукты
      //если какой-то не создавался в этот сеанс работы, то надо взять из предыдущей версии (определить по update.xml)
      //атомарный архив может содержать не полный набор продуктов

      //собираем недостающие продукты из предыдущих версий
      if (UpdatesInfo.Count == 0)
      {
        throw new PackageCreatorException(
          "Patches for all products or old patches info in 'updates.xml' for cumulative patch are required");
      }
      var updateInfo = UpdatesInfo[UpdatesInfo.Count - 1];
      if (!m_settings.AUM.IsIncluded)
      {
        AddOldUpdate(updates, updateInfo, ProductHelper.AumProgramId);
      }
      if (!m_settings.DB.IsIncluded)
      {
        AddOldUpdate(updates, updateInfo, ProductHelper.DbProgramId);
      }
      if (!m_settings.DBa.IsIncluded)
      {
        AddOldUpdate(updates, updateInfo, ProductHelper.DbaProgramId);
      }
      if (!m_settings.Eidss.IsIncluded)
      {
        AddOldUpdate(updates, updateInfo, ProductHelper.EidssProgramId);
      }
      if (!m_settings.NS.IsIncluded)
      {
        AddOldUpdate(updates, updateInfo, ProductHelper.NsProgramId);
      }
      if (!m_settings.CustomTasks.IsIncluded)
      {
        AddOldUpdate(updates, updateInfo, ProductHelper.CustomTasksProgramId);
      }
      //if (!m_settings.Snapshoot.IsIncluded) AddOldUpdate(updates, ui, ProductHelper.SnapshotProgramId);
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="programID"></param>
    /// <param name="version"></param>
    /// <param name="versionTotal">Версия total/small архива</param>
    /// <param name="sourceDir"></param>
    /// <param name="isSmallUpdate"></param>
    /// <param name="cortegeVersion"> </param>
    /// <returns>Имя файла патча</returns>
    private string CreatePatchFile(string programID, string version, string versionTotal, string sourceDir, bool isSmallUpdate, string cortegeVersion)
    {
      CreateUpdateFile(programID, version, sourceDir, isSmallUpdate, cortegeVersion);

      //архивируем
      var fZip = new FastZip();
      var updateFile = Path.Combine(m_settings.BuildPath, FileHelper.GetUpdateFileName(programID, versionTotal));
      fZip.CreateZip(
          updateFile
          , sourceDir
          , true
          , string.Empty);
      var crcFileInfo = new FileInfo(FileHelper.GetCRCFilename(updateFile));
      var crc = FileHelper.CaclulateCRC(updateFile);
      using (var sw = crcFileInfo.CreateText())
      {
        //определяем контрольную сумму получившегося архива
        sw.Write(crc);
      }
      return updateFile;
    }

    /// <summary>
    /// Собирает пользовательский ввод и формирует файл run.upd
    /// </summary>
    /// <returns></returns>
    private void CreateUpdateFile(string programId, string version, string sourceDir, bool isSmallUpdate, string cortegeVersion)
    {
      var filename = Path.Combine(sourceDir, FileHelper.FileNameUpdate);

      var textWriter = XmlHelper.CreateXmlTextWriter(filename, version, programId, isSmallUpdate, cortegeVersion);

      m_SqlScriptsList.Clear();
      m_ExecuteDataList.Clear();

      if (programId == ProductHelper.DbProgramId)
      {
        foreach (RunScriptData scriptData in clbSQLScripts.CheckedItems)
        {
          m_SqlScriptsList.Add(scriptData);
        }
      }
      else if (programId == ProductHelper.DbaProgramId)
      {
        foreach (RunScriptData scriptData in clbSQLScriptsDba.CheckedItems)
        {
          m_SqlScriptsList.Add(scriptData);
        }
      }
      else if (programId == ProductHelper.CustomTasksProgramId)
      {
        foreach (ExecuteData data in clbExecute.CheckedItems)
        {
          m_ExecuteDataList.Add(data);
        }
      }

      //скрипты
      XmlHelper.AddSQLScriptSection(textWriter, m_SqlScriptsList);

      //собираем перечень изменений в конфиг-файлах
      //XmlHelper.AddChangeConfigValueSection(textWriter, m_ConfigFilesList);

      //собираем перечень удаляемых файлов
      XmlHelper.AddDeleteFilesSection(textWriter, lbDeleteFiles);

      //запускаемые файлы
      XmlHelper.AddExecuteSection(textWriter, m_ExecuteDataList);

      XmlHelper.CloseXmlTextWriter(textWriter);
    }

  }
}