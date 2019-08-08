using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Linq;
using System.Security.Cryptography;

namespace AUM.Core.Helper
{
    public static class ServiceHelper
    {
        /// <summary>
        /// Проверяет, остановлен ли сервис
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static bool IsServiceStopped(string serviceName)
        {
            using (var sc = new ServiceController(serviceName))
            {
                return sc.IsServiceStopped();
            }
        }

        private static bool IsServiceStoped(ServiceController sc, bool waitForStop)
        {
            if (!waitForStop)
                return ((sc.Status == ServiceControllerStatus.Stopped) ||
                        (sc.Status == ServiceControllerStatus.StopPending));

            return sc.Status == ServiceControllerStatus.Stopped;
        }

        /// <summary>
        /// Запускает или останавливает сервис
        /// </summary>
        public static string ServiceChangeState(string serviceName, bool start, string args = "", bool waitForStop = false)
        {
            var action = start ? "start" : "stop";
            AUMLog.WriteInLog("Try to {0} {1}", action, serviceName);
            if (!IsServiceExists(serviceName)) return String.Format("Service '{0}' isn't exists!", serviceName);
            var errorString = String.Empty;
            try
            {
                using (var sc = new ServiceController(serviceName))
                {
                    if (start)
                    {
                        var arguments = args.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        if (IsServiceStopped(serviceName)) sc.Start(arguments);
                    }
                    else
                    {
                        if (!IsServiceStopped(serviceName)) sc.Stop();
                    }
                    if (!start)
                    {
                        //будем ожидать остановку сервиса
                        AUMLog.WriteInLog("Wait for service stoping");
                        var timeout = new TimeSpan(0, 0, 0, 30, 0);
                        var tsStart = DateTime.Now;
                        var canClose = IsServiceStoped(sc, waitForStop);
                        while (!canClose)
                        {
                            if (IsServiceStoped(sc, waitForStop)) canClose = true;
                            if (DateTime.Now - tsStart >= timeout) canClose = true;
                        }
                        AUMLog.WriteInLog((sc.Status == ServiceControllerStatus.Stopped) || (sc.Status == ServiceControllerStatus.StopPending)
                          ? String.Format(
                            "Service {0} stopped successully.",
                            serviceName)
                          : String.Format(
                            "Service {0} don't stopped. Timeout expiried. Status = {1}",
                            serviceName, sc.Status));
                    }
                }
            }
            catch (Exception exc)
            {
                errorString = exc.Message;
                AUMLog.WriteInLog("Can't {0} {1}. Error: {2}", action, serviceName, errorString);
                SecurityLog.WriteToEventLogWindows(EventLogEntryType.Error, errorString);
            }

            return errorString;
        }

        /// <summary>
        /// Проверяет существование сервиса в системе
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static bool IsServiceExists(string serviceName)
        {
            return ServiceController.GetServices().Count(s => s.ServiceName == serviceName) > 0;
        }

        public static void NotificationServiceChangeState(bool start)
        {
            var errorString = ServiceChangeState(UpdHelper.NSServiceName, start);
            if (errorString.Length > 0)
            {
                //пробуем второй вариант
                ServiceChangeState(UpdHelper.NSServiceName2, start);
            }
        }

        public static void AUMServiceChangeState(bool start, string args = "", bool waitForStop = false)
        {
            ServiceChangeState(UpdHelper.AUMServiceName, start, args, waitForStop);
        }

