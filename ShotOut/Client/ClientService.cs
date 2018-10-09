using ShotOut.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShotOut.Client
{
    class ClientService : IClientService
    {
        readonly int tcpPort = 12345;
        TcpClient tcpClient;
        IServer server;
        IPEndPoint remoteEP;
        public int ConnectToServer(string server, string nickname)
        {
            //IPEndPoint localEP;
            //int ctr = 0;
            //IPAddress[] localAddress = Dns.GetHostAddresses(Dns.GetHostName());
            //foreach (var item in localAddress)
            //{
            //    if (item.AddressFamily == AddressFamily.InterNetwork)
            //        break;
            //    ctr++;
            //}
            //localEP = new IPEndPoint(localAddress[ctr], tcpPort);
            //tcpClient = new TcpClient(localEP);

            //IPAddress[] remoteAddress = Dns.GetHostAddresses(server);
            //ctr=0;
            //foreach (var item in remoteAddress)
            //{
            //    if (item.AddressFamily == AddressFamily.InterNetwork)
            //        break;
            //    ctr++;
            //}
            //remoteEP = new IPEndPoint(remoteAddress[ctr], tcpPort); ;
            //try
            //{
            //    tcpClient.Connect(remoteEP);
            //}
            //catch (Exception ex)
            //{
                
            //}
            //if (tcpClient.Connected)
                return 0;
            //else
              //  return 1;
        }
        //TcpClient client = new TcpClient();
        //IPAddress address = IPAddress.Parse();
        //int port = 0; //serverPort constants list

        //IPEndPoint remoteEndpoint = new IPEndPoint(address, port);
        //client.Connect(remoteEndpoint);
    }
}
