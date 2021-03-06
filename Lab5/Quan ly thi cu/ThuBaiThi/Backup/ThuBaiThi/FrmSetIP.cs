using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ThuBaiThi
{
    public partial class FrmSetIP : Form
    {
        public FrmSetIP()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (this.txtIP.Text.IndexOf('-') == -1)
                MessageBox.Show("Địa chỉ IP không hợp lệ");
            else
            {
                string[] arrayIP = this.txtIP.Text.Split('-');
                StaticInfo.FirstIP = arrayIP[0].Trim();
                StaticInfo.LastIP = arrayIP[1].Trim();
                StaticInfo.SubnetMask = this.txtSubnetMask.Text.Trim();
                this.Close();
            }
            
        }
    }
}