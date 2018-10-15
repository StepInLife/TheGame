using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShotOut.Client
{
    internal interface IClientService
    {
        object ConnectToServer(string server, string nickname);
    }
}
