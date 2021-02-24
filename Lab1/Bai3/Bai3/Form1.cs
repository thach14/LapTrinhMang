using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPhanGiai_Click(object sender, EventArgs e)
        {
            string tenmien = txtTenMien.Text;
            lblKetQua.Text = PhanGiaiTenMien(tenmien);
        }
        private string PhanGiaiTenMien (string tenmien)
        {
            string kq = "";
            IPHostEntry hostInfo = Dns.GetHostEntry(tenmien);
            kq += "Ten mien: " + hostInfo.HostName +"\n" + "Dia chi IP: \n";
            foreach (IPAddress ip in hostInfo.AddressList)
            {
                kq += ip.ToString() + "";

            }
            return kq;
        }
    }
}
