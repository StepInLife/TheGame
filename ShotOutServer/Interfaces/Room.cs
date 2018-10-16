using GamePackages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShotOutServer.Interfaces
{
    class Room : IRoom
    {
        public string RoomName { get; set; }
        public GameMode RoomMode { get; set; }

        public List<Player> Players = new List<Player>();

        public Room (string rn, GameMode gm)
        {
            RoomName = rn;
            RoomMode = gm;
        }
    }
}
