/**
 * ______________________________________________________
 * This file is part of ko-packet-logger project.
 * 
 * @author       Mustafa Kemal Gılor <mustafagilor@gmail.com> (2015)
 * .
 * SPDX-License-Identifier:	MIT
 * ______________________________________________________
 */
 
using EasyHook;
using KOPacketTool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using KOPacketTool.Class;

/*DataPack::DataPack(int size, BYTE *pData, BOOL bSend)
{
	static BYTE pTIBuf[RECEIVE_BUF_SIZE];
	static BYTE pTBuf[RECEIVE_BUF_SIZE];
	__ASSERT(size, "size is 0");
	if (TRUE == s_bCryptionFlag)
	{
		if (bSend)
		{	// 서버로 보낼것 (일반 -> 암호화된것)
			// inmate - cryption
			if(TRUE == s_bCryptionFlag)
			{
				int clyp_size = size + (sizeof(WORD)+1+1);

				++s_wSendVal;

				pTIBuf[0] = 0xfc; // 암호가 정확한지
				memcpy( pTIBuf+1, &s_wSendVal, sizeof(WORD) );
				pTIBuf[3] = 0x00;
				memcpy( pTIBuf+4, pData, size );
				s_JvCrypt.JvEncryptionFast( clyp_size, pTIBuf, pTBuf );

				BYTE* pTmp = pTIBuf;
				
				m_Size = clyp_size;
				m_pData = new BYTE[m_Size+1];
				CopyMemory(m_pData, pTBuf, m_Size);
			}
			else
			{
				m_Size = size;
				m_pData = new BYTE[m_Size+1];
				CopyMemory(m_pData, pData, m_Size);
			}
		}
		else
		{	// 서버로부터 받은 데이타(암호화된것 -> 일반)
			s_JvCrypt.JvDecryptionFast( size, pData, pTBuf );
			if(pTBuf[0] != 0xfc) // 압축 푼 데이터 오류 일경우
			{
				m_Size = 0;
				m_pData = NULL;
				__ASSERT(0, "Crypt Error");
			}
			else
			{
				m_Size = size-4;
				m_pData = new BYTE[m_Size+1];
				CopyMemory(m_pData, &(pTBuf[4]), m_Size);
				m_pData[m_Size] = '\0';
			}
		}
	}
	else
	{	// 암호화가 아니다.
		m_Size = size;
		m_pData = new BYTE[size+1];
		CopyMemory(m_pData, pData, size);
	}
}*/



namespace KOPacketLoggerDLL
{




    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void TJVDecryptionFast(IntPtr xThis, int len, IntPtr datain, IntPtr dataout);


    public class Main : IEntryPoint
    {
       // const long fAddrDataPackConstructor = 0x0046ED10;
        private long datapackAddrToHook = 0;
        private long datapackAddrStaticBuffer = 0;
        const long fAddrJvDecryptionFast    = 0x007F23E0;
     //   const long fAddrDataPackStaticBuffer = fAddrDataPackConstructor + 0x47;

        HookInterface Interface;
        Stack<byte[]> Queue = new Stack<byte[]>();



        /// Return Type: void
        ///size: int
        ///pData: unsigned char*
        ///bSend: BOOL->int
        [UnmanagedFunctionPointer(CallingConvention.ThisCall/*, CharSet = CharSet.Ansi, SetLastError = true*/)]
        public delegate int TDataPack(IntPtr thisX, int size, IntPtr pData, int bSend);

        IntPtr ptrDatapackReal = IntPtr.Zero;

        Process hookedProcess;


        public static TDataPack OriginalDatapackFunction;
        public static TDataPack MyDatapackFunction;
        Detours.Hook DatapackHook;


        public static TJVDecryptionFast JVDecryptionFast;
        public static TJVDecryptionFast Hooked_JVDecryptionFast;
        Detours.Hook JVDecryptionFastHook;
        IntPtr ptrBufReal;
        IntPtr findPtrBufReal;


        public Main(RemoteHooking.IContext InContext, string InChannelName)
        {
            Interface = RemoteHooking.IpcConnectClient<HookInterface>(InChannelName);
        }
        
      


