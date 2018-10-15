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
        readonly int tcpPort = 48081;
        TcpClient tcpClient;
        IPEndPoint remoteEP;
        Serializing helper = new Serializing();

        public object ConnectToServer(string server, string nickname)
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
            tcpClient = new TcpClient();

            IPAddress[] remoteAddress = Dns.GetHostAddresses(server);
            int ctr = 0;
            foreach (var item in remoteAddress)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                    break;
                ctr++;
            }

            remoteEP = new IPEndPoint(remoteAddress[ctr], tcpPort);
            try
            {
                tcpClient.Connect(remoteEP);
                var message = Encoding.UTF8.GetBytes(nickname);
                Package login = new Package() { _packageType = PackageType.LoginInfo, _package = message };
                var buff = helper.Serialize(login);
                tcpClient.GetStream().Write(buff, 0, buff.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            byte[] buffer = new byte[1024];
            tcpClient.GetStream().Read(buffer, 0, buffer.Length);
            Package p = helper.Deserialize(buffer);

            if (p._packageType == PackageType.LoginInfo)
                return Guid.Parse(Encoding.UTF8.GetString(p._package));
            else
                return Encoding.UTF8.GetString(p._package);
        }
    }
}
