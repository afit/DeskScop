using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Configuration;

using LothianProductions.DeskScop.SpamCop;
using LothianProductions.Util;

namespace LothianProductions.DeskScop.Forms {

	/// <summary>
	/// Summary description for frmMain.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form, UiConfiguration {
		private System.Windows.Forms.TabPage tabConfiguration;
		private System.Windows.Forms.TabPage tabAction;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.TextBox txtUri;
		private System.Windows.Forms.DataGrid dgdMessages;
		private System.Windows.Forms.TabControl tabBackground;
		private System.Windows.Forms.ProgressBar pgbMain;
		private System.Windows.Forms.GroupBox grpActions;
		private System.Windows.Forms.ContextMenu cxmGrid;
		private System.Windows.Forms.Timer tmrProgress;
		private System.Windows.Forms.RadioButton rdoActionQuick;
		private System.Windows.Forms.RadioButton rdoActionDont;
		private System.Windows.Forms.RadioButton rdoActionForwardWhitelist;
		private System.Windows.Forms.RadioButton rdoActionForward;
		private System.Windows.Forms.RadioButton rdoActionQueueTrash;
		private System.Windows.Forms.RadioButton rdoActionQueue;
		private System.Windows.Forms.RadioButton rdoActionDelete;
		private System.Windows.Forms.Button btnSetAll;
		private System.Windows.Forms.MenuItem mnuActionDont;
		private System.Windows.Forms.MenuItem mnuActionQuick;
		private System.Windows.Forms.MenuItem mnuActionForward;
		private System.Windows.Forms.MenuItem mnuActionForwardWhitelist;
		private System.Windows.Forms.MenuItem mnuActionQueueTrash;
		private System.Windows.Forms.MenuItem mnuActionQueue;
		private System.Windows.Forms.MenuItem mnuActionDelete;
		private System.Windows.Forms.LinkLabel lnkStrap;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.StatusBar stsMain;
		private System.Windows.Forms.Button btnNext;
		private System.ComponentModel.IContainer components;

