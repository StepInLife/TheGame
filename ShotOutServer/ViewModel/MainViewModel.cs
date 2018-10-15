using GamePackages;
using Prism.Commands;
using Prism.Mvvm;
using ShotOutServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShotOutServer.ViewModel
{
    internal class MainViewModel : BindableBase
    {
        TcpListener _listener;
        readonly int tcpPort = 48081;
        List<IPAddress> localAddress = new List<IPAddress>();
        IPAddress _chosenAddress;
        List<TcpClient> clients = new List<TcpClient>();
        ICommand _start;
        ICommand _stop;
        Serializing helper = new Serializing();
        List<Player> _players = new List<Player>();

        public MainViewModel()
        {
            var list = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var adr in list)
            {
                if (adr.AddressFamily == AddressFamily.InterNetwork)
                    localAddress.Add(adr);
            }
            localAddress.Add(IPAddress.Parse("127.0.0.1"));
            _start = new DelegateCommand(ServerConnect);
            _stop = new DelegateCommand(ServerDisconnect);
        }

        public List<IPAddress> LocalAddresses
        {
            get => localAddress; 
        }

        public IPAddress Address
        {
            get { return _chosenAddress; }
            set { SetProperty(ref _chosenAddress, value); }
        }

        public ICommand Start
        {
            get { return _start; }
        }

        public ICommand Stop
        {
            get { return _stop; }
        }
        private void ServerConnect()
        {
            _listener = new TcpListener(Address, tcpPort);
            _listener.Start();
            Listen();
        }

        private async void Listen()
        {
            try
            {
                while(true)
                {
                    TcpClient client = await _listener.AcceptTcpClientAsync();
                    clients.Add(client);
                    receivePackage(client);
                }
            }
            catch { }
        }

        private void receivePackage(TcpClient client)
        {
                byte[] buffer = new byte[1024];
                client.GetStream().Read(buffer, 0, buffer.Length);
                Package p = helper.Deserialize(buffer);

                if(p._packageType == PackageType.LoginInfo)
                {
                    var nick = Encoding.UTF8.GetString(p._package);
                    Player newPlayer = new Player(nick);
                    _players.Add(newPlayer);
                    sendPackage(client, PackageType.LoginInfo, newPlayer.Id.ToString());
                }
                else
                {
                    string message = "Connection error. Please fill the authorization form.";
                    sendPackage(client, PackageType.ErrorInfo, message);
                }
        }

        private void sendPackage(TcpClient client, PackageType type, string m)
        {
            var message = Encoding.UTF8.GetBytes(m);
            Package toSend = new Package() { _packageType = type, _package = message };
            var buffer = helper.Serialize(toSend);
            client.GetStream().Write(buffer, 0, buffer.Length);
        }

        private void ServerDisconnect()
        {
            _listener.Stop();
        }
    }
}
