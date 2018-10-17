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
                sendMessage(PackageType.LoginInfo, null, nickname);
                //var message = Encoding.UTF8.GetBytes(nickname);
                //Package login = new Package() { _packageType = PackageType.LoginInfo, _player = null, _package = message };
                //var buff = helper.Serialize(login);
                //tcpClient.GetStream().Write(buff, 0, buff.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            byte[] buffer = new byte[1024];
            tcpClient.GetStream().Read(buffer, 0, buffer.Length);
            Package p = helper.Deserialize(buffer);

            if (p._packageType == PackageType.LoginInfo)
                return p._player;
            else
                return Encoding.UTF8.GetString(p._package);
        }

        public void sendMessage(PackageType pt, Guid? g, string m)
        {
            byte[] message = null;
            if (!String.IsNullOrEmpty(m))
                message = Encoding.UTF8.GetBytes(m);
            
            Package p = new Package()
            {
                _packageType = pt,
                _player = g,
                _package = message
            };
            var buff = helper.Serialize(p);
            tcpClient.GetStream().Write(buff, 0, buff.Length);
        }

        public RoomViewModel getRoom()
        {
            byte[] buffer = new byte[1024];
            int counter = 0;
            //List<RoomViewModel> rooms = new List<RoomViewModel>();
            RoomViewModel newRoom = new RoomViewModel();

            do
            {
                int readed = tcpClient.GetStream().Read(buffer, 0, buffer.Length);
                Package p = helper.Deserialize(buffer);

                if (p._packageType != PackageType.RoomInfo)
                    return null;
                else
                {
                    counter++;
                    var msg = Encoding.UTF8.GetString(p._package);
                    if (counter == 1)
                        newRoom.RoomName = msg;
                    else if (counter == 2)
                        newRoom.RoomMode = (GameMode)Enum.Parse(typeof(GameMode), msg);
                    else
                        newRoom.PlayersAmount = Convert.ToInt32(msg);
                }

            } while (counter < 3);

            return newRoom;
        }
    }
}
