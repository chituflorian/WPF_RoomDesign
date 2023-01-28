using System.Windows.Shapes;
using WPF_Design.BusinessLogicLayer;
using WPF_Design.Models;

namespace WPF_Design.ViewModels
{
    public class DrawingViewModel : PropertyChange
    {
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

        private object _selectedObject;
        public object SelectedObject
        {
            get => _selectedObject;
            set 
            { 
                _selectedObject = value;
                NotifyPropertyChanged(nameof(SelectedObject));
            }
        }      


        public DrawingViewModel()
        {
            RoomObjects = new()
            {
                AuxiliaryObjects = new(),
                SelectedRoomType = "custom"
            };
        }
    }
}
