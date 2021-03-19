using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        byte[] buff;
        int byteReceive;
        Socket clientSocket;
        Socket serverSocket;
        IPEndPoint serverEndPoint;
        string str;
        public delegate void SetTextDelegate(string Text);
        public SetTextDelegate SetTextFunction = null;

        public void StartServer()
        {
            serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(serverEndPoint);
            serverSocket.Listen(10);
            richTextBox1.Text += "Dang cho client ket noi!!!\n";
           serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), serverSocket);
        }
        void AcceptCallback(IAsyncResult ia)
        {
            buff = Encoding.ASCII.GetBytes("Hello client");
            
            serverSocket = (Socket)ia.AsyncState;
            clientSocket = serverSocket.EndAccept(ia);
            clientSocket.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendCallback), clientSocket);


        }
        void SendCallback(IAsyncResult ia)
        {
            clientSocket.EndSend(ia);
           
            clientSocket.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);
        }



        void ReceiveCallback(IAsyncResult ia)
        {
            serverSocket = (Socket)ia.AsyncState;
            byteReceive = serverSocket.EndReceive(ia);
            str = Encoding.ASCII.GetString(buff, 0 , byteReceive);
            richTextBox1.Text += clientSocket.RemoteEndPoint.ToString()+ ": " + str + "\n" ;
            clientSocket.BeginSend(buff, 0, byteReceive, SocketFlags.None, new AsyncCallback(SendCallback), clientSocket);

        }


        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
                StartServer();
            
        }
    }
}
