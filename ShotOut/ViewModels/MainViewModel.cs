using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ShotOut.ViewModels
{
    internal class MainViewModel : BindableBase
    {
        Dictionary<string, BindableBase> _viewModels = new Dictionary<string, BindableBase>();
        BindableBase _currentViewModel;

        public MainViewModel()
        {
            _viewModels.Add( typeof(WaitStartGameViewModel).Name, new WaitStartGameViewModel());
            CurrentViewModel = _viewModels[typeof(WaitStartGameViewModel).Name];
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