        bool HookDatapackFunct()
        {         
            ptrDatapackReal = (IntPtr)(datapackAddrToHook + hookedProcess.MainModule.BaseAddress.ToInt32() - 0x00400000);
          
            findPtrBufReal = (IntPtr)(datapackAddrStaticBuffer + 1 + hookedProcess.MainModule.BaseAddress.ToInt32() - 0x00400000);
            byte[] staticBufferAddr = new byte[4];
          
            PInvoke.ReadProcessMemory(hookedProcess.Handle, findPtrBufReal, staticBufferAddr, 4, 0);  
            Interface.Log("StaBuf : " + staticBufferAddr[0].ToString("X") + staticBufferAddr[1].ToString("X") + staticBufferAddr[2].ToString("X") + staticBufferAddr[3].ToString("X"));
           
            int addr = BitConverter.ToInt32(staticBufferAddr, 0);
            ptrBufReal = (IntPtr)(addr + hookedProcess.MainModule.BaseAddress.ToInt32() - 0x00400000);
            Interface.Log("BUFF ADDR " + addr.ToString("X"));
         //   Marshal.GetDelegateForFunctionPointer()
         
            OriginalDatapackFunction = (TDataPack)Marshal.GetDelegateForFunctionPointer(ptrDatapackReal, typeof(TDataPack));
            MyDatapackFunction = DataPack_Hooked;
            DatapackHook = new Detours.Hook(OriginalDatapackFunction, MyDatapackFunction);
            return DatapackHook.Install();
        }


     /* private void Interface_OnProcessDetach()
        {
            UnhookAll();
            Interface.IsUninstalled();
        }*/

        bool UnhookAll()
        {
            Interface.Log("Uninstalling all hooks");
            ;
          //  Trace.WriteLine("Uninstalling all hooks");
            return DatapackHook.Uninstall();
        }

        public void Run(RemoteHooking.IContext InContext, String InChannelName)
        {
            try
            {
             //   Interface.OnProcessDetach += Interface_OnProcessDetach;     
                Interface.Log("HookModule::Run()");
                Interface.Log("Enabling debug privileges..");
                bool dpEnabled = DebugPrivilegeHelper.EnableDebugPrivileges();
                Interface.Log(dpEnabled ? "Debug privileges are enabled" : "Debug privileges are not enabled");
                Interface.Log("Getting process information");
                //PUSH 0x9F5080
                hookedProcess = Process.GetProcessById(RemoteHooking.GetCurrentProcessId());
                Interface.Log(
                    $"Process '{hookedProcess.ProcessName}', PID : {hookedProcess.Id}, Base : {hookedProcess.MainModule.BaseAddress.ToInt32().ToString("x")}");

                datapackAddrToHook = Interface.GetDatapackAddr();
               

                Interface.Log($"Datapack Address to Hook : {datapackAddrToHook.ToString("X")}");

                if (Interface.GetStaticBufferAddr() > 0)
                    datapackAddrStaticBuffer = Interface.GetStaticBufferAddr();
                else
                    datapackAddrStaticBuffer = datapackAddrToHook + 0x47;

                Interface.Log($"Datapack static buff. addr. to hook : {datapackAddrStaticBuffer.ToString("X")}");

                Interface.Log(HookDatapackFunct() ? "Datapack function successfully hooked." : "Datapack function hook fail!");
             


            }
            catch (Exception ExtInfo)
            {
                Interface.ErrorHandler(ExtInfo);
                return;
            }
            Interface.IsInstalled(RemoteHooking.GetCurrentProcessId());
            try
            {
                while (true)
                {
                    Thread.Sleep(10);   //was 500, need something faster tho.
                    if (Queue.Count > 0)
                    {
                        byte[][] Package = null;
                        lock (Queue)
                        {
                            Package = Queue.ToArray();
                            Queue.Clear();
                        }

                        Interface.OnPacketReceived(Package);
                    }
                    else
                    {
                        if (!Interface.ShouldDetach())
                            continue;
                        UnhookAll();
                        return;
                    }
                }
            }
            catch
            {
                // NET Remoting will raise an exception if host is unreachable
            }
        }


        private int DataPack_Hooked(IntPtr thisx, int size, IntPtr buf, int flag)
        {
         
            
         //   Interface.Log("Hook callback");
            int retValue = 0;
            if(flag == 1)
            {
                // SEND
                lock (Queue)
                {
                    byte[] buffer = new byte[size + 1];
                    buffer[0] = 0x01;
                    Marshal.Copy(buf, buffer, 1, size);
                    Queue.Push(buffer);
                }
                retValue = (int)DatapackHook.CallOriginal(thisx, size, buf, flag);
            }
            else
            {
                retValue = (int)DatapackHook.CallOriginal(thisx, size, buf, flag);

                lock (Queue)
                {
                    //
                    byte[] buffer = new byte[size -4];
                    buffer[0] = 0x00;
                    Marshal.Copy(ptrBufReal + 5, buffer, 1, size - 5);
                    Queue.Push(buffer);
                }

            }

            return retValue;
        }

    }

}
