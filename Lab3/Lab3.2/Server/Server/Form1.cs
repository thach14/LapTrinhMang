using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public delegate void AddTextEvenHandle(object sender, AddTextEvenArgs AddTextEA);
        public event AddTextEvenHandle OnAddText;
        List<Client> list = new List<Client>();
        UdpClient server = new UdpClient(5000);
        public void Start()
        {
            Thread mainThread = new Thread(new ThreadStart(ClientConnected));
            mainThread.Start();

        }
        
        void ClientConnected()
        {
            try
            {
                IPEndPoint clientEP = new IPEndPoint(IPAddress.Any, 5000);
                byte[] data = server.Receive(ref clientEP);
                string str = Encoding.ASCII.GetString(data);
                richTextBox1.Text += clientEP.ToString() + ": "+str +"\n";
                richTextBox2.Text += clientEP.ToString() + "\n";
                str = "hello Client";
                data = Encoding.ASCII.GetBytes(str);
                server.Send(data, data.Length, clientEP);

                while (true)
                { 
                    data = new byte[1024];
                    data = server.Receive(ref clientEP);
                    str = Encoding.ASCII.GetString(data);
                    richTextBox1.Text += clientEP.ToString() + ": " + str + "\n";
                    server.Send(data, data.Length, clientEP);
                }
            }
            catch
            {
                richTextBox1.Text += "\n Client đã ngắt kết nối";
            }
        }
       
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Server: Started Server!\n";
            Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class AddTextEvenArgs : EventArgs
    {
        string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public AddTextEvenArgs (string Text )
        {
            this.text = Text;
        }
    }
}
