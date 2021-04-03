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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EasyHook;
using FastColoredTextBoxNS;
using KOPacketTool.Class;
using static KOPacketTool.Class.StaticReference;

namespace KOPacketTool.Interface
{
    public partial class mainFrm : XtraForm
    {

        private static mainFrm _formReference = null;
        TextStyle warningStyle = new TextStyle(Brushes.BurlyWood, null, FontStyle.Regular);
        TextStyle errorStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);

        TextStyle typeStyle = new TextStyle(Brushes.CadetBlue, null, FontStyle.Regular);
        TextStyle opcodeStyle = new TextStyle(Brushes.Gold, null, FontStyle.Regular);
        TextStyle suboptyle = new TextStyle(Brushes.Crimson, null, FontStyle.Regular);
        TextStyle subop2tyle = new TextStyle(Brushes.Chartreuse, null, FontStyle.Regular);
        TextStyle dataStyle = new TextStyle(Brushes.White, null, FontStyle.Regular);
        readonly Font _textFont = new Font("Tahoma", 7.11f, FontStyle.Regular);
        public delegate void DetachReq();
        public event DetachReq OnDetachRequest;

        private ManualResetEvent _packetMre = new ManualResetEvent(false);
        private Queue<byte[]> _packetQueue = new Queue<byte[]>();
        private ConcurrentStack<byte[]> packetStk;
        internal long datapackPtr = 0;
        FastColoredTextBox fctb = new FastColoredTextBox();
        private Thread _packetWorkerThread;
        private bool _working = false;
        private Process _attachedProcess;
        private void WorkerThreadFunct()
        {
            while (_working)
            {
                _packetMre.WaitOne();
                lock (_packetQueue)
                {
                    while (_packetQueue.Count > 0)
                    {

                        byte[] arr = _packetQueue.Dequeue();
                        ProcessPacket(arr);
                    }
                }
                _packetMre.Reset();
            }
        }

        public mainFrm()
        {
            InitializeComponent();
            _formReference = this;
            this.Size = new Size(nbMain.Width + 10, 160);
            Application.ApplicationExit += Application_ApplicationExit;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            fctb.BackColor = Color.FromArgb(45, 45, 48);
            fctb.ReadOnly = true;
            fctb.TextAreaBorderColor = Color.FromArgb(45, 45, 48);
            fctb.PaddingBackColor = Color.FromArgb(45, 45, 48);
            fctb.ServiceLinesColor = Color.FromArgb(45, 45, 48);
           fctb.FoldingIndicatorColor = Color.FromArgb(45, 45, 48);
            fctb.IndentBackColor = Color.FromArgb(45, 45, 48);
            fctb.Dock = DockStyle.Fill;
            gcPacketLog.Controls.Add(fctb);
            chbReceive.Checked = true;
            chbSend.Checked = true;
        }

