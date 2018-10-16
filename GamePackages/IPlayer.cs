using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackages
{
    public interface IPlayer
    {
        string Nickname { get; set; }
        Guid Id { get; set; }
    }
}
