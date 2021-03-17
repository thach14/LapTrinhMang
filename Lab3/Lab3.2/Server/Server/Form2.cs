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

namespace Server
{
    public partial class Form2 : Form
    {
        TcpListener server;
        StreamReader sr;
        StreamWriter sw;
        public Form2()
        {
            InitializeComponent();
            Receive();
        }
        public void SendData(string text)
        {
            sw.WriteLine(text);
            sw.Flush();
            string str = sr.ReadLine();
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendData(textBox1.Text);
        }
        public void Receive()
        {
            string str = sr.ReadLine();
            listBox1.Items.Add(str);
        }
    }
}