        public static void AvrServiceChangeState(bool start)
        {
            var action = start ? "start" : "stop";
            var errStr = ServiceChangeState(UpdHelper.AVRServiceName, start);
            if (errStr.Length > 0)
            {
                AUMLog.WriteInLog("Can't {0} service. Try to stop it into non-impersonate regime", action);
                errStr = ServiceChangeState(UpdHelper.AVRServiceName, start);
                AUMLog.WriteInLog(errStr.Length > 0
                  ? string.Format("Can't {0} service again.", action)
                  : string.Format("Service {0} successfully.", action));
            }
            else
            {
                AUMLog.WriteInLog("Service {0} successfully.", action);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sc"></param>
        /// <returns></returns>
        public static bool IsServiceStopped(this ServiceController sc)
        {
            return (sc.Status.Equals(ServiceControllerStatus.Stopped)) ||
                   (sc.Status.Equals(ServiceControllerStatus.StopPending));
        }


        public static void ChangeStartMode(string serviceName, ServiceStartMode mode, bool delayedAutoStart = true)
        {
            using (var sc = new ServiceController(serviceName))
            {
                ChangeStartMode(sc, mode, delayedAutoStart);
            }
        }

        public static string ChangeStartModeWithoutThrow(string serviceName, ServiceStartMode mode, bool delayedAutoStart = true)
        {
            using (var sc = new ServiceController(serviceName))
            {
                return ChangeStartModeWithoutThrow(sc, mode, delayedAutoStart);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct QueryServiceConfigStruct
        {
            public int serviceType;
            public int startType;
            public int errorControl;
            public IntPtr binaryPathName;
            public IntPtr loadOrderGroup;
            public int tagID;
            public IntPtr dependencies;
            public IntPtr startName;
            public IntPtr displayName;
        }

        public struct ServiceInfo
        {
            public int serviceType;
            public int startType;
            public int errorControl;
            public string binaryPathName;
            public string loadOrderGroup;
            public int tagID;
            public string dependencies;
            public string startName;
            public string displayName;
        }
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Boolean ChangeServiceConfig
          (
          IntPtr hService,
          UInt32 nServiceType,
          UInt32 nStartType,
          UInt32 nErrorControl,
          String lpBinaryPathName,
          String lpLoadOrderGroup,
          IntPtr lpdwTagId,
          [In] char[] lpDependencies,
          String lpServiceStartName,
          String lpPassword,
          String lpDisplayName);


        // SERVICE_CONFIG_DELAYED_AUTO_START_INFO
        private const uint ServiceConfigDelayedAutoStartInfo = 0x03;
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]

        //SERVICE_DELAYED_AUTO_START_INFO
        private struct ServiceDelayedAutoStartInfo
        {
            public bool fDelayedAutostart;
        }
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ChangeServiceConfig2(
          IntPtr hService,
          uint dwInfoLevel,
          [MarshalAs(UnmanagedType.Struct)] ref ServiceDelayedAutoStartInfo lpInfo);


        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr OpenService(IntPtr hScManager, string lpServiceName, uint dwDesiredAccess);

        [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern IntPtr OpenSCManager(string machineName, string databaseName, uint dwAccess);

        [DllImport("advapi32.dll", EntryPoint = "CloseServiceHandle")]
        public static extern int CloseServiceHandle(IntPtr hScObject);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int QueryServiceConfig
            (IntPtr service, IntPtr queryServiceConfig, int bufferSize, ref int bytesNeeded);

        private const uint ServiceNoChange = 0xFFFFFFFF;
        private const uint ServiceQueryConfig = 0x00000001;
        private const uint ServiceChangeConfig = 0x00000002;
        private const uint ScManagerAllAccess = 0x000F003F;

        public static string ChangeStartModeWithoutThrow(ServiceController svc, ServiceStartMode mode, bool delayedAutoStart = true)
        {
            try
            {
                ChangeStartMode(svc, mode, delayedAutoStart);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return null;
        }

        private static int GetServiceStartMode(IntPtr serviceHandle)
        {
            int bytesNeeded = 5;
            QueryServiceConfigStruct qscs = new QueryServiceConfigStruct();
            IntPtr qscPtr = Marshal.AllocCoTaskMem(0);

            int retCode = QueryServiceConfig(serviceHandle, qscPtr,
            0, ref bytesNeeded);
            if (retCode == 0 && bytesNeeded == 0)
            {
                throw new ExternalException("Query Service Config Error");
            }
            qscPtr = Marshal.AllocCoTaskMem(bytesNeeded);
            retCode = QueryServiceConfig(serviceHandle, qscPtr,
            bytesNeeded, ref bytesNeeded);
            if (retCode == 0)
            {
                throw new ExternalException("Query service config retrieving error");
            }
            qscs.binaryPathName = IntPtr.Zero;
            qscs.dependencies = IntPtr.Zero;
            qscs.displayName = IntPtr.Zero;
            qscs.loadOrderGroup = IntPtr.Zero;
            qscs.startName = IntPtr.Zero;

            qscs = (QueryServiceConfigStruct)
            Marshal.PtrToStructure(qscPtr,
            new QueryServiceConfigStruct().GetType());

            int result = qscs.startType;
            Marshal.FreeCoTaskMem(qscPtr);
            return result;
        }
        public static void ChangeStartMode(ServiceController svc, ServiceStartMode mode, bool delayedAutoStart = true)
        {
            var scManagerHandle = OpenSCManager(null, null, ScManagerAllAccess);
            if (scManagerHandle == IntPtr.Zero)
            {
                throw new ExternalException("Open Service Manager Error");
            }

            var serviceHandle = OpenService(
                scManagerHandle,
                svc.ServiceName,
                ServiceQueryConfig | ServiceChangeConfig);

            if (serviceHandle == IntPtr.Zero)
            {
                throw new ExternalException("Open Service Error");
            }

            if (GetServiceStartMode(serviceHandle) == (int)ServiceStartMode.Automatic)
                return;

            if (!ChangeServiceConfig(
                serviceHandle,
                ServiceNoChange,
                (uint)mode,
                ServiceNoChange,
                null,
                null,
                IntPtr.Zero,
                null,
                null,
                null,
                null))
            {
                var nError = Marshal.GetLastWin32Error();
                var win32Exception = new Win32Exception(nError);
                throw new ExternalException("Could not change service start type: " + win32Exception.Message);
            }

            if (delayedAutoStart)
            {
                var serviceDelayedAutoStartInfo = new ServiceDelayedAutoStartInfo { fDelayedAutostart = true };
                ChangeServiceConfig2(serviceHandle, ServiceConfigDelayedAutoStartInfo, ref serviceDelayedAutoStartInfo);
            }
            CloseServiceHandle(serviceHandle);
            CloseServiceHandle(scManagerHandle);
        }
    }
}