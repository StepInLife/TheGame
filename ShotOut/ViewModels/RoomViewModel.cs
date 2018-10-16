using GamePackages;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShotOut.ViewModels
{
    internal class RoomViewModel : BindableBase, IRoom
    {
        string _roomName;
        GameMode _roomMode;  

        public string RoomName
        {
            get { return _roomName; }
            set { SetProperty(ref _roomName, value); }
        }

        public GameMode RoomMode
        {
            get { return _roomMode; }
            set { SetProperty(ref _roomMode, value); }
        }
    }
}
