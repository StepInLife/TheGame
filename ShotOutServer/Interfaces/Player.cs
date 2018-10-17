using GamePackages;
using ShotOutServer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShotOutServer.Interfaces
{
    internal class Player : IPlayer
    {
       byte[] buffer = new byte[1024];
       public string Nickname { get; set; }
        public Guid Id { get; set; }    

        public TcpClient Client { get; set; }

        public MainViewModel Owner { get; set; }

        public Player (string n, TcpClient client)
        {
            Nickname = n;
            Id = Guid.NewGuid();
            Client = client;
            client.GetStream().BeginRead(buffer, 0, 1024, ReadCallback, null);
        }

        void ReadCallback(IAsyncResult ar)
        {
            int amount = Client.GetStream().EndRead(ar);
            Serializing helper = new Serializing();
            Package p = helper.Deserialize(buffer);
            if (p._packageType == PackageType.RoomInfo)
            {
                var message = Encoding.UTF8.GetString(p._package);
                if (message == "RoomList")
                {
                    foreach (var r in Owner.Rooms)
                    {
                        var buffer = helper.Serialize(r);
                        sendPackage(PackageType.RoomInfo, p._player, buffer);
                    }
                }
            }

            Client.GetStream().BeginRead(buffer, 0, 1024, ReadCallback, null);
        }
        public void sendPackage(PackageType type, Guid? g, byte[] m)
        {
            Serializing helper = new Serializing();
            Package toSend = new Package() { _packageType = type, _player = g, _package = m };
            var buffer = helper.Serialize(toSend);
            Client.GetStream().Write(buffer, 0, buffer.Length);
        }

    }
}
