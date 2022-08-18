
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{

	class Program
	{
		static void Main(string[] args)
		{
			ExecuteClient();
		}
		static void ExecuteClient()
		{

			try
			{
				IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
				IPAddress ipAddr = ipHost.AddressList[0];
				IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);
				Socket server = new Socket(ipAddr.AddressFamily,
						   SocketType.Stream, ProtocolType.Tcp);

				server.Connect(localEndPoint);

				while (true)
				{
					Console.WriteLine("Message:");
					string msg = Console.ReadLine();
					if (msg=="quit")
                    {
						break;
                    }
					byte[] messageSent = Encoding.ASCII.GetBytes(msg + "<EOF>");
					int byteSent = server.Send(messageSent);

					byte[] bytes = new Byte[1024];
					string data = null;

					while (true)
					{

						int numByte = server.Receive(bytes);

						data += Encoding.ASCII.GetString(bytes,
												0, numByte);

						if (data.IndexOf("<EOF>") > -1)
							break;
					}
					Console.WriteLine("Server -> {0} ", data);
				}
				server.Shutdown(SocketShutdown.Both);
				server.Close();
			
			}

			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
	}
}
