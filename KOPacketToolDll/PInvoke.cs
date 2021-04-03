using System;
using System.Runtime.InteropServices;

namespace KOPacketLoggerDLL
{
    public static class PInvoke
    {
        public const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        public const int MEM_COMMIT = 0x1000;
        public const int MEM_RELEASE = 0x8000;
        public const int PAGE_READWRITE = 0x04;
        public const int PAGE_EXECUTE_READWRITE = 0x40;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize,
   uint flNewProtect, out uint lpflOldProtect);

        [DllImport("kernel32.dll")]
        //Reserves or commits a region of memory within the virtual address space of a specified process. The function initializes the memory it allocates to zero, unless MEM_RESET is used.
        public static extern IntPtr VirtualAllocEx(IntPtr hpProcess, IntPtr lpAddress, int dwSize,
                                             int flAllocationType, int flProtect);

        [DllImport("kernel32.dll")]
        //Reads data from an area of memory in a specified process. The entire area to be read must be accessible or the operation fails.
        public static extern int ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, long nSize,
                                                    long lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        //Writes data to an area of memory in a specified process. The entire area to be written to must be accessible or the operation fails.
        public static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, long size,
                                                      uint lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")] //Opens an existing local process object.
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
    }

}
