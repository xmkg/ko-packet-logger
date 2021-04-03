/**
 * ______________________________________________________
 * This file is part of ko-packet-logger project.
 * 
 * @author       Mustafa Kemal Gılor <mustafagilor@gmail.com> (2015)
 * .
 * SPDX-License-Identifier:	MIT
 * ______________________________________________________
 */
 
using System;
using System.Runtime.InteropServices;

namespace KOPacketTool
{
    public static class DebugPrivilegeHelper
    {
        #region Define
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool OpenProcessToken(IntPtr ProcessHandle,
          UInt32 DesiredAccess, out IntPtr TokenHandle);

        private static uint STANDARD_RIGHTS_REQUIRED = 0x000F0000;
        private static uint STANDARD_RIGHTS_READ = 0x00020000;
        private static uint TOKEN_ASSIGN_PRIMARY = 0x0001;
        private static uint TOKEN_DUPLICATE = 0x0002;
        private static uint TOKEN_IMPERSONATE = 0x0004;
        private static uint TOKEN_QUERY = 0x0008;
        private static uint TOKEN_QUERY_SOURCE = 0x0010;
        private static uint TOKEN_ADJUST_PRIVILEGES = 0x0020;
        private static uint TOKEN_ADJUST_GROUPS = 0x0040;
        private static uint TOKEN_ADJUST_DEFAULT = 0x0080;
        private static uint TOKEN_ADJUST_SESSIONID = 0x0100;
        private static uint TOKEN_READ = (STANDARD_RIGHTS_READ | TOKEN_QUERY);
        private static uint TOKEN_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | TOKEN_ASSIGN_PRIMARY |
            TOKEN_DUPLICATE | TOKEN_IMPERSONATE | TOKEN_QUERY | TOKEN_QUERY_SOURCE |
            TOKEN_ADJUST_PRIVILEGES | TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT |
            TOKEN_ADJUST_SESSIONID);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool LookupPrivilegeValue(string lpSystemName, string lpName,
            out LUID lpLuid);

        private const string SE_ASSIGNPRIMARYTOKEN_NAME = "SeAssignPrimaryTokenPrivilege";

        private const string SE_AUDIT_NAME = "SeAuditPrivilege";

        private const string SE_BACKUP_NAME = "SeBackupPrivilege";

        private const string SE_CHANGE_NOTIFY_NAME = "SeChangeNotifyPrivilege";

        private const string SE_CREATE_GLOBAL_NAME = "SeCreateGlobalPrivilege";

        private const string SE_CREATE_PAGEFILE_NAME = "SeCreatePagefilePrivilege";

        private const string SE_CREATE_PERMANENT_NAME = "SeCreatePermanentPrivilege";

        private const string SE_CREATE_SYMBOLIC_LINK_NAME = "SeCreateSymbolicLinkPrivilege";

        private const string SE_CREATE_TOKEN_NAME = "SeCreateTokenPrivilege";

        private const string SE_DEBUG_NAME = "SeDebugPrivilege";

        private const string SE_ENABLE_DELEGATION_NAME = "SeEnableDelegationPrivilege";

        private const string SE_IMPERSONATE_NAME = "SeImpersonatePrivilege";

        private const string SE_INC_BASE_PRIORITY_NAME = "SeIncreaseBasePriorityPrivilege";

        private const string SE_INCREASE_QUOTA_NAME = "SeIncreaseQuotaPrivilege";

        private const string SE_INC_WORKING_SET_NAME = "SeIncreaseWorkingSetPrivilege";

        private const string SE_LOAD_DRIVER_NAME = "SeLoadDriverPrivilege";

        private const string SE_LOCK_MEMORY_NAME = "SeLockMemoryPrivilege";

        private const string SE_MACHINE_ACCOUNT_NAME = "SeMachineAccountPrivilege";

        private const string SE_MANAGE_VOLUME_NAME = "SeManageVolumePrivilege";

        private const string SE_PROF_SINGLE_PROCESS_NAME = "SeProfileSingleProcessPrivilege";

        private const string SE_RELABEL_NAME = "SeRelabelPrivilege";

