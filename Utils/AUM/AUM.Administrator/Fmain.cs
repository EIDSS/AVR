namespace AUM.Administrator
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Drawing;
  using System.Globalization;
  using System.IO;
  using System.Windows.Forms;
  using Properties;
  using Core;
  using Core.Enums;
  using Core.Helper;
  using System.Linq;


  internal partial class Fmain : Form
  {
    /// <summary>
    /// Настройки из bvupdate.config
    /// </summary>
    private readonly ConfigSettings m_settings;
    private readonly bool m_noDb;
    private List<TotalUpdateInfo> m_totalUpdates = new List<TotalUpdateInfo>();
    private int m_sortMode;
    private string m_selectedComputerName = string.Empty;
    private string m_selectedAlias = string.Empty;
    private string m_selectedVersion = string.Empty;
    private bool m_busyStatus;
    private event EventHandler<BusyEventArgs> BusyStatusChanged;

    private bool BusyStatus
    {
      get { return m_busyStatus; }
      set
      {
        m_busyStatus = value;

        var handler = BusyStatusChanged;
        if (handler != null)
        {
          handler(this, new BusyEventArgs { Busy = value });
        }
      }
    }

    internal Fmain(ConfigSettings settings)
    {
      if (null == settings)
      {
        throw new ArgumentNullException("settings");
      }

      m_settings = settings;
      m_noDb = MachineLevel.IsWebWks(m_settings.Level);
      BusyStatusChanged += ToggleRefresh;

      InitializeComponent();

      lStatus.Visible = false;
      lDatetime.Visible = false;

      RefreshAll();

      //настраиваем автообновление
      timerAutoRefresh.Interval = m_settings.AutoRefreshSeconds * 1000;
      timerAutoRefresh.Enabled = cbAutoRefresh.Checked;
      bReplicate.Visible = !string.IsNullOrEmpty(m_settings.ReplicationJob);
    }

    private void ToggleRefresh(object sender, BusyEventArgs e)
    {
      bRefresh.Enabled = !e.Busy;
    }

    private void RefreshAll()
    {
      if (BusyStatus || MutexHelper.MutexExists(MutexType.DbUpdate))
      {
        return;
      }

      try
      {
        BusyStatus = true;
        Cursor = Cursors.WaitCursor;

        string errorString;

        m_totalUpdates = AdminHelper.GetTotalUpdateInfo(
          Path.Combine(m_settings.UpdateLocal, FileHelper.UpdatesInfoFileName),
          out errorString);

        RefreshComputers();

        labelCountry.Text = string.Format("Country: {0}", AdminHelper.GetCurrentCountry());
      }
      finally
      {
        Cursor = Cursors.Default;
        BusyStatus = false;
      }
    }

        private void RefreshSelectedComputerName(TreeNode selectedNode)
        {
            labelComputer.Text = string.Format("Computer: {0}", GetSelectedComputerName(selectedNode));
        }

        private static string GetSelectedComputerName(TreeNode selectedNode)
        {
            return selectedNode != null ? selectedNode.Text : string.Empty;
        }

        private TreeNode AddNode(TreeNodeCollection parentNodes, SiteInfo siteInfo)
        {
            //обновим статусы патчей для этой машины
            //RefreshTotalUpdatesInfo(si.ComputerName);
            //var status = AdminHelper.GetStatusForLastTotalUpdate(m_totalUpdates);
            var imageIndex = GetImageIndex(siteInfo.Status);
            var node = parentNodes.Add(siteInfo.ComputerName, siteInfo.ComputerName, imageIndex, imageIndex);
            node.Tag = siteInfo;
            //если этот нод равен данному компьютеру или был ранее задан, то встанем на него
            if (m_selectedComputerName.Length > 0) 
            {
                if (siteInfo.ComputerName == m_selectedComputerName) tvComputers.SelectedNode = node;
            }
            else if (siteInfo.ComputerName == Environment.MachineName)
            {
                tvComputers.SelectedNode = node;
                m_selectedComputerName = siteInfo.ComputerName;
            }
            return node;
        }

    private void BuildTreeComputersBranch(
      TreeNodeCollection parentNodes,
      IEnumerable<SiteInfo> allSites,
      SiteInfo siStart)
    {
        var allSitesCopy = allSites.ToList();
        var branchSites = allSitesCopy.Where(c => c.IdfsParentSite == siStart.IdfsSite).ToList();
      var comparer = m_sortMode == 0 ? (IComparer<SiteInfo>) new SiteInfoCompareByName() : new SiteInfoCompareByStatus();
      branchSites.Sort(comparer);
      foreach (var branchSite in branchSites)
      {
        var node = AddNode(parentNodes, branchSite);
        node.Tag = branchSite;
        BuildTreeComputersBranch(node.Nodes, allSitesCopy, branchSite);
      }
    }

        /// <summary>
        /// Отыскивает логи, соответствующие указанному апдейту, и выставляет реальный статус
        /// </summary>
        /// <param name="aumlogPath"></param>
        /// <param name="totalUpdates"></param>
        /// <param name="computerName"></param>
        private static string CheckTotalUpdateInfoStatus(
          string aumlogPath,
          IEnumerable<TotalUpdateInfo> totalUpdates,
          string computerName)
        {
          if (!Directory.Exists(aumlogPath))
          {
            return string.Format("Directory not found: '{0}'", aumlogPath);
          }

          foreach (var totalUpdate in totalUpdates)
          {
            for (var j = 0; j < totalUpdate.Updates.Count; j++)
            {
              var logFile = LogFile(aumlogPath, computerName, totalUpdate.Updates[j]);

              totalUpdate.Updates[j].Status = File.Exists(logFile)
                ? (UpdHelper.IsUpdateSuccess(logFile) ? UpdateStatus.Success : UpdateStatus.Error)
                : UpdateStatus.Unknown;
              totalUpdate.Updates[j] = totalUpdate.Updates[j];
            }
          }
          return string.Empty;
        }

    private static string LogFile(string aumlogPath, string computerName, UpdateInfo updateInfo)
    {
      return Path.Combine(Path.Combine(aumlogPath, computerName), updateInfo.ExtendedInfo.GetLogFilename(computerName));
    }

    private void BuildComputersTreeBranch(TreeNodeCollection parentNodes, string folder)
    {
      if (!Directory.Exists(folder))
      {
        return;
      }

      var computers = Directory.GetDirectories(folder, "*", SearchOption.TopDirectoryOnly);
      if (!computers.Any())
      {
        return;
      }

      foreach (var directory in computers)
      {
        var directoryInfo = new DirectoryInfo(directory);
        //по каждому компьютеру получаем статус его старшего тотал архива
        //корректируем перечень реальными логами
        CheckTotalUpdateInfoStatus(
          Path.Combine(UpdHelper.AUMPath, FileHelper.AUMLogDirName),
          m_totalUpdates,
          directoryInfo.Name);

        var imageIndex = GetImageIndexForLastTotalUpdate();
        var node = parentNodes.Add(directoryInfo.Name, directoryInfo.Name, imageIndex, imageIndex);
        node.Tag = directory;
        //если этот нод равен данному компьютеру, то встанем на него
        if (directoryInfo.Name == Environment.MachineName)
        {
          tvComputers.SelectedNode = node;
        }
        //для каждой директории запускаем построение дочерних узлов
        BuildComputersTreeBranch(node.Nodes, directory);
      }
    }

    private void BuildComputersTreeLocally(IList parentNodes)
    {
      Debug.Assert(m_noDb);

      parentNodes.Clear();
      BuildComputersTreeBranch(tvComputers.Nodes, Path.Combine(UpdHelper.AUMPath, FileHelper.AUMLogDirName));
    }

    private void BuildComputersTree(TreeNodeCollection parentNodes)
    {
      parentNodes.Clear();

      var sites = DatabaseHelper.GetSiteTree(Environment.MachineName, m_settings.Level);
      if (sites.Count == 0)
      {
        return;
      }

      foreach (var parentSite in GetSiteParents(sites))
      {
        var node = AddNode(parentNodes, parentSite);
        BuildTreeComputersBranch(node.Nodes, sites, parentSite);
      }
    }

    private static IEnumerable<SiteInfo> GetSiteParents(IEnumerable<SiteInfo> sites)
    {
      return sites.Where(site => site.IsParent()).ToList();
    }

    private void RefreshComputers()
    {
      try
      {
        if (m_noDb)
        {
          BuildComputersTreeLocally(tvComputers.Nodes);
        }
        else
        {
          BuildComputersTree(tvComputers.Nodes);
        }

        if (tvComputers.SelectedNode == null && tvComputers.Nodes.Count > 0)
        {
          tvComputers.SelectedNode = tvComputers.Nodes[0];
        }

        OnTvComputersNodeMouseClick(
          this,
          new TreeNodeMouseClickEventArgs(tvComputers.SelectedNode, MouseButtons.None, 1, 0, 0));
      }
      catch (Exception exc)
      {
        MessageBox.Show(
          string.Format(CultureInfo.InvariantCulture, "Message='{0}'{1}StackTrace='{2}'", Environment.NewLine, exc.Message, exc.StackTrace)
          , Resources.ErrorCaption
          , MessageBoxButtons.OK
          , MessageBoxIcon.Exclamation);
        SecurityLog.WriteToEventLogWindows(EventLogEntryType.Error, exc.Message);
      }
    }

    private static TreeNode FindNode(TreeView tree, TreeNode parentNode, string name)
    {
      var nodes = parentNode != null ? parentNode.Nodes : tree.Nodes;
      if ((parentNode != null) && (parentNode.Name == name))
      {
        return parentNode;
      }

      return (from TreeNode node in nodes select FindNode(tree, node, name)).FirstOrDefault(n => n != null);
    }

    private void RefreshTotalUpdatesInfo(string computerName)
    {
      //корректируем перечень реальными логами
      if (m_noDb)
      {
        CheckTotalUpdateInfoStatus(
          Path.Combine(UpdHelper.AUMPath, FileHelper.AUMLogDirName),
          m_totalUpdates,
          computerName);
      }
      //else
      //{
        //AdminHelper.RefreshUpdateLogInfo(computerName, m_totalUpdates);
      //}
      if (computerName == m_selectedComputerName)
      {
        RefreshTotalUpdatesTree(computerName);
      }
    }

        private void RefreshTotalUpdatesTree(string computerName)
        {
          if (!m_noDb)
          {
            m_totalUpdates = DatabaseHelper.GetUpdatesInfo(computerName, RawTotalUpdates());
          }

          foreach (var totalUpdate in m_totalUpdates)
          {
            var keyTotal = string.Format(CultureInfo.InvariantCulture, "k{0}", totalUpdate.Version);
            var nameTotal = string.Format(
              CultureInfo.InvariantCulture,
              "{0} update {1}", totalUpdate.IsSmall ? "small" : "total",
              totalUpdate.Version);
            //определяем состояние тотал-патча по его составляющим
            //если узел с таким ключом существует, то обновляем его картинку
            var totalNode = FindNode(tvTotalUpdates, null, keyTotal);
            var totalUpdateStatus = totalUpdate.GetTotalUpdateStatus();
            if (totalNode != null)
            {
              UpdateNodeImage(totalNode, totalUpdateStatus);
              UpdateNodeComputerName(totalNode, computerName);
            }
            else
            {
              var imageIndexTotal = GetImageIndex(totalUpdateStatus);
              //totalNode = tvTotalUpdates.Nodes.Add(keyTotal, nameTotal, imageIndexTotal, imageIndexTotal);
              totalNode = tvTotalUpdates.Nodes.Insert(0, keyTotal, nameTotal, imageIndexTotal, imageIndexTotal);
            }

            foreach (var updateInfo in totalUpdate.Updates)
            {
              if (updateInfo.VersionFinish == VersionFactory.EmptyVersion)
              {
                continue;
              }

              ////на WKS не нужно проверять обновления БД
              ////в разных total могут встречаться одинаковые апдейты (с одной версией)
              //var programId = updateInfo.Alias;
              //var updateVersion = updateInfo.VersionFinish;
              var keyUpdate = string.Format("{0}u{1}version{2}", keyTotal, updateInfo.Alias, updateInfo.VersionFinish);
              ////отыскиваем нод с логами. Может быть несколько записей, нужна самая старшая
              ////там хранятся помимо логов актуальный статус
              //var relevantUpdateRecord = updateInfoList.FirstOrDefault(c => (c.Alias == programId) && (c.VersionFinish == updateVersion));
              //if (relevantUpdateRecord == null)
              //  continue;

              var updateNode = FindNode(tvTotalUpdates, totalNode, keyUpdate);
              if (updateNode != null)
              {
                UpdateNodeImage(updateNode, updateInfo.Status);
              }
              else
              {
                AddNode(totalNode, keyUpdate, updateInfo.GetName(), updateInfo.Status, updateInfo);
              }
            }
          }
        }

    private List<TotalUpdateInfo> RawTotalUpdates()
    {
      string errorString;
      var pureTotalUpdates = AdminHelper.GetTotalUpdateInfo(
        Path.Combine(m_settings.UpdateLocal, FileHelper.UpdatesInfoFileName),
        out errorString);
      return pureTotalUpdates;
    }

    private static void AddNode(TreeNode parentNode, string key, string name, UpdateStatus status, object tag = null)
        {
            var imageIndex = GetImageIndex(status);
            var node = parentNode.Nodes.Add(key, name, imageIndex, imageIndex);
            if (tag != null) node.Tag = tag;
        }

        private static void UpdateNodeImage(TreeNode node, UpdateStatus status)
        {
            var imageIndex = GetImageIndex(status);
            node.ImageIndex = node.StateImageIndex = node.SelectedImageIndex = imageIndex;
        }

        private void UpdateNodeComputerName(TreeNode node, string name)
        {
          foreach (var ui in (from TreeNode nd in node.Nodes select nd.Tag).OfType<UpdateInfo>())
          {
            ui.ComputerName = name;
          }
        }

    private static int GetImageIndex(UpdateStatus updateStatus)
        {
          switch (updateStatus)
          {
            case UpdateStatus.Success:
              return 0;
            case UpdateStatus.Error:
              return 1;
            default:
              return 2;
          }
        }

    private void RefreshLogInfo()
    {
      tbLogContent.RememberCurrentState();

      SetEmptyLogInfo();

      if (string.IsNullOrEmpty(m_selectedComputerName)
          || string.IsNullOrEmpty(m_selectedAlias)
          || string.IsNullOrEmpty(m_selectedVersion))
      {
        return;
      }

      if (m_noDb)
      {
        var filename = GetLogFor(m_selectedComputerName, m_selectedAlias, m_selectedVersion);
        if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
        {
          return;
        }

        SetStatus(UpdHelper.IsUpdateSuccess(filename));

        //выводим дату работы апдейта
        SetDateTime(XmlHelper.ReadAttributeFromXML(filename, "datetime", "datetime"));

        //заполняем содержимым протокола лога
        var log = XmlHelper.ReadAttributeFromXML(filename, "logdata", "data");
        tbLogContent.Text = log;
      }
      else
      {
        //TODO рефакторинг! оптимизация запросов к БД
        var uiActual = DatabaseHelper.GetUpdateLog(m_selectedComputerName, m_selectedAlias, m_selectedVersion);

        //последний, потому что они по датам отсортированы
        //UpdateInfo uiActual = null;
        //foreach (var totalUpdate in m_totalUpdates)
        //{
        //  foreach (var updateInfo in totalUpdate.Updates.Where(
        //    updateInfo => updateInfo.Alias == m_selectedAlias
        //                  && m_selectedVersion.Equals(updateInfo.VersionFinish.ToString(), StringComparison.OrdinalIgnoreCase)))
        //  {
        //    uiActual = updateInfo;
        //    break;
        //  }
        //}
        //if (uiActual == null)
        //{
        //  return;
        //}

        SetStatus(uiActual.Status);

        //выводим дату работы апдейта
        SetDateTime((uiActual.DateFinish.HasValue ? uiActual.DateFinish : uiActual.DateStart).ToString());

        //заполняем содержимым протокола лога
        //var log = new StringBuilder();
        //foreach (var str in uiActual.Log)
        //{
        //  log.AppendLine(str);
        //}
        //tbLogContent.Text = log.ToString();
        tbLogContent.Text = string.Join(Environment.NewLine, uiActual.Log);
      }

      tbLogContent.RestoreState();
    }

    private void SetDateTime(string dateTime)
    {
      lDatetime.Text = string.Format("Last run at {0}", dateTime);
      lDatetime.Visible = true;
    }

    private void SetStatus(bool success)
    {
      if (success)
      {
        lStatus.Text = Resources.StatusSuccess;
        lStatus.ForeColor = Color.Green;
      }
      else
      {
        lStatus.Text = Resources.StatusFailed;
        lStatus.ForeColor = Color.Red;
      }
      lStatus.Visible = true;
    }

    private void SetStatus(UpdateStatus status)
    {
      lStatus.Visible = true;
      switch (status)
      {
        case UpdateStatus.Success:
          lStatus.Text = Resources.StatusSuccess;
          lStatus.ForeColor = Color.Green;
          break;
        case UpdateStatus.Error:
          lStatus.Text = Resources.StatusFailed;
          lStatus.ForeColor = Color.Red;
          break;
        default:
          lStatus.Visible = false;
          break;
      }
    }

    private string GetLogFor(string computerName, string alias, string version)
    {
      foreach (
        var updateInfo in
          m_totalUpdates.SelectMany(
            totalUpdateInfo =>
              totalUpdateInfo.Updates.Where(updateInfo =>
                updateInfo.Alias.Equals(alias, StringComparison.OrdinalIgnoreCase)
                && version.Equals(updateInfo.VersionFinish.ToString(), StringComparison.OrdinalIgnoreCase))))
      {
        return LogFile(Path.Combine(UpdHelper.AUMPath, FileHelper.AUMLogDirName), computerName, updateInfo);
      }
      return string.Empty;
    }

    private void SetEmptyLogInfo()
    {
      lStatus.Visible = lDatetime.Visible = false;
      tbLogContent.Text = string.Empty;
    }

    private void OnTvTotalUpdatesAfterSelect(object sender, TreeViewEventArgs e)
    {
      var oldBusy = BusyStatus;
      var oldCursor = Cursor;

      try
      {
        BusyStatus = true;
        Cursor = Cursors.WaitCursor;

        m_selectedAlias = string.Empty;
        m_selectedVersion = string.Empty;

        if (e.Node != null)
        {
          var ui = e.Node.Tag as UpdateInfo;
          if (ui != null)
          {
            m_selectedAlias = ui.Alias;
            m_selectedVersion = ui.VersionFinish.ToString();
          }
        }
        RefreshLogInfo();
      }
      finally
      {
        Cursor = oldCursor;
        BusyStatus = oldBusy;
      }
    }

    private void OnBRefreshClick(object sender, EventArgs e)
    {
      RefreshAll();
    }

    private void OnTvComputersNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      var oldBusy = BusyStatus;
      var oldCursor = Cursor;
      try
      {
        BusyStatus = true;
        Cursor = Cursors.WaitCursor;

        if (e.Node == null)
        {
          return;
        }

        var isUpdateTreeRequiresToBeUpdated = m_selectedComputerName != GetSelectedComputerName(e.Node);

        m_selectedComputerName = GetSelectedComputerName(e.Node);
        RefreshTotalUpdatesInfo(m_selectedComputerName);
        //по статусу самого старшего тотал-апдейта определяем индекс картинки
        UpdateNodeImage(e.Node, AdminHelper.GetStatusForLastTotalUpdate(m_totalUpdates));
        RefreshSelectedComputerName(e.Node);

        if (isUpdateTreeRequiresToBeUpdated)
        {
          OnTvTotalUpdatesAfterSelect(
            this,
            new TreeViewEventArgs(tvTotalUpdates.SelectedNode, TreeViewAction.Unknown));
        }
      }
      finally
      {
        Cursor = oldCursor;
        BusyStatus = oldBusy;
      }
    }

        private void cbAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            timerAutoRefresh.Enabled = cbAutoRefresh.Checked;
        }

        private void timerAutoRefresh_Tick(object sender, EventArgs e)
        {
            ////перечитаем updates.xml
            //string errorString;
            //m_totalUpdates = AdminHelper.GetTotalUpdateInfo(Path.Combine(m_settings.UpdateLocal, FileHelper.UpdatesInfoFileName), out errorString);
            ////RefreshComputersState(tvComputers.Nodes);
            //RefreshComputers();

            RefreshAll();
        }

        private void tsbLaunchUpdate_Click(object sender, EventArgs e)
        {
            AUMLog.WriteInLog("Relaunch begin");
            //проверим, не идёт ли сейчас какая-либо операция АУМ
            if (FileHelper.IsProcessExists(UpdHelper.AUMProsessName))
            {
                MessageBox.Show("AUM is running now", "AUM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                //перезапускаем службу
                ServiceHelper.AUMServiceChangeState(false, string.Empty, true); //ожидаем завершения
                ServiceHelper.AUMServiceChangeState(true);
                MessageBox.Show("Launch process started", "AUM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "AUM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            AUMLog.WriteInLog("Relaunch end");
        }

        private void tsbSortByCompName_Click(object sender, EventArgs e)
        {
            m_sortMode = 0;
            if (m_noDb)
            {
              BuildComputersTreeLocally(tvComputers.Nodes);
            }
            else
            {
              BuildComputersTree(tvComputers.Nodes);
            }
        }

        private void tspSortByStatus_Click(object sender, EventArgs e)
        {
            m_sortMode = 1;
            if (m_noDb)
            {
              BuildComputersTreeLocally(tvComputers.Nodes);
            }
            else
            {
              BuildComputersTree(tvComputers.Nodes);
            }
        }

        private void bReplicate_Click(object sender, EventArgs e)
        {
            var conn = DatabaseHelper.GetConnection(UpdateDatabases.DbAdmin);
            string user;
            string password;
            UpdHelper.GetSqlAdminSettings(string.Empty, string.Empty, out user, out password);

            JobAccessor.Instance = new JobAccessor(conn.DataSource, user, password);
            lbReplicationStatus.Text = "";
            bReplicate.Enabled = false;
            JobAccessor.Instance.OnJobFinished += OnJobFinished;
            if (JobAccessor.Instance.RunReplicationJob(m_settings.ReplicationJob) != 0)
            {
                MessageBox.Show(string.Format("Starting replication job is failed. Error: {0}", JobAccessor.Instance.JobProvider.LastError), "AUM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bReplicate.Enabled = true;
            }
            else
                lbReplicationStatus.Text = "Replication is started";
        }
        private void OnJobFinished(object state)
        {
            var job = state as IJobProvider;
            if (job != null)
            {
                if (string.IsNullOrEmpty(job.LastError))
                    lbReplicationStatus.Text = "Replication is finished successfully";
                else
                    lbReplicationStatus.Text = "Replication failed. See error log for details.";
            }
            bReplicate.Enabled = true;
            JobAccessor.Instance.OnJobFinished -= OnJobFinished;

        }

        private void lbReplicationStatus_Click(object sender, EventArgs e)
        {
            lbReplicationStatus.Text = "";
        }

    private int GetImageIndexForLastTotalUpdate()
    {
      if (!m_totalUpdates.Any())
      {
        return 0;
      }
      //отыскиваем последний тотал-патч и выставляем по нему
      TotalUpdateInfo lastTotal = null;
      for (var index = m_totalUpdates.Count - 1; index >= 0; index--)
      {
        var p = m_totalUpdates[index];
        if (p.IsSmall)
        {
          continue;
        }
        lastTotal = p;
        break;
      }

      var result = 0;
      if (lastTotal != null)
      {
        result = GetImageIndex(lastTotal.GetTotalUpdateStatus());
      }

      return result;
    }
  }
}