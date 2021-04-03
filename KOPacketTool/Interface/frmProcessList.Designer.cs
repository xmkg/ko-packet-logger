namespace KOPacketTool.Interface
{
    partial class frmProcessList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessList));
            this.gcProcessList = new DevExpress.XtraGrid.GridControl();
            this.gvMainView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAttachSelected = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.rgAttachMethod = new DevExpress.XtraEditors.RadioGroup();
            this.teProcessName = new DevExpress.XtraEditors.TextEdit();
            this.teWindowTitle = new DevExpress.XtraEditors.TextEdit();
            this.seProcessID = new DevExpress.XtraEditors.SpinEdit();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcProcessList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMainView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgAttachMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teProcessName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teWindowTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seProcessID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcProcessList
            // 
            this.gcProcessList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gcProcessList.Location = new System.Drawing.Point(0, 134);
            this.gcProcessList.MainView = this.gvMainView;
            this.gcProcessList.Name = "gcProcessList";
            this.gcProcessList.Size = new System.Drawing.Size(757, 200);
            this.gcProcessList.TabIndex = 0;
            this.gcProcessList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMainView});
            // 
            // gvMainView
            // 
            this.gvMainView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvMainView.GridControl = this.gcProcessList;
            this.gvMainView.Name = "gvMainView";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "PID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Window Title";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Status";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Description";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // btnAttachSelected
            // 
            this.btnAttachSelected.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAttachSelected.Location = new System.Drawing.Point(2, 26);
            this.btnAttachSelected.Name = "btnAttachSelected";
            this.btnAttachSelected.Size = new System.Drawing.Size(250, 29);
            this.btnAttachSelected.TabIndex = 2;
            this.btnAttachSelected.Text = "Attach selected";
            this.btnAttachSelected.Click += new System.EventHandler(this.btnAttachSelected_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Location = new System.Drawing.Point(502, 26);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(250, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.Location = new System.Drawing.Point(252, 26);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(250, 29);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            // 
            // rgAttachMethod
            // 
            this.rgAttachMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.rgAttachMethod.EditValue = "PID";
            this.rgAttachMethod.Location = new System.Drawing.Point(2, 26);
            this.rgAttachMethod.Name = "rgAttachMethod";
            this.rgAttachMethod.Properties.Appearance.Options.UseTextOptions = true;
            this.rgAttachMethod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rgAttachMethod.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.rgAttachMethod.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("PID", "Process ID"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Window Title"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Process Name")});
            this.rgAttachMethod.Size = new System.Drawing.Size(753, 37);
            this.rgAttachMethod.TabIndex = 5;
            this.rgAttachMethod.SelectedIndexChanged += new System.EventHandler(this.rgAttachMethod_SelectedIndexChanged);
            // 
            // teProcessName
            // 
            this.teProcessName.EditValue = "KnightOnLine.exe";
            this.teProcessName.Enabled = false;
            this.teProcessName.Location = new System.Drawing.Point(502, 65);
            this.teProcessName.Name = "teProcessName";
            this.teProcessName.Properties.Appearance.Options.UseTextOptions = true;
            this.teProcessName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.teProcessName.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.teProcessName.Size = new System.Drawing.Size(250, 22);
            this.teProcessName.TabIndex = 8;
            // 
            // teWindowTitle
            // 
            this.teWindowTitle.EditValue = "Knight OnLine Client";
            this.teWindowTitle.Enabled = false;
            this.teWindowTitle.Location = new System.Drawing.Point(252, 65);
            this.teWindowTitle.Name = "teWindowTitle";
            this.teWindowTitle.Properties.Appearance.Options.UseTextOptions = true;
            this.teWindowTitle.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.teWindowTitle.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.teWindowTitle.Size = new System.Drawing.Size(244, 22);
            this.teWindowTitle.TabIndex = 6;
            // 
            // seProcessID
            // 
            this.seProcessID.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seProcessID.Location = new System.Drawing.Point(5, 61);
            this.seProcessID.Name = "seProcessID";
            this.seProcessID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seProcessID.Size = new System.Drawing.Size(247, 30);
            this.seProcessID.TabIndex = 7;
            // 
            // btnFind
            // 
            this.btnFind.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFind.Location = new System.Drawing.Point(2, 93);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(753, 33);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnCancel);
            this.groupControl1.Controls.Add(this.btnRefresh);
            this.groupControl1.Controls.Add(this.btnAttachSelected);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 334);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(757, 57);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "Operation";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnFind);
            this.groupControl2.Controls.Add(this.teProcessName);
            this.groupControl2.Controls.Add(this.rgAttachMethod);
            this.groupControl2.Controls.Add(this.teWindowTitle);
            this.groupControl2.Controls.Add(this.seProcessID);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(757, 128);
            this.groupControl2.TabIndex = 11;
            this.groupControl2.Text = "Search Options";
            // 
            // frmProcessList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 391);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.gcProcessList);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmProcessList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Process List";
            this.Load += new System.EventHandler(this.frmProcessList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcProcessList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMainView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgAttachMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teProcessName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teWindowTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seProcessID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcProcessList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMainView;
        private DevExpress.XtraEditors.SimpleButton btnAttachSelected;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.RadioGroup rgAttachMethod;
        private DevExpress.XtraEditors.TextEdit teProcessName;
        private DevExpress.XtraEditors.TextEdit teWindowTitle;
        private DevExpress.XtraEditors.SpinEdit seProcessID;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}