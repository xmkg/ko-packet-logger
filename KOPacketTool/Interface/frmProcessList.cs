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
using System.Data;
using System.Diagnostics;
using DevExpress.XtraEditors;

namespace KOPacketTool.Interface
{
    public partial class frmProcessList : XtraForm
    {

        public delegate void AttachResultingProcessID(int pid);

        public event AttachResultingProcessID OnAttachProcess;
        private readonly DataTable _dtProcessList = new DataTable("dtProcessList");
        public frmProcessList()
        {
            InitializeComponent();
            _dtProcessList.Columns.Add(new DataColumn("PID", typeof(int)));
            _dtProcessList.Columns.Add(new DataColumn("Name", typeof(string)));
            _dtProcessList.Columns.Add(new DataColumn("Window Title", typeof(string)));
            _dtProcessList.Columns.Add(new DataColumn("Status", typeof(string)));
            _dtProcessList.Columns.Add(new DataColumn("Description", typeof(string)));
            RefreshProcessList();
            rgAttachMethod.SelectedIndex = 1;}

        private void SearchMatchingProcesses()
        {
            _dtProcessList.Rows.Clear();
            switch (rgAttachMethod.SelectedIndex)
            {
                case 0:
                {
                    foreach (var p in Process.GetProcesses())
                    {
                        if (p.Id != seProcessID.Value)
                            continue;
                            var dr = _dtProcessList.NewRow();
                            dr["PID"] = p.Id;
                            dr["Name"] = p.ProcessName + ".exe";
                            dr["Window Title"] = p.MainWindowTitle;
                            dr["Status"] = p.Responding ? "Responding" : "Not Responding";
                            dr["Description"] = "-";
                            _dtProcessList.Rows.Add(dr);
                        }
                    }
                    break;
                case 1:
                    foreach (var p in Process.GetProcesses())
                    {
                        if (!p.MainWindowTitle.ToLowerInvariant().Contains(teWindowTitle.Text.ToLowerInvariant()))
                            continue;
                        var dr = _dtProcessList.NewRow();
                        dr["PID"] = p.Id;
                        dr["Name"] = p.ProcessName + ".exe";
                        dr["Window Title"] = p.MainWindowTitle;
                        dr["Status"] = p.Responding ? "Responding" : "Not Responding";
                        dr["Description"] = "-";
                        _dtProcessList.Rows.Add(dr);
                    }
            
            break;
                case 2:
                    foreach (var p in Process.GetProcessesByName(teProcessName.Text.Replace(".exe","")))
                    {
                        var dr = _dtProcessList.NewRow();
                        dr["PID"] = p.Id;
                        dr["Name"] = p.ProcessName + ".exe";
                        dr["Window Title"] = p.MainWindowTitle;
                        dr["Status"] = p.Responding ? "Responding" : "Not Responding";
                        dr["Description"] = "-";
                        _dtProcessList.Rows.Add(dr);
                    }
                    break;
            }
           
        }

        private void rgAttachMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rgAttachMethod.SelectedIndex)
            {
                case 0:
                    teProcessName.Enabled = false;
                    teWindowTitle.Enabled = false;
                    seProcessID.Enabled = true;
                    break;
                case 1:
                    teProcessName.Enabled = false;
                    teWindowTitle.Enabled = true;
                    seProcessID.Enabled = false;
                    break;
                case 2:
                    teProcessName.Enabled = true;
                    teWindowTitle.Enabled = false;
                    seProcessID.Enabled = false;
                    break;
                default:
                    return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        void RefreshProcessList()
        {
            gvMainView.Columns.Clear();
            gcProcessList.BeginUpdate();

        
          
            gcProcessList.DataSource = _dtProcessList;
            gcProcessList.MainView = gvMainView;

            gvMainView.RefreshData();
            gvMainView.OptionsBehavior.Editable = false;
            gvMainView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvMainView.OptionsBehavior.ReadOnly = true;
            gcProcessList.Refresh();
            gcProcessList.EndUpdate();
        }

        private void frmProcessList_Load(object sender, EventArgs e)
        {
        
         //   gvMainView.AddNewRow();
          //  gvMainView.getrow
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SearchMatchingProcesses();
        }

        private void btnAttachSelected_Click(object sender, EventArgs e)
        {
            int[] rows = gvMainView.GetSelectedRows();
            if (rows.Length == 0)
            {
                return;
            }

            using(frmSelectPointerList ptrList = new frmSelectPointerList())
            {
                ptrList.ShowDialog()
                    ;

            }

            var firstSelectedRow = gvMainView.GetDataRow(rows[0]);
            OnAttachProcess?.Invoke(Convert.ToInt32(firstSelectedRow["PID"]));
            Close();
        }
    }
}