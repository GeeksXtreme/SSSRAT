using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Public {
	public class _ {
		public const string PROGRAM_NAME = "SSSRAT";
		public const string VERSION = "v0.3.1";
		public const int MAX_BUFFER = 8192;
		public const string SPLITTER = "{_$}";
		public static int port = 13337;
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
	}



	public struct Client {
		public readonly uint id;
		public TcpClient tcp;
		public readonly Thread ka;
		public readonly ListViewItem lvi;
		public Client(uint Id, TcpClient Tcp, Thread Ka, ListViewItem Lvi) {
			id = Id;
			tcp = Tcp;
			ka = Ka;
			lvi = Lvi;
		}
	}
}
