using GamePackages;
using ShotOut.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<RoomViewModel> getRooms()
        {
            int readed = 0;
            ObservableCollection<RoomViewModel> rooms = new ObservableCollection<RoomViewModel>();
            
            do
            {
                byte[] buffer = new byte[1024];
                NetworkStream stream = tcpClient.GetStream();
                readed = stream.Read(buffer, 0, buffer.Length);
                Package p = helper.Deserialize(buffer);

                if (p._packageType == PackageType.SizeInfo)
                {
                    var size = BitConverter.ToInt32(p._package, 0);
                    var tmp = helper.Serialize(p);
                    byte[] buff = new byte[size];
                    var len = readed - tmp.Length;
                    Array.Copy(buffer, tmp.Length, buff, 0, len);
                    readed = stream.Read(buff, len, buff.Length - len);
                    Package pack = helper.Deserialize(buff);
                    RoomViewModel newRoom = new RoomViewModel();

                    if (pack._packageType == PackageType.RoomInfo)
                    {
                        MemoryStream ms = new MemoryStream();
                        BinaryFormatter bf = new BinaryFormatter();
                        ms.Write(pack._package, 0, pack._package.Length);
                        ms.Seek(0, SeekOrigin.Begin);
                        newRoom = (RoomViewModel)bf.Deserialize(ms);
                    }
                    else
                        break;
                }

                else
                    break;

            } while (readed > 0);

            return rooms;
        }
    }
}
