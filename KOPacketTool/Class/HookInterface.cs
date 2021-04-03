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
using System.Diagnostics;
using System.Windows.Forms;
using KOPacketTool.Interface;

namespace KOPacketTool.Class
{

    public class HookInterface : MarshalByRefObject
    {
        mainFrm _frm;

        public delegate void DetachDelegate();

        private bool shouldDetach = false;
        public event DetachDelegate OnProcessDetach;

        public long GetDatapackAddr()
        {
            // v1534 const long fAddrDataPackConstructor = 0x0046ED10;
            // v1397-linux const long fAddrDataPackConstructor = 0x0045B7E0;
            return StaticReference.DatapackPtr;
            // return 0x0046ED10;
            // return 0x0045B7E0;
        }

        public long GetStaticBufferAddr()
        {
            return StaticReference.StaticBufferPtr;
        }

        public void IsInstalled(int clientId)
        {
            Trace.WriteLine("Hook successfully installed to process : " + clientId);

            _frm = (mainFrm)Application.OpenForms[0];
            _frm.OnDetachRequest += _frm_OnDetachRequest;
            _frm.Invoke(new Action(() => { _frm.OnInject(); }));

        }

        public void IsUninstalled()
        {
            Trace.WriteLine("Hook successfully uninstalled.");
            _frm = (mainFrm)Application.OpenForms[0];
            _frm.Invoke(new Action(() => { _frm.OnDeinject(); }));
        }

        private void _frm_OnDetachRequest()
        {
            shouldDetach = true;
        }

        public void ErrorHandler(Exception ex)
        {
            Trace.WriteLine("The hook module thrown an exception : " + ex.Message);

        }

        public void Log(string msg)
        {
            Trace.WriteLine(msg);
        }

        public void OnPacketReceived(byte[][] package)
        {
            for (int i = package.Length - 1; i >= 0; i--)
            {
                _frm.PacketOperation(package[i]);
            }


        }

        public bool ShouldDetach()
        {
            return shouldDetach;
            //throw new NotImplementedException();
        }
    }
}
