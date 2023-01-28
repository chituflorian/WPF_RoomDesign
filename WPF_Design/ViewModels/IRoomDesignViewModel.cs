using System.Collections.ObjectModel;
using System.Windows;
using WPF_Design.Models;

namespace WPF_Design.ViewModels
{
    public interface IRoomDesignViewModel
    {
        ObservableCollection<BaseFurniture> AvailableObjects { get; set; }
        RoomObjects RoomObjects { get; set; }
        BaseFurniture SelectedObject { get; set; }

        void AddObject(BaseFurniture objectToAdd, Point dropPosition, double canvasWidth, double canvasHeight);
        bool CheckIfObjectsOverlap(Point newPosition, BaseFurniture _draggedObject, double canvasWidth, double canvasHeight);
        void Initialize();
    }
}