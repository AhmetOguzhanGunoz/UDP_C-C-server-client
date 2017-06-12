using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Server
{
    class Server
    {
        static void Main(string[] args)
        {
            int recv;
            byte[] data = new byte[1024];

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            newsock.Bind(ipep);

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)sender;

            recv = newsock.ReceiveFrom(data, ref Remote);
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

            string welcome = "welcome to test server";
            data = Encoding.ASCII.GetBytes(welcome);
            newsock.SendTo(data, data.Length, SocketFlags.None, Remote);

            Console.ReadLine();
        }
    }
}
