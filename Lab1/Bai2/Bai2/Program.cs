using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            InfoLocalHost();
            Console.ReadKey();
        }
        static void InfoLocalHost()
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                Console.WriteLine();
                foreach (UnicastIPAddressInformation ip in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        Console.WriteLine("Dia chi IP: " + ip.Address.ToString());
                        Console.WriteLine("Subnet Mask: " + ip.IPv4Mask.ToString());
                    }

                }
                var gateway = adapter.GetIPProperties().GatewayAddresses;
                if (gateway.Count > 0 )
                {
                    foreach (var item in gateway)
                    {
                        Console.WriteLine("Default Gateway: " + item.Address.ToString() );
                    }    
                }
            }
        }
    }
}
