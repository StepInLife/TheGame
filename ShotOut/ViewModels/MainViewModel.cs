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
        ObservableCollection<BindableBase> _viewModels = new ObservableCollection<BindableBase>();
        private BindableBase _currentViewModel;
        private int _currentViewIndex = 0;
    }
}
