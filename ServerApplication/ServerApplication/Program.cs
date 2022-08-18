
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{

	class Program
	{

		static void Main(string[] args)
		{
			ExecuteServer();
		}

		public static void ExecuteServer()
		{
			IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
			IPAddress ipAddr = ipHost.AddressList[0];
			IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);
			Socket listener = new Socket(ipAddr.AddressFamily,
						 SocketType.Stream, ProtocolType.Tcp);
			try
			{

				listener.Bind(localEndPoint);
				listener.Listen(100);
				Socket clientSocket = listener.Accept();

				while (true)
				{
					byte[] bytes = new Byte[1024];
					string data = null;

					while (true)
					{

						int numByte = clientSocket.Receive(bytes);

						data += Encoding.ASCII.GetString(bytes,
												0, numByte);

						if (data.IndexOf("<EOF>") > -1)
							break;
					}


					Console.WriteLine("Client -> {0} ", data);

					Console.WriteLine("Message:");
					string msg = Console.ReadLine();
					if (msg == "quit")
					{
						break;
					}
					byte[] message = Encoding.ASCII.GetBytes(msg+"<EOF>");
					clientSocket.Send(message);
				}
				clientSocket.Shutdown(SocketShutdown.Both);
				clientSocket.Close();
			}

			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
	}
}
