namespace SSSRAT_GUI {
	partial class FrmCMD {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCMD));
			this.t_main = new System.Windows.Forms.TextBox();
			this.t_cmd = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// t_main
			// 
			this.t_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.t_main.BackColor = System.Drawing.Color.Black;
			this.t_main.ForeColor = System.Drawing.Color.White;
			this.t_main.Location = new System.Drawing.Point(-1, 0);
			this.t_main.Multiline = true;
			this.t_main.Name = "t_main";
			this.t_main.Size = new System.Drawing.Size(449, 213);
			this.t_main.TabIndex = 0;
			// 
			// t_cmd
			// 
			this.t_cmd.Location = new System.Drawing.Point(-1, 211);
			this.t_cmd.Name = "t_cmd";
			this.t_cmd.Size = new System.Drawing.Size(449, 20);
			this.t_cmd.TabIndex = 1;
			this.t_cmd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TCMDKeyUp);
			// 
			// frm_cmd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 231);
			this.Controls.Add(this.t_cmd);
			this.Controls.Add(this.t_main);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmCMD";
			this.Text = "CMD (N/A)";
			this.Load += new System.EventHandler(this.FrmCMDLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox t_main;
		private System.Windows.Forms.TextBox t_cmd;
	}
}