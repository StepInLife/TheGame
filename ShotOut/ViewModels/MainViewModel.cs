using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ShotOut.ViewModels
{
    class MainViewModel : BindableBase
    {
        Dictionary<string, BindableBase> _viewModels = new Dictionary<string, BindableBase>();
        BindableBase _currentViewModel;

        public MainViewModel()
        {
            _viewModels.Add( typeof(WaitStartGameViewModel).Name, new WaitStartGameViewModel());
            _viewModels.Add(typeof(LoginViewModel).Name, new LoginViewModel());
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
    }
}
