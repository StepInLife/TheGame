using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackages
{
    public interface IRoom
    {
        string RoomName { get; set; }
        GameMode RoomMode { get; set; }
        int PlayersAmount { get; set; }
    }
}
