using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using ShotOut.Client;

namespace ShotOut.ViewModels
{
    internal class LoginViewModel : BindableBase, ILoginViewModel
    {
        string _nickname;
        string _server;
        int error;
        IClientService _clientService;

        ICommand _okCommand;
        Action _login;
        ICommand _cancelCommand;
        Action _cancel;

        public LoginViewModel(Action login, Action cancel)
        {
            _login = login;
            _cancel = cancel;
        }

        public int Error { get
            {
                return error;
            }
            set
            {
                SetProperty(ref error, value);
            }
        }

        public string Nickname
        {
            get
            {
                return _nickname;
            }
            set
            {
                SetProperty(ref _nickname, value);
            }
        }

        public string Server
        {
            get
            {
                return _server;
            }

            set
            {
                SetProperty(ref _server, value);
            }
        }

        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new DelegateCommand(_login));
            }
        }
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new DelegateCommand(_cancel));
            }
        }


        private void login()
        {
            int error = _clientService.ConnectToServer(Server, Nickname);
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