        private void AppendPacket(string type, string op,string data)
        {
            //some stuffs for best performance
            fctb.BeginUpdate();
            fctb.Selection.BeginUpdate();
            //remember user selection
            var userSelection = fctb.Selection.Clone();
            //add text with predefined style
    
            fctb.TextSource.CurrentTB = fctb;
            fctb.AppendText(type + ' ', typeStyle);
            fctb.AppendText(op, opcodeStyle);
            fctb.AppendText(": " + data + Environment.NewLine, dataStyle);
            //restore user selection
            if (!userSelection.IsEmpty || userSelection.Start.iLine < fctb.LinesCount - 2)
            {
                fctb.Selection.Start = userSelection.Start;
                fctb.Selection.End = userSelection.End;
            }
            else
                fctb.GoEnd();//scroll to end of the text
            //
            fctb.Selection.EndUpdate();
            fctb.EndUpdate();
        }
        private void AppendPacket(string type, string op,string subop, string data)
        {
            //some stuffs for best performance

            fctb.BeginUpdate();
            fctb.Selection.BeginUpdate();
            //remember user selection
            var userSelection = fctb.Selection.Clone();
            //add text with predefined style
            fctb.TextSource.CurrentTB = fctb;
            fctb.AppendText(type + ' ', typeStyle);
            fctb.AppendText(op, opcodeStyle);
            fctb.AppendText('<' + subop + '>', suboptyle);
            fctb.AppendText(": " + data + Environment.NewLine, dataStyle);
            //restore user selection
            if (!userSelection.IsEmpty || userSelection.Start.iLine < fctb.LinesCount - 2)
            {
                fctb.Selection.Start = userSelection.Start;
                fctb.Selection.End = userSelection.End;
            }
            else
                fctb.GoEnd();//scroll to end of the text
            //
            fctb.Selection.EndUpdate();
            fctb.EndUpdate();
        }
        private void AppendLogText(string type,string data)
        {
         
            fctb.BeginUpdate();
            fctb.Selection.BeginUpdate();
            //remember user selection
            var userSelection = fctb.Selection.Clone();
            fctb.TextSource.CurrentTB = fctb;
            fctb.AppendText(type + ' ', typeStyle);
            fctb.AppendText(": " + data + Environment.NewLine, dataStyle);
            //restore user selection
            if (!userSelection.IsEmpty || userSelection.Start.iLine < fctb.LinesCount - 2)
            {
                fctb.Selection.Start = userSelection.Start;
                fctb.Selection.End = userSelection.End;
            }
            else
                fctb.GoEnd();//scroll to end of the text
            //
            fctb.Selection.EndUpdate();
            fctb.EndUpdate();
        }

