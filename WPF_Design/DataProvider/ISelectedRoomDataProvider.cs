using System;
using System.Collections.ObjectModel;
using WPF_Design.Models;

namespace WPF_Design.DataProvider
{
    public interface ISelectedRoomDataProvider
    {
        ObservableCollection<BaseFurniture> LoadDefaultRoom(string selectedRoomType, Type type);
        void OpenSavedRoom(RoomObjects roomObjects);
    }
}
