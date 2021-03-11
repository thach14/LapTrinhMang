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
    public class Client
    {
        string name; 
        string mssv;
        string queQuan;
        public Client()
        {

        }
        public Client(string ten, string maSo, string quequan)
        {
            name = ten; mssv = maSo; queQuan = quequan;
        }
        public string Name { get { return name; } set { name = value; } }
        public string MSSV { get { return mssv; } set { mssv = value; } }
        public string QueQuan { get { return queQuan; } set { queQuan = value; } }
    }
    public class QuanLyClient
    {
        public List<Client> list { get; set; }
        public QuanLyClient()
        {
            list = new List<Client>();
        }
        public QuanLyClient(List<Client> list)
        {
            this.list = list;
        }
        public Client TimKiemTheoMSSV(string mssv)
        {
            foreach (Client item in list)
            {
                if (item.MSSV == mssv)
                    return item;
            }
            return null;
        }
        public void GhiThongTinVaoFile()
        {
            string filepath = "E:\\Dev\\DEV\\LapTrinhMang\\KiemTraLan1\\Server\\Server\\DanhSach.txt";
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);

            foreach (Client item in list)
            {

                writer.WriteLine(item.MSSV);
                writer.WriteLine(item.Name);
                writer.WriteLine(item.QueQuan);
                writer.WriteLine();
            }
            fs.Close();
            
            
        }
    }
    
   
}
