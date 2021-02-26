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
            IPEndPoint serEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Connecting to Server.........");


            try
            {
                serverSocket.Connect(serEndPoint);


                if (serverSocket.Connected)
                {
                    byte[] buff = new byte[100];

                    int byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                    string str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                    Console.WriteLine(str);
                    Console.WriteLine("Nhap du lieu gui len Server: \n");

                    while (true)
                    {
                        str = Console.ReadLine(); buff = Encoding.ASCII.GetBytes(str);
                        serverSocket.Send(buff, 0, buff.Length, SocketFlags.None); buff = new byte[1024];
                        byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                        str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                        Console.WriteLine(str);
                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong the ket noi toi Server");
            }

        }
    }
}
