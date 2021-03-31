using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using MayTinh;
using NetLib;
using System.Net;
using System.Net.Sockets;
using System.IO;
using NetLib;
using System.Diagnostics;
namespace ThuBaiThi
{
    public partial class FrmServer : Form
    {

        ServerThread serverThread;
        Thread t, CommandProcessThread, threadDemLuiThoiGian;
        Thread copyDir;

        MangMayTinh mangMayTinh= new MangMayTinh();
        Thread threadXuatMayTinh;
        ArrayList DSDeThi = new ArrayList();

        private void Form1_Load(object sender, EventArgs e)
        {
            
           serverThread = new ServerThread();
        }

        #region It Khi dung den

        public delegate void SetTextCallBack(string text);


        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {

        }
        public FrmServer()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox99_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (t != null)
                t.Abort();
            
            serverThread.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void mnuSetIP_Click(object sender, EventArgs e)
        {
            
        }

        void NhapDanhSachIP()
        {
            FrmSetIP frmSetIP = new FrmSetIP();
            frmSetIP.ShowDialog();
            // mangMayTinh = serverThread.AddMayTinh("192.168.255.1", "192.168.255.60", "255.255.255.0");

            // this.MainGroupBox.Controls.Add(mangMayTinh);

            mangMayTinh = serverThread.AddMayTinh(StaticInfo.FirstIP, StaticInfo.LastIP, StaticInfo.SubnetMask);
            this.MainGroupBox.Controls.Add(mangMayTinh);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            

        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

       

        #endregion

        

        private void cmdChon_Click(object sender, EventArgs e)
        {
           
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            
        }

        private void DisableAllControl()
        { 
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
           
        }

        private void cmdGoiDeThi_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdBatDauLamBai_Click(object sender, EventArgs e)
        {

        }



        private void txtServerPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdChonClientPath_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmdKichHoatAllClient_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }


       

       

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void cmdNhapVungIP_Click(object sender, EventArgs e)
        {
            NhapDanhSachIP();
        }

        
    }
}