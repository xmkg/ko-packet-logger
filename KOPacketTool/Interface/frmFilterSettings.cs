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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KOPacketTool.Class;

namespace KOPacketTool.Interface
{
    public partial class frmFilterSettings : XtraForm
    {
        public frmFilterSettings()
        {
            InitializeComponent();
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        bool _checkboxActionSuspended = true;
        private void frmFilterSettings_Load(object sender, EventArgs e)
        {
            foreach (OPAuthCharSelection val in Enum.GetValues(typeof (OPAuthCharSelection)))
            {
                int z =  clbAuth.Items.Add(val, false);
                clbAuth.Items[z].Value = (byte) val;
                clbAuth.Items[z].Description = val.ToString();
            }

            foreach (OPPlayerInformation val in Enum.GetValues(typeof (OPPlayerInformation)))
            {
                int z = clbPlayerInfo.Items.Add(val, false);
                clbPlayerInfo.Items[z].Value = (byte)val;
                clbPlayerInfo.Items[z].Description = val.ToString();
            }

            foreach (OPMovementRegion val in Enum.GetValues(typeof(OPMovementRegion)))
            {
                int z = clbMovement.Items.Add(val, false);
                clbMovement.Items[z].Value = (byte)val;
                clbMovement.Items[z].Description = val.ToString();
            }

            foreach (OPPlayerState val in Enum.GetValues(typeof(OPPlayerState)))
            {
                int z = clbPlayerState.Items.Add(val, false);
                clbPlayerState.Items[z].Value = (byte)val;
                clbPlayerState.Items[z].Description = val.ToString();
            }

            foreach (OPGameState val in Enum.GetValues(typeof(OPGameState)))
            {
                int z = clbGameState.Items.Add(val, false);
                clbGameState.Items[z].Value = (byte)val;
                clbGameState.Items[z].Description = val.ToString();
            }

            foreach (OPProtocol val in Enum.GetValues(typeof(OPProtocol)))
            {
                int z = clbProto.Items.Add(val, false);
                clbProto.Items[z].Value = (byte)val;
                clbProto.Items[z].Description = val.ToString();
            }

            foreach (OPSystems val in Enum.GetValues(typeof(OPSystems)))
            {
                int z = clbSystems.Items.Add(val, false);
                clbSystems.Items[z].Value = (byte)val;
                clbSystems.Items[z].Description = val.ToString();
            }

            foreach (OPItemRelated val in Enum.GetValues(typeof(OPItemRelated)))
            {
                int z = clbItemRelated.Items.Add(val, false);
                clbItemRelated.Items[z].Value = (byte)val;
                clbItemRelated.Items[z].Description = val.ToString();
            }

            foreach (OPNPCInteraction val in Enum.GetValues(typeof(OPNPCInteraction)))
            {
                int z = clbNpcInteract.Items.Add(val, false);
                clbNpcInteract.Items[z].Value = (byte)val;
                clbNpcInteract.Items[z].Description = val.ToString();
            }

            foreach (byte b in StaticReference.FilteredOpcodes)
            {
                foreach (var ch in GetAll(this, typeof(CheckedListBoxControl)).Cast<CheckedListBoxControl>())
                {
                    for (int i = 0; i < ch.Items.Count; i++)
                    {
                        if(Convert.ToByte(ch.Items[i].Value) ==  b)
                            ch.Items[i].CheckState = CheckState.Checked;
                        
                    }
                }
                
            }
            _checkboxActionSuspended = false;

        }




        private void ChecklistBoxItemCheckChanged(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (_checkboxActionSuspended)
                return;
            CheckedListBoxControl clb = sender as CheckedListBoxControl;
            if (clb == null)
                return;
            if (e.State == CheckState.Checked)
                StaticReference.FilteredOpcodes.Add((byte) clb.Items[e.Index].Value);
            else
                StaticReference.FilteredOpcodes.Remove((byte) clb.Items[e.Index].Value);

            foreach (byte b in StaticReference.FilteredOpcodes)
            {
                Trace.WriteLine("Filtered OP : " + b.ToString("X"));
            }
            
        }

        private void tsAuthChar_Toggled(object sender, EventArgs e)
        {
            for (int i = 0; i < clbAuth.Items.Count; i++)
            {
                clbAuth.Items[i].CheckState = tsAuthChar.IsOn ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        private void tsMovementRegion_Toggled(object sender, EventArgs e)
        {
            for (int i = 0; i < clbMovement.Items.Count; i++)
            {
                clbMovement.Items[i].CheckState = tsMovementRegion.IsOn ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        private void tsPlayerState_Toggled(object sender, EventArgs e)
        {
            for (int i = 0; i < clbPlayerState.Items.Count; i++)
            {
                clbPlayerState.Items[i].CheckState = tsPlayerState.IsOn ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        private void tsGameState_Toggled(object sender, EventArgs e)
        {
            for (int i = 0; i < clbGameState.Items.Count; i++)
            {
                clbGameState.Items[i].CheckState = tsGameState.IsOn ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        private void tsPlayerInfo_Toggled(object sender, EventArgs e)
        {
            for (int i = 0; i < clbPlayerInfo.Items.Count; i++)
            {
                clbPlayerInfo.Items[i].CheckState = tsPlayerInfo.IsOn ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        private void tsNpcInteraction_Toggled(object sender, EventArgs e)
        {
            for (int i = 0; i < clbNpcInteract.Items.Count; i++)
            {
                clbNpcInteract.Items[i].CheckState = tsNpcInteraction.IsOn ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        private void tsProtocol_Toggled(object sender, EventArgs e)
        {
            for (int i = 0; i < clbProto.Items.Count; i++)
            {
                clbProto.Items[i].CheckState = tsProtocol.IsOn ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        private void tsSystems_Toggled(object sender, EventArgs e)
        {
            for (int i = 0; i < clbSystems.Items.Count; i++)
            {
                clbSystems.Items[i].CheckState = tsSystems.IsOn ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        private void tsItemRelated_Toggled(object sender, EventArgs e)
        {
            for (int i = 0; i < clbItemRelated.Items.Count; i++)
            {
                clbItemRelated.Items[i].CheckState = tsItemRelated.IsOn ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StaticReference.SaveFilterSettings();
            XtraMessageBox.Show(this, "Saved.");
        }
    }
}