using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;

namespace AUM.Core.Helper
{
    public enum MutexType
    {
        EidssUpdate,
        DbUpdate
    }
    public class MutexHelper
    {
        private const string DbUpateMutexName = "aum_dbupdate";
        private const string EidssUpateMutexName = "aumupdatenow";
        public static Mutex CreateMutex(MutexType mutexType, out bool created)
        {
            var mutexName = GetMutexName(mutexType);
            created = false;
            try
            {
                return Mutex.OpenExisting(mutexName, MutexRights.FullControl);
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                return new Mutex(true, mutexName, out created);
            }
            catch (UnauthorizedAccessException)
            {
                return new Mutex(false, mutexName, out created);
            }
        }

        public static bool MutexExists(MutexType mutexType)
        {
            var mutexName = GetMutexName(mutexType);
            try
            {
                using (var mutex = Mutex.OpenExisting(mutexName, MutexRights.FullControl))
                {

                }
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return true;
            }
            return true;
        }

        private static string GetMutexName(MutexType mutexType)
        {
            switch (mutexType)
            {
                case MutexType.DbUpdate:
                    return DbUpateMutexName;
                case MutexType.EidssUpdate:
                    return EidssUpateMutexName;
            }
            return string.Empty;
        }
    }
}
