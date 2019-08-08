namespace AUM.Service
{
  using System;
  using System.Diagnostics;
  using System.IO;
  using System.ServiceProcess;
  using System.Threading;
  using Core;
  using Core.Helper;


  public partial class ServiceMain : ServiceBase
  {
    public ServiceMain()
    {
      InitializeComponent();
    }

    internal void TestStart()
    {
      OnStart(new string[] { });
    }
    
    protected override void OnStart(string[] args)
    {
      SecurityLog.WriteToEventLogWindows(
        EventLogEntryType.Information,
        ResourceHelper.Get("AUMServiceStarted"),
        DateTime.Now);
      //проверяем наличие нужных каталогов
      m_appPath = FileHelper.GetExecutingPath();
      m_runner = new RunHelper();
      //читаем настройки конфига
      m_settings = new ConfigSettings(Path.Combine(m_appPath, FileHelper.BVUpdaterConfigFileName));

      var intervalSaveState = ConfigHelper.GetTimerInterval(m_settings.IntervalSaveState);
      var intervalSync = ConfigHelper.GetTimerInterval(m_settings.IntervalDownload);
      var intervalUpdate = ConfigHelper.GetTimerInterval(m_settings.IntervalUpdate);

      m_nowBusy = false;

      if (0 < intervalSaveState)
      {
        m_timerSaveState = new Timer(TimerSaveStateExecuted, new AutoResetEvent(false), intervalSaveState, intervalSaveState);
      }

      if (0 < intervalSync)
      {
        m_timerSync = new Timer(TimerSyncExecuted, new AutoResetEvent(false), intervalSync, intervalSync);
      }

      if (0 < intervalUpdate)
      {
        m_timerUpdate = new Timer(TimerUpdateExecuted, new AutoResetEvent(false), intervalUpdate, intervalUpdate);
      }

      m_timerStartup = new Timer(TimerStartupExecuted, new AutoResetEvent(false), 0, 0);
    }

    protected override void OnStop()
    {
    }


    /// <summary>
    ///   Настройки из bvupdate.config
    /// </summary>
    private ConfigSettings m_settings;

    /// <summary>
    ///   Стартовый каталог приложения
    /// </summary>
    private string m_appPath;
    private bool m_nowBusy;
    private RunHelper m_runner;
    private Timer m_timerStartup;
    private Timer m_timerSync;
    private Timer m_timerUpdate;
    private Timer m_timerSaveState;

    private void TimerStartupExecuted(object stateInfo)
    {
      if (m_timerStartup == null)
      {
        return;
      }
      m_timerStartup = null;
      TimerSyncExecuted(null);
      TimerUpdateExecuted(null);
      TimerSyncExecuted(null);
    }

    private void TimerSyncExecuted(object stateInfo)
    {
      if (m_timerSync == null)
      {
        return;
      }
      if (m_nowBusy)
      {
        return;
      }
      m_nowBusy = true;
      m_runner.Run(Synchronizer.TransferData, null, string.Empty, m_settings);
      //здесь же выполняем служебные операции
      m_runner.Run(null, Updater.SystemOperations, m_appPath, m_settings);
      m_nowBusy = false;
    }

    private void TimerUpdateExecuted(object stateInfo)
    {
      if (m_timerUpdate == null)
      {
        return;
      }
      if (m_nowBusy)
      {
        return;
      }
      m_nowBusy = true;
      m_runner.Run(Updater.RunUpdateForAllProducts, m_settings);
      m_nowBusy = false;
    }

    private void TimerSaveStateExecuted(object stateInfo)
    {
      if (m_timerSaveState == null || MachineLevel.IsWebWks(m_settings.Level) || MutexHelper.MutexExists(MutexType.DbUpdate))
      {
        return;
      }
      AdminHelper.SaveState();
    }
  }
}
