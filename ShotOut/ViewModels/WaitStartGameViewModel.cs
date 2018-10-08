using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShotOut.ViewModels
{
    public class WaitStartGameViewModel : BindableBase
    {
        ObservableCollection<TeamViewModel> teams = new ObservableCollection<TeamViewModel>();
        public ObservableCollection<TeamViewModel> Teams
        {
            get => teams;
            set
            {
                SetProperty(ref teams, value);
            }
        }
    }
}
