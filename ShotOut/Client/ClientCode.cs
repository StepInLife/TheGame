using ShotOut.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShotOut.Client
{
    class ClientCode
    {
        TcpClient client = new TcpClient();
        IPAddress address = IPAddress.Parse();
        int port = 0; //serverPort constants list

        IPEndPoint remoteEndpoint = new IPEndPoint(address, port);
        client.Connect(remoteEndpoint);
    }
}
