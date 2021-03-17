using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);

            string str = "Hello Server gap";
            byte[] buff = new byte[1024];
            EndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            buff = Encoding.ASCII.GetBytes(str);
            server.SendTo(buff, buff.Length, SocketFlags.None, serverEndPoint);
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remote = (EndPoint)sender;


             while (true)
             {
                 buff = new byte[1024];
                 Console.WriteLine("Nhap du lieu len server: ");
                 str = Console.ReadLine();
                 buff = Encoding.ASCII.GetBytes(str);
                 server.SendTo(buff, buff.Length, SocketFlags.None, serverEndPoint);
                 if (str == "exit" || str == "exit all") break;
            buff = new byte[1024];
                server.ReceiveFrom(buff, 0, buff.Length, SocketFlags.None, ref remote);
                str = Encoding.ASCII.GetString(buff, 0,buff.Length);
                Console.WriteLine(str);
             }

            
        }
    }
}