		public MainForm() {
			InitializeComponent();
			this.Text = Application.ProductName + " " + Application.ProductVersion;

			lnkStrap.Links.Add( 6, 20, "www.lothianproductions.co.uk" );
			lnkStrap.Links.Add( 49, 14, "www.lothianproductions.co.uk/deskscop" );

			txtUri.Text = ConfigurationSettings.AppSettings[ "defaultUri" ];
			txtUsername.Text = ConfigurationSettings.AppSettings[ "defaultUsername" ];
			txtPassword.Text = ConfigurationSettings.AppSettings[ "defaultPassword" ];

			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = "HeldMessages";
			tableStyle.RowHeadersVisible = false;

			DataGridTextBoxColumn columnStyle = new DataGridRowColourColumn();
			columnStyle.MappingName = "Action";
			columnStyle.Width = Convert.ToInt16( ConfigurationSettings.AppSettings[ "columnActionWidth" ] );
			tableStyle.GridColumnStyles.Add( columnStyle );

			columnStyle = new DataGridRowColourColumn();
			columnStyle.MappingName = "From";
			columnStyle.HeaderText = "From";
			columnStyle.Width = Convert.ToInt16( ConfigurationSettings.AppSettings[ "columnFromWidth" ] );
			tableStyle.GridColumnStyles.Add( columnStyle );

			columnStyle = new DataGridRowColourColumn();
			columnStyle.MappingName = "Subject";
			columnStyle.HeaderText = "Subject";
			columnStyle.Width = Convert.ToInt16( ConfigurationSettings.AppSettings[ "columnSubjectWidth" ] );
			tableStyle.GridColumnStyles.Add( columnStyle );

			columnStyle = new DataGridRowColourColumn();
			columnStyle.MappingName = "Sent";
			columnStyle.HeaderText = "Sent";
			columnStyle.Format = "f";
			columnStyle.Width = Convert.ToInt16( ConfigurationSettings.AppSettings[ "columnSentWidth" ] );
			tableStyle.GridColumnStyles.Add( columnStyle );

			columnStyle = new DataGridRowColourColumn();
			columnStyle.MappingName = "Why Held";
			columnStyle.HeaderText = "Why Held";
			columnStyle.Width = Convert.ToInt16( ConfigurationSettings.AppSettings[ "columnWhyHeldWidth" ] );
			tableStyle.GridColumnStyles.Add( columnStyle );

			dgdMessages.TableStyles.Add( tableStyle );
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		// FIXME stop radio buttons focussing
		// FIXME preview msgs
		// FIXME update multiple when selected
		// FIXME update action text
		// FIXME read and process in another thread

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.tabBackground = new System.Windows.Forms.TabControl();
			this.tabConfiguration = new System.Windows.Forms.TabPage();
			this.btnNext = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtUri = new System.Windows.Forms.TextBox();
			this.tabAction = new System.Windows.Forms.TabPage();
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnSetAll = new System.Windows.Forms.Button();
			this.pgbMain = new System.Windows.Forms.ProgressBar();
			this.grpActions = new System.Windows.Forms.GroupBox();
			this.rdoActionDelete = new System.Windows.Forms.RadioButton();
			this.rdoActionQueue = new System.Windows.Forms.RadioButton();
			this.rdoActionQueueTrash = new System.Windows.Forms.RadioButton();
			this.rdoActionDont = new System.Windows.Forms.RadioButton();
			this.rdoActionQuick = new System.Windows.Forms.RadioButton();
			this.rdoActionForward = new System.Windows.Forms.RadioButton();
			this.rdoActionForwardWhitelist = new System.Windows.Forms.RadioButton();
			this.dgdMessages = new System.Windows.Forms.DataGrid();
			this.cxmGrid = new System.Windows.Forms.ContextMenu();
			this.mnuActionDont = new System.Windows.Forms.MenuItem();
			this.mnuActionQuick = new System.Windows.Forms.MenuItem();
			this.mnuActionForward = new System.Windows.Forms.MenuItem();
			this.mnuActionForwardWhitelist = new System.Windows.Forms.MenuItem();
			this.mnuActionQueueTrash = new System.Windows.Forms.MenuItem();
			this.mnuActionQueue = new System.Windows.Forms.MenuItem();
			this.mnuActionDelete = new System.Windows.Forms.MenuItem();
			this.btnProcess = new System.Windows.Forms.Button();
			this.btnRead = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tmrProgress = new System.Windows.Forms.Timer(this.components);
			this.lnkStrap = new System.Windows.Forms.LinkLabel();
			this.stsMain = new System.Windows.Forms.StatusBar();
			this.tabBackground.SuspendLayout();
			this.tabConfiguration.SuspendLayout();
			this.tabAction.SuspendLayout();
			this.grpActions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgdMessages)).BeginInit();
			this.SuspendLayout();
			// 
			// tabBackground
			// 
			this.tabBackground.AccessibleDescription = resources.GetString("tabBackground.AccessibleDescription");
			this.tabBackground.AccessibleName = resources.GetString("tabBackground.AccessibleName");
			this.tabBackground.Alignment = ((System.Windows.Forms.TabAlignment)(resources.GetObject("tabBackground.Alignment")));
			this.tabBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabBackground.Anchor")));
			this.tabBackground.Appearance = ((System.Windows.Forms.TabAppearance)(resources.GetObject("tabBackground.Appearance")));
			this.tabBackground.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabBackground.BackgroundImage")));
			this.tabBackground.Controls.Add(this.tabConfiguration);
			this.tabBackground.Controls.Add(this.tabAction);
			this.tabBackground.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabBackground.Dock")));
			this.tabBackground.Enabled = ((bool)(resources.GetObject("tabBackground.Enabled")));
			this.tabBackground.Font = ((System.Drawing.Font)(resources.GetObject("tabBackground.Font")));
			this.tabBackground.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabBackground.ImeMode")));
			this.tabBackground.ItemSize = ((System.Drawing.Size)(resources.GetObject("tabBackground.ItemSize")));
			this.tabBackground.Location = ((System.Drawing.Point)(resources.GetObject("tabBackground.Location")));
			this.tabBackground.Name = "tabBackground";
			this.tabBackground.Padding = ((System.Drawing.Point)(resources.GetObject("tabBackground.Padding")));
			this.tabBackground.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabBackground.RightToLeft")));
			this.tabBackground.SelectedIndex = 0;
			this.tabBackground.ShowToolTips = ((bool)(resources.GetObject("tabBackground.ShowToolTips")));
			this.tabBackground.Size = ((System.Drawing.Size)(resources.GetObject("tabBackground.Size")));
			this.tabBackground.TabIndex = ((int)(resources.GetObject("tabBackground.TabIndex")));
			this.tabBackground.Text = resources.GetString("tabBackground.Text");
			this.tabBackground.Visible = ((bool)(resources.GetObject("tabBackground.Visible")));
			// 
			// tabConfiguration
			// 
			this.tabConfiguration.AccessibleDescription = resources.GetString("tabConfiguration.AccessibleDescription");
			this.tabConfiguration.AccessibleName = resources.GetString("tabConfiguration.AccessibleName");
			this.tabConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabConfiguration.Anchor")));
			this.tabConfiguration.AutoScroll = ((bool)(resources.GetObject("tabConfiguration.AutoScroll")));
			this.tabConfiguration.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("tabConfiguration.AutoScrollMargin")));
			this.tabConfiguration.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("tabConfiguration.AutoScrollMinSize")));
			this.tabConfiguration.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabConfiguration.BackgroundImage")));
			this.tabConfiguration.Controls.Add(this.btnNext);
			this.tabConfiguration.Controls.Add(this.label3);
			this.tabConfiguration.Controls.Add(this.label2);
			this.tabConfiguration.Controls.Add(this.txtPassword);
			this.tabConfiguration.Controls.Add(this.txtUsername);
			this.tabConfiguration.Controls.Add(this.label1);
			this.tabConfiguration.Controls.Add(this.txtUri);
			this.tabConfiguration.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabConfiguration.Dock")));
			this.tabConfiguration.Enabled = ((bool)(resources.GetObject("tabConfiguration.Enabled")));
			this.tabConfiguration.Font = ((System.Drawing.Font)(resources.GetObject("tabConfiguration.Font")));
			this.tabConfiguration.ImageIndex = ((int)(resources.GetObject("tabConfiguration.ImageIndex")));
			this.tabConfiguration.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabConfiguration.ImeMode")));
			this.tabConfiguration.Location = ((System.Drawing.Point)(resources.GetObject("tabConfiguration.Location")));
			this.tabConfiguration.Name = "tabConfiguration";
			this.tabConfiguration.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabConfiguration.RightToLeft")));
			this.tabConfiguration.Size = ((System.Drawing.Size)(resources.GetObject("tabConfiguration.Size")));
			this.tabConfiguration.TabIndex = ((int)(resources.GetObject("tabConfiguration.TabIndex")));
			this.tabConfiguration.Text = resources.GetString("tabConfiguration.Text");
			this.tabConfiguration.ToolTipText = resources.GetString("tabConfiguration.ToolTipText");
			this.tabConfiguration.Visible = ((bool)(resources.GetObject("tabConfiguration.Visible")));
			// 
			// btnNext
			// 
			this.btnNext.AccessibleDescription = resources.GetString("btnNext.AccessibleDescription");
			this.btnNext.AccessibleName = resources.GetString("btnNext.AccessibleName");
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnNext.Anchor")));
			this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
			this.btnNext.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnNext.Dock")));
			this.btnNext.Enabled = ((bool)(resources.GetObject("btnNext.Enabled")));
			this.btnNext.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnNext.FlatStyle")));
			this.btnNext.Font = ((System.Drawing.Font)(resources.GetObject("btnNext.Font")));
			this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
			this.btnNext.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnNext.ImageAlign")));
			this.btnNext.ImageIndex = ((int)(resources.GetObject("btnNext.ImageIndex")));
			this.btnNext.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnNext.ImeMode")));
			this.btnNext.Location = ((System.Drawing.Point)(resources.GetObject("btnNext.Location")));
			this.btnNext.Name = "btnNext";
			this.btnNext.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnNext.RightToLeft")));
			this.btnNext.Size = ((System.Drawing.Size)(resources.GetObject("btnNext.Size")));
			this.btnNext.TabIndex = ((int)(resources.GetObject("btnNext.TabIndex")));
			this.btnNext.Text = resources.GetString("btnNext.Text");
			this.btnNext.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnNext.TextAlign")));
			this.btnNext.Visible = ((bool)(resources.GetObject("btnNext.Visible")));
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// label3
			// 
			this.label3.AccessibleDescription = resources.GetString("label3.AccessibleDescription");
			this.label3.AccessibleName = resources.GetString("label3.AccessibleName");
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label3.Anchor")));
			this.label3.AutoSize = ((bool)(resources.GetObject("label3.AutoSize")));
			this.label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label3.Dock")));
			this.label3.Enabled = ((bool)(resources.GetObject("label3.Enabled")));
			this.label3.Font = ((System.Drawing.Font)(resources.GetObject("label3.Font")));
			this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
			this.label3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.ImageAlign")));
			this.label3.ImageIndex = ((int)(resources.GetObject("label3.ImageIndex")));
			this.label3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label3.ImeMode")));
			this.label3.Location = ((System.Drawing.Point)(resources.GetObject("label3.Location")));
			this.label3.Name = "label3";
			this.label3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label3.RightToLeft")));
			this.label3.Size = ((System.Drawing.Size)(resources.GetObject("label3.Size")));
			this.label3.TabIndex = ((int)(resources.GetObject("label3.TabIndex")));
			this.label3.Text = resources.GetString("label3.Text");
			this.label3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.TextAlign")));
			this.label3.Visible = ((bool)(resources.GetObject("label3.Visible")));
			// 
			// label2
			// 
			this.label2.AccessibleDescription = resources.GetString("label2.AccessibleDescription");
			this.label2.AccessibleName = resources.GetString("label2.AccessibleName");
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
			this.label2.Enabled = ((bool)(resources.GetObject("label2.Enabled")));
			this.label2.Font = ((System.Drawing.Font)(resources.GetObject("label2.Font")));
			this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
			this.label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.ImageAlign")));
			this.label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			this.label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode")));
			this.label2.Location = ((System.Drawing.Point)(resources.GetObject("label2.Location")));
			this.label2.Name = "label2";
			this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label2.RightToLeft")));
			this.label2.Size = ((System.Drawing.Size)(resources.GetObject("label2.Size")));
			this.label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.TextAlign")));
			this.label2.Visible = ((bool)(resources.GetObject("label2.Visible")));
			// 
			// txtPassword
			// 
			this.txtPassword.AccessibleDescription = resources.GetString("txtPassword.AccessibleDescription");
			this.txtPassword.AccessibleName = resources.GetString("txtPassword.AccessibleName");
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtPassword.Anchor")));
			this.txtPassword.AutoSize = ((bool)(resources.GetObject("txtPassword.AutoSize")));
			this.txtPassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtPassword.BackgroundImage")));
			this.txtPassword.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtPassword.Dock")));
			this.txtPassword.Enabled = ((bool)(resources.GetObject("txtPassword.Enabled")));
			this.txtPassword.Font = ((System.Drawing.Font)(resources.GetObject("txtPassword.Font")));
			this.txtPassword.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtPassword.ImeMode")));
			this.txtPassword.Location = ((System.Drawing.Point)(resources.GetObject("txtPassword.Location")));
			this.txtPassword.MaxLength = ((int)(resources.GetObject("txtPassword.MaxLength")));
			this.txtPassword.Multiline = ((bool)(resources.GetObject("txtPassword.Multiline")));
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = ((char)(resources.GetObject("txtPassword.PasswordChar")));
			this.txtPassword.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtPassword.RightToLeft")));
			this.txtPassword.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtPassword.ScrollBars")));
			this.txtPassword.Size = ((System.Drawing.Size)(resources.GetObject("txtPassword.Size")));
			this.txtPassword.TabIndex = ((int)(resources.GetObject("txtPassword.TabIndex")));
			this.txtPassword.Text = resources.GetString("txtPassword.Text");
			this.txtPassword.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtPassword.TextAlign")));
			this.txtPassword.Visible = ((bool)(resources.GetObject("txtPassword.Visible")));
			this.txtPassword.WordWrap = ((bool)(resources.GetObject("txtPassword.WordWrap")));
			// 
			// txtUsername
			// 
			this.txtUsername.AccessibleDescription = resources.GetString("txtUsername.AccessibleDescription");
			this.txtUsername.AccessibleName = resources.GetString("txtUsername.AccessibleName");
			this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtUsername.Anchor")));
			this.txtUsername.AutoSize = ((bool)(resources.GetObject("txtUsername.AutoSize")));
			this.txtUsername.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtUsername.BackgroundImage")));
			this.txtUsername.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtUsername.Dock")));
			this.txtUsername.Enabled = ((bool)(resources.GetObject("txtUsername.Enabled")));
			this.txtUsername.Font = ((System.Drawing.Font)(resources.GetObject("txtUsername.Font")));
			this.txtUsername.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtUsername.ImeMode")));
			this.txtUsername.Location = ((System.Drawing.Point)(resources.GetObject("txtUsername.Location")));
			this.txtUsername.MaxLength = ((int)(resources.GetObject("txtUsername.MaxLength")));
			this.txtUsername.Multiline = ((bool)(resources.GetObject("txtUsername.Multiline")));
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.PasswordChar = ((char)(resources.GetObject("txtUsername.PasswordChar")));
			this.txtUsername.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtUsername.RightToLeft")));
			this.txtUsername.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtUsername.ScrollBars")));
			this.txtUsername.Size = ((System.Drawing.Size)(resources.GetObject("txtUsername.Size")));
			this.txtUsername.TabIndex = ((int)(resources.GetObject("txtUsername.TabIndex")));
			this.txtUsername.Text = resources.GetString("txtUsername.Text");
			this.txtUsername.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtUsername.TextAlign")));
			this.txtUsername.Visible = ((bool)(resources.GetObject("txtUsername.Visible")));
			this.txtUsername.WordWrap = ((bool)(resources.GetObject("txtUsername.WordWrap")));
			// 
			// label1
			// 
			this.label1.AccessibleDescription = resources.GetString("label1.AccessibleDescription");
			this.label1.AccessibleName = resources.GetString("label1.AccessibleName");
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
			this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
			this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
			this.label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
			// 
			// txtUri
			// 
			this.txtUri.AccessibleDescription = resources.GetString("txtUri.AccessibleDescription");
			this.txtUri.AccessibleName = resources.GetString("txtUri.AccessibleName");
			this.txtUri.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtUri.Anchor")));
			this.txtUri.AutoSize = ((bool)(resources.GetObject("txtUri.AutoSize")));
			this.txtUri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtUri.BackgroundImage")));
			this.txtUri.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtUri.Dock")));
			this.txtUri.Enabled = ((bool)(resources.GetObject("txtUri.Enabled")));
			this.txtUri.Font = ((System.Drawing.Font)(resources.GetObject("txtUri.Font")));
			this.txtUri.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtUri.ImeMode")));
			this.txtUri.Location = ((System.Drawing.Point)(resources.GetObject("txtUri.Location")));
			this.txtUri.MaxLength = ((int)(resources.GetObject("txtUri.MaxLength")));
			this.txtUri.Multiline = ((bool)(resources.GetObject("txtUri.Multiline")));
			this.txtUri.Name = "txtUri";
			this.txtUri.PasswordChar = ((char)(resources.GetObject("txtUri.PasswordChar")));
			this.txtUri.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtUri.RightToLeft")));
			this.txtUri.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtUri.ScrollBars")));
			this.txtUri.Size = ((System.Drawing.Size)(resources.GetObject("txtUri.Size")));
			this.txtUri.TabIndex = ((int)(resources.GetObject("txtUri.TabIndex")));
			this.txtUri.Text = resources.GetString("txtUri.Text");
			this.txtUri.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtUri.TextAlign")));
			this.txtUri.Visible = ((bool)(resources.GetObject("txtUri.Visible")));
			this.txtUri.WordWrap = ((bool)(resources.GetObject("txtUri.WordWrap")));
			// 
			// tabAction
			// 
			this.tabAction.AccessibleDescription = resources.GetString("tabAction.AccessibleDescription");
			this.tabAction.AccessibleName = resources.GetString("tabAction.AccessibleName");
			this.tabAction.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabAction.Anchor")));
			this.tabAction.AutoScroll = ((bool)(resources.GetObject("tabAction.AutoScroll")));
			this.tabAction.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("tabAction.AutoScrollMargin")));
			this.tabAction.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("tabAction.AutoScrollMinSize")));
			this.tabAction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabAction.BackgroundImage")));
			this.tabAction.Controls.Add(this.btnSearch);
			this.tabAction.Controls.Add(this.btnSetAll);
			this.tabAction.Controls.Add(this.pgbMain);
			this.tabAction.Controls.Add(this.grpActions);
			this.tabAction.Controls.Add(this.dgdMessages);
			this.tabAction.Controls.Add(this.btnProcess);
			this.tabAction.Controls.Add(this.btnRead);
			this.tabAction.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabAction.Dock")));
			this.tabAction.Enabled = ((bool)(resources.GetObject("tabAction.Enabled")));
			this.tabAction.Font = ((System.Drawing.Font)(resources.GetObject("tabAction.Font")));
			this.tabAction.ImageIndex = ((int)(resources.GetObject("tabAction.ImageIndex")));
			this.tabAction.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabAction.ImeMode")));
			this.tabAction.Location = ((System.Drawing.Point)(resources.GetObject("tabAction.Location")));
			this.tabAction.Name = "tabAction";
			this.tabAction.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabAction.RightToLeft")));
			this.tabAction.Size = ((System.Drawing.Size)(resources.GetObject("tabAction.Size")));
			this.tabAction.TabIndex = ((int)(resources.GetObject("tabAction.TabIndex")));
			this.tabAction.Text = resources.GetString("tabAction.Text");
			this.tabAction.ToolTipText = resources.GetString("tabAction.ToolTipText");
			this.tabAction.Visible = ((bool)(resources.GetObject("tabAction.Visible")));
			// 
			// btnSearch
			// 
			this.btnSearch.AccessibleDescription = resources.GetString("btnSearch.AccessibleDescription");
			this.btnSearch.AccessibleName = resources.GetString("btnSearch.AccessibleName");
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnSearch.Anchor")));
			this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
			this.btnSearch.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnSearch.Dock")));
			this.btnSearch.Enabled = ((bool)(resources.GetObject("btnSearch.Enabled")));
			this.btnSearch.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnSearch.FlatStyle")));
			this.btnSearch.Font = ((System.Drawing.Font)(resources.GetObject("btnSearch.Font")));
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSearch.ImageAlign")));
			this.btnSearch.ImageIndex = ((int)(resources.GetObject("btnSearch.ImageIndex")));
			this.btnSearch.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnSearch.ImeMode")));
			this.btnSearch.Location = ((System.Drawing.Point)(resources.GetObject("btnSearch.Location")));
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnSearch.RightToLeft")));
			this.btnSearch.Size = ((System.Drawing.Size)(resources.GetObject("btnSearch.Size")));
			this.btnSearch.TabIndex = ((int)(resources.GetObject("btnSearch.TabIndex")));
			this.btnSearch.Text = resources.GetString("btnSearch.Text");
			this.btnSearch.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSearch.TextAlign")));
			this.btnSearch.Visible = ((bool)(resources.GetObject("btnSearch.Visible")));
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnSetAll
			// 
			this.btnSetAll.AccessibleDescription = resources.GetString("btnSetAll.AccessibleDescription");
			this.btnSetAll.AccessibleName = resources.GetString("btnSetAll.AccessibleName");
			this.btnSetAll.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnSetAll.Anchor")));
			this.btnSetAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetAll.BackgroundImage")));
			this.btnSetAll.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnSetAll.Dock")));
			this.btnSetAll.Enabled = ((bool)(resources.GetObject("btnSetAll.Enabled")));
			this.btnSetAll.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnSetAll.FlatStyle")));
			this.btnSetAll.Font = ((System.Drawing.Font)(resources.GetObject("btnSetAll.Font")));
			this.btnSetAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSetAll.Image")));
			this.btnSetAll.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSetAll.ImageAlign")));
			this.btnSetAll.ImageIndex = ((int)(resources.GetObject("btnSetAll.ImageIndex")));
			this.btnSetAll.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnSetAll.ImeMode")));
			this.btnSetAll.Location = ((System.Drawing.Point)(resources.GetObject("btnSetAll.Location")));
			this.btnSetAll.Name = "btnSetAll";
			this.btnSetAll.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnSetAll.RightToLeft")));
			this.btnSetAll.Size = ((System.Drawing.Size)(resources.GetObject("btnSetAll.Size")));
			this.btnSetAll.TabIndex = ((int)(resources.GetObject("btnSetAll.TabIndex")));
			this.btnSetAll.Text = resources.GetString("btnSetAll.Text");
			this.btnSetAll.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSetAll.TextAlign")));
			this.btnSetAll.Visible = ((bool)(resources.GetObject("btnSetAll.Visible")));
			this.btnSetAll.Click += new System.EventHandler(this.btnSetAll_Click);
			// 
			// pgbMain
			// 
			this.pgbMain.AccessibleDescription = resources.GetString("pgbMain.AccessibleDescription");
			this.pgbMain.AccessibleName = resources.GetString("pgbMain.AccessibleName");
			this.pgbMain.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("pgbMain.Anchor")));
			this.pgbMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pgbMain.BackgroundImage")));
			this.pgbMain.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("pgbMain.Dock")));
			this.pgbMain.Enabled = ((bool)(resources.GetObject("pgbMain.Enabled")));
			this.pgbMain.Font = ((System.Drawing.Font)(resources.GetObject("pgbMain.Font")));
			this.pgbMain.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("pgbMain.ImeMode")));
			this.pgbMain.Location = ((System.Drawing.Point)(resources.GetObject("pgbMain.Location")));
			this.pgbMain.Name = "pgbMain";
			this.pgbMain.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("pgbMain.RightToLeft")));
			this.pgbMain.Size = ((System.Drawing.Size)(resources.GetObject("pgbMain.Size")));
			this.pgbMain.TabIndex = ((int)(resources.GetObject("pgbMain.TabIndex")));
			this.pgbMain.Text = resources.GetString("pgbMain.Text");
			this.pgbMain.Visible = ((bool)(resources.GetObject("pgbMain.Visible")));
			// 
			// grpActions
			// 
			this.grpActions.AccessibleDescription = resources.GetString("grpActions.AccessibleDescription");
			this.grpActions.AccessibleName = resources.GetString("grpActions.AccessibleName");
			this.grpActions.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("grpActions.Anchor")));
			this.grpActions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grpActions.BackgroundImage")));
			this.grpActions.Controls.Add(this.rdoActionDelete);
			this.grpActions.Controls.Add(this.rdoActionQueue);
			this.grpActions.Controls.Add(this.rdoActionQueueTrash);
			this.grpActions.Controls.Add(this.rdoActionDont);
			this.grpActions.Controls.Add(this.rdoActionQuick);
			this.grpActions.Controls.Add(this.rdoActionForward);
			this.grpActions.Controls.Add(this.rdoActionForwardWhitelist);
			this.grpActions.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("grpActions.Dock")));
			this.grpActions.Enabled = ((bool)(resources.GetObject("grpActions.Enabled")));
			this.grpActions.Font = ((System.Drawing.Font)(resources.GetObject("grpActions.Font")));
			this.grpActions.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("grpActions.ImeMode")));
			this.grpActions.Location = ((System.Drawing.Point)(resources.GetObject("grpActions.Location")));
			this.grpActions.Name = "grpActions";
			this.grpActions.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("grpActions.RightToLeft")));
			this.grpActions.Size = ((System.Drawing.Size)(resources.GetObject("grpActions.Size")));
			this.grpActions.TabIndex = ((int)(resources.GetObject("grpActions.TabIndex")));
			this.grpActions.TabStop = false;
			this.grpActions.Text = resources.GetString("grpActions.Text");
			this.grpActions.Visible = ((bool)(resources.GetObject("grpActions.Visible")));
			// 
			// rdoActionDelete
			// 
			this.rdoActionDelete.AccessibleDescription = resources.GetString("rdoActionDelete.AccessibleDescription");
			this.rdoActionDelete.AccessibleName = resources.GetString("rdoActionDelete.AccessibleName");
			this.rdoActionDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("rdoActionDelete.Anchor")));
			this.rdoActionDelete.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("rdoActionDelete.Appearance")));
			this.rdoActionDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rdoActionDelete.BackgroundImage")));
			this.rdoActionDelete.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionDelete.CheckAlign")));
			this.rdoActionDelete.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("rdoActionDelete.Dock")));
			this.rdoActionDelete.Enabled = ((bool)(resources.GetObject("rdoActionDelete.Enabled")));
			this.rdoActionDelete.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("rdoActionDelete.FlatStyle")));
			this.rdoActionDelete.Font = ((System.Drawing.Font)(resources.GetObject("rdoActionDelete.Font")));
			this.rdoActionDelete.Image = ((System.Drawing.Image)(resources.GetObject("rdoActionDelete.Image")));
			this.rdoActionDelete.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionDelete.ImageAlign")));
			this.rdoActionDelete.ImageIndex = ((int)(resources.GetObject("rdoActionDelete.ImageIndex")));
			this.rdoActionDelete.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("rdoActionDelete.ImeMode")));
			this.rdoActionDelete.Location = ((System.Drawing.Point)(resources.GetObject("rdoActionDelete.Location")));
			this.rdoActionDelete.Name = "rdoActionDelete";
			this.rdoActionDelete.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("rdoActionDelete.RightToLeft")));
			this.rdoActionDelete.Size = ((System.Drawing.Size)(resources.GetObject("rdoActionDelete.Size")));
			this.rdoActionDelete.TabIndex = ((int)(resources.GetObject("rdoActionDelete.TabIndex")));
			this.rdoActionDelete.Text = resources.GetString("rdoActionDelete.Text");
			this.rdoActionDelete.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionDelete.TextAlign")));
			this.rdoActionDelete.Visible = ((bool)(resources.GetObject("rdoActionDelete.Visible")));
			this.rdoActionDelete.CheckedChanged += new System.EventHandler(this.rdoActionDelete_CheckedChanged);
			// 
			// rdoActionQueue
			// 
			this.rdoActionQueue.AccessibleDescription = resources.GetString("rdoActionQueue.AccessibleDescription");
			this.rdoActionQueue.AccessibleName = resources.GetString("rdoActionQueue.AccessibleName");
			this.rdoActionQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("rdoActionQueue.Anchor")));
			this.rdoActionQueue.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("rdoActionQueue.Appearance")));
			this.rdoActionQueue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rdoActionQueue.BackgroundImage")));
			this.rdoActionQueue.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionQueue.CheckAlign")));
			this.rdoActionQueue.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("rdoActionQueue.Dock")));
			this.rdoActionQueue.Enabled = ((bool)(resources.GetObject("rdoActionQueue.Enabled")));
			this.rdoActionQueue.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("rdoActionQueue.FlatStyle")));
			this.rdoActionQueue.Font = ((System.Drawing.Font)(resources.GetObject("rdoActionQueue.Font")));
			this.rdoActionQueue.Image = ((System.Drawing.Image)(resources.GetObject("rdoActionQueue.Image")));
			this.rdoActionQueue.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionQueue.ImageAlign")));
			this.rdoActionQueue.ImageIndex = ((int)(resources.GetObject("rdoActionQueue.ImageIndex")));
			this.rdoActionQueue.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("rdoActionQueue.ImeMode")));
			this.rdoActionQueue.Location = ((System.Drawing.Point)(resources.GetObject("rdoActionQueue.Location")));
			this.rdoActionQueue.Name = "rdoActionQueue";
			this.rdoActionQueue.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("rdoActionQueue.RightToLeft")));
			this.rdoActionQueue.Size = ((System.Drawing.Size)(resources.GetObject("rdoActionQueue.Size")));
			this.rdoActionQueue.TabIndex = ((int)(resources.GetObject("rdoActionQueue.TabIndex")));
			this.rdoActionQueue.Text = resources.GetString("rdoActionQueue.Text");
			this.rdoActionQueue.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionQueue.TextAlign")));
			this.rdoActionQueue.Visible = ((bool)(resources.GetObject("rdoActionQueue.Visible")));
			this.rdoActionQueue.CheckedChanged += new System.EventHandler(this.rdoActionQueue_CheckedChanged);
			// 
			// rdoActionQueueTrash
			// 
			this.rdoActionQueueTrash.AccessibleDescription = resources.GetString("rdoActionQueueTrash.AccessibleDescription");
			this.rdoActionQueueTrash.AccessibleName = resources.GetString("rdoActionQueueTrash.AccessibleName");
			this.rdoActionQueueTrash.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("rdoActionQueueTrash.Anchor")));
			this.rdoActionQueueTrash.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("rdoActionQueueTrash.Appearance")));
			this.rdoActionQueueTrash.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rdoActionQueueTrash.BackgroundImage")));
			this.rdoActionQueueTrash.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionQueueTrash.CheckAlign")));
			this.rdoActionQueueTrash.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("rdoActionQueueTrash.Dock")));
			this.rdoActionQueueTrash.Enabled = ((bool)(resources.GetObject("rdoActionQueueTrash.Enabled")));
			this.rdoActionQueueTrash.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("rdoActionQueueTrash.FlatStyle")));
			this.rdoActionQueueTrash.Font = ((System.Drawing.Font)(resources.GetObject("rdoActionQueueTrash.Font")));
			this.rdoActionQueueTrash.Image = ((System.Drawing.Image)(resources.GetObject("rdoActionQueueTrash.Image")));
			this.rdoActionQueueTrash.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionQueueTrash.ImageAlign")));
			this.rdoActionQueueTrash.ImageIndex = ((int)(resources.GetObject("rdoActionQueueTrash.ImageIndex")));
			this.rdoActionQueueTrash.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("rdoActionQueueTrash.ImeMode")));
			this.rdoActionQueueTrash.Location = ((System.Drawing.Point)(resources.GetObject("rdoActionQueueTrash.Location")));
			this.rdoActionQueueTrash.Name = "rdoActionQueueTrash";
			this.rdoActionQueueTrash.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("rdoActionQueueTrash.RightToLeft")));
			this.rdoActionQueueTrash.Size = ((System.Drawing.Size)(resources.GetObject("rdoActionQueueTrash.Size")));
			this.rdoActionQueueTrash.TabIndex = ((int)(resources.GetObject("rdoActionQueueTrash.TabIndex")));
			this.rdoActionQueueTrash.Text = resources.GetString("rdoActionQueueTrash.Text");
			this.rdoActionQueueTrash.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionQueueTrash.TextAlign")));
			this.rdoActionQueueTrash.Visible = ((bool)(resources.GetObject("rdoActionQueueTrash.Visible")));
			this.rdoActionQueueTrash.CheckedChanged += new System.EventHandler(this.rdoActionQueueTrash_CheckedChanged);
			// 
			// rdoActionDont
			// 
			this.rdoActionDont.AccessibleDescription = resources.GetString("rdoActionDont.AccessibleDescription");
			this.rdoActionDont.AccessibleName = resources.GetString("rdoActionDont.AccessibleName");
			this.rdoActionDont.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("rdoActionDont.Anchor")));
			this.rdoActionDont.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("rdoActionDont.Appearance")));
			this.rdoActionDont.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rdoActionDont.BackgroundImage")));
			this.rdoActionDont.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionDont.CheckAlign")));
			this.rdoActionDont.Checked = true;
			this.rdoActionDont.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("rdoActionDont.Dock")));
			this.rdoActionDont.Enabled = ((bool)(resources.GetObject("rdoActionDont.Enabled")));
			this.rdoActionDont.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("rdoActionDont.FlatStyle")));
			this.rdoActionDont.Font = ((System.Drawing.Font)(resources.GetObject("rdoActionDont.Font")));
			this.rdoActionDont.Image = ((System.Drawing.Image)(resources.GetObject("rdoActionDont.Image")));
			this.rdoActionDont.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionDont.ImageAlign")));
			this.rdoActionDont.ImageIndex = ((int)(resources.GetObject("rdoActionDont.ImageIndex")));
			this.rdoActionDont.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("rdoActionDont.ImeMode")));
			this.rdoActionDont.Location = ((System.Drawing.Point)(resources.GetObject("rdoActionDont.Location")));
			this.rdoActionDont.Name = "rdoActionDont";
			this.rdoActionDont.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("rdoActionDont.RightToLeft")));
			this.rdoActionDont.Size = ((System.Drawing.Size)(resources.GetObject("rdoActionDont.Size")));
			this.rdoActionDont.TabIndex = ((int)(resources.GetObject("rdoActionDont.TabIndex")));
			this.rdoActionDont.TabStop = true;
			this.rdoActionDont.Text = resources.GetString("rdoActionDont.Text");
			this.rdoActionDont.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionDont.TextAlign")));
			this.rdoActionDont.Visible = ((bool)(resources.GetObject("rdoActionDont.Visible")));
			this.rdoActionDont.CheckedChanged += new System.EventHandler(this.rdoActionDont_CheckedChanged);
			// 
			// rdoActionQuick
			// 
			this.rdoActionQuick.AccessibleDescription = resources.GetString("rdoActionQuick.AccessibleDescription");
			this.rdoActionQuick.AccessibleName = resources.GetString("rdoActionQuick.AccessibleName");
			this.rdoActionQuick.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("rdoActionQuick.Anchor")));
			this.rdoActionQuick.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("rdoActionQuick.Appearance")));
			this.rdoActionQuick.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rdoActionQuick.BackgroundImage")));
			this.rdoActionQuick.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionQuick.CheckAlign")));
			this.rdoActionQuick.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("rdoActionQuick.Dock")));
			this.rdoActionQuick.Enabled = ((bool)(resources.GetObject("rdoActionQuick.Enabled")));
			this.rdoActionQuick.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("rdoActionQuick.FlatStyle")));
			this.rdoActionQuick.Font = ((System.Drawing.Font)(resources.GetObject("rdoActionQuick.Font")));
			this.rdoActionQuick.Image = ((System.Drawing.Image)(resources.GetObject("rdoActionQuick.Image")));
			this.rdoActionQuick.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionQuick.ImageAlign")));
			this.rdoActionQuick.ImageIndex = ((int)(resources.GetObject("rdoActionQuick.ImageIndex")));
			this.rdoActionQuick.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("rdoActionQuick.ImeMode")));
			this.rdoActionQuick.Location = ((System.Drawing.Point)(resources.GetObject("rdoActionQuick.Location")));
			this.rdoActionQuick.Name = "rdoActionQuick";
			this.rdoActionQuick.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("rdoActionQuick.RightToLeft")));
			this.rdoActionQuick.Size = ((System.Drawing.Size)(resources.GetObject("rdoActionQuick.Size")));
			this.rdoActionQuick.TabIndex = ((int)(resources.GetObject("rdoActionQuick.TabIndex")));
			this.rdoActionQuick.Text = resources.GetString("rdoActionQuick.Text");
			this.rdoActionQuick.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionQuick.TextAlign")));
			this.rdoActionQuick.Visible = ((bool)(resources.GetObject("rdoActionQuick.Visible")));
			this.rdoActionQuick.CheckedChanged += new System.EventHandler(this.rdoActionQuick_CheckedChanged);
			// 
			// rdoActionForward
			// 
			this.rdoActionForward.AccessibleDescription = resources.GetString("rdoActionForward.AccessibleDescription");
			this.rdoActionForward.AccessibleName = resources.GetString("rdoActionForward.AccessibleName");
			this.rdoActionForward.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("rdoActionForward.Anchor")));
			this.rdoActionForward.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("rdoActionForward.Appearance")));
			this.rdoActionForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rdoActionForward.BackgroundImage")));
			this.rdoActionForward.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionForward.CheckAlign")));
			this.rdoActionForward.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("rdoActionForward.Dock")));
			this.rdoActionForward.Enabled = ((bool)(resources.GetObject("rdoActionForward.Enabled")));
			this.rdoActionForward.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("rdoActionForward.FlatStyle")));
			this.rdoActionForward.Font = ((System.Drawing.Font)(resources.GetObject("rdoActionForward.Font")));
			this.rdoActionForward.Image = ((System.Drawing.Image)(resources.GetObject("rdoActionForward.Image")));
			this.rdoActionForward.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionForward.ImageAlign")));
			this.rdoActionForward.ImageIndex = ((int)(resources.GetObject("rdoActionForward.ImageIndex")));
			this.rdoActionForward.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("rdoActionForward.ImeMode")));
			this.rdoActionForward.Location = ((System.Drawing.Point)(resources.GetObject("rdoActionForward.Location")));
			this.rdoActionForward.Name = "rdoActionForward";
			this.rdoActionForward.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("rdoActionForward.RightToLeft")));
			this.rdoActionForward.Size = ((System.Drawing.Size)(resources.GetObject("rdoActionForward.Size")));
			this.rdoActionForward.TabIndex = ((int)(resources.GetObject("rdoActionForward.TabIndex")));
			this.rdoActionForward.Text = resources.GetString("rdoActionForward.Text");
			this.rdoActionForward.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionForward.TextAlign")));
			this.rdoActionForward.Visible = ((bool)(resources.GetObject("rdoActionForward.Visible")));
			this.rdoActionForward.CheckedChanged += new System.EventHandler(this.rdoActionForward_CheckedChanged);
			// 
			// rdoActionForwardWhitelist
			// 
			this.rdoActionForwardWhitelist.AccessibleDescription = resources.GetString("rdoActionForwardWhitelist.AccessibleDescription");
			this.rdoActionForwardWhitelist.AccessibleName = resources.GetString("rdoActionForwardWhitelist.AccessibleName");
			this.rdoActionForwardWhitelist.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("rdoActionForwardWhitelist.Anchor")));
			this.rdoActionForwardWhitelist.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("rdoActionForwardWhitelist.Appearance")));
			this.rdoActionForwardWhitelist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rdoActionForwardWhitelist.BackgroundImage")));
			this.rdoActionForwardWhitelist.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionForwardWhitelist.CheckAlign")));
			this.rdoActionForwardWhitelist.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("rdoActionForwardWhitelist.Dock")));
			this.rdoActionForwardWhitelist.Enabled = ((bool)(resources.GetObject("rdoActionForwardWhitelist.Enabled")));
			this.rdoActionForwardWhitelist.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("rdoActionForwardWhitelist.FlatStyle")));
			this.rdoActionForwardWhitelist.Font = ((System.Drawing.Font)(resources.GetObject("rdoActionForwardWhitelist.Font")));
			this.rdoActionForwardWhitelist.Image = ((System.Drawing.Image)(resources.GetObject("rdoActionForwardWhitelist.Image")));
			this.rdoActionForwardWhitelist.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionForwardWhitelist.ImageAlign")));
			this.rdoActionForwardWhitelist.ImageIndex = ((int)(resources.GetObject("rdoActionForwardWhitelist.ImageIndex")));
			this.rdoActionForwardWhitelist.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("rdoActionForwardWhitelist.ImeMode")));
			this.rdoActionForwardWhitelist.Location = ((System.Drawing.Point)(resources.GetObject("rdoActionForwardWhitelist.Location")));
			this.rdoActionForwardWhitelist.Name = "rdoActionForwardWhitelist";
			this.rdoActionForwardWhitelist.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("rdoActionForwardWhitelist.RightToLeft")));
			this.rdoActionForwardWhitelist.Size = ((System.Drawing.Size)(resources.GetObject("rdoActionForwardWhitelist.Size")));
			this.rdoActionForwardWhitelist.TabIndex = ((int)(resources.GetObject("rdoActionForwardWhitelist.TabIndex")));
			this.rdoActionForwardWhitelist.Text = resources.GetString("rdoActionForwardWhitelist.Text");
			this.rdoActionForwardWhitelist.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rdoActionForwardWhitelist.TextAlign")));
			this.rdoActionForwardWhitelist.Visible = ((bool)(resources.GetObject("rdoActionForwardWhitelist.Visible")));
			this.rdoActionForwardWhitelist.CheckedChanged += new System.EventHandler(this.rdoActionForwardWhitelist_CheckedChanged);
			// 
			// dgdMessages
			// 
			this.dgdMessages.AccessibleDescription = resources.GetString("dgdMessages.AccessibleDescription");
			this.dgdMessages.AccessibleName = resources.GetString("dgdMessages.AccessibleName");
			this.dgdMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("dgdMessages.Anchor")));
			this.dgdMessages.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dgdMessages.BackgroundImage")));
			this.dgdMessages.CaptionFont = ((System.Drawing.Font)(resources.GetObject("dgdMessages.CaptionFont")));
			this.dgdMessages.CaptionText = resources.GetString("dgdMessages.CaptionText");
			this.dgdMessages.CaptionVisible = false;
			this.dgdMessages.ContextMenu = this.cxmGrid;
			this.dgdMessages.DataMember = "";
			this.dgdMessages.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("dgdMessages.Dock")));
			this.dgdMessages.Enabled = ((bool)(resources.GetObject("dgdMessages.Enabled")));
			this.dgdMessages.Font = ((System.Drawing.Font)(resources.GetObject("dgdMessages.Font")));
			this.dgdMessages.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgdMessages.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgdMessages.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("dgdMessages.ImeMode")));
			this.dgdMessages.Location = ((System.Drawing.Point)(resources.GetObject("dgdMessages.Location")));
			this.dgdMessages.Name = "dgdMessages";
			this.dgdMessages.ReadOnly = true;
			this.dgdMessages.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("dgdMessages.RightToLeft")));
			this.dgdMessages.Size = ((System.Drawing.Size)(resources.GetObject("dgdMessages.Size")));
			this.dgdMessages.TabIndex = ((int)(resources.GetObject("dgdMessages.TabIndex")));
			this.dgdMessages.Visible = ((bool)(resources.GetObject("dgdMessages.Visible")));
			this.dgdMessages.CurrentCellChanged += new System.EventHandler(this.dgdMessages_CurrentCellChanged);
			// 
			// cxmGrid
			// 
			this.cxmGrid.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuActionDont,
																					this.mnuActionQuick,
																					this.mnuActionForward,
																					this.mnuActionForwardWhitelist,
																					this.mnuActionQueueTrash,
																					this.mnuActionQueue,
																					this.mnuActionDelete});
			this.cxmGrid.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cxmGrid.RightToLeft")));
			// 
			// mnuActionDont
			// 
			this.mnuActionDont.Checked = true;
			this.mnuActionDont.Enabled = ((bool)(resources.GetObject("mnuActionDont.Enabled")));
			this.mnuActionDont.Index = 0;
			this.mnuActionDont.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuActionDont.Shortcut")));
			this.mnuActionDont.ShowShortcut = ((bool)(resources.GetObject("mnuActionDont.ShowShortcut")));
			this.mnuActionDont.Text = resources.GetString("mnuActionDont.Text");
			this.mnuActionDont.Visible = ((bool)(resources.GetObject("mnuActionDont.Visible")));
			this.mnuActionDont.Click += new System.EventHandler(this.mnuActionDont_Click);
			// 
			// mnuActionQuick
			// 
			this.mnuActionQuick.Enabled = ((bool)(resources.GetObject("mnuActionQuick.Enabled")));
			this.mnuActionQuick.Index = 1;
			this.mnuActionQuick.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuActionQuick.Shortcut")));
			this.mnuActionQuick.ShowShortcut = ((bool)(resources.GetObject("mnuActionQuick.ShowShortcut")));
			this.mnuActionQuick.Text = resources.GetString("mnuActionQuick.Text");
			this.mnuActionQuick.Visible = ((bool)(resources.GetObject("mnuActionQuick.Visible")));
			this.mnuActionQuick.Click += new System.EventHandler(this.mnuActionQuick_Click);
			// 
			// mnuActionForward
			// 
			this.mnuActionForward.Enabled = ((bool)(resources.GetObject("mnuActionForward.Enabled")));
			this.mnuActionForward.Index = 2;
			this.mnuActionForward.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuActionForward.Shortcut")));
			this.mnuActionForward.ShowShortcut = ((bool)(resources.GetObject("mnuActionForward.ShowShortcut")));
			this.mnuActionForward.Text = resources.GetString("mnuActionForward.Text");
			this.mnuActionForward.Visible = ((bool)(resources.GetObject("mnuActionForward.Visible")));
			this.mnuActionForward.Click += new System.EventHandler(this.mnuActionForward_Click);
			// 
			// mnuActionForwardWhitelist
			// 
			this.mnuActionForwardWhitelist.Enabled = ((bool)(resources.GetObject("mnuActionForwardWhitelist.Enabled")));
			this.mnuActionForwardWhitelist.Index = 3;
			this.mnuActionForwardWhitelist.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuActionForwardWhitelist.Shortcut")));
			this.mnuActionForwardWhitelist.ShowShortcut = ((bool)(resources.GetObject("mnuActionForwardWhitelist.ShowShortcut")));
			this.mnuActionForwardWhitelist.Text = resources.GetString("mnuActionForwardWhitelist.Text");
			this.mnuActionForwardWhitelist.Visible = ((bool)(resources.GetObject("mnuActionForwardWhitelist.Visible")));
			this.mnuActionForwardWhitelist.Click += new System.EventHandler(this.mnuActionForwardWhitelist_Click);
			// 
			// mnuActionQueueTrash
			// 
			this.mnuActionQueueTrash.Enabled = ((bool)(resources.GetObject("mnuActionQueueTrash.Enabled")));
			this.mnuActionQueueTrash.Index = 4;
			this.mnuActionQueueTrash.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuActionQueueTrash.Shortcut")));
			this.mnuActionQueueTrash.ShowShortcut = ((bool)(resources.GetObject("mnuActionQueueTrash.ShowShortcut")));
			this.mnuActionQueueTrash.Text = resources.GetString("mnuActionQueueTrash.Text");
			this.mnuActionQueueTrash.Visible = ((bool)(resources.GetObject("mnuActionQueueTrash.Visible")));
			this.mnuActionQueueTrash.Click += new System.EventHandler(this.mnuActionQueueTrash_Click);
			// 
			// mnuActionQueue
			// 
			this.mnuActionQueue.Enabled = ((bool)(resources.GetObject("mnuActionQueue.Enabled")));
			this.mnuActionQueue.Index = 5;
			this.mnuActionQueue.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuActionQueue.Shortcut")));
			this.mnuActionQueue.ShowShortcut = ((bool)(resources.GetObject("mnuActionQueue.ShowShortcut")));
			this.mnuActionQueue.Text = resources.GetString("mnuActionQueue.Text");
			this.mnuActionQueue.Visible = ((bool)(resources.GetObject("mnuActionQueue.Visible")));
			this.mnuActionQueue.Click += new System.EventHandler(this.mnuActionQueue_Click);
			// 
			// mnuActionDelete
			// 
			this.mnuActionDelete.Enabled = ((bool)(resources.GetObject("mnuActionDelete.Enabled")));
			this.mnuActionDelete.Index = 6;
			this.mnuActionDelete.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuActionDelete.Shortcut")));
			this.mnuActionDelete.ShowShortcut = ((bool)(resources.GetObject("mnuActionDelete.ShowShortcut")));
			this.mnuActionDelete.Text = resources.GetString("mnuActionDelete.Text");
			this.mnuActionDelete.Visible = ((bool)(resources.GetObject("mnuActionDelete.Visible")));
			this.mnuActionDelete.Click += new System.EventHandler(this.mnuActionDelete_Click);
			// 
			// btnProcess
			// 
			this.btnProcess.AccessibleDescription = resources.GetString("btnProcess.AccessibleDescription");
			this.btnProcess.AccessibleName = resources.GetString("btnProcess.AccessibleName");
			this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnProcess.Anchor")));
			this.btnProcess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcess.BackgroundImage")));
			this.btnProcess.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnProcess.Dock")));
			this.btnProcess.Enabled = ((bool)(resources.GetObject("btnProcess.Enabled")));
			this.btnProcess.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnProcess.FlatStyle")));
			this.btnProcess.Font = ((System.Drawing.Font)(resources.GetObject("btnProcess.Font")));
			this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
			this.btnProcess.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnProcess.ImageAlign")));
			this.btnProcess.ImageIndex = ((int)(resources.GetObject("btnProcess.ImageIndex")));
			this.btnProcess.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnProcess.ImeMode")));
			this.btnProcess.Location = ((System.Drawing.Point)(resources.GetObject("btnProcess.Location")));
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnProcess.RightToLeft")));
			this.btnProcess.Size = ((System.Drawing.Size)(resources.GetObject("btnProcess.Size")));
			this.btnProcess.TabIndex = ((int)(resources.GetObject("btnProcess.TabIndex")));
			this.btnProcess.Text = resources.GetString("btnProcess.Text");
			this.btnProcess.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnProcess.TextAlign")));
			this.btnProcess.Visible = ((bool)(resources.GetObject("btnProcess.Visible")));
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// btnRead
			// 
			this.btnRead.AccessibleDescription = resources.GetString("btnRead.AccessibleDescription");
			this.btnRead.AccessibleName = resources.GetString("btnRead.AccessibleName");
			this.btnRead.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnRead.Anchor")));
			this.btnRead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRead.BackgroundImage")));
			this.btnRead.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnRead.Dock")));
			this.btnRead.Enabled = ((bool)(resources.GetObject("btnRead.Enabled")));
			this.btnRead.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnRead.FlatStyle")));
			this.btnRead.Font = ((System.Drawing.Font)(resources.GetObject("btnRead.Font")));
			this.btnRead.Image = ((System.Drawing.Image)(resources.GetObject("btnRead.Image")));
			this.btnRead.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnRead.ImageAlign")));
			this.btnRead.ImageIndex = ((int)(resources.GetObject("btnRead.ImageIndex")));
			this.btnRead.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnRead.ImeMode")));
			this.btnRead.Location = ((System.Drawing.Point)(resources.GetObject("btnRead.Location")));
			this.btnRead.Name = "btnRead";
			this.btnRead.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnRead.RightToLeft")));
			this.btnRead.Size = ((System.Drawing.Size)(resources.GetObject("btnRead.Size")));
			this.btnRead.TabIndex = ((int)(resources.GetObject("btnRead.TabIndex")));
			this.btnRead.Text = resources.GetString("btnRead.Text");
			this.btnRead.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnRead.TextAlign")));
			this.btnRead.Visible = ((bool)(resources.GetObject("btnRead.Visible")));
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.AccessibleDescription = resources.GetString("pictureBox1.AccessibleDescription");
			this.pictureBox1.AccessibleName = resources.GetString("pictureBox1.AccessibleName");
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("pictureBox1.Anchor")));
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("pictureBox1.Dock")));
			this.pictureBox1.Enabled = ((bool)(resources.GetObject("pictureBox1.Enabled")));
			this.pictureBox1.Font = ((System.Drawing.Font)(resources.GetObject("pictureBox1.Font")));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("pictureBox1.ImeMode")));
			this.pictureBox1.Location = ((System.Drawing.Point)(resources.GetObject("pictureBox1.Location")));
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("pictureBox1.RightToLeft")));
			this.pictureBox1.Size = ((System.Drawing.Size)(resources.GetObject("pictureBox1.Size")));
			this.pictureBox1.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode)(resources.GetObject("pictureBox1.SizeMode")));
			this.pictureBox1.TabIndex = ((int)(resources.GetObject("pictureBox1.TabIndex")));
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Text = resources.GetString("pictureBox1.Text");
			this.pictureBox1.Visible = ((bool)(resources.GetObject("pictureBox1.Visible")));
			// 
			// label4
			// 
			this.label4.AccessibleDescription = resources.GetString("label4.AccessibleDescription");
			this.label4.AccessibleName = resources.GetString("label4.AccessibleName");
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label4.Anchor")));
			this.label4.AutoSize = ((bool)(resources.GetObject("label4.AutoSize")));
			this.label4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label4.Dock")));
			this.label4.Enabled = ((bool)(resources.GetObject("label4.Enabled")));
			this.label4.Font = ((System.Drawing.Font)(resources.GetObject("label4.Font")));
			this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
			this.label4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.ImageAlign")));
			this.label4.ImageIndex = ((int)(resources.GetObject("label4.ImageIndex")));
			this.label4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label4.ImeMode")));
			this.label4.Location = ((System.Drawing.Point)(resources.GetObject("label4.Location")));
			this.label4.Name = "label4";
			this.label4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label4.RightToLeft")));
			this.label4.Size = ((System.Drawing.Size)(resources.GetObject("label4.Size")));
			this.label4.TabIndex = ((int)(resources.GetObject("label4.TabIndex")));
			this.label4.Text = resources.GetString("label4.Text");
			this.label4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.TextAlign")));
			this.label4.Visible = ((bool)(resources.GetObject("label4.Visible")));
			// 
			// label6
			// 
			this.label6.AccessibleDescription = resources.GetString("label6.AccessibleDescription");
			this.label6.AccessibleName = resources.GetString("label6.AccessibleName");
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label6.Anchor")));
			this.label6.AutoSize = ((bool)(resources.GetObject("label6.AutoSize")));
			this.label6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label6.Dock")));
			this.label6.Enabled = ((bool)(resources.GetObject("label6.Enabled")));
			this.label6.Font = ((System.Drawing.Font)(resources.GetObject("label6.Font")));
			this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
			this.label6.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.ImageAlign")));
			this.label6.ImageIndex = ((int)(resources.GetObject("label6.ImageIndex")));
			this.label6.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label6.ImeMode")));
			this.label6.Location = ((System.Drawing.Point)(resources.GetObject("label6.Location")));
			this.label6.Name = "label6";
			this.label6.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label6.RightToLeft")));
			this.label6.Size = ((System.Drawing.Size)(resources.GetObject("label6.Size")));
			this.label6.TabIndex = ((int)(resources.GetObject("label6.TabIndex")));
			this.label6.Text = resources.GetString("label6.Text");
			this.label6.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.TextAlign")));
			this.label6.Visible = ((bool)(resources.GetObject("label6.Visible")));
			// 
			// tmrProgress
			// 
			this.tmrProgress.Interval = 250;
			this.tmrProgress.Tick += new System.EventHandler(this.tmrProgress_Tick);
			// 
			// lnkStrap
			// 
			this.lnkStrap.AccessibleDescription = resources.GetString("lnkStrap.AccessibleDescription");
			this.lnkStrap.AccessibleName = resources.GetString("lnkStrap.AccessibleName");
			this.lnkStrap.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lnkStrap.Anchor")));
			this.lnkStrap.AutoSize = ((bool)(resources.GetObject("lnkStrap.AutoSize")));
			this.lnkStrap.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lnkStrap.Dock")));
			this.lnkStrap.Enabled = ((bool)(resources.GetObject("lnkStrap.Enabled")));
			this.lnkStrap.Font = ((System.Drawing.Font)(resources.GetObject("lnkStrap.Font")));
			this.lnkStrap.Image = ((System.Drawing.Image)(resources.GetObject("lnkStrap.Image")));
			this.lnkStrap.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lnkStrap.ImageAlign")));
			this.lnkStrap.ImageIndex = ((int)(resources.GetObject("lnkStrap.ImageIndex")));
			this.lnkStrap.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lnkStrap.ImeMode")));
			this.lnkStrap.LinkArea = ((System.Windows.Forms.LinkArea)(resources.GetObject("lnkStrap.LinkArea")));
			this.lnkStrap.Location = ((System.Drawing.Point)(resources.GetObject("lnkStrap.Location")));
			this.lnkStrap.Name = "lnkStrap";
			this.lnkStrap.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lnkStrap.RightToLeft")));
			this.lnkStrap.Size = ((System.Drawing.Size)(resources.GetObject("lnkStrap.Size")));
			this.lnkStrap.TabIndex = ((int)(resources.GetObject("lnkStrap.TabIndex")));
			this.lnkStrap.Text = resources.GetString("lnkStrap.Text");
			this.lnkStrap.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lnkStrap.TextAlign")));
			this.lnkStrap.Visible = ((bool)(resources.GetObject("lnkStrap.Visible")));
			this.lnkStrap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkStrap_LinkClicked);
			// 
			// stsMain
			// 
			this.stsMain.AccessibleDescription = resources.GetString("stsMain.AccessibleDescription");
			this.stsMain.AccessibleName = resources.GetString("stsMain.AccessibleName");
			this.stsMain.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("stsMain.Anchor")));
			this.stsMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stsMain.BackgroundImage")));
			this.stsMain.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("stsMain.Dock")));
			this.stsMain.Enabled = ((bool)(resources.GetObject("stsMain.Enabled")));
			this.stsMain.Font = ((System.Drawing.Font)(resources.GetObject("stsMain.Font")));
			this.stsMain.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("stsMain.ImeMode")));
			this.stsMain.Location = ((System.Drawing.Point)(resources.GetObject("stsMain.Location")));
			this.stsMain.Name = "stsMain";
			this.stsMain.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("stsMain.RightToLeft")));
			this.stsMain.Size = ((System.Drawing.Size)(resources.GetObject("stsMain.Size")));
			this.stsMain.TabIndex = ((int)(resources.GetObject("stsMain.TabIndex")));
			this.stsMain.Text = resources.GetString("stsMain.Text");
			this.stsMain.Visible = ((bool)(resources.GetObject("stsMain.Visible")));
			// 
			// MainForm
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.stsMain);
			this.Controls.Add(this.lnkStrap);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.tabBackground);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "MainForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.tabBackground.ResumeLayout(false);
			this.tabConfiguration.ResumeLayout(false);
			this.tabAction.ResumeLayout(false);
			this.grpActions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgdMessages)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public String Username {
			get{ return txtUsername.Text; }
		}

		public String Uri {
			get{ return txtUri.Text; }
		}

		public String Password {
			get{ return txtPassword.Text; }
		}

		public void DisableControls() {
			btnRead.Enabled = false;
			btnProcess.Enabled = false;

			grpActions.Enabled = false;
			mnuActionDont.Enabled = false;
			mnuActionQuick.Enabled = false;
			mnuActionQueueTrash.Enabled = false;
			mnuActionQueue.Enabled = false;
			mnuActionForwardWhitelist.Enabled = false;
			mnuActionForward.Enabled = false;
			mnuActionDelete.Enabled = false;

			btnSetAll.Enabled = false;
			//btnSearch.Enabled = false;

			tmrProgress.Enabled = true;
		}

		public void EnableControls() {
			pgbMain.Value = 0;
			tmrProgress.Enabled = false;

			btnRead.Enabled = true;
			btnProcess.Enabled = true;

			grpActions.Enabled = true;
			mnuActionDont.Enabled = true;
			mnuActionQuick.Enabled = true;
			mnuActionQueueTrash.Enabled = true;
			mnuActionQueue.Enabled = true;
			mnuActionForwardWhitelist.Enabled = true;
			mnuActionForward.Enabled = true;
			mnuActionDelete.Enabled = true;

			btnSetAll.Enabled = true;
			//btnSearch.Enabled = true;
		}

		private void btnProcess_Click(object sender, System.EventArgs e) {
			int count = DeskScop.Instance().Messages.Count;
			DeskScop.Instance().Process( dgdMessages );
			btnRead.Enabled = true;
			SetSelectedAction( MessageAction.None );
			pgbMain.Value = 0;
			tmrProgress.Enabled = false;
			stsMain.Text = ( count - DeskScop.Instance().Messages.Count ) + " messages processed.";
		}

		private void btnRead_Click(object sender, System.EventArgs e) {
			if(	DeskScop.Instance().UiConfiguration.Password.Length == 0 &&
				MessageBox.Show(
					"You haven't entered a password. Do you want to continue?",
					"No password",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Warning
				) == DialogResult.Cancel )
				return;

			if(	DeskScop.Instance().Messages != null && DeskScop.Instance().Messages.Count > 0 &&
				MessageBox.Show(
				"You've already got read messages that you haven't processed. Do you really want to read them again?",
				"Reread messages?",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question
				) == DialogResult.No )
				return;

			SetSelectedAction( MessageAction.None );

			//Thread t = new Thread( new ThreadStart( updateForm ) );
			//t.Start();
			DeskScop.Instance().Read( dgdMessages );

			// Hack to fix status bar updating with no messages.
			tmrProgress.Enabled = false;
			//t.Join();
			//t.Suspend();

			btnRead.Enabled = true;
			stsMain.Text = DeskScop.Instance().Messages.Count + " messages read.";
		}

		/*public void updateForm() {
			while( true ) {
				//this.Refresh();
				Thread.Sleep( 100 );
			}
		}*/

		private void MainForm_Resize(object sender, System.EventArgs e) {
			tabBackground.Size = new Size( this.Size.Width - 27, this.Size.Height - 120 );
			dgdMessages.Size = new Size( tabBackground.Size.Width - 176, tabBackground.Size.Height - 40 );

			btnRead.Left = dgdMessages.Width + 16;
			grpActions.Left = dgdMessages.Width + 16;
			btnSetAll.Left = dgdMessages.Width + 16;
			btnProcess.Left = dgdMessages.Width + 16;	
			btnSearch.Left = dgdMessages.Width + 16;
			pgbMain.Left = dgdMessages.Width + 16;
		}

		private void tmrProgress_Tick(object sender, System.EventArgs e) {
			if( pgbMain.Value == 100 ) {
				pgbMain.Value = 0;
				return;
			}

			pgbMain.Value = pgbMain.Value + 10;
		}

		private void btnSetAll_Click(object sender, System.EventArgs e) {
			DisableControls();

			foreach( DataRow row in ((DataSet) dgdMessages.DataSource).Tables[0].Rows ) {
				row[ "Action" ] = GetCurrentAction();

				foreach( LothianProductions.DeskScop.SpamCop.Message message in DeskScop.Instance().Messages.GetUnderlyingValues() )
					message.Action = GetCurrentAction();
			}

			EnableControls();
		}

		#region Message action wireups

		private void rdoActionDont_CheckedChanged(object sender, System.EventArgs e) {
			if( rdoActionDont.Checked )
                SetMessageAction( MessageAction.None );
		}

		private void rdoActionQuick_CheckedChanged(object sender, System.EventArgs e) {
			if( rdoActionQuick.Checked )
				SetMessageAction( MessageAction.Quick );
		}

		private void rdoActionForward_CheckedChanged(object sender, System.EventArgs e) {
			if( rdoActionForward.Checked )
				SetMessageAction( MessageAction.Forward );
		}

		private void rdoActionForwardWhitelist_CheckedChanged(object sender, System.EventArgs e) {
			if( rdoActionForwardWhitelist.Checked )
				SetMessageAction( MessageAction.ForwardWhitelist );
		}

		private void rdoActionQueueTrash_CheckedChanged(object sender, System.EventArgs e) {
			if( rdoActionQueueTrash.Checked )
				SetMessageAction( MessageAction.QueueTrash );
		}

		private void rdoActionQueue_CheckedChanged(object sender, System.EventArgs e) {
			if( rdoActionQueue.Checked )
				SetMessageAction( MessageAction.Queue );
		}

		private void rdoActionDelete_CheckedChanged(object sender, System.EventArgs e) {
			if( rdoActionDelete.Checked )
				SetMessageAction( MessageAction.Delete );
		}

		private void mnuActionDont_Click(object sender, System.EventArgs e) {
			SetMessageAction( MessageAction.None );
		}

		private void mnuActionQueue_Click(object sender, System.EventArgs e) {
			SetMessageAction( MessageAction.Queue );
		}

		private void mnuActionQueueTrash_Click(object sender, System.EventArgs e) {
			SetMessageAction( MessageAction.QueueTrash );
		}

		private void mnuActionForwardWhitelist_Click(object sender, System.EventArgs e) {
			SetMessageAction( MessageAction.ForwardWhitelist );
		}

		private void mnuActionForward_Click(object sender, System.EventArgs e) {
			SetMessageAction( MessageAction.Forward );
		}

		private void mnuActionQuick_Click(object sender, System.EventArgs e) {
			SetMessageAction( MessageAction.Quick );
		}

		private void mnuActionDelete_Click(object sender, System.EventArgs e) {
			SetMessageAction( MessageAction.Delete );
		}

		#endregion

		private MessageAction GetCurrentAction() {
			if( ((DataSet) dgdMessages.DataSource).Tables[ "HeldMessages" ].Rows.Count == 0 )
				return MessageAction.None;

			CurrencyManager cm = (CurrencyManager) dgdMessages.BindingContext[ dgdMessages.DataSource, "HeldMessages" ];
			DataView dv = (DataView) cm.List;
			return (MessageAction) dv[ dgdMessages.CurrentRowIndex ][ "Action" ];
		}

		private void SetMessageAction( MessageAction action ) {
			if( ! GetCurrentAction().Equals( action ) ) {
				// Update form
				CurrencyManager cm = (CurrencyManager) dgdMessages.BindingContext[ dgdMessages.DataSource, "HeldMessages" ];
				DataView dv = (DataView) cm.List;

				dv[ dgdMessages.CurrentRowIndex ][ "Action" ] = (int) action;

				// Update underlying data
				DeskScop.Instance().Messages[ (int) dv[ dgdMessages.CurrentRowIndex ][ "Message ID" ] ].Action = action;
			}
		}

		private void dgdMessages_CurrentCellChanged(object sender, System.EventArgs e) {
			SetSelectedAction( GetCurrentAction() );
		}

		private void SetSelectedAction( MessageAction action ) {
			switch( action ) {
				case MessageAction.None:
					if( ! rdoActionDont.Checked )
						rdoActionDont.Checked = true;
					rdoActionQuick.Checked = false;
					rdoActionQueueTrash.Checked = false;
					rdoActionQueue.Checked = false;
					rdoActionForwardWhitelist.Checked = false;
					rdoActionForward.Checked = false;
					rdoActionDelete.Checked = false;

					if( ! mnuActionDont.Checked )
						mnuActionDont.Checked = true;
					mnuActionQuick.Checked = false;
					mnuActionQueueTrash.Checked = false;
					mnuActionQueue.Checked = false;
					mnuActionForwardWhitelist.Checked = false;
					mnuActionForward.Checked = false;
					mnuActionDelete.Checked = false;

					break;
				case MessageAction.Queue:
					rdoActionDont.Checked = false;
					rdoActionQuick.Checked = false;
					rdoActionQueueTrash.Checked = false;
					if( ! rdoActionQueue.Checked )
						rdoActionQueue.Checked = true;
					rdoActionForwardWhitelist.Checked = false;
					rdoActionForward.Checked = false;
					rdoActionDelete.Checked = false;

					mnuActionDont.Checked = false;
					mnuActionQuick.Checked = false;
					mnuActionQueueTrash.Checked = false;
					if( ! mnuActionQueue.Checked )
						mnuActionQueue.Checked = true;
					mnuActionForwardWhitelist.Checked = false;
					mnuActionForward.Checked = false;
					mnuActionDelete.Checked = false;

					break;
				case MessageAction.QueueTrash:
					rdoActionDont.Checked = false;
					rdoActionQuick.Checked = false;
					if( ! rdoActionQueueTrash.Checked )
						rdoActionQueueTrash.Checked = true;
					rdoActionQueue.Checked = false;
					rdoActionForwardWhitelist.Checked = false;
					rdoActionForward.Checked = false;
					rdoActionDelete.Checked = false;

					mnuActionDont.Checked = false;
					mnuActionQuick.Checked = false;
					if( ! mnuActionQueueTrash.Checked )
						mnuActionQueueTrash.Checked = true;
					mnuActionQueue.Checked = false;
					mnuActionForwardWhitelist.Checked = false;
					mnuActionForward.Checked = false;
					mnuActionDelete.Checked = false;

					break;
				case MessageAction.Forward:
					rdoActionDont.Checked = false;
					rdoActionQuick.Checked = false;
					rdoActionQueueTrash.Checked = false;
					rdoActionQueue.Checked = false;
					rdoActionForwardWhitelist.Checked = false;
					if( ! rdoActionForward.Checked )
						rdoActionForward.Checked = true;
					rdoActionDelete.Checked = false;

					mnuActionDont.Checked = false;
					mnuActionQuick.Checked = false;
					mnuActionQueueTrash.Checked = false;
					mnuActionQueue.Checked = false;
					mnuActionForwardWhitelist.Checked = false;
					if( ! mnuActionForward.Checked )
						mnuActionForward.Checked = true;
					mnuActionDelete.Checked = false;

					break;
				case MessageAction.ForwardWhitelist:
					rdoActionDont.Checked = false;
					rdoActionQuick.Checked = false;
					rdoActionQueueTrash.Checked = false;
					rdoActionQueue.Checked = false;
					if( ! rdoActionForwardWhitelist.Checked )
						rdoActionForwardWhitelist.Checked = true;
					rdoActionForward.Checked = false;
					rdoActionDelete.Checked = false;

					mnuActionDont.Checked = false;
					mnuActionQuick.Checked = false;
					mnuActionQueueTrash.Checked = false;
					mnuActionQueue.Checked = false;
					if( ! mnuActionForwardWhitelist.Checked )
						mnuActionForwardWhitelist.Checked = true;
					mnuActionForward.Checked = false;
					mnuActionDelete.Checked = false;

					break;
				case MessageAction.Quick:
					rdoActionDont.Checked = false;
					if( ! rdoActionQuick.Checked )
						rdoActionQuick.Checked = true;
					rdoActionQueueTrash.Checked = false;
					rdoActionQueue.Checked = false;
					rdoActionForwardWhitelist.Checked = false;
					rdoActionForward.Checked = false;
					rdoActionDelete.Checked = false;

					mnuActionDont.Checked = false;
					if( ! mnuActionQuick.Checked )
						mnuActionQuick.Checked = true;
					mnuActionQueueTrash.Checked = false;
					mnuActionQueue.Checked = false;
					mnuActionForwardWhitelist.Checked = false;
					mnuActionForward.Checked = false;
					mnuActionDelete.Checked = false;

					break;
				case MessageAction.Delete:
					rdoActionDont.Checked = false;
					rdoActionQuick.Checked = false;
					rdoActionQueueTrash.Checked = false;
					rdoActionQueue.Checked = false;
					rdoActionForwardWhitelist.Checked = false;
					rdoActionForward.Checked = false;
					if( ! rdoActionDelete.Checked )
						rdoActionDelete.Checked = true;

					mnuActionDont.Checked = false;
					mnuActionQuick.Checked = false;
					mnuActionQueueTrash.Checked = false;
					mnuActionQueue.Checked = false;
					mnuActionForwardWhitelist.Checked = false;
					mnuActionForward.Checked = false;
					if( ! rdoActionDelete.Checked )
						mnuActionDelete.Checked = true;

					break;
			}
		}

		private void lnkStrap_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start( e.Link.LinkData as String );
		}

		private void btnSearch_Click(object sender, System.EventArgs e) {
			new SearchForm().ShowDialog();
		}

		private void btnNext_Click(object sender, System.EventArgs e) {
			tabBackground.SelectedIndex = 1;
		}
	}
}
