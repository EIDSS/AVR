using System;
using System.Threading;
using AUM.Core.Enums;
using AUM.Core.db;

namespace AUM.Core.Helper
{
    public class TerminateDbHelper
    {

        private Timer TimerListener { get; set; }
        private Timer TimerTerminate { get; set; }
        private readonly UpdateMessenger m_UpdateMessenger;

        /// <summary>
        /// 
        /// </summary>
        public TerminateDbHelper(bool isDbUpdate, UpdateDatabases whichDatabase)
        {
            CanClose = false;
            WasError = false;
            IsDbUpdate = isDbUpdate;
            CanCheckConnections = false;
            NowBusy = false;

            var sqlConnection = DatabaseHelper.GetConnection(whichDatabase);
            if (sqlConnection == null) throw new Exception("Connection is null!!");
            m_UpdateMessenger = new UpdateMessenger(sqlConnection);
            TimerListener = new Timer(TimerListenerExecuted, new AutoResetEvent(false), 5 * 1000, 5 * 1000); //каждые 5 секунд
            TimerTerminate = new Timer(TimerTerminateExecuted, new AutoResetEvent(false), 30 * 60 * 1000, 0); //через 30 минут окончится
        }

        /// <summary>
        /// 
        /// </summary>
        private bool CanCheckConnections { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void StartCheckConnections()
        {
            CanCheckConnections = true;
            //сразу проверим
            TimerListenerExecuted(null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateInfo"></param>
        private void TimerListenerExecuted(object stateInfo)
        {
            if ((TimerListener == null) || !CanCheckConnections) return;
            RefreshRunningApps();
        }

        /// <summary>
        /// Была ли ошибка в процессе получения данных
        /// </summary>
        public bool WasError { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorString { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateInfo"></param>
        private void TimerTerminateExecuted(object stateInfo)
        {
            if (TimerTerminate == null) return;
            TerminateConnections();
        }

        /// <summary>
        /// Происходит ли обновление БД
        /// </summary>
        public bool IsDbUpdate { get; private set; }

        /// <summary>
        /// Разрывает все соединения с БД EIDSS и закрывает форму
        /// </summary>
        private void TerminateConnections()
        {
            TimerListener = TimerTerminate = null;
            if (IsDbUpdate) m_UpdateMessenger.ManageConnections(false);
            CanClose = true;
        }

        public bool CanClose { get; set; }

        private bool NowBusy { get; set; }

        /// <summary>
        /// Обновляет информацию по тем процессам, которые сейчас запущены
        /// </summary>
        private void RefreshRunningApps()
        {
            if (NowBusy) return;
            string errorString;
            var dataTable = m_UpdateMessenger.GetRunningApps(out errorString);
            if (errorString.Length > 0)
            {
                WasError = true;
                CanClose = true;
                ErrorString = errorString;
                NowBusy = false;
                return;
            }
            OpenConnectionsCount = dataTable.Rows.Count;
            if (OpenConnectionsCount == 0) TerminateConnections();
            NowBusy = false;
        }

        /// <summary>
        /// Количество открытых в данный момент соединений
        /// </summary>
        public int OpenConnectionsCount { get; private set; }
    }
}
