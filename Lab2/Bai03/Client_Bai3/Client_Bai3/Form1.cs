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

namespace Client_Bai3
{
    public partial class Form1 : Form
    {
        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form1()
        {
            InitializeComponent();
            ConnectToServer();
        }


        public void ConnectToServer()
        {
            try
            {
                serverSocket.Connect(serverEndPoint);       
            }
            catch
            {
                toolStripStatusLabel1.Text = "Mất kết nối với Server!";
                return;
            }
            if (serverSocket.Connected)
            {
                toolStripStatusLabel1.Text = "Đã kết nối thành công tới Server!";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            TinhToan();
        }
        public void TinhToan()
        {
            byte[] buff = new byte[1024];
            serverSocket.Send(Encoding.ASCII.GetBytes(txtPhepTinh.Text));
            int byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
            txtKetQua.Text = Encoding.ASCII.GetString(buff, 0, byteReceive);
        }
    }
}
