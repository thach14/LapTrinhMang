using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        private static int SendData(Socket s, byte[] data)
        {
            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            sent = s.Send(datasize);
            while (total < size)
            {
                sent = s.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }
            return total;
        }
        private static byte[] ReceiveVarData(Socket s)
        {
            int total = 0;
            int recv;
            byte[] datasize = new byte[4];
            recv = s.Receive(datasize, 0, 4, 0);
            int size = BitConverter.ToInt32(datasize, 0);
            int dataleft = size;
            byte[] data = new byte[size];
            while (total < size)
            {
                recv = s.Receive(data, total, dataleft, 0);
                if (recv == 0)
                {
                    data = Encoding.ASCII.GetBytes("exit ");
                    break;
                }
                total += recv;
                dataleft -= recv;
            }
            return data;
        }
        private static int SendVarData(Socket s, byte[] data)
        {
            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            sent = s.Send(datasize);
            while (total < size)
            {
                sent = s.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }
            return total;
        }

        static void Main(string[] args)
        {
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(serverEndPoint);
                serverSocket.Listen(10);
                Console.WriteLine("Waiting.........");
                Socket clientSocket = serverSocket.Accept();
                EndPoint clientEndPoint = clientSocket.RemoteEndPoint;

                Console.WriteLine("Client co dia chi va port: " + clientEndPoint.ToString() + " da ket noi toi");
                byte[] buff;
                string hello = "Hello Client\n";
             
                buff = Encoding.ASCII.GetBytes(hello);

                SendVarData(clientSocket, buff);
                Console.WriteLine("Nhan du lieu tu client gui len! \n");
                /* while (true)
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

                 }*/

                
                
                try
                {
                    for (int i = 0; i < 5; i++)
                    {
                        buff = ReceiveVarData(clientSocket);
                        Console.WriteLine(Encoding.ASCII.GetString(buff, 0, buff.Length));
                    }
                    while (true)
                    {
                        NetworkStream ns = new NetworkStream(clientSocket);
                        StreamReader sr = new StreamReader(ns);
                        StreamWriter sw = new StreamWriter(ns);
                        var data = sr.ReadLine();
                        Console.WriteLine(data);
                    }
                }
                catch
                {
                    Console.WriteLine("Client da ngat ket noi!");
                }

            }
            

          
        }
    }


