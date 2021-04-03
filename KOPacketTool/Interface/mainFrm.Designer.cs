using DevExpress.XtraEditors;

namespace KOPacketTool.Interface
{
    partial class mainFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrm));
            this.nbMain = new DevExpress.XtraNavBar.NavBarControl();
            this.ngAttach = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.btnAttach = new DevExpress.XtraEditors.SimpleButton();
            this.btnDetach = new DevExpress.XtraEditors.SimpleButton();
            this.navBarGroupControlContainer3 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.hyperlinkLabelControl1 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.hlBlogLink = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.btnChangeFont = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnFollow = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnHideNavBar = new DevExpress.XtraEditors.SimpleButton();
            this.btnFilterSettings = new DevExpress.XtraEditors.SimpleButton();
            this.chbWordWrap = new DevExpress.XtraEditors.CheckButton();
            this.chbAlwaysOnTop = new DevExpress.XtraEditors.CheckButton();
            this.chbSend = new DevExpress.XtraEditors.CheckButton();
            this.chbReceive = new DevExpress.XtraEditors.CheckButton();
            this.ngOptions = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.gcPacketLog = new DevExpress.XtraEditors.GroupControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FontDialog = new System.Windows.Forms.FontDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nbMain)).BeginInit();
            this.nbMain.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            this.navBarGroupControlContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.navBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPacketLog)).BeginInit();
            this.SuspendLayout();
            // 
            // nbMain
            // 
            this.nbMain.ActiveGroup = this.ngAttach;
            this.nbMain.Controls.Add(this.navBarGroupControlContainer1);
            this.nbMain.Controls.Add(this.navBarGroupControlContainer3);
            this.nbMain.Controls.Add(this.navBarGroupControlContainer2);
            this.nbMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.nbMain.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.ngAttach,
            this.ngOptions,
            this.navBarGroup2,
            this.navBarGroup1});
            this.nbMain.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1,
            this.navBarItem2,
            this.navBarItem3,
            this.navBarItem4,
            this.navBarItem5});
            this.nbMain.Location = new System.Drawing.Point(0, 0);
            this.nbMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nbMain.Name = "nbMain";
            this.nbMain.OptionsNavPane.ExpandedWidth = 245;
            this.nbMain.Size = new System.Drawing.Size(245, 703);
            this.nbMain.TabIndex = 0;
            this.nbMain.Text = "navBarControl1";
            // 
            // ngAttach
            // 
            this.ngAttach.Caption = "Attach & Detach";
            this.ngAttach.ControlContainer = this.navBarGroupControlContainer1;
            this.ngAttach.Expanded = true;
            this.ngAttach.GroupClientHeight = 55;
            this.ngAttach.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.ngAttach.Name = "ngAttach";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer1.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer1.Controls.Add(this.btnAttach);
            this.navBarGroupControlContainer1.Controls.Add(this.btnDetach);
            this.navBarGroupControlContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(235, 46);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // btnAttach
            // 
            this.btnAttach.AutoWidthInLayoutControl = true;
            this.btnAttach.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAttach.Image = global::KOPacketTool.Properties.Resources._1440522056_plug_connect;
            this.btnAttach.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightTop;
            this.btnAttach.Location = new System.Drawing.Point(0, 0);
            this.btnAttach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(235, 23);
            this.btnAttach.TabIndex = 5;
            this.btnAttach.Text = "Attach to process";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // btnDetach
            // 
            this.btnDetach.Appearance.Options.UseTextOptions = true;
            this.btnDetach.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnDetach.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnDetach.AutoWidthInLayoutControl = true;
            this.btnDetach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDetach.Enabled = false;
            this.btnDetach.Image = global::KOPacketTool.Properties.Resources._1440521982_plug_disconnect_slash;
            this.btnDetach.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightTop;
            this.btnDetach.Location = new System.Drawing.Point(0, 23);
            this.btnDetach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(235, 23);
            this.btnDetach.TabIndex = 2;
            this.btnDetach.Text = "Detach from process";
            this.btnDetach.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // navBarGroupControlContainer3
            // 
            this.navBarGroupControlContainer3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer3.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer3.Controls.Add(this.hyperlinkLabelControl1);
            this.navBarGroupControlContainer3.Controls.Add(this.hlBlogLink);
            this.navBarGroupControlContainer3.Controls.Add(this.pictureBox1);
            this.navBarGroupControlContainer3.Controls.Add(this.labelControl12);
            this.navBarGroupControlContainer3.Controls.Add(this.labelControl10);
            this.navBarGroupControlContainer3.Name = "navBarGroupControlContainer3";
            this.navBarGroupControlContainer3.Size = new System.Drawing.Size(235, 136);
            this.navBarGroupControlContainer3.TabIndex = 2;
            // 
            // hyperlinkLabelControl1
            // 
            this.hyperlinkLabelControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hyperlinkLabelControl1.Location = new System.Drawing.Point(62, 106);
            this.hyperlinkLabelControl1.Name = "hyperlinkLabelControl1";
            this.hyperlinkLabelControl1.Size = new System.Drawing.Size(115, 16);
            this.hyperlinkLabelControl1.TabIndex = 9;
            this.hyperlinkLabelControl1.Text = "<href=https://www.kodevelopers.com/>KODevelopers, 2017</href>";
            // 
            // hlBlogLink
            // 
            this.hlBlogLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlBlogLink.Location = new System.Drawing.Point(77, 59);
            this.hlBlogLink.Name = "hlBlogLink";
            this.hlBlogLink.Size = new System.Drawing.Size(152, 16);
            this.hlBlogLink.TabIndex = 8;
            this.hlBlogLink.Text = "Developed by <href=http://insomniacoder.blogspot.com>PENTAGRAM</href>";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::KOPacketTool.Properties.Resources.if_mail_send_receive_1187841;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::KOPacketTool.Properties.Resources.if_mail_send_receive_118784;
            this.pictureBox1.InitialImage = global::KOPacketTool.Properties.Resources.if_mail_send_receive_118784;
            this.pictureBox1.Location = new System.Drawing.Point(8, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(77, 81);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(48, 16);
            this.labelControl12.TabIndex = 6;
            this.labelControl12.Text = "(c) 2015";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(77, 37);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(144, 16);
            this.labelControl10.TabIndex = 5;
            this.labelControl10.Text = "Knight OnLine packet tool";
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer2.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer2.Controls.Add(this.btnChangeFont);
            this.navBarGroupControlContainer2.Controls.Add(this.btnClear);
            this.navBarGroupControlContainer2.Controls.Add(this.btnFollow);
            this.navBarGroupControlContainer2.Controls.Add(this.btnSave);
            this.navBarGroupControlContainer2.Controls.Add(this.btnHideNavBar);
            this.navBarGroupControlContainer2.Controls.Add(this.btnFilterSettings);
            this.navBarGroupControlContainer2.Controls.Add(this.chbWordWrap);
            this.navBarGroupControlContainer2.Controls.Add(this.chbAlwaysOnTop);
            this.navBarGroupControlContainer2.Controls.Add(this.chbSend);
            this.navBarGroupControlContainer2.Controls.Add(this.chbReceive);
            this.navBarGroupControlContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(235, 230);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // btnChangeFont
            // 
            this.btnChangeFont.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChangeFont.Image = global::KOPacketTool.Properties.Resources.if_font_x_generic_118886;
            this.btnChangeFont.Location = new System.Drawing.Point(0, 202);
            this.btnChangeFont.Name = "btnChangeFont";
            this.btnChangeFont.Size = new System.Drawing.Size(235, 23);
            this.btnChangeFont.TabIndex = 3;
            this.btnChangeFont.Text = "Change Font";
            this.btnChangeFont.Click += new System.EventHandler(this.btnChangeFont_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClear.Image = global::KOPacketTool.Properties.Resources.if_edit_clear_118917;
            this.btnClear.Location = new System.Drawing.Point(0, 180);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(235, 22);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear log";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFollow
            // 
            this.btnFollow.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFollow.Image = global::KOPacketTool.Properties.Resources.if_Spread_446297;
            this.btnFollow.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnFollow.Location = new System.Drawing.Point(0, 158);
            this.btnFollow.Name = "btnFollow";
            this.btnFollow.Size = new System.Drawing.Size(235, 22);
            this.btnFollow.TabIndex = 8;
            this.btnFollow.Text = "Scroll log to bottom";
            this.btnFollow.Click += new System.EventHandler(this.btnFollow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSave.Image = global::KOPacketTool.Properties.Resources.if_save_173091;
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(0, 136);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(235, 22);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save log to file";
            // 
            // btnHideNavBar
            // 
            this.btnHideNavBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHideNavBar.Image = global::KOPacketTool.Properties.Resources.if_minus_1282962;
            this.btnHideNavBar.Location = new System.Drawing.Point(0, 114);
            this.btnHideNavBar.Name = "btnHideNavBar";
            this.btnHideNavBar.Size = new System.Drawing.Size(235, 22);
            this.btnHideNavBar.TabIndex = 0;
            this.btnHideNavBar.Text = "Hide navigation bar";
            this.btnHideNavBar.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnFilterSettings
            // 
            this.btnFilterSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFilterSettings.Image = global::KOPacketTool.Properties.Resources.if_filter_173013;
            this.btnFilterSettings.Location = new System.Drawing.Point(0, 92);
            this.btnFilterSettings.Name = "btnFilterSettings";
            this.btnFilterSettings.Size = new System.Drawing.Size(235, 22);
            this.btnFilterSettings.TabIndex = 2;
            this.btnFilterSettings.Text = "Filter Settings";
            this.btnFilterSettings.Click += new System.EventHandler(this.btnFilterSettings_Click);
            // 
            // chbWordWrap
            // 
            this.chbWordWrap.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbWordWrap.Image = global::KOPacketTool.Properties.Resources.if_bag_icons_25_1075421;
            this.chbWordWrap.Location = new System.Drawing.Point(0, 69);
            this.chbWordWrap.Name = "chbWordWrap";
            this.chbWordWrap.Size = new System.Drawing.Size(235, 23);
            this.chbWordWrap.TabIndex = 12;
            this.chbWordWrap.Text = "Enable `Word Wrap`";
            this.chbWordWrap.CheckedChanged += new System.EventHandler(this.chbWordWrap_CheckedChanged);
            // 
            // chbAlwaysOnTop
            // 
            this.chbAlwaysOnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbAlwaysOnTop.Image = global::KOPacketTool.Properties.Resources.if_go_top_118775;
            this.chbAlwaysOnTop.Location = new System.Drawing.Point(0, 46);
            this.chbAlwaysOnTop.Name = "chbAlwaysOnTop";
            this.chbAlwaysOnTop.Size = new System.Drawing.Size(235, 23);
            this.chbAlwaysOnTop.TabIndex = 11;
            this.chbAlwaysOnTop.Text = "Enable `Always on top`";
            this.chbAlwaysOnTop.CheckedChanged += new System.EventHandler(this.chbAlwaysOnTop_CheckedChanged);
            // 
            // chbSend
            // 
            this.chbSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbSend.Image = global::KOPacketTool.Properties.Resources.if_box_out_299067;
            this.chbSend.Location = new System.Drawing.Point(0, 23);
            this.chbSend.Name = "chbSend";
            this.chbSend.Size = new System.Drawing.Size(235, 23);
            this.chbSend.TabIndex = 10;
            this.chbSend.Text = "Disable SEND log";
            this.chbSend.CheckedChanged += new System.EventHandler(this.chbSend_CheckedChanged);
            // 
            // chbReceive
            // 
            this.chbReceive.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbReceive.Image = global::KOPacketTool.Properties.Resources.if_box_in_299102;
            this.chbReceive.Location = new System.Drawing.Point(0, 0);
            this.chbReceive.Name = "chbReceive";
            this.chbReceive.Size = new System.Drawing.Size(235, 23);
            this.chbReceive.TabIndex = 9;
            this.chbReceive.Text = "Disable RECV log";
            this.chbReceive.CheckedChanged += new System.EventHandler(this.chbReceive_CheckedChanged);
            // 
            // ngOptions
            // 
            this.ngOptions.Caption = "Options";
            this.ngOptions.ControlContainer = this.navBarGroupControlContainer2;
            this.ngOptions.Expanded = true;
            this.ngOptions.GroupClientHeight = 239;
            this.ngOptions.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.ngOptions.Name = "ngOptions";
            this.ngOptions.Visible = false;
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Hotkeys";
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem4)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "F9                  Toggle send logging";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "F10                Toggle receive logging";
            this.navBarItem2.Name = "navBarItem2";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "F11                Show / hide navbar";
            this.navBarItem3.Name = "navBarItem3";
            // 
            // navBarItem4
            // 
            this.navBarItem4.Caption = "Shift + Del      Clear log screen";
            this.navBarItem4.Name = "navBarItem4";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "About";
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer3;
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupClientHeight = 145;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "navBarItem5";
            this.navBarItem5.Name = "navBarItem5";
            // 
            // gcPacketLog
            // 
            this.gcPacketLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPacketLog.Location = new System.Drawing.Point(245, 0);
            this.gcPacketLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcPacketLog.Name = "gcPacketLog";
            this.gcPacketLog.Size = new System.Drawing.Size(687, 703);
            this.gcPacketLog.TabIndex = 2;
            this.gcPacketLog.Text = "Packet log";
            this.gcPacketLog.Visible = false;
            this.gcPacketLog.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gcPacketLog_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(932, 703);
            this.Controls.Add(this.gcPacketLog);
            this.Controls.Add(this.nbMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "mainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message Watcher | 2017, PENTAGRAM, www.kodevelopers.com";
            this.Load += new System.EventHandler(this.mainFrm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainFrm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mainFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.nbMain)).EndInit();
            this.nbMain.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            this.navBarGroupControlContainer3.ResumeLayout(false);
            this.navBarGroupControlContainer3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.navBarGroupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPacketLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl nbMain;
        private DevExpress.XtraNavBar.NavBarGroup ngAttach;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private SimpleButton btnDetach;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private DevExpress.XtraNavBar.NavBarGroup ngOptions;
        private SimpleButton btnAttach;
        private GroupControl gcPacketLog;
        private SimpleButton btnFilterSettings;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer3;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private HyperlinkLabelControl hlBlogLink;
        private System.Windows.Forms.PictureBox pictureBox1;
        private LabelControl labelControl12;
        private LabelControl labelControl10;
        private SimpleButton btnSave;
        private SimpleButton btnClear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private SimpleButton btnFollow;
        private SimpleButton btnHideNavBar;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private SimpleButton btnChangeFont;
        private System.Windows.Forms.FontDialog FontDialog;
        private HyperlinkLabelControl hyperlinkLabelControl1;
        private CheckButton chbWordWrap;
        private CheckButton chbAlwaysOnTop;
        private CheckButton chbSend;
        private CheckButton chbReceive;
    }
}

