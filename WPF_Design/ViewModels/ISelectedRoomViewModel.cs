using WPF_Design.Models;

namespace WPF_Design.ViewModels
{
    public interface ISelectedRoomViewModel
    {
        RoomObjects RoomObjects { get; set; }

        void LoadDefaultRoom();
        void OpenSavedRoom();
    }
}