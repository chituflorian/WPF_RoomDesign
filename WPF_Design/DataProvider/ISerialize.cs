using System;
using System.Collections.ObjectModel;
using WPF_Design.Models;

namespace WPF_Design.DataProvider
{
    public interface ISerialize
    {
        ObservableCollection<BaseFurniture> LoadDefaultRoom(string fileName, Type type);
        void OpenSavedRoom(RoomObjects roomObjects);
        void SaveRoom(RoomObjects roomObjects);
    }
}