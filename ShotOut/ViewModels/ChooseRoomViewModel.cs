using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShotOut.ViewModels
{
    internal class ChooseRoomViewModel : BindableBase
    {
        ObservableCollection<RoomViewModel> _rooms = new ObservableCollection<RoomViewModel>();
        RoomViewModel _newRoom;

        ICommand joinRoom = new DelegateCommand(addPlayer);
        ICommand createRoom = new DelegateCommand(addRoom);

        public ObservableCollection<RoomViewModel> Rooms
        {
            get { return _rooms; }
            set { SetProperty(ref _rooms, value); }
        }

        public RoomViewModel NewRoom
        {
            get { return _newRoom; }
            set { SetProperty(ref _newRoom, value); }
        }

        private static void addPlayer()
        {
            throw new NotImplementedException();
        }
        private static void addRoom()
        {
            throw new NotImplementedException();
        }
    }
}
