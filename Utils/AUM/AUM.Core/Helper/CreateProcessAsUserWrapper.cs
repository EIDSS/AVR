/************************************* Module Header ***********************************\
* Module Name:  CreateProcessAsUserWrapper.cs
* Project:      CSCreateProcessAsUserFromService
* Copyright (c) Microsoft Corporation.
* 
* The sample demonstrates how to create/launch a process interactively in the session of 
* the logged-on user from a service application written in C#.Net.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************************/

namespace AUM.Core.Helper
{
  using System;
  using System.Runtime.InteropServices;


  internal static class CreateProcessAsUserWrapper
  {
    public static void LaunchChildProcess(string childProcName)
    {
      var ppSessionInfo = IntPtr.Zero;
      uint sessionCount = 0;

      if (!WTSEnumerateSessions(
        (IntPtr) WTS_CURRENT_SERVER_HANDLE, // Current RD Session Host Server handle would be zero.
        0, // This reserved parameter must be zero.
        1, // The version of the enumeration request must be 1.
        ref ppSessionInfo, // This would point to an array of session info.
        ref sessionCount // This would indicate the length of the above array.
        ))
      {
        return;
      }
      for (var nCount = 0; nCount < sessionCount; nCount++)
      {
        // Extract each session info and check if it is the 
        // "Active Session" of the current logged-on user.
        var tSessionInfo = (WTS_SESSION_INFO)Marshal.PtrToStructure(
          ppSessionInfo + nCount * Marshal.SizeOf(typeof(WTS_SESSION_INFO)),
          typeof(WTS_SESSION_INFO)
          );

        if (WTS_CONNECTSTATE_CLASS.WTSActive != tSessionInfo.State)
        {
          continue;
        }
        IntPtr hToken;
        if (!WTSQueryUserToken(tSessionInfo.SessionID, out hToken))
        {
          continue;
        }
        // Launch the child process interactively 
        // with the token of the logged-on user.
        PROCESS_INFORMATION tProcessInfo;
        var tStartUpInfo = new STARTUPINFO { cb = Marshal.SizeOf(typeof(STARTUPINFO)) };

        var childProcStarted = CreateProcessAsUser(
          hToken, // Token of the logged-on user.
          childProcName, // Name of the process to be started.
          null, // Any command line arguments to be passed.
          IntPtr.Zero, // Default Process' attributes.
          IntPtr.Zero, // Default Thread's attributes.
          false, // Does NOT inherit parent's handles.
          0, // No any specific creation flag.
          null, // Default environment path.
          null, // Default current directory.
          ref tStartUpInfo, // Process Startup Info. 
          out tProcessInfo // Process information to be returned.
          );

        if (childProcStarted)
        {
          // The child process creation is successful!

          // If the child process is created, it can be controlled via the out 
          // param "tProcessInfo". For now, as we don't want to do any thing 
          // with the child process, closing the child process' handles 
          // to prevent the handle leak.
          CloseHandle(tProcessInfo.hThread);
          CloseHandle(tProcessInfo.hProcess);
        }

        // Whether child process was created or not, close the token handle 
        // and break the loop as processing for current active user has been done.
        CloseHandle(hToken);
        break;
      }

      // Free the memory allocated for the session info array.
      WTSFreeMemory(ppSessionInfo);
    }

    #region P/Invoke WTS APIs

    // ReSharper disable InconsistentNaming
    /// <summary>
    ///   Struct, Enum and P/Invoke Declarations of WTS APIs.
    /// </summary>
    private const int WTS_CURRENT_SERVER_HANDLE = 0;
    

    private enum WTS_CONNECTSTATE_CLASS
    {
      WTSActive
      /*,
      WTSConnected,
      WTSConnectQuery,
      WTSShadow,
      WTSDisconnected,
      WTSIdle,
      WTSListen,
      WTSReset,
      WTSDown,
      WTSInit*/
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private struct WTS_SESSION_INFO
    {
      public readonly uint SessionID;
      public readonly string pWinStationName;
      public readonly WTS_CONNECTSTATE_CLASS State;
    }
    // ReSharper restore InconsistentNaming

    [DllImport("WTSAPI32.DLL", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern bool WTSEnumerateSessions(
      IntPtr hServer,
      [MarshalAs(UnmanagedType.U4)] uint reserved,
      [MarshalAs(UnmanagedType.U4)] uint version,
      ref IntPtr ppSessionInfo,
      [MarshalAs(UnmanagedType.U4)] ref uint pSessionInfoCount
      );

    [DllImport("WTSAPI32.DLL", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern void WTSFreeMemory(IntPtr pMemory);

    [DllImport("WTSAPI32.DLL", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern bool WTSQueryUserToken(uint sessionId, out IntPtr token);
    #endregion

    #region P/Invoke CreateProcessAsUser
    // ReSharper disable InconsistentNaming

    /// <summary>
    ///   Struct, Enum and P/Invoke Declarations for CreateProcessAsUser.
    /// </summary>
    /// 
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    
    private struct STARTUPINFO
    
    {
      public int cb;
      public readonly string lpReserved;
      public readonly string lpDesktop;
      public readonly string lpTitle;
      public readonly int dwX;
      public readonly int dwY;
      public readonly int dwXSize;
      public readonly int dwYSize;
      public readonly int dwXCountChars;
      public readonly int dwYCountChars;
      public readonly int dwFillAttribute;
      public readonly int dwFlags;
      public readonly short wShowWindow;
      public readonly short cbReserved2;
      public readonly IntPtr lpReserved2;
      public readonly IntPtr hStdInput;
      public readonly IntPtr hStdOutput;
      public readonly IntPtr hStdError;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private struct PROCESS_INFORMATION
    {
      public readonly IntPtr hProcess;
      public readonly IntPtr hThread;
      public readonly int dwProcessId;
      public readonly int dwThreadId;
    }

    // ReSharper restore InconsistentNaming
    [DllImport("ADVAPI32.DLL", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern bool CreateProcessAsUser(
      IntPtr hToken,
      string lpApplicationName,
      string lpCommandLine,
      IntPtr lpProcessAttributes,
      IntPtr lpThreadAttributes,
      bool bInheritHandles,
      uint dwCreationFlags,
      string lpEnvironment,
      string lpCurrentDirectory,
      ref STARTUPINFO lpStartupInfo,
      out PROCESS_INFORMATION lpProcessInformation
      );

    [DllImport("KERNEL32.DLL", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern bool CloseHandle(IntPtr hHandle);

    #endregion
  }
}