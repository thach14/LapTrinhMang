using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace Server_Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(serverEndPoint);
            serverSocket.Listen(10);
            Socket clientSocket = serverSocket.Accept();
            EndPoint clientEndPoint = clientSocket.RemoteEndPoint;

            string str;

            byte[] buff ;

            try
            {
                buff = new byte[1024];
                int byteReceive = clientSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
                string kq = TinhToan(str).ToString();
                Console.WriteLine(kq);
                clientSocket.Send(Encoding.ASCII.GetBytes(kq));
            }
            catch
            {
                Console.WriteLine("Client da ngat ket noi!");
            }
            

        }
        public static int TinhToan(string phepTinh)
        {
            int kq = 0;
            if (phepTinh.IndexOf('+')!=-1)
            {
                string[] s = phepTinh.Split('+');
                kq = int.Parse(s[0]) + int.Parse(s[1]);
            }
            if (phepTinh.IndexOf('-') != -1)
            {
                string[] s = phepTinh.Split('-');
                kq = int.Parse(s[0]) - int.Parse(s[1]);
            }
            if (phepTinh.IndexOf('*') != -1)
            {
                string[] s = phepTinh.Split('*');
                kq = int.Parse(s[0]) * int.Parse(s[1]);
            }
            if (phepTinh.IndexOf('/') != -1)
            {
                string[] s = phepTinh.Split('/');
                kq = int.Parse(s[0]) / int.Parse(s[1]);
            }
            return kq;
        }
    }
}
