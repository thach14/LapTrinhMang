using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao ten mien!!\n");
            
            string tenmien = Console.ReadLine();
            GetHostInfo(tenmien);
            Console.ReadKey();
        }
        static void GetHostInfo(string host)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(host);
                Console.WriteLine("Ten mien: "+ hostInfo.HostName);
                Console.WriteLine("Dia chi IP: \n");
                foreach (IPAddress ip in hostInfo.AddressList)
                {
                    Console.WriteLine(ip.ToString() + "");

                }
                Console.WriteLine();

            }
            catch
            {
                Console.WriteLine("Khong the phan giai ten mien!"+ host );
            }
        }
    }
}
