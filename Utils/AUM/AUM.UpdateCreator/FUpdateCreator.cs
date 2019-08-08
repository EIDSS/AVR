using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AUM.Core;
using AUM.Core.Helper;
using AUM.UpdateCreator.Properties;
using System.Linq;

namespace AUM.UpdateCreator
{
  using System.Globalization;


  /// <summary>
    /// Создание апдейтов
    /// </summary>
    public partial class FUpdateCreator : Form
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public FUpdateCreator()
        {
            InitializeComponent();

            //
            //m_CopyDirsList = new List<CopyDirData>();
            m_SqlScriptsList = new List<RunScriptData>();
            //m_ConfigFilesList = new List<ChangeConfigData>();
            m_ExecuteDataList = new List<ExecuteData>();
            //
            var configFilename = Path.Combine(Application.StartupPath, "bvupdatecreator.xml");
            CrSettings = new CreatorSettings(configFilename);
            CrSettings.ReadConfigFile();
          if (CrSettings.UpdatePath.Length == 0)
          {
            CrSettings.UpdatePath = Path.Combine(
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
              "UpdateSource");
          }
          tbUpdateDirDestination.Text = CrSettings.UpdatePath;
          
          string errorString;
          UpdatesInfo = AdminHelper.GetTotalUpdateInfo(
            Path.Combine(CrSettings.BuildPath, FileHelper.UpdatesInfoFileName),
            out errorString);

          browserPreview.Url = new Uri(Path.Combine(Application.StartupPath, "DefaultPreview.htm"));
          ToggleCortegeColumn();
        }

        /// <summary>
        /// Настройки приложения
        /// </summary>
        private CreatorSettings CrSettings { get; set; }

        /// <summary>
        /// Информация из updates.xml (без снапшотов)
        /// </summary>
        private List<TotalUpdateInfo> UpdatesInfo { get; set; }

        /// <summary>
        /// Обновляет перечень файлов для запуска
        /// </summary>
        private void RefreshExecuteList()
        {
            clbExecute.Items.Clear();
            var rootfolderName = CrSettings.CustomTasksPath;
            if (rootfolderName.Length == 0)
                return;
            if (!Directory.Exists(rootfolderName))
                return;
            var files = FileHelper.GetFiles(rootfolderName, "*.bat", false);
            files.AddRange(FileHelper.GetFiles(rootfolderName, "*.cmd", false));
            files.AddRange(FileHelper.GetFiles(rootfolderName, "*.exe", false));
            foreach (var fileInfo in files)
            {
                //вычисляем относительный путь
                var data = new ExecuteData
                    {
                        FileName = Path.GetFileName(fileInfo.FullName),
                        Checked = CalculateCheckedState(fileInfo),
                        NeedWait = true
                    };
                clbExecute.Items.Add(data, data.Checked ? CheckState.Checked : CheckState.Unchecked);
            }
        }

