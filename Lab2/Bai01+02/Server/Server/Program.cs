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
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                serverSocket.Bind(serverEndPoint);
                serverSocket.Listen(10);
                Console.WriteLine("Waiting.........");
                Socket clientSocket = serverSocket.Accept();
                EndPoint clientEndPoint = clientSocket.RemoteEndPoint;
                Console.WriteLine("Client co dia chi va port: " + clientEndPoint.ToString() + " da ket noi toi");
                byte[] buff;
                string huongDan = "Hello Client\n exit : thoat";
             
                buff = Encoding.ASCII.GetBytes(huongDan);

                clientSocket.Send(buff, 0, buff.Length, SocketFlags.None);
                Console.WriteLine("Nhan du lieu tu client gui len! \n");
                while (true)
                {
                    buff = new byte[1024];
                    int byteReceive = clientSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                    string str = Encoding.ASCII.GetString(buff, 0, byteReceive); 
                    Console.WriteLine(str);
                    if (str == "exit")
                    {
                        Console.WriteLine("Client da ngat ket noi!");
                        break;
                    }
                   
                    clientSocket.Send(buff, 0, byteReceive, SocketFlags.None);
                    
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Client ngat ket noi");
            }

          
        }
    }
}

