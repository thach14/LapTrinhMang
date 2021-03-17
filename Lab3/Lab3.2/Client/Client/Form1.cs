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

namespace Client
{
    

    public partial class Form1 : Form
    {
        IPEndPoint server = new IPEndPoint(IPAddress.Loopback, 5000);

        UdpClient client = new UdpClient("127.0.0.1", 5100);
        
        public Form1()
        {
            InitializeComponent(); client.Connect(server);
        }
        public void Connect()
        {
            
            try
            {
               
                    string str = txtChat.Text;
                byte[] data = Encoding.ASCII.GetBytes(str);
                client.Send(data, data.Length);
                AddTextFunction("Me: " + str);
                
                    data = new byte[1024];
                    IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);
                    data =  client.Receive(ref remote);
                AddTextFunction("Server: " + Encoding.ASCII.GetString(data));
                str = Encoding.ASCII.GetString(data);
            }
            catch
            {
                richTextBox1.Text = "Chưa kết nối tới Server";
            }
        }
        public void AddTextFunction(string str)
        {
            richTextBox1.Text += str + "\n";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            Connect();
        }

       public void Start()
        {
            Thread t = new Thread(Connect);
            t.Start();
        }
    }
}