        private static bool CalculateCheckedState(FileSystemInfo fileInfo)
        {
            if (fileInfo.Extension.Equals(".exe", StringComparison.OrdinalIgnoreCase))
            {
                var fileParentDirector = Path.GetDirectoryName(fileInfo.FullName);
                var fileName = Path.GetFileNameWithoutExtension(fileInfo.Name);

                if (FileHelper.GetFiles(fileParentDirector, fileName + ".bat", false).Any()
                    || FileHelper.GetFiles(fileParentDirector, fileName + ".cmd", false).Any())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Обновляет перечень всех найденных SQL-скриптов
        /// </summary>
        private void RefreshSQLScriptsList(CheckedListBox listbox, string folder)
        {
            listbox.Items.Clear();
            if (folder.Length == 0)
                return;
            if (!Directory.Exists(folder))
                return;
            var sqlFiles = FileHelper.GetFiles(folder, "*.sql", true);
            var list =
                sqlFiles.Select(
                    fileInfo => new RunScriptData {FileName = Path.GetFileName(fileInfo.FullName), Checked = true})
                        .ToList();
            list.Sort(new SqlFileComparer());
            foreach (var runScriptData in list)
            {
                listbox.Items.Add(runScriptData, CheckState.Checked);
            }
        }

        /// <summary>
        /// Получает литеру (programid) выбранной программы
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetProgramID(int index)
        {
            var prog = String.Empty;
            switch (index)
            {
                case 0:
                    prog = ProductHelper.AumProgramId;
                    break;
                case 1:
                    prog = ProductHelper.DbProgramId;
                    break;
                case 2:
                    prog = ProductHelper.DbaProgramId;
                    break;
                case 3:
                    prog = ProductHelper.AvrServiceDbProgramId;
                    break;
                case 4:
                    prog = ProductHelper.AvrServiceProgramId;
                    break;
                case 5:
                    prog = ProductHelper.EidssProgramId;
                    break;
                case 6:
                    prog = ProductHelper.NsProgramId;
                    break;
                case 7:
                    prog = ProductHelper.CustomTasksProgramId;
                    break;
            }
            return prog;
        }

        /// <summary>
        /// Возвращает версию продукта, которую пользователь ввёл
        /// </summary>
        /// <param name="programID"></param>
        /// <returns></returns>
        private string GetProductVersion(string programID)
        {
            var result = String.Empty;
            if (programID.Equals(ProductHelper.AumProgramId))
                result = tbAUMVersion.Text;
            else if (programID.Equals(ProductHelper.DbProgramId))
                result = tbDBVersion.Text;
            else if (programID.Equals(ProductHelper.DbaProgramId))
                result = tbDBaVersion.Text;
            else if (programID.Equals(ProductHelper.AvrServiceDbProgramId))
            {
                result = tbAvrDbVersion.Text;
            }
            else if (programID.Equals(ProductHelper.AvrServiceProgramId))
            {
                result = tbAvrServiceVersion.Text;
            }
            else if (programID.Equals(ProductHelper.EidssProgramId))
                result = tbEIDSSVersion.Text;
            else if (programID.Equals(ProductHelper.NsProgramId))
                result = tbNSVersion.Text;
            else if (programID.Equals(ProductHelper.CustomTasksProgramId))
                result = tbTotalVersion.Text;
            return result;
        }

        private readonly List<RunScriptData> m_SqlScriptsList;
        private readonly List<ExecuteData> m_ExecuteDataList;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBsqlScriptsMoveUpClick(object sender, EventArgs e)
        {
            MoveUp(clbSQLScripts);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listBox"></param>
        private void MoveUp(CheckedListBox listBox)
        {
            var index = listBox.SelectedIndex;
            if (index < 1)
                return;
            var chk = listBox.CheckedIndices.Contains(index);
            listBox.Items.Insert(index - 1, listBox.Items[index]);
            listBox.Items.RemoveAt(index + 1);
            listBox.SetItemChecked(index - 1, chk);
            listBox.SelectedItem = listBox.Items[index - 1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listBox"></param>
        private void MoveDown(CheckedListBox listBox)
        {
            var index = listBox.SelectedIndex;
            if (index >= listBox.Items.Count - 1)
                return;
            var chk = listBox.CheckedIndices.Contains(index);
            listBox.Items.Insert(index + 2, listBox.Items[index]);
            listBox.Items.RemoveAt(index);
            listBox.SetItemChecked(index + 1, chk);
            listBox.SelectedItem = listBox.Items[index + 1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBsqlScriptsMoveDownClick(object sender, EventArgs e)
        {
            MoveDown(clbSQLScripts);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBsqlScriptsSelectAllClick(object sender, EventArgs e)
        {
            SelectAllItems(clbSQLScripts, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBsqlScriptsUnSelectAllClick(object sender, EventArgs e)
        {
            SelectAllItems(clbSQLScripts, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkedListBox"></param>
        /// <param name="ch"></param>
        private void SelectAllItems(CheckedListBox checkedListBox, bool ch)
        {
            for (var i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, ch);
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void OnBConfigFilesAddClick(object sender, EventArgs e)
        //{
        //    //if ((cbConfigFiles.Text.Length == 0) || (tbConfigFilesKey.Text.Length == 0) 
        //    //    || (tbConfigFilesValue.Text.Length == 0)
        //    //    || (cbAtttributeKey.Text.Length == 0)
        //    //    || (cbAttributeValue.Text.Length == 0)
        //    //    ) return;
        //    //var addString = String.Format("{0}: {1}='{2}' {3}='{4}' (ValueIsRegularExpression={5}, DeleteConfigFile={6})"
        //    //    , cbConfigFiles.Text
        //    //    , cbAtttributeKey.Text
        //    //    , cbAttributeValue.Text
        //    //    , tbConfigFilesKey.Text
        //    //    , tbConfigFilesValue.Text
        //    //    , chbRegularExpressions.Checked
        //    //    , cbDeleteConfigFileValue.Checked);
        //    //if (!lbChangedKeys.Items.Contains(addString)) lbChangedKeys.Items.Add(addString);
        //    //var changeConfigData = new ChangeConfigData
        //    //                           {
        //    //                               FileName = cbConfigFiles.Text,
        //    //                               Path = cbConfigFilePath.Text,
        //    //                               AttributeKey = cbAtttributeKey.Text,
        //    //                               AttributeValue = cbAttributeValue.Text,
        //    //                               Key = tbConfigFilesKey.Text,
        //    //                               Value = tbConfigFilesValue.Text,
        //    //                               ValueIsRegularExpression = chbRegularExpressions.Checked,
        //    //                               DeleteThisNode = cbDeleteConfigFileValue.Checked
        //    //                           };
        //    //m_ConfigFilesList.Add(changeConfigData);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void OnBConfigFilesRemoveClick(object sender, EventArgs e)
        //{
        //    //if (lbChangedKeys.SelectedItem == null) return;
        //    //lbChangedKeys.Items.Remove(lbChangedKeys.SelectedItem);
        //    //m_ConfigFilesList.RemoveAt(lbChangedKeys.SelectedIndex);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBRefreshPreviewClick(object sender, EventArgs e)
        {
            var programmID = GetProgramID(cbProduct.SelectedIndex);
            if (programmID.Length == 0)
                return;
            var version = GetProductVersion(programmID);
            if (version.Length == 0)
                return;

            var dir = String.Empty;
            var cortege = String.Empty;
            if (programmID.Equals(ProductHelper.AumProgramId))
            {
                dir = CrSettings.AUMPath;
                cortege = vcAUM.CortegeVersion;
            }
            else if (programmID.Equals(ProductHelper.DbProgramId))
            {
                dir = CrSettings.DBPath;
                cortege = vcDB.CortegeVersion;
            }
            else if (programmID.Equals(ProductHelper.DbaProgramId))
            {
                dir = CrSettings.DBaPath;
                cortege = vcDBa.CortegeVersion;
            }
            else if (programmID.Equals(ProductHelper.AvrServiceDbProgramId))
            {
                dir = CrSettings.AvrDbPath;
                cortege = vcAvrDB.CortegeVersion;
            }
            else if (programmID.Equals(ProductHelper.AvrServiceProgramId))
            {
                dir = CrSettings.AvrServicePath;
                cortege = vcAvrService.CortegeVersion;
            }
            else if (programmID.Equals(ProductHelper.EidssProgramId))
            {
                dir = CrSettings.EidssPath;
                cortege = vcEIDSS.CortegeVersion;
            }
            else if (programmID.Equals(ProductHelper.NsProgramId))
            {
                dir = CrSettings.NSPath;
                cortege = vcNS.CortegeVersion;
            }
            else if (programmID.Equals(ProductHelper.CustomTasksProgramId))
                dir = CrSettings.CustomTasksPath;

            CreateUpdateFile(programmID, VersionFactory.NewVersion(version), dir, cbIsSmallUpdate.Checked, cortege);
            var filename = Path.Combine(dir, FileHelper.FileNameUpdate);
            browserPreview.Url = new Uri(filename);
        }

        ///// <summary>
        ///// Вычисляет полный путь к файлу run.upd
        ///// </summary>
        ///// <returns></returns>
        //private string GetFileUpdateFullPath(string sourceDir)
        //{
        //    var fileInfo = new FileInfo(sourceDir);
        //    return !String.IsNullOrEmpty(fileInfo.DirectoryName) ? Path.Combine(fileInfo.DirectoryName, FileHelper.FileNameUpdate) : FileHelper.FileNameUpdate;
        //}

        /// <summary>
        /// Собирает пользовательский ввод и формирует файл run.upd
        /// </summary>
        /// <returns></returns>
        private void CreateUpdateFile(
          string programId,
          Version version,
          string sourceDir,
          bool isSmallUpdate,
          string cortegeVersion)
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
            else if (programId == ProductHelper.AvrServiceDbProgramId)
            {
                foreach (RunScriptData scriptData in clbSQLScriptsAvrDb.CheckedItems)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="version"></param>
        /// <param name="versionTotal">Версия total/small архива</param>
        /// <param name="sourceDir"></param>
        /// <param name="isSmallUpdate"></param>
        /// <param name="cortegeVersion"> </param>
        /// <returns>Имя файла патча</returns>
        private string CreatePatchFile(
          string programId,
          Version version,
          Version versionTotal,
          string sourceDir,
          bool isSmallUpdate,
          string cortegeVersion)
        {
            CreateUpdateFile(programId, version, sourceDir, isSmallUpdate, cortegeVersion);

            //архивируем
            var fZip = UpdHelper.CreateZipper();
            var updateFile = Path.Combine(
              CrSettings.BuildPath,
              FileHelper.GetUpdateFileName(programId, versionTotal.ToString()));
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
        /// Сохраняет файл run.upd и создаёт пакет апдейта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBCreatePackageClick(object sender, EventArgs e)
        {
            if (CrSettings.BuildPath.Length == 0)
                return;
            var totalVersion = VersionFactory.GetCorrectVersion(tbTotalVersion.Text);
            if (totalVersion == VersionFactory.EmptyVersion)
                return;
            var isSmall = cbIsSmallUpdate.Checked;

            //создаём отдельные пакеты для каждого продукта и единый total-пакет
            //создаём программы апдейтов для каждого продукта

            Version v;
            var needAum = cbNeedAUM.Checked && Version.TryParse(tbAUMVersion.Text, out v);
            var needDb = cbNeedDB.Checked && Version.TryParse(tbDBVersion.Text, out v);
            var needDba = cbNeedDBa.Checked && Version.TryParse(tbDBaVersion.Text, out v);
            var needAvrDb = cbNeedAvrDB.Checked && Version.TryParse(tbAvrDbVersion.Text, out v);
            var needAvrS = cbNeedAvrS.Checked && Version.TryParse(tbAvrServiceVersion.Text, out v);
            var needEidss = cbNeedEIDSS.Checked && Version.TryParse(tbEIDSSVersion.Text, out v);
            var needNs = cbNeedNS.Checked && Version.TryParse(tbNSVersion.Text, out v);
            var needCustom = cbNeedCustTasks.Checked && Version.TryParse(tbTotalVersion.Text, out v);

            if (!Version.TryParse(tbTotalVersion.Text, out v)) return;

            Cursor = Cursors.WaitCursor;
            var updates = new List<string>();

            if (needAum)
            {
                //проверим наличие лишний конфигов, которые были случайно добавлены
                var badFiles = Directory.GetFiles(CrSettings.AUMPath, "bvupdater*.config*");
                if (badFiles.Length > 0)
                {
                    foreach (var badFile in badFiles)
                    {
                        MessageBox.Show(
                          string.Format(CultureInfo.InvariantCulture, "Delete bad file {0}", badFile),
                          "Bad files",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation);
                    }
                    MessageBox.Show("Update wasn't created", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                updates.Add(CreatePatchFile(
                  ProductHelper.AumProgramId,
                  VersionFactory.NewVersion(tbAUMVersion.Text),
                  totalVersion,
                  CrSettings.AUMPath,
                  isSmall,
                  vcAUM.CortegeVersion));
            }
            if (needDb)
            {
                updates.Add(CreatePatchFile(
                  ProductHelper.DbProgramId,
                  VersionFactory.NewVersion(tbDBVersion.Text),
                  totalVersion,
                  CrSettings.DBPath,
                  isSmall,
                  vcDB.CortegeVersion));
            }
            if (needDba)
            {
                updates.Add(CreatePatchFile(
                  ProductHelper.DbaProgramId,
                  VersionFactory.NewVersion(tbDBaVersion.Text),
                  totalVersion,
                  CrSettings.DBaPath,
                  isSmall,
                  vcDBa.CortegeVersion));
            }
            if (needAvrDb)
            {
                updates.Add(CreatePatchFile(
                    ProductHelper.AvrServiceDbProgramId,
                    VersionFactory.NewVersion(tbAvrDbVersion.Text),
                    totalVersion,
                    CrSettings.AvrDbPath,
                    isSmall,
                    vcAvrDB.CortegeVersion));
            }
            if (needAvrS)
            {
                updates.Add(CreatePatchFile(
                    ProductHelper.AvrServiceProgramId,
                    VersionFactory.NewVersion(tbAvrServiceVersion.Text),
                    totalVersion,
                    CrSettings.AvrServicePath,
                    isSmall,
                    vcAvrService.CortegeVersion));
            }
            if (needEidss)
            {
                updates.Add(CreatePatchFile(
                  ProductHelper.EidssProgramId,
                  VersionFactory.NewVersion(tbEIDSSVersion.Text),
                  totalVersion,
                  CrSettings.EidssPath,
                  isSmall,
                  vcEIDSS.CortegeVersion));
            }
            if (needNs)
            {
                updates.Add(CreatePatchFile(
                  ProductHelper.NsProgramId,
                  VersionFactory.NewVersion(tbNSVersion.Text),
                  totalVersion,
                  CrSettings.NSPath,
                  isSmall,
                  vcNS.CortegeVersion));
            }
            if (needCustom)
            {
                updates.Add(CreatePatchFile(
                  ProductHelper.CustomTasksProgramId,
                  VersionFactory.NewVersion(tbTotalVersion.Text),
                  totalVersion,
                  CrSettings.CustomTasksPath,
                  isSmall,
                  string.Empty));
            }

            //все ли апдейты были сделаны
            var allPatchesComplete = needAum && needDb && needDba && needAvrDb && needAvrS && needEidss && needNs && needCustom;

            #region Подготовка к записи файла updates.xml

            var tui = UpdatesInfo.FirstOrDefault(u => u.Version == totalVersion);
            var needAdd = tui == null;
            var totalUpdateInfo = tui ?? new TotalUpdateInfo {Version = VersionFactory.NewVersion(tbTotalVersion.Text)};
            AddUpdateInfo(totalUpdateInfo, ProductHelper.AumProgramId, needAum ? VersionFactory.GetCorrectVersion(tbAUMVersion.Text) : VersionFactory.EmptyVersion);
            AddUpdateInfo(totalUpdateInfo, ProductHelper.DbProgramId, needDb ? VersionFactory.GetCorrectVersion(tbDBVersion.Text) : VersionFactory.EmptyVersion);
            AddUpdateInfo(totalUpdateInfo, ProductHelper.DbaProgramId, needDba ? VersionFactory.GetCorrectVersion(tbDBaVersion.Text) : VersionFactory.EmptyVersion);
            AddUpdateInfo(totalUpdateInfo, ProductHelper.AvrServiceDbProgramId,
                          needAvrDb ? VersionFactory.GetCorrectVersion(tbAvrDbVersion.Text) : VersionFactory.EmptyVersion);
            AddUpdateInfo(totalUpdateInfo, ProductHelper.AvrServiceProgramId,
                          needAvrS ? VersionFactory.GetCorrectVersion(tbAvrServiceVersion.Text) : VersionFactory.EmptyVersion);
            AddUpdateInfo(totalUpdateInfo, ProductHelper.DbaProgramId, needDba ? VersionFactory.GetCorrectVersion(tbDBaVersion.Text) : VersionFactory.EmptyVersion);
            AddUpdateInfo(totalUpdateInfo, ProductHelper.EidssProgramId, needEidss ? VersionFactory.GetCorrectVersion(tbEIDSSVersion.Text) : VersionFactory.EmptyVersion);
            AddUpdateInfo(totalUpdateInfo, ProductHelper.NsProgramId, needNs ? VersionFactory.GetCorrectVersion(tbNSVersion.Text) : VersionFactory.EmptyVersion);
            AddUpdateInfo(totalUpdateInfo, ProductHelper.CustomTasksProgramId,
                          needCustom ? VersionFactory.GetCorrectVersion(tbTotalVersion.Text) : VersionFactory.EmptyVersion);
            totalUpdateInfo.IsSmall = isSmall;

            //TODO определиться, как задавать апдейты, специфичные для страны
            //totalUpdateInfo.Country = reader.GetAttribute("country") ?? String.Empty;
            //if (totalUpdateInfo.Country.Length > 0)
            //{
            //    //если задана страна, то этот тотал-архив нужно выводить, если только эта страна -- текущая
            //    if (!totalUpdateInfo.Country.Equals(AdminHelper.GetCurrentCountry())) continue;
            //}

            if (needAdd) UpdatesInfo.Add(totalUpdateInfo);

            #endregion

            //собираем полный архив
            //если это кумулятивный апдейт, то в него обязательно должны входить все продукты
            //если какой-то не создавался в этот сеанс работы, то надо взять из предыдущей версии (определить по update.xml)
            //атомарный архив может содержать не полный набор продуктов
            if (!isSmall)
            {
                //кумулятивный патч
                if (!allPatchesComplete)
                {
                    //собираем недостающие продукты из предыдущих версий
                    if (UpdatesInfo.Count == 0)
                    {
                        MessageBox.Show(
                            "Patches for all products or old patches info in 'updates.xml' for cumulative patch are required",
                            String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    var ui = UpdatesInfo[UpdatesInfo.Count - 1];
                    if (!needAum)
                        AddOldUpdate(updates, ui, ProductHelper.AumProgramId);
                    if (!needDb)
                        AddOldUpdate(updates, ui, ProductHelper.DbProgramId);
                    if (!needDba)
                        AddOldUpdate(updates, ui, ProductHelper.DbaProgramId);
                    if (!needAvrDb)
                    {
                        AddOldUpdate(updates, ui, ProductHelper.AvrServiceDbProgramId);
                    }
                    if (!needAvrS)
                    {
                        AddOldUpdate(updates, ui, ProductHelper.AvrServiceProgramId);
                    }
                    if (!needEidss)
                        AddOldUpdate(updates, ui, ProductHelper.EidssProgramId);
                    if (!needNs)
                        AddOldUpdate(updates, ui, ProductHelper.NsProgramId);
                    if (!needCustom)
                        AddOldUpdate(updates, ui, ProductHelper.CustomTasksProgramId);
                }
            }
            var updateTotal = UpdHelper.CreateTotalArchive(CrSettings.BuildPath, updates, isSmall, v.ToString());
            totalUpdateInfo.CRC = FileHelper.CaclulateCRC(updateTotal);
            
            //в updates.xml записываем информацию о продуктах и о контрольной сумме полного архива
            TotalUpdateInfo.Save(UpdatesInfo, Path.Combine(CrSettings.BuildPath, FileHelper.UpdatesInfoFileName));
            
            Cursor = Cursors.Default;
            MessageBox.Show(String.Format("{0} archived successfully!", Path.GetFileName(updateTotal)),
                            Resources.Archive, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updates"></param>
        /// <param name="ui"></param>
        /// <param name="programID"> </param>
        private void AddOldUpdate(ICollection<string> updates, TotalUpdateInfo ui, string programID)
        {
            var uiProg = ui.GetProduct(programID);
            if (uiProg != null)
            {
                updates.Add(Path.Combine(
                  CrSettings.BuildPath,
                  FileHelper.GetUpdateFileName(programID, uiProg.VersionFinish.ToString())));
                if (programID.Equals(ProductHelper.AumProgramId))
                    tbAUMVersion.Text = ui.Version.ToString();
                else if (programID.Equals(ProductHelper.DbProgramId))
                    tbDBVersion.Text = ui.Version.ToString();
                else if (programID.Equals(ProductHelper.AvrServiceDbProgramId))
                {
                    tbAvrDbVersion.Text = ui.Version.ToString();
                }
                else if (programID.Equals(ProductHelper.AvrServiceProgramId))
                {
                    tbAvrServiceVersion.Text = ui.Version.ToString();
                }
                else if (programID.Equals(ProductHelper.EidssProgramId))
                    tbEIDSSVersion.Text = ui.Version.ToString();
                else if (programID.Equals(ProductHelper.NsProgramId))
                    tbNSVersion.Text = ui.Version.ToString();
                //else if (programID.Equals(ProductHelper.CustomTasksProgramId)) tbTotalVersion.Text = ui.Version;
            }
        }

        private void OnBAddDeleteFileClick(object sender, EventArgs e)
        {
            if (tbFullPathDeleteFile.Text.Length == 0)
                return;
            lbDeleteFiles.Items.Add(String.Format("{0}:{1}", GetProgramID(cbDeleteFileProduct.SelectedIndex),
                                                  tbFullPathDeleteFile.Text));
        }

        private void OnBRemoveDeleteFileClick(object sender, EventArgs e)
        {
            if (lbDeleteFiles.SelectedIndex >= 0)
                lbDeleteFiles.Items.RemoveAt(lbDeleteFiles.SelectedIndex);
        }

        private void OnBExecuteMoveUpClick(object sender, EventArgs e)
        {
            MoveUp(clbExecute);
        }

        private void OnBExecuteMoveDownClick(object sender, EventArgs e)
        {
            MoveDown(clbExecute);
        }

        private void OnBExecuteSelectAllClick(object sender, EventArgs e)
        {
            SelectAllItems(clbExecute, true);
        }

        private void OnBExecuteUnselectAllClick(object sender, EventArgs e)
        {
            SelectAllItems(clbExecute, false);
        }

        private void OnFUpdateCreatorLoad(object sender, EventArgs e)
        {
            RefreshSQLScriptsList(clbSQLScripts, CrSettings.DBPath);
            RefreshSQLScriptsList(clbSQLScriptsDba, CrSettings.DBaPath);
            RefreshSQLScriptsList(clbSQLScriptsAvrDb, CrSettings.AvrDbPath);
            RefreshExecuteList();
        }

        private void OnBUpdateDirDestinationClick(object sender, EventArgs e)
        {
            FileHelper.BrowseDialog(folderBrowserDialog, tbUpdateDirDestination);
        }

        private void OnBSaveSettingsClick(object sender, EventArgs e)
        {
            if (Directory.Exists(tbUpdateDirDestination.Text))
            {
                CrSettings.UpdatePath = tbUpdateDirDestination.Text;
                CrSettings.SaveSettings();
                MessageBox.Show("Successfully complete!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Создание структуры каталогов для апдейтов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBApplySettingsClick(object sender, EventArgs e)
        {
            if (CrSettings.UpdatePath.Length == 0)
                return;
            if (Directory.Exists(CrSettings.UpdatePath))
            {
                if (
                    MessageBox.Show(
                        String.Format("Directory {0} is exists. Do you want recreate it?", CrSettings.UpdatePath),
                        "Apply settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                FileHelper.DeleteDir(CrSettings.UpdatePath, true);
            }

            //создаём подкаталоги для каждого продукта и результирующий каталог
            Directory.CreateDirectory(CrSettings.AUMPath); //aum
            Directory.CreateDirectory(CrSettings.DBPath); //database
            Directory.CreateDirectory(CrSettings.DBaPath); //database archive
            Directory.CreateDirectory(CrSettings.AvrDbPath);
            Directory.CreateDirectory(CrSettings.AvrServicePath);
            Directory.CreateDirectory(CrSettings.EidssPath); //EIDSS
            Directory.CreateDirectory(CrSettings.NSPath); //Notification service
            Directory.CreateDirectory(CrSettings.CustomTasksPath); //custom tasks
            Directory.CreateDirectory(CrSettings.BuildPath); //каталог, куда выгружаются готовые патчи

            //копируем файл updates.xml из корня приложения в билд-каталог
            var updatesFile = Path.Combine(Application.StartupPath, FileHelper.UpdatesInfoFileName);
            if (File.Exists(updatesFile))
            {
                File.Copy(updatesFile, Path.Combine(CrSettings.BuildPath, FileHelper.UpdatesInfoFileName));
            }
            else
            {
                MessageBox.Show(String.Format("{0} not found!", FileHelper.UpdatesInfoFileName), "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("Successfully complete!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        /// <summary>
        /// Обновление версий программ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBRefreshVersionClick(object sender, EventArgs e)
        {
            const string UnknownVersion = "<unknown>";

            //aum
            var aumVersion = FileHelper.GetAUMVersion(CrSettings.AUMPath);
            tbAUMVersion.Text = aumVersion != null ? aumVersion.ToString() : UnknownVersion;

            //e
            var eVersion = FileHelper.GetEIDSSVersion(CrSettings.EidssPath);
            tbEIDSSVersion.Text = eVersion != null ? eVersion.ToString() : UnknownVersion;

            //ns
            var nsVersion = FileHelper.GetNSVersion(CrSettings.NSPath);
            tbNSVersion.Text = nsVersion != null ? nsVersion.ToString() : UnknownVersion;

            //avsrs
            var avrsVersion = FileHelper.GetAvrServiceVersion(CrSettings.AvrServicePath);
            tbAvrServiceVersion.Text = avrsVersion != null ? avrsVersion.ToString() : UnknownVersion;
        }

        private void AddUpdateInfo(TotalUpdateInfo totalUpdateInfo, string programID, Version version)
        {
            var ui = totalUpdateInfo.Updates.FirstOrDefault(u => u.Alias.Equals(programID));
            if (ui == null)
            {
                totalUpdateInfo.Updates.Add(new UpdateInfo(programID, version.ToString()));
            }
            else
            {
                ui.VersionFinish = version;
            }
        }

    private void OnBRefreshExeClick(object sender, EventArgs e)
        {
            RefreshExecuteList();
        }

        private void OnBRefreshSqlClick(object sender, EventArgs e)
        {
            RefreshSQLScriptsList(clbSQLScripts, CrSettings.DBPath);
        }

        private void OnCbIsSmallUpdateCheckedChanged(object sender, EventArgs e)
        {
          ToggleCortegeColumn();
        }

    private void ToggleCortegeColumn()
    {
      if (cbIsSmallUpdate.Checked)
      {
        lblVersionCortege.Enabled = true;

        vcAUM.Enabled = true;
        vcDB.Enabled = true;
        vcDBa.Enabled = true;
        vcAvrDB.Enabled = true;
        vcAvrService.Enabled = true;
        vcEIDSS.Enabled = true;
        vcNS.Enabled = true;
      }
      else
      {
        lblVersionCortege.Enabled = false;

        vcAUM.Enabled = false;
        vcDB.Enabled = false;
        vcDBa.Enabled = false;
        vcAvrDB.Enabled = false;
        vcAvrService.Enabled = false;
        vcEIDSS.Enabled = false;
        vcNS.Enabled = false;
      }
    }

    private void OnBSQLScriptsDbaMoveUpClick(object sender, EventArgs e)
        {
            MoveUp(clbSQLScriptsDba);
        }

        private void OnBSQLScriptsDbaMoveDownClick(object sender, EventArgs e)
        {
            MoveDown(clbSQLScriptsDba);
        }

        private void OnBSQLScriptsDbaSelectAllClick(object sender, EventArgs e)
        {
            SelectAllItems(clbSQLScriptsDba, true);
        }

        private void OnBSQLScriptsDbaUnSelectAllClick(object sender, EventArgs e)
        {
            SelectAllItems(clbSQLScriptsDba, false);
        }

        private void OnBRefreshSqlDbaClick(object sender, EventArgs e)
        {
            RefreshSQLScriptsList(clbSQLScriptsDba, CrSettings.DBaPath);
        }

        private void OnBDBVersionSetEqualClick(object sender, EventArgs e)
        {
            tbDBaVersion.Text = tbDBVersion.Text;
        }


        private void OnBSQLScriptsAvrDbMoveUpClick(object sender, EventArgs e)
        {
            MoveUp(clbSQLScriptsAvrDb);
        }

        private void OnBSQLScriptsAvrDbMoveDownClick(object sender, EventArgs e)
        {
            MoveDown(clbSQLScriptsAvrDb);
        }

        private void OnBSQLScriptsAvrDbSelectAllClick(object sender, EventArgs e)
        {
            SelectAllItems(clbSQLScriptsAvrDb, true);
        }

        private void OnBSQLScriptsAvrDbUnSelectAllClick(object sender, EventArgs e)
        {
            SelectAllItems(clbSQLScriptsAvrDb, false);
        }

        private void OnBRefreshSqlAvrDbClick(object sender, EventArgs e)
        {
            RefreshSQLScriptsList(clbSQLScriptsAvrDb, CrSettings.AvrDbPath);
        }
    }
}