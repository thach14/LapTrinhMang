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
        string ip;
        string nickName;
        public Client()
        {

        }
        public Client(string iPEndPoint, string name)
        {
            ip = iPEndPoint;
            nickName = name;

        }
    }
   
}
