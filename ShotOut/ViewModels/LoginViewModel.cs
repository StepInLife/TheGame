using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace ShotOut.ViewModels
{
    internal class LoginViewModel : BindableBase, ILoginViewModel
    {
        string _nickname;
        string _server;
        ICommand _okCommand = new DelegateCommand(login);
        ICommand _cancelCommand = new DelegateCommand(logout);

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
                _server = value;
            }
        }

        public ICommand OkCommand { get => _okCommand; }
        public ICommand CancelCommand { get => _cancelCommand; }

        private static void login()
        {
            throw new NotImplementedException();
        }

        private static void logout()
        {
            throw new NotImplementedException();
        }
    }
}
