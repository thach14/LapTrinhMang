using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Common;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace Server
{
    public partial class Server : Form
    {
        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;

        List<Student> listStudent = new List<Student>();
        List<MonThi> listMonThi = new List<MonThi>();
        MonThi monThi;
        Student sinhVien;
        private const int PORT = 2010;

        int counter = 0;
        System.Timers.Timer countdown;

        OpenFileDialog dialog;
        FolderBrowserDialog folder;
        string fileName;

        public Server()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            countdown = new System.Timers.Timer();
            countdown.Elapsed += Countdown_Elapsed;
            countdown.Interval = 1000;

            Start();
        }
        void GetActiveIP()
        {
            foreach (NetworkInterface f in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (f.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties ipInterface = f.GetIPProperties();
                    if (ipInterface.GatewayAddresses.Count > 0)
                    {
                        foreach (UnicastIPAddressInformation unicastAddress in ipInterface.UnicastAddresses)
                        {
                            if ((unicastAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) && (unicastAddress.IPv4Mask.ToString() != "0.0.0.0"))
                            {
                                txtIP.Text = unicastAddress.Address.ToString();
                                break;

                            }
                        }
                    }
                }
            }
        }
        
        void Start()
        {
            IP = new IPEndPoint(IPAddress.Any, PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientList = new List<Socket>();

            server.Bind(IP);

            Thread listen = new Thread(StartServer);

            listen.IsBackground = true;
            listen.Start();

            AddMessage("Server đã khởi động!");
        }

        void StartServer()
        {
            try
            {
                while (true)
                {
                    server.Listen(100);
                    Socket client = server.Accept();
                    clientList.Add(client);

                    Thread receive = new Thread(Receive);
                    receive.IsBackground = true;
                    receive.Start(client);

                    AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã kết nối");
                }
            }
            catch
            {
                IP = new IPEndPoint(IPAddress.Any, PORT);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
        }

       
        void CloseConnection()
        {
            server.Close();
        }

       
        void Receive(object obj)
        {
            Socket client = obj as Socket;

            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 1024 * 20];
                    client.Receive(buffer);

                    object data = Deserialize(buffer);
                    ServerResponse container = data as ServerResponse;

                    switch (container.Type)
                    {
                        case ServerResponseType.SendStudent:

                            Student student = container.Data as Student;
                            AddMessage(client.RemoteEndPoint.ToString() + ": Thông tin sinh viên thao tác trên máy: " + student.FullNameAndId);

                            break;

                        case ServerResponseType.SendFile:

                            FileResponse file = container.Data as FileResponse;

                            string fileName = file.FileInfo.Name;
                            

                            using (var fileStream = File.Create(txtLuuBai.Text + "/"+fileName))
                            {
                                fileStream.Write(file.FileContent, 0, file.FileContent.Length);
                            }

                            break;

                        case ServerResponseType.SendList:
                            break;

                        case ServerResponseType.SendString:

                            string computerName = (string)container.Data;

                            AddMessage(client.RemoteEndPoint.ToString() + ": Tên máy: " + computerName);

                            break;

                        case ServerResponseType.BeginExam:
                            break;
                        case ServerResponseType.FinishExam:
                            break;
                        case ServerResponseType.SendMessage:
                            string go = container.Data as string;
                            AddMessage(go+" đã nộp bài");

                            break;
                        case ServerResponseType.LockClient:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
                AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã đóng kết nối");
                clientList.Remove(client);
                client.Close();
            }
        }


        void AddMessage(string message)
        {
            lsvMain.Items.Add(new ListViewItem() { Text = message });
        }

        byte[] Serialize(object data)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, data);

            return stream.ToArray();
        }

        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }

        private void btnSendStudents_Click(object sender, EventArgs e)
        {

            string sqlserver = @"server=.; database=Students; integrated security = true;";
            SqlConnection connection = new SqlConnection(sqlserver);
            SqlDataReader read;
            SqlCommand cmd = connection.CreateCommand();
            connection.Open();

            cmd.CommandText = "Select * from ThongTinSinhVien ";
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                sinhVien = new Student();
                sinhVien.ID = read.GetValue(0).ToString();
                sinhVien.FullName = read.GetValue(1).ToString();
                listStudent.Add(sinhVien);
            }
            cmd.Dispose();
            read.Close();
            connection.Close();

            ServerResponse container = new ServerResponse();
            container.Type = ServerResponseType.SendList;
            container.Data = listStudent;

            byte[] buffer = Serialize(container);

            foreach (Socket client in clientList)
            {
                try
                {
                    client.Send(buffer);

                    AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã gửi danh sách sinh viên thành công");
                }
                catch
                {
                    AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã xảy ra sự cố trong quá trình gửi danh sách. Đã đóng kết nối");

                    clientList.Remove(client);
                    client.Close();
                }
            }
            MessageBox.Show("Đã gửi danh sách cho Client");
        }
        
        private void btnSendFile_Click(object sender, EventArgs e)
        {
          
            if (txtTenDeThi.Text != null&& txtTenDeThi.Text != "Chọn đề thi")
            {

                FileResponse fileResponse = new FileResponse(fileName);
                ServerResponse container1 = new ServerResponse();
                container1.Type = ServerResponseType.SendFile;
                container1.Data = fileResponse;


                ServerResponse container2 = new ServerResponse();
                container2.Type = ServerResponseType.SendString;
                List<string> listDeGui = new List<string>();
                listDeGui.Add(cbbMonThi.Text);

                container2.Data = listDeGui;


                byte[] buffer1 = Serialize(container1);
                byte[] buffer2 = Serialize(container2);

                foreach (Socket client in clientList)
                {
                    try
                    {
                        client.Send(buffer1);
                        client.Send(buffer2);

                        AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã gửi đề thi thành công");
                    }
                    catch 
                    {
                        AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã xảy ra sự cố trong quá trình gửi đề thi. Đã đóng kết nối");

                        clientList.Remove(client);
                        client.Close();
                    }
                }
            }
            else
            {
                AddMessage("Vui lòng chọn đề thi!");
            }
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            int minute = Convert.ToInt32(txtSetTime.Text);
            counter = minute * 60; 
            countdown.Enabled = true;

            ServerResponse container = new ServerResponse();
            container.Type = ServerResponseType.BeginExam;
            container.Data = minute;

            byte[] buffer = Serialize(container);

            foreach (Socket client in clientList)
            {
                try
                {
                    client.Send(buffer);

                    AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã bắt đầu làm bài thi");
                }
                catch 
                {
                    AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã xảy ra sự cố trong quá trình gửi yêu cầu làm bài. Đã đóng kết nối");

                    clientList.Remove(client);
                    client.Close();
                }
            }
        }

        private void Countdown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter -= 1;

            int minute = counter / 60;
            int second = counter % 60;

            lblTimeLeft.Text = minute + ":" + second;

            if (counter == 0)
            {
                countdown.Stop();

                AddMessage("Server: Đã hết thời gian làm bài");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChonDeThi_Click(object sender, EventArgs e)
        {
            dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
                txtTenDeThi.Text = fileName;

               
            }
        }

        
        private void Server_Load(object sender, EventArgs e)
        {
            GetActiveIP();
            string sqlserver = @"server=.; database=Students; integrated security = true;";
            SqlConnection connection = new SqlConnection(sqlserver);
            SqlDataReader read;
            SqlCommand cmd = connection.CreateCommand();
            connection.Open();

            cmd.CommandText = "Select * from MonThi ";
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                monThi = new MonThi()
;
                monThi.ID = read.GetValue(0).ToString();
                monThi.Name = read.GetValue(1).ToString();
                listMonThi.Add(monThi);
            }
            cmd.Dispose();
            read.Close();
            connection.Close();
            foreach (MonThi mon in listMonThi)
            {
                cbbMonThi.Items.Add(mon.Name);
            }
            cbbMonThi.Text = cbbMonThi.Items[1].ToString();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            server.Close();
            AddMessage("Đã đóng kết nối tất cả các client!!");

            IP = new IPEndPoint(IPAddress.Any, PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientList = new List<Socket>();

            server.Bind(IP);

            Thread listen = new Thread(StartServer);

            listen.IsBackground = true;
            listen.Start();
        }
        private void btnLuuBai_Click(object sender, EventArgs e)
        {
            folder = new FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                fileName = folder.SelectedPath;
               txtLuuBai.Text = fileName;


            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            if (txtMesseage.Text != null) { 
            string mess = txtMesseage.Text;
            ServerResponse container = new ServerResponse();
            container.Type = ServerResponseType.SendMessage;
            container.Data = mess;
            byte[] buffer = Serialize(container);

                foreach (Socket client in clientList)
                {
                    try
                    {
                        client.Send(buffer);

                        AddMessage("Đã gửi đến "+client.RemoteEndPoint.ToString() + ": " + txtMesseage.Text);
                    }
                    catch
                    {
                        AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã xảy ra sự cố trong quá trình gửi thông điệp. Đã đóng kết nối");

                        clientList.Remove(client);
                        client.Close();
                    }
                    txtMesseage.Text = "";
                }
            }

        }


        
        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
                textBox1.Text = fileName;
                
                
                LayDSExcel();
                MessageBox.Show("Lấy DSSV thành công, gửi DS cho client");
                
            }
           
        }
        void LayDSExcel()
        {
            string sqlserver = @"server=.; database=Students; integrated security = true;";
            SqlConnection connection = new SqlConnection(sqlserver);
            SqlDataReader read;
            SqlCommand cmd = connection.CreateCommand();
            connection.Open();

            cmd.CommandText = "Select * from ThongTinSinhVien ";
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                sinhVien = new Student();
                sinhVien.ID = read.GetValue(0).ToString();
                sinhVien.FullName = read.GetValue(1).ToString();
                listStudent.Add(sinhVien);
            }
            cmd.Dispose();
            read.Close();
            connection.Close();

            ServerResponse container = new ServerResponse();
            container.Type = ServerResponseType.SendList;
            container.Data = listStudent;

            byte[] buffer = Serialize(container);

            foreach (Socket client in clientList)
            {
                try
                {
                    client.Send(buffer);

                    AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã gửi danh sách sinh viên thành công");
                }
                catch
                {
                    AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã xảy ra sự cố trong quá trình gửi danh sách. Đã đóng kết nối");

                    clientList.Remove(client);
                    client.Close();
                }
            }
        }
    }
}
