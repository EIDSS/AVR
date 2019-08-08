using System;
using System.Threading;

namespace AUM.Core.Helper
{
    public class TerminateEIDSSHelper
    {
        private TimeSpan m_TimeSpan;
        private readonly TimeSpan m_TimeSpanSecond;

        private Timer TimerCheck { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TerminateEIDSSHelper()
        {
            CanClose = false;
            //ожидание автозакрытия 30 минут
            m_TimeSpan = new TimeSpan(0, 30, 0);
            m_TimeSpanSecond = new TimeSpan(0, 0, 1);
            TimerCheck = new Timer(TimerCheckExecuted, new AutoResetEvent(false), 0, 3000); //проверка раз в 3 сек.
        }

        public bool CanClose { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateInfo"></param>
        private void TimerCheckExecuted(object stateInfo)
        {
            if (TimerCheck == null) return;
            //если время вышло или EIDSS закрылся
            if ((m_TimeSpan.TotalSeconds <= 0) || !FileHelper.IsProcessExists(UpdHelper.EIDSSFileName))
            {
                CanClose = true;
            }
            m_TimeSpan = m_TimeSpan.Add(-m_TimeSpanSecond);
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan TimeSpanRemain { get { return m_TimeSpan; } }
    }
}
