/**
 * ______________________________________________________
 * This file is part of ko-packet-logger project.
 * 
 * @author       Mustafa Kemal Gılor <mustafagilor@gmail.com> (2015)
 * .
 * SPDX-License-Identifier:	MIT
 * ______________________________________________________
 */

using KOPacketTool.Class;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace KOPacketTool.Interface
{
    public partial class frmSelectPointerList : DevExpress.XtraEditors.XtraForm
    {

        Dictionary<string, FileInfo> pointerFileInfoDict = new Dictionary<string, FileInfo>();
        public frmSelectPointerList()
        {
            InitializeComponent();
        }

        private void frmSelectPointerList_Load(object sender, EventArgs e)
        {
            lbPointerList.Items.Clear();
            foreach(string strfn in Directory.EnumerateFiles("./"))
            {
                FileInfo fi = new FileInfo(strfn);
                if (fi.Extension == ".ptr")
                {
                    pointerFileInfoDict.Add(fi.Name, fi);
                    lbPointerList.Items.Add(fi.Name);
                }
            }

            if (pointerFileInfoDict.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Pointer list is empty!\nPlease place pointer information files into packet logger folder.");
                Environment.Exit(0);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lbPointerList.SelectedIndex == -1)
                return;
            FileInfo fi = pointerFileInfoDict[lbPointerList.Items[lbPointerList.SelectedIndex].ToString()];

            StaticReference.DatapackPtr = Int64.Parse(File.ReadAllLines(fi.FullName)[0].Replace("0x", ""), NumberStyles.HexNumber);
            if (File.ReadAllLines(fi.FullName).Length > 1)
                StaticReference.StaticBufferPtr = Int64.Parse(File.ReadAllLines(fi.FullName)[1].Replace("0x", ""), NumberStyles.HexNumber);
            this.Close();
        }
    }
}