using WPF_Design.BusinessLogicLayer;
using WPF_Design.DataProvider;
using WPF_Design.Models;

namespace WPF_Design.ViewModels
{
    public class SelectedRoomViewModel : PropertyChange, ISelectedRoomViewModel
    {
        private readonly ISelectedRoomDataProvider _selectedRoomDataProvider;

        private RoomObjects _roomObjects;
        public RoomObjects RoomObjects
        {
            get => _roomObjects;
            set
            {
                _roomObjects = value;
                NotifyPropertyChanged(nameof(RoomObjects));
            }
        }


        public SelectedRoomViewModel(ISelectedRoomDataProvider selectedRoomDataProvider)
        {
            RoomObjects = new();
            _selectedRoomDataProvider = selectedRoomDataProvider;
        }

        public void LoadDefaultRoom()
        {
            RoomObjects.AuxiliaryObjects = _selectedRoomDataProvider.LoadDefaultRoom(RoomObjects.SelectedRoomType, RoomObjects.AuxiliaryObjects.GetType());
        }

        public void OpenSavedRoom() => _selectedRoomDataProvider.OpenSavedRoom(RoomObjects);
    }
}
