using GamePackages;
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

            Client.GetStream().BeginRead(buffer, 0, 1024, ReadCallback, null);
        }
    }
}
