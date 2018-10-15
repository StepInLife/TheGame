using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShotOutServer.Interfaces
{
    interface IPlayer
    {
        string Nickname { get; set; }
        Guid Id { get; set; }
    }

    internal class Player : IPlayer
    {
        public string Nickname { get; set; }
        public Guid Id { get; set; }    

        public Player (string n)
        {
            Nickname = n;
            Id = Guid.NewGuid();
        }
    }
}
