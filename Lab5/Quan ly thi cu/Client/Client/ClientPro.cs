using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections;
using NetLib;
using System.Windows.Forms;
using System.Diagnostics;
	
namespace Client
{

    class ClientPro
    {
        Thread t, sendThread, receiveThread;
        public Queue outQueue = new Queue();
        public Queue inQueue = new Queue();
        public Queue inCommandQueue = new Queue();

        public Queue CommandQueue = new Queue();

        NetworkStream ns;
        StreamWriter sw;
        StreamReader sr;
        TcpClient client;
        private string Name = "";
        public string CurrDir = "";
        public string ClientPath = "";
        public string ServerPath = "";
        public string ServerShareName = "";


        public void Connect(string TenServer)
        {
            try
            {

                client = new TcpClient(TenServer , 3000);
                ns = client.GetStream();
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);

                sendThread = new Thread(new ThreadStart(Send));
                sendThread.Start();

                receiveThread = new Thread(new ThreadStart(Receive));
                receiveThread.Start();
                inQueue.Enqueue("Ket noi thanh cong");
                string tenmay = Dns.GetHostName();
                CommandQueue.Enqueue(NetCommand.Connect + "-" +  tenmay);
                
                CommandQueue.Enqueue(NetCommand.StatusConnect + "-Thanh Cong");
            }
            catch
            {
                CommandQueue.Enqueue(NetCommand.StatusConnect + "-That Bai");
                MessageBox.Show("Server chưa sẵng sàng");

            }
        }

        public void SendMSSV(string MSSV)
        {
           
            CommandQueue.Enqueue(NetCommand.CombineCommandParam(NetCommand.MSSV, MSSV + '`' + Dns.GetHostName()));
        }

        public void GoiBaiThiLenServer()
        {
            string rarPath = Environment.CurrentDirectory + "\\rar.exe";
            IPEndPoint ep = (IPEndPoint)client.Client.RemoteEndPoint;
            string ServerDir = @"\\" + ep.Address.ToString() + @"\" +  ServerPath+ "\\" + CurrDir;
            string clientpath = ClientPath + "\\" + CurrDir;
            string command = "a " + ServerDir + "  " + clientpath;
            Process.Start(rarPath, command);
            
        }

        public void Send()
        {
            while (true)
            {

                if (CommandQueue.Count > 0)
                {
                    string s = CommandQueue.Dequeue().ToString();
                    //MessageBox.Show(s);
                    sw.WriteLine(s);
                    sw.Flush();
                }
                Thread.Sleep(100);
            }

        }

        public void Receive()
        {
            while (true)
            {

                string s = "";
                try
                {
                    s = sr.ReadLine();
                    inCommandQueue.Enqueue(s);
                   //MessageBox.Show("Nhan duoc phia client: " + s);
                }
                catch { }



                Thread.Sleep(100);
            }
        }



        public void InPut(string text)
        {
            outQueue.Enqueue(text);
            inQueue.Enqueue(text);

        }

        public void Close()
        {
            if (t != null)
                t.Abort();
            if (receiveThread != null)
                receiveThread.Abort();
            if (sendThread != null)
                sendThread.Abort();
            if (ns != null)
                ns.Close();
            if (sw != null)
                sw.Close();
            if (this.client != null)

                this.client.Close();
        }

        private bool KiemTraKhacNull(params object[] obs)
        {
            foreach (object ob in obs)
            {
                if (ob == null)
                    return false;
            }
            return true;
        }

        public void SendFinishSignal()
        {
            CommandQueue.Enqueue(NetCommand.CombineCommandParam(NetCommand.ClientFinish, Dns.GetHostName() ));
        }

    }
}
