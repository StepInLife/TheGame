using Prism.Commands;
using Prism.Mvvm;
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
        readonly int tcpPort = 8081;
        List<IPAddress> localAddress = new List<IPAddress>();
        IPAddress _chosenAddress;
        ICommand _start;
        ICommand _stop;

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
            new Thread(this.Listen).Start();
        }

        private void Listen()
        {
            throw new NotImplementedException();
        }

        private void ServerDisconnect()
        {
            _listener.Stop();
        }
    }
}
