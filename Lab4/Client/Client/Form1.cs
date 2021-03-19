using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
     
        byte[] buff;
        int byteReceive;
        Socket clientSocket;
        IPEndPoint clientEndPoint;
        string str;
        public delegate void SetTextDelegate(string Text);
        public SetTextDelegate SetTextFunction = null;
        public void Connect()
        {
            clientEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
           
            clientSocket.BeginConnect(clientEndPoint,new AsyncCallback(ConnectCallback), clientSocket );
        }
        void ConnectCallback(IAsyncResult ia)
        {
            buff = new byte[1024];
            clientSocket = (Socket)ia.AsyncState;
            clientSocket.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);


        }
        void SendCallback(IAsyncResult ia)
        {
           

            clientSocket = (Socket)ia.AsyncState;
            
            clientSocket.EndSend(ia);
            richTextBox1.Text += "Me: " + txtChat.Text+"\n";
            txtChat.Text = "";
            clientSocket.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);
        }



        void ReceiveCallback(IAsyncResult ia)
        {
            
            clientSocket = (Socket)ia.AsyncState;
            byteReceive = clientSocket.EndReceive(ia);
            str = Encoding.ASCII.GetString(buff, 0, byteReceive);
            richTextBox1.Text +=  "Server: " + str + "\n";
            

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }

        public void Send()
        {
            buff = Encoding.ASCII.GetBytes(txtChat.Text);
            clientSocket.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendCallback), clientSocket);

        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
        }
    }
}
