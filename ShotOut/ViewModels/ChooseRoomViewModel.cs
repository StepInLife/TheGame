using GamePackages;
using Prism.Commands;
using Prism.Mvvm;
//using ShotOut.MockServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace ShotOut.ViewModels
{
    internal class ChooseRoomViewModel : BindableBase
    {
        ObservableCollection<RoomViewModel> _rooms = new ObservableCollection<RoomViewModel>();
        ObservableCollection<GameMode> _gameMode = new ObservableCollection<GameMode>() { GamePackages.GameMode.OnePlayer, GamePackages.GameMode.MultiPlayer };
        RoomViewModel _newRoom;

        Timer t;
//        MockClientServer mockClient;

        ICommand joinRoom;
        Action _joinRoom;
        ICommand createRoom;
        Action _createRoom;


        public ChooseRoomViewModel(Action CreateRoom, Action JoinRoom)
        {
 //           mockClient = new MockClientServer();
            _createRoom = CreateRoom;
            _joinRoom = JoinRoom;

        }

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

        public ObservableCollection<GameMode> GameMode
        {
            get { return _gameMode; }
        }

        private static void addPlayer()
        {
            throw new NotImplementedException();
        }
        private static void addRoom()
        {
            throw new NotImplementedException();
        }

        public ICommand JoinRoom
        {
            get
            {
                return joinRoom ?? (joinRoom = new DelegateCommand(_joinRoom));
            }
        }
        public ICommand CreateRoom
        {
            get
            {
                return createRoom ?? (createRoom = new DelegateCommand(_createRoom));
            }
        }
        private  void RefreshListOfRooms(object source, ElapsedEventArgs e)
        {
   //         List<string> Rooms = mockClient.GetRooms();

        }


        void StartTimer()
        {
            t = new Timer(50000);
            t.Elapsed += new ElapsedEventHandler(RefreshListOfRooms);
            t.Start();
        }
        void EndTimer()
        {
            t.Stop();
        }
    }
}
