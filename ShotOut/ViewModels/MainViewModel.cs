using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using ShotOut.Client;

namespace ShotOut.ViewModels
{
    internal class MainViewModel : BindableBase
    {
        Dictionary<string, BindableBase> _viewModels = new Dictionary<string, BindableBase>();
        BindableBase _currentViewModel;
        ClientService clientService;
        Guid _myGuid;

        public MainViewModel()
        {
            _viewModels.Add(typeof(WaitStartGameViewModel).Name, new WaitStartGameViewModel());
            _viewModels.Add(typeof(LoginViewModel).Name, new LoginViewModel(login, logout));
            _viewModels.Add(typeof(ChooseRoomViewModel).Name, new ChooseRoomViewModel(CreateRoom, JoinRoom));
            clientService = new ClientService();
            CurrentViewModel = _viewModels[typeof(LoginViewModel).Name];
        }

        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                SetProperty(ref _currentViewModel, value);
            }
        }
        private void login()
        {
            var lvm = CurrentViewModel as LoginViewModel;
            object connect = clientService.ConnectToServer(lvm.Server, lvm.Nickname);
            if (connect is Guid)
            {
                _myGuid = (Guid)connect;
                clientService.sendMessage(GamePackages.PackageType.RoomInfo, _myGuid, "RoomList");
                CurrentViewModel = _viewModels[typeof(ChooseRoomViewModel).Name];
                (CurrentViewModel as ChooseRoomViewModel).Rooms = clientService.getRooms();

            }
            else
            {
                MessageBox.Show(connect.ToString());
            }

        }

        private void logout()
        {
            //close window
        }

        private void CreateRoom()
        {

        }
        private void JoinRoom()
        {

        }

    }
}
