using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShotOut.ViewModels
{
    class WaitStartGameViewModel
    {
        ObservableCollection<TeamViewModel> teams;
        public ObservableCollection<TeamViewModel> Teams { get => teams; set => teams = value; }
    }
}
