using System.Windows;
using System.Windows.Media;
using WPF_Design.Models;

namespace WPF_Design.DataProvider
{
    public interface IRoomDesignDataProvider
    {
        public void OpenSavedRoom(RoomObjects roomObjects);

        public void SaveRoom(RoomObjects roomObjects);

        public void DeleteObject(BaseFurniture objectToDelete);

        public void RotateObject(BaseFurniture objectToRotate);
        Geometry Clone(BaseFurniture draggedObject, double angle, Point newPosition);
        bool CheckIfObjectsOverlap(BaseFurniture draggedObject, Geometry clone);
    }
}
