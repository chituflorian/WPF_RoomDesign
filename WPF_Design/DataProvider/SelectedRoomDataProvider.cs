using System;
using System.Collections.ObjectModel;
using WPF_Design.Models;

namespace WPF_Design.DataProvider
{
    public class SelectedRoomDataProvider : ISelectedRoomDataProvider
    {
        private readonly ISerialize _serialization;

        public SelectedRoomDataProvider()
        {
            _serialization = new Serialization();
        }

        public ObservableCollection<BaseFurniture> LoadDefaultRoom(string selectedRoomType, Type type)
        {
            return _serialization.LoadDefaultRoom(selectedRoomType, type);
        }

        public void OpenSavedRoom(RoomObjects roomObjects)
        {
            _serialization.OpenSavedRoom(roomObjects);
        }
    }
}