        private const string SE_REMOTE_SHUTDOWN_NAME = "SeRemoteShutdownPrivilege";

        private const string SE_RESTORE_NAME = "SeRestorePrivilege";

        private const string SE_SECURITY_NAME = "SeSecurityPrivilege";

        private const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";

        private const string SE_SYNC_AGENT_NAME = "SeSyncAgentPrivilege";

        private const string SE_SYSTEM_ENVIRONMENT_NAME = "SeSystemEnvironmentPrivilege";

        private const string SE_SYSTEM_PROFILE_NAME = "SeSystemProfilePrivilege";

        private const string SE_SYSTEMTIME_NAME = "SeSystemtimePrivilege";

        private const string SE_TAKE_OWNERSHIP_NAME = "SeTakeOwnershipPrivilege";

        private const string SE_TCB_NAME = "SeTcbPrivilege";

        private const string SE_TIME_ZONE_NAME = "SeTimeZonePrivilege";

        private const string SE_TRUSTED_CREDMAN_ACCESS_NAME = "SeTrustedCredManAccessPrivilege";

        private const string SE_UNDOCK_NAME = "SeUndockPrivilege";

        private const string SE_UNSOLICITED_INPUT_NAME = "SeUnsolicitedInputPrivilege";

        [StructLayout(LayoutKind.Sequential)]
        private struct LUID
        {
            public UInt32 LowPart;
            public Int32 HighPart;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hHandle);

        private const UInt32 SE_PRIVILEGE_ENABLED_BY_DEFAULT = 0x00000001;
        private const UInt32 SE_PRIVILEGE_ENABLED = 0x00000002;
        private const UInt32 SE_PRIVILEGE_REMOVED = 0x00000004;
        private const UInt32 SE_PRIVILEGE_USED_FOR_ACCESS = 0x80000000;

        [StructLayout(LayoutKind.Sequential)]
        private struct TOKEN_PRIVILEGES
        {
            public UInt32 PrivilegeCount;
            public LUID Luid;
            public UInt32 Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct LUID_AND_ATTRIBUTES
        {
            public LUID Luid;
            public UInt32 Attributes;
        }

        // Use this signature if you do not want the previous state
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AdjustTokenPrivileges(IntPtr TokenHandle,
           [MarshalAs(UnmanagedType.Bool)]bool DisableAllPrivileges,
           ref TOKEN_PRIVILEGES NewState,
           UInt32 Zero,
           IntPtr Null1,
           IntPtr Null2);
        #endregion

        public static bool EnableDebugPrivileges()
        {
            IntPtr hToken;
            LUID luidSEDebugNameValue;
            TOKEN_PRIVILEGES tkpPrivileges;

            if (!OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out hToken))
            {
                Console.WriteLine("OpenProcessToken() failed, error = {0} . SeDebugPrivilege is not available", Marshal.GetLastWin32Error());
                return false;
            }
            else
            {
                Console.WriteLine("OpenProcessToken() successfully");
            }

            if (!LookupPrivilegeValue(null, SE_DEBUG_NAME, out luidSEDebugNameValue))
            {
                Console.WriteLine("LookupPrivilegeValue() failed, error = {0} .SeDebugPrivilege is not available", Marshal.GetLastWin32Error());
                CloseHandle(hToken);
                return false;
            }
            else
            {
                Console.WriteLine("LookupPrivilegeValue() successfully");
            }

            tkpPrivileges.PrivilegeCount = 1;
            tkpPrivileges.Luid = luidSEDebugNameValue;
            tkpPrivileges.Attributes = SE_PRIVILEGE_ENABLED;

            if (!AdjustTokenPrivileges(hToken, false, ref tkpPrivileges, 0, IntPtr.Zero, IntPtr.Zero))
            {
                Console.WriteLine("LookupPrivilegeValue() failed, error = {0} .SeDebugPrivilege is not available", Marshal.GetLastWin32Error());
            }
            else
            {
                Console.WriteLine("SeDebugPrivilege is now available");

            }
            CloseHandle(hToken);
            return true;
        }

    }
}
