using System;
using System.Collections.ObjectModel;
using WPF_Design.BusinessLogicLayer;

namespace WPF_Design.Models
{
    [Serializable]
    public class RoomObjects : PropertyChange
    {
        private ObservableCollection<BaseFurniture> _addedObjects;
        public ObservableCollection<BaseFurniture> AddedObjects
        {
            get => _addedObjects;
            set
            {
                _addedObjects = value;
                NotifyPropertyChanged(nameof(AddedObjects));
            }
        }


        private ObservableCollection<BaseFurniture> _auxiliaryObjects;
        public ObservableCollection<BaseFurniture> AuxiliaryObjects
        {
            get => _auxiliaryObjects;
            set
            {
                _auxiliaryObjects = value;
                NotifyPropertyChanged(nameof(AuxiliaryObjects));
            }
        }


        private string _selectedRoomType;
        public string SelectedRoomType
        {
            get => _selectedRoomType;
            set
            {
                _selectedRoomType = value;
                NotifyPropertyChanged(nameof(SelectedRoomType));
            }
        }


        public RoomObjects()
        {
            AddedObjects = new();
            AuxiliaryObjects = new();
        }
    }
}
