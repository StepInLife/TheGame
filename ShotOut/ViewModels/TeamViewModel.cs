using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShotOut.ViewModels
{
    public class TeamViewModel
    {
        ObservableCollection<PlayerViewModel> players;

        public ObservableCollection<PlayerViewModel> Players { get => players; set => players = value; }

        public string Name { get; set; }
    }
}
