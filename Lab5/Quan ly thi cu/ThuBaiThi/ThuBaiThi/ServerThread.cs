using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections;
using MayTinh;
using NetLib;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;		

namespace ThuBaiThi
{
    class ServerThread
    {
        public ArrayList ListClient = new ArrayList();
        public TcpListener listener;
      
        public Queue InQueue = new Queue();
        public Queue OutQueue = new Queue();
        public Queue CommandQueue = new Queue();
        public Queue inCommandQueue = new Queue();


        StreamReader sr;
       
        StreamWriter sw;
        Thread mainThread;
        Thread t;

        Thread sendCommand;
        Thread receiveCommand;

        NetworkStream serverNS;
        StreamReader serverSR;
        StreamWriter serverSW;

        public ServerThread()
        {
            listener = new TcpListener(3000);
            listener.Start();
            OutQueue.Enqueue("Dang cho ket noi den...");
            mainThread = new Thread(new ThreadStart(Tam));
            
            mainThread.Start();

            sendCommand = new Thread(new ThreadStart(SendCommand));
            sendCommand.Start();

            receiveCommand = new Thread(new ThreadStart(ProcessCommand));
            receiveCommand.Start();

        }

        public void ReceiveCommand()
        {
           
        }

        public void ProcessCommand()
        {
            
        }


      

        public void Close()
        {
            if (mainThread != null)
                mainThread.Abort();
            if (t != null)
                t.Abort();

            if(sendCommand != null)
                sendCommand.Abort();
            if(receiveCommand != null)
                receiveCommand.Abort();
        }

        public void SendCommand()
        {
            
        }

       

        public void Tam()
        {
            while (true)
            {
                while (!listener.Pending())
                {
                    Thread.Sleep(1000);
                }
               
                TcpClient clientToHandle = listener.AcceptTcpClient();
                ListClient.Add(clientToHandle);

                IPEndPoint remoteEP = (IPEndPoint)clientToHandle.Client.RemoteEndPoint;
                string IP = remoteEP.Address.ToString();
             

                serverNS = clientToHandle.GetStream();
                serverSR = new StreamReader(serverNS);
                serverSW = new StreamWriter(serverNS);
                receiveCommand = new Thread(new ThreadStart(ReceiveCommand));
                receiveCommand.Start();
            

            }
        }

        MangMayTinh mangMayTinh;
        ArrayList list; 

        public  MangMayTinh AddMayTinh(string FirstIP, string LastIP, string SubnetMask)
        {

            MayTinh.MayTinh mt;
            list = new ArrayList();
            list = this.InitIpRange(FirstIP, LastIP, SubnetMask);
            mangMayTinh = new MangMayTinh(list);
            mangMayTinh.Location = new Point(20, 20);
            return mangMayTinh;
        }
        
        
        public void HandleConnection()
        {

            TcpListener threadListener = listener;
            TcpClient clientToHandle = listener.AcceptTcpClient();
            ListClient.Add(clientToHandle);

            IPEndPoint remoteEP = (IPEndPoint) clientToHandle.Client.RemoteEndPoint;
            string IP = remoteEP.Address.ToString();
            this.mangMayTinh.SetStatusClientConnected(IP);
         
            clientToHandle.Close();

        }

       

        private void ThreadSendMessage(object Data)
        {
            string temp = (string)Data;
            string IP = temp.Split('-')[0];
            string MessageToClient = temp.Split('-')[1];

            MayTinh.MayTinh mt = mangMayTinh.GetMayTinh(IP);

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(mt.IP), mt.Port);
            TcpClient client = new TcpClient(ep);
            NetworkStream ns = client.GetStream();
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(MessageToClient);
            ns.Write(data, 0, data.Length);
            ns.Close();
            client.Close();
        }

        

        public ArrayList InitIpRange(string FirstIP, string LastIP, string SubnetMask)
        {
            ArrayList listIP = new ArrayList();
            try
            {
                string s1 = "", s2 = "";
                int y = 0, x = 0, z = 0, t = 0;
                if (FirstIP != "")
                {
                    s1 = FirstIP.Substring(0, FirstIP.LastIndexOf("."));
                    x = int.Parse(FirstIP.Substring(FirstIP.LastIndexOf(".") + 1));
                }
                if (LastIP != "")
                {
                    s2 = LastIP.Substring(0, LastIP.LastIndexOf("."));
                    y = int.Parse(LastIP.Substring(LastIP.LastIndexOf(".") + 1));
                }
                t = y - x;
                if (SubnetMask != "")
                    z = 256 - int.Parse(SubnetMask.Substring(SubnetMask.LastIndexOf(".") + 1));
                if (x < 255 && y < 255 && s1.CompareTo(s2) == 0)
                    listIP = XuatIP(x, y, z);
                else
                    MessageBox.Show("Nhập sai");
            }
            catch
            {
                MessageBox.Show("Nhập IP sai");
            }
            return listIP;
        }

        public ArrayList XuatIP(int batdau, int cuoi, int chieudai)
        {
            ArrayList tam = new ArrayList();
            for (int i = batdau; i < chieudai && i <= cuoi; i++)
            {
                string ip = "192.168.255." + i.ToString();
                MayTinh.MayTinh temp = new MayTinh.MayTinh();
                temp.IP = ip;
                tam.Add(temp);
            }
            return tam;
        }
    }
}
