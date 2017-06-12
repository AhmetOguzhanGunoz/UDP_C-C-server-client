using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Client
{
    class Client
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient("127.0.0.1", 9050);
            byte[] data = new byte[1024];

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string welcome = "Hi, are there anybody?";
            data = Encoding.ASCII.GetBytes(welcome);

            server.SendTo(data, data.Length, SocketFlags.None, ipep);

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)sender;

            data = new byte[1024];
            int recv = server.ReceiveFrom(data,ref Remote);

            Console.WriteLine("Message from {0}: ", Remote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data,0,recv));

            Console.ReadLine();
            server.Close();
        }
    }
}
