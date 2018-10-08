using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using ShotOut.Client;

namespace ShotOut.ViewModels
{
    internal class MainViewModel : BindableBase
    {
        Dictionary<string, BindableBase> _viewModels = new Dictionary<string, BindableBase>();
        BindableBase _currentViewModel;
        IClientService _clientService;

        public MainViewModel()
        {
            _viewModels.Add( typeof(WaitStartGameViewModel).Name, new WaitStartGameViewModel());
            _viewModels.Add(typeof(LoginViewModel).Name, new LoginViewModel(login, logout));
            _viewModels.Add(typeof(ChooseRoomViewModel).Name, new ChooseRoomViewModel());

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
            int error = _clientService.ConnectToServer(lvm.Server, lvm.Nickname);
            if (error != 0)
            {
                //error 
            }


        }

        private void logout()
        {
            //close window
        }
    }
}
