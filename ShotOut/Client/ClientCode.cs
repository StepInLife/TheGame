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
        IPAddress address = new IPAddress(); //serverIP
        int port = 0; //serverPort

        IPEndPoint remoteEndpoint = new IPEndPoint(address, port);
        client.Connect(remoteEndpoint);
    }
}
