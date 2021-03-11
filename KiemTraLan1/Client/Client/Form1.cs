using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    

    public partial class Form1 : Form
    {
        StreamReader sr;
        StreamWriter sw;
        public void Connect()
        {
            try
            {
                richTextBox1.Text += "Đã kết nối tới Server \n";
                TcpClient client = new TcpClient("127.0.0.1", 5000);
                NetworkStream ns = client.GetStream();
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);
                string str = sr.ReadLine();
                AddTextFunction("Server: " + str);
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
        
        public void SendData(string text)
        {
            sw.WriteLine(text);
            sw.Flush();
            string str = sr.ReadLine();
            AddTextFunction(txtName.Text +": "+str);
        }
        public Form1()
        {
            InitializeComponent();
            Connect();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendData(String.Format(txtGetInfo.Text));

            richTextBox1.Text = String.Format("Tên: {0}", txtGetInfo.Text);
        }
        public void Receive()
        {
            string str = sr.ReadLine();
            richTextBox1.Text += str;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SendData(String.Format("{0};{1};{2}", txtName.Text, txtMSSV.Text, txtQueQuan.Text));

            richTextBox1.Text = String.Format("Tên: {0}\nMSSV: {1}\nQuê quán: {2}\n", txtName.Text, txtMSSV.Text, txtQueQuan.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
