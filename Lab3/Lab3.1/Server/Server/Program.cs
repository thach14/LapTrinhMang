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
            string str;
            int byteReceive;
            byte[] buff = new byte[1024];
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverSocket.Bind(serverEndPoint);
            Console.WriteLine("Dang cho client ket noi den......");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remote = (EndPoint)(sender);

            byteReceive = serverSocket.ReceiveFrom(buff, ref remote);
            Console.WriteLine("Thong diep duoc nhan tu {0}:", remote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(buff, 0, byteReceive));
            

            
            Console.WriteLine("Client ket noi toi: {0}",remote.ToString());
            /*    while (true)
                {
                    buff = new byte[1024];
                    serverSocket.ReceiveFrom(buff, 0, buff.Length, SocketFlags.None, ref remote);
                    str = Encoding.ASCII.GetString(buff).ToString();
                    
                    Console.WriteLine(str);

                }*/
            while (true)
            {
                buff = new byte[1024];
                byteReceive = serverSocket.ReceiveFrom(buff, 0, buff.Length, SocketFlags.None,ref remote);
                str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
                if (str.Replace("\0", "").Equals("exit all")) break;
                serverSocket.SendTo(buff, 0, buff.Length, SocketFlags.None, remote);
            }

        }
    }
}
