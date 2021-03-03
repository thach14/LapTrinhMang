using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        private static int SendData(Socket s, byte[] data)
        {
            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;
            while (total < size)
            {
                sent = s.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }
            return total;
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


        static void Main(string[] args)
        {
            string str;
            IPEndPoint serEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Connecting to Server.........");
            byte[] buff = new byte[1024];



            try
            {
                serverSocket.Connect(serEndPoint);
            }
            catch
            {
                Console.WriteLine("Khong the ket noi toi server");
                return;
            }


            if (serverSocket.Connected)
            {

                try
                {
                    Console.WriteLine("Ket noi thanh cong voi server: \n");
                    buff = ReceiveVarData(serverSocket);
                    str = Encoding.ASCII.GetString(buff, 0, buff.Length);
                    Console.WriteLine(str);

                    /*  while (true)
                      {
                          str = Console.ReadLine();

                          buff = Encoding.ASCII.GetBytes(str);
                          serverSocket.Send(buff, 0, buff.Length, SocketFlags.None); buff = new byte[1024];
                          byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                          str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                          Console.WriteLine(str);

                      }
                      SendData(serverSocket, Encoding.ASCII.GetBytes("Thong Diep 1"));
                      SendData(serverSocket, Encoding.ASCII.GetBytes("Thong Diep 2"));
                      SendData(serverSocket, Encoding.ASCII.GetBytes("Thong Diep 3"));
                      SendData(serverSocket, Encoding.ASCII.GetBytes("Thong Diep 4"));
                      SendData(serverSocket, Encoding.ASCII.GetBytes("Thong Diep 5"));
                      */

                    string message1 = "Thong diep dau tien";
                    string message2 = "Thong diep ngan";
                    string message3 = "Day la thong diep dai hon";
                    string message4 = "Xin chao, day la thong diep dai nhat";
                    string message5 = "Ngan nhat";
                    SendVarData(serverSocket, Encoding.ASCII.GetBytes(message1));
                    SendVarData(serverSocket, Encoding.ASCII.GetBytes(message2));
                    SendVarData(serverSocket, Encoding.ASCII.GetBytes(message3));
                    SendVarData(serverSocket, Encoding.ASCII.GetBytes(message4));
                    SendVarData(serverSocket, Encoding.ASCII.GetBytes(message5));


                    while (true)
                    {
                        NetworkStream ns = new NetworkStream(serverSocket);
                        StreamReader sr = new StreamReader(ns);
                        StreamWriter sw = new StreamWriter(ns);
                        var input = Console.ReadLine();
                        if (input == "exit")
                            break;
                        sw.WriteLine(input);
                        sw.Flush();
                    }


                }

                catch (Exception)
                {
                    Console.WriteLine("Server bi ngat ket noi");
                }


            }
        }
    }
}
