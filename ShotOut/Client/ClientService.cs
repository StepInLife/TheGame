using GamePackages;
using ShotOut.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShotOut.Client
{
    class ClientService : IClientService
    {
        readonly int tcpPort = 12345;
        TcpClient tcpClient;
        IPEndPoint remoteEP;
        Serializing helper = new Serializing();
        public int ConnectToServer(string server, string nickname)
        {
            IPEndPoint localEP;
            int ctr = 0;
            IPAddress[] localAddress = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var item in localAddress)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                    break;
                ctr++;
            }

            localEP = new IPEndPoint(localAddress[ctr], tcpPort);
            tcpClient = new TcpClient(localEP);

            IPAddress[] remoteAddress = Dns.GetHostAddresses(server);
            ctr = 0;
            foreach (var item in remoteAddress)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                    break;
                ctr++;
            }

            remoteEP = new IPEndPoint(remoteAddress[ctr], tcpPort); ;
            try
            {
                tcpClient.Connect(remoteEP);
                var message = Encoding.UTF8.GetBytes(nickname);
                Package login = new Package() { _packageType = PackageType.LoginInfo, _package = message };
                var buffer = helper.Serialize(login);
                tcpClient.GetStream().Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (tcpClient.Connected)
                return 0;
            else
                return 1;
        }
    }
}
