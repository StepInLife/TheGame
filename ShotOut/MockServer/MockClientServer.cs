using ShotOut.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShotOut.MockServer
{
    class MockClientServer : IClientService
    {
        public int ConnectToServer(string server, string nickname)
        {
            throw new NotImplementedException();
        }
        public List<string> GetRooms()
        {
            return new List<string>();
        }
    }
}
