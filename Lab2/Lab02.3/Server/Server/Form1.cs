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
        TcpListener server;
        public void Start()
        {
            Thread mainThread = new Thread(new ThreadStart(StartConnection));
            mainThread.Start();

        }
        void StartConnection()
        {
            server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            while (true)
            {
               
                Thread clientThread = new Thread(new ThreadStart(ClientConnected));
                clientThread.Start();
            }
        }
        void ClientConnected()
        {
            try
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream ns = client.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
             
                string str = "hello Client\n";
                sw.WriteLine(str);
                sw.Flush();
                richTextBox2.Text += client.Client.RemoteEndPoint.ToString() + "\n";
                while (true)
                {
                    str = sr.ReadLine();
                    if (OnAddText != null)
                    {
                        this.OnAddText(this, new AddTextEvenArgs(client.Client.RemoteEndPoint.ToString() + ": " + str));

                    }
                    sw.WriteLine();
                    sw.Flush();
                    richTextBox1.Text += str + "\n";
                    
                  //  string ip = client.Client.RemoteEndPoint.ToString();
                  //  string nickname = str.ToString();
                  // Client item = new Client(ip, nickname.ToString());
                  //list.Add(item);
                  //  LoadListView(list);
                }
 
            }
            catch
            {
                richTextBox1.Text += "\n Client đã ngắt kết nối";
            }
        }
        // public void LoadListView(List<Client> list)
        /*{
            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add(list[i].ToString());
                lvi.SubItems.Add(list[i].ToString());
                listView1.Items.Add(lvi);
            }
        }*/
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
