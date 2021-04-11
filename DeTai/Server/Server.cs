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

namespace Server
{
    public partial class Server : Form
    {
        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;

        private const int PORT = 2010;

        int counter = 0;
        System.Timers.Timer countdown;

        OpenFileDialog dialog;
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


        void Start()
        {
            IP = new IPEndPoint(IPAddress.Any, PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientList = new List<Socket>();

            server.Bind(IP);

            Thread listen = new Thread(StartServer);

            listen.IsBackground = true;
            listen.Start();

            AddMessage("Server đã khởi động tại địa chỉ 127.0.0.1:" + PORT);
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
                            AddMessage(client.RemoteEndPoint.ToString() + ": Đã nhận bài làm, tập tin có tên: " + fileName);

                            using (var fileStream = File.Create(fileName))
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
            List<Student> listStudent = new List<Student>();
            listStudent.Add(new Student()
            {
                ID = "1812756",
                FirstName = "Hieu",
                LastName = "Nguyen Trong"
            });
            
            listStudent.Add(new Student()
            {
                ID = "1812751",
                FirstName = "Ha",
                LastName = "Nguyen Thi"
            });

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
        
        private void btnSendFile_Click(object sender, EventArgs e)
        {
          
            if (txtTenDeThi.Text != null)
            {

                FileResponse fileResponse = new FileResponse(fileName);
                ServerResponse container = new ServerResponse();
                container.Type = ServerResponseType.SendFile;
                container.Data = fileResponse;

                byte[] buffer = Serialize(container);

                foreach (Socket client in clientList)
                {
                    try
                    {
                        client.Send(buffer);

                        AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã gửi đề thi thành công");
                    }
                    catch (Exception ex)
                    {
                        AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã xảy ra sự cố trong quá trình gửi đề thi. Đã đóng kết nối");

                        clientList.Remove(client);
                        client.Close();
                    }
                }
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
                catch (Exception ex)
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
    }
}
