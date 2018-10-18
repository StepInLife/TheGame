using GamePackages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShotOutServer.Interfaces
{
    [Serializable]
    class Room : IRoom
    {
        public string RoomName { get; set; }
        public GameMode RoomMode { get; set; }
        public int PlayersAmount { get; set; }

        public List<IPlayer> Players = new List<IPlayer>();

        public Room (string rn, GameMode gm)
        {
            RoomName = rn;
            RoomMode = gm;
        }
    }
}