        private void AppendPacket(string type, string op, string subop,string subop2, string data)
        {//some stuffs for best performance
            fctb.BeginUpdate();
            fctb.Selection.BeginUpdate();
            //remember user selection
            var userSelection = fctb.Selection.Clone();
            //add text with predefined style
            fctb.TextSource.CurrentTB = fctb;
            fctb.AppendText(type + ' ', typeStyle);
            fctb.AppendText(op, opcodeStyle);
            fctb.AppendText('<'+subop+'>', suboptyle);
            fctb.AppendText('<' + subop2 + '>', subop2tyle);
            fctb.AppendText(": " + data + Environment.NewLine, dataStyle );
            
            //restore user selection
            if (!userSelection.IsEmpty || userSelection.Start.iLine < fctb.LinesCount - 2)
            {
                fctb.Selection.Start = userSelection.Start;
                fctb.Selection.End = userSelection.End;
            }
            else
                fctb.GoEnd();//scroll to end of the text
            //
            fctb.Selection.EndUpdate();
            fctb.EndUpdate();
        }
     

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            OnDetachRequest?.Invoke();
        }

        private static void reattach_worker(object x)
        {
            string process_name = x as string;
            // reattach worker
            while (true)
            {
                var plist = Process.GetProcessesByName(process_name);
                if(plist.Length > 0)
                {
                    AttachProcess(plist[0].Id);
                    var ke = new KeyEventArgs(Keys.F8);
                   _formReference.mainFrm_KeyDown(null, ke);
                   // var ke2 = new KeyEventArgs(Keys.F12);
                    break;
                }
                Thread.Sleep(1000);
            }
        }

        static void AttachProcess(int pid)
        {
            try
            {
                string chanName = null;
                Process pc = Process.GetProcessById(pid);
                pc.EnableRaisingEvents = true;
                
                pc.Exited +=  delegate {
                    // XtraMessageBox.Show( _formReference,"Attached process exited.");
                    ThreadPool.QueueUserWorkItem(reattach_worker, pc.ProcessName);
                    _formReference.AppendLogText("TERM", "Knight OnLine Client terminated.");
                    var ke = new KeyEventArgs(Keys.F7);
                    _formReference.mainFrm_KeyDown(null, ke);
                };
                RemoteHooking.IpcCreateServer<HookInterface>(ref chanName, WellKnownObjectMode.Singleton);
                
                RemoteHooking.Inject(pid, InjectionOptions.Default | InjectionOptions.DoNotRequireStrongName, "fucking.dll", "fucking.dll", chanName);
                _formReference._attachedProcess = pc;
                _formReference.AppendLogText("ATTACH", "Successfully attached to the client.");
                //_formReference.ti
            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception occured when trying to connect to the target.\nMessage : " + ex.Message + "\nStack trace : "+ ex.StackTrace);
            }
        }


        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (var v = new frmProcessList())
            {
                v.OnAttachProcess += AttachProcess;
                v.ShowDialog();
            }
        }


        public void OnInject()
        {
            
            _working = true;
            _packetWorkerThread = new Thread(WorkerThreadFunct) {IsBackground = true};
            _packetWorkerThread.Start();
            
            Text = $"Message Watcher | Atached to `{_attachedProcess.ProcessName}`~`{_attachedProcess.MainWindowTitle}`";
            btnDetach.Enabled = true;
            btnAttach.Enabled = false;
         //   ngSendFilter.Visible = true;
            ngOptions.Visible = true;
            gcPacketLog.Visible = true;
            Size = new Size(975, 750);
            FormBorderStyle = FormBorderStyle.Sizable;
            CenterToScreen();
        }
        public void OnDeinject()
        {
            _working = false;
            _packetMre.Set();
            _packetWorkerThread.Join();
            lock (_packetQueue)
                _packetQueue.Clear();
            chbAlwaysOnTop.Checked = false;
            XtraMessageBox.Show(this, "Detached successfully.", "Detach status", MessageBoxButtons.OK,
                MessageBoxIcon.Information);//   MessageBox.Show("Detached successfully");
            Text = "Packet tool";
            btnDetach.Enabled = false;
            btnAttach.Enabled = true;
            this.Size = new Size(nbMain.Width + 5, 170);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            CenterToScreen();
            fctb.Clear();
            // throw new NotImplementedException();
        }

        private void ProcessPacket(byte[] buf)
        {
            string packetContent = BitConverter.ToString(buf, 1, buf.Length - 1);
            packetContent = packetContent.Replace("-", "");
            string opCode = Enum.GetName(typeof(KOOpcodes), buf[1]);
            string type = buf[0] == 1 ? "SEND" : "RECV";

           /* if (buf[0] != 1)
            {
                Array.Copy(buf, buf, buf.Length - 4);
                
            }*/

            if (buf[1] == (byte)KOOpcodes.WIZ_COMPRESS_PACKET)
            {
                AppendPacket(type, opCode, "Decompressing data..");
                DecompressPacket(buf);
                return;
            }

            if (buf[1] == (byte)KOOpcodes.WIZ_CONTINOUS_PACKET)
            {
                AppendPacket(type, opCode, "Seperating data..");
                SeperateContinuousPacket(buf);
                return;
            }

            #region Parse subopcodes

            string subopCode = "";
            string subopCode2 = "";
            switch (buf[1])
            {
                case (byte) KOOpcodes.WIZ_CHAT:

                    subopCode = Enum.GetName(typeof (ChatType), buf[2]);


                    break;

                case (byte) KOOpcodes.WIZ_EXCHANGE:

                    subopCode = Enum.GetName(typeof (TradeOpcodes), buf[2]);

                    break;
                case (byte) KOOpcodes.WIZ_MERCHANT:

                    subopCode = Enum.GetName(typeof (MerchantOpcodes), buf[2]);

                    break;
                case (byte) KOOpcodes.WIZ_MINING:
                    subopCode = Enum.GetName(typeof (MiningSystemOpcodes), buf[2]);

                    break;
                case (byte) KOOpcodes.WIZ_MAGIC_PROCESS:
                    subopCode = Enum.GetName(typeof (MagicOpcode), buf[2]);

                    break;
                case (byte) KOOpcodes.WIZ_KNIGHTS_PROCESS:
                    subopCode = Enum.GetName(typeof (Knights), buf[2]);

                    break;
                case (byte) KOOpcodes.WIZ_OPERATOR:
                    subopCode = Enum.GetName(typeof (OperatorCommands), buf[2]);

                    break;
                case (byte) KOOpcodes.WIZ_FRIEND_PROCESS:
                    subopCode = Enum.GetName(typeof (FriendOpcodes), buf[2]);

                    break;
                case (byte) KOOpcodes.WIZ_ITEM_UPGRADE:
                    subopCode = Enum.GetName(typeof (ItemUpgradeOpcodes), buf[2]);

                    break;
                case (byte) KOOpcodes.WIZ_SHOPPING_MALL:
                    subopCode = Enum.GetName(typeof (ShoppingMallOpcodes), buf[2]);
                    if (buf[2] == (int) ShoppingMallOpcodes.STORE_LETTER)
                    {
                        subopCode2 = Enum.GetName(typeof (LetterOpcodes), buf[3]);
                        AppendPacket(type, opCode, subopCode, subopCode2, packetContent);
                        return;
                    }
                    break;
                case (byte) KOOpcodes.WIZ_SKILLDATA:
                    subopCode = Enum.GetName(typeof (SkillBarOpcodes), buf[2]);

                    break;
                case (byte) KOOpcodes.WIZ_RENTAL:
                    subopCode = Enum.GetName(typeof (RentalOpcodes), buf[2]);

                    if (buf[2] == (int) RentalOpcodes.RENTAL_PVP)
                    {
                        subopCode2 = Enum.GetName(typeof (RentalPvPOpcodes), buf[3]);
                        AppendPacket(type, opCode, subopCode, subopCode2, packetContent);
                        return;
                    }

                    break;
                case (byte) KOOpcodes.WIZ_PARTY_BBS:
                    subopCode = Enum.GetName(typeof (PartyBBSOpcodes), buf[2]);

                    break;

                case (byte) KOOpcodes.WIZ_WAREHOUSE:
                    subopCode = Enum.GetName(typeof (WarehouseOpcodes), buf[2]);

                    break;
                case (byte) KOOpcodes.WIZ_PARTY:
                    subopCode = Enum.GetName(typeof (PartyOpcodes), buf[2]);

                    break;
                case (byte) KOOpcodes.WIZ_WEATHER:
                    subopCode = Enum.GetName(typeof (WeatherOpcodes), buf[2]);

                    break;

                case (byte) KOOpcodes.WIZ_ZONE_CHANGE:
                    subopCode = Enum.GetName(typeof (ZoneChangeOpcodes), buf[2]);

                    break;

                case (byte) KOOpcodes.WIZ_MARKET_BBS:
                    subopCode = Enum.GetName(typeof (MarketBBSOpcodes), buf[2]);

                    break;
                default:
                    AppendPacket(type, opCode, packetContent);
                    return;

            }
            AppendPacket(type, opCode, subopCode, packetContent);

            #endregion

        }

        public void PacketOperation(byte[] buf)
        {
            if ((buf[0] == 1 && !chbSend.Checked) || (buf[0] == 0 && !chbReceive.Checked) || buf.Length < 2)
                return;
            /* Check for filtered opcodes */
            if (StaticReference.FilteredOpcodes.Contains(buf[1]))
                return;

            lock (_packetQueue)
            {
                _packetQueue.Enqueue(buf);
                _packetMre.Set();
            }

        }

        private void SeperateContinuousPacket(byte[] buf)
        {
            // 01 44 0700 0400 11 11 11 11 0300 11 11 11 11
            var iWholeSize = BitConverter.ToInt16(buf, 2);
            int processed = 0;
            int startindex = 4;
            while (processed < iWholeSize)
            {
                short currentPktsize = BitConverter.ToInt16(buf, processed + startindex);
                var pkt = new byte[currentPktsize + 1];
                pkt[0] = buf[0];
                Array.Copy(buf, processed + startindex + 2, pkt, 1, currentPktsize);
                processed += currentPktsize + 2;
                PacketOperation(pkt);

            }
       
        }

        private void DecompressPacket(byte[] buf)
        {
            var outLength = BitConverter.ToInt32(buf, 2);
            var inLength = BitConverter.ToInt32(buf, 6);
            var crc32 = BitConverter.ToInt32(buf, 10);
            byte[] compressed = buf.Skip(14).ToArray();
            var decompressed = new byte[inLength];
            LZF.Decompress(compressed, outLength, decompressed, inLength);


            Trace.TraceWarning("[{0}] - Compressed packet received. (in : {1} out : {2} crc : {3})", "asd", inLength,
                outLength, crc32.ToString("x"));
            var result = new byte[inLength + 1];
            result[0] = buf[0];
            Array.Copy(decompressed, 0, result, 1, decompressed.Length);

            PacketOperation(result);

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OnDetachRequest?.Invoke();
            OnDeinject();
        }


        private void mainFrm_Load(object sender, EventArgs e)
        {

        }





        private void btnFilterSettings_Click(object sender, EventArgs e)
        {
            using (var fs = new frmFilterSettings())
            {
                fs.ShowDialog();
            }

        }

        private void tsTopMost_Toggled(object sender, EventArgs e)
        {
         
        }

        private void btnFollow_Click(object sender, EventArgs e)
        {
            fctb.GoEnd();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            fctb.Clear();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            nbMain.Visible = false;
            XtraMessageBox.Show(this, "To show navigation bar again, press F11.");
        }

        private void mainFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
         //   if (e.KeyChar == Keys.F11)
                
        }

        private void mainFrm_KeyDown(object sender, KeyEventArgs e)
        {
            /* Hotkeys */
           
            if(e.KeyCode == Keys.F9)
                chbSend.Checked = !chbSend.Checked;
            if (e.KeyCode == Keys.F10)
                chbReceive.Checked = !chbReceive.Checked;
            if (e.KeyCode == Keys.F11)
                nbMain.Visible = !nbMain.Visible;
            if(e.Shift && e.KeyCode == Keys.Delete)
                fctb.Clear();
            if (e.KeyCode == Keys.F12)
                fctb.ShowScrollBars = !fctb.ShowScrollBars;
            if(e.KeyCode == Keys.F8)
            {
                if(_attachedProcess == null)
                {
                    XtraMessageBox.Show(this, "Not attached to any process yet!");
                    return;
                }
                if(FormBorderStyle == FormBorderStyle.None)
                {
                    this.FormBorderStyle = FormBorderStyle.Fixed3D;
                }
                else
                {   /* Lets fuck this shit up */
                    IntPtr ptr = _attachedProcess.MainWindowHandle;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.nbMain.Visible = false;
                    Rect kolRekt = new Rect();
                    GetWindowRect(ptr, ref kolRekt);
                    Location = new Point(kolRekt.Right, kolRekt.Top);
                    fctb.ShowScrollBars = false;
                }
              
            }
            if (e.KeyCode == Keys.F7)
            {/* reset all */
                nbMain.Visible = true;
                fctb.ShowScrollBars = true;
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
            }
        }
        

        private void gcPacketLog_MouseClick(object sender, MouseEventArgs e)
        {
         
        }


        private void btnChangeFont_Click(object sender, EventArgs e)
        {
            FontDialog.FontMustExist = true;
            
            DialogResult fdr = FontDialog.ShowDialog(this);
            if (fdr == DialogResult.OK)
            {
                fctb.Font = FontDialog.Font;
            }
        }

 

        private void chbReceive_CheckedChanged(object sender, EventArgs e)
        {
            chbReceive.Text = chbReceive.Checked ? "Disable RECV log" : "Enable RECV log";
        }

        private void chbSend_CheckedChanged(object sender, EventArgs e)
        {
            chbSend.Text = chbSend.Checked ? "Disable SEND log" : "Enable SEND log";
        }

        private void chbAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            chbAlwaysOnTop.Text = chbAlwaysOnTop.Checked ? "Disable `Always on top`" : "Enable `Always on top`";
            TopMost = chbAlwaysOnTop.Checked;
            if (TopMost)
                BringToFront();
        }

        private void chbWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            chbWordWrap.Text = chbWordWrap.Checked ? "Disable `Word wrap`" : "Enable `Word wrap`";
            fctb.WordWrap = chbWordWrap.Checked;
        }
    }
}
