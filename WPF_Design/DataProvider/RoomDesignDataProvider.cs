using System.Windows;
using System.Windows.Media;
using WPF_Design.BusinessLogicLayer;
using WPF_Design.Models;
using WPF_Design.ViewModels;

namespace WPF_Design.DataProvider
{
    public class RoomDesignDataProvider : IRoomDesignDataProvider
    {
        private readonly GeometryManipulation _geometryManipulation;
        private readonly Serialization _serialization;
        private readonly ObjectsOverlap _objectsOverlap;

        public RoomDesignDataProvider(RoomDesignViewModel roomDesignViewModel)
        {
            _geometryManipulation = new(roomDesignViewModel);
            _serialization = new();
            _objectsOverlap = new(roomDesignViewModel);
        }

        public void OpenSavedRoom(RoomObjects roomObjects)
        {
            _serialization.OpenSavedRoom(roomObjects);
        }

        public void SaveRoom(RoomObjects roomObjects)
        {
            _serialization.SaveRoom(roomObjects);
        }

        public void DeleteObject(BaseFurniture objectToDelete)
        {
            _geometryManipulation.DeleteObject(objectToDelete);
        }

        public void RotateObject(BaseFurniture objectToRotate)
        {
            _geometryManipulation.RotateObject(objectToRotate);
        }

        public Geometry Clone(BaseFurniture draggedObject, double angle, Point newPosition)
        {
            return _objectsOverlap.Clone(draggedObject, angle, newPosition);
        }

        public bool CheckIfObjectsOverlap(BaseFurniture draggedObject, Geometry clone)
        {
            return _objectsOverlap.CheckIfObjectsOverlap(draggedObject, clone);
        }
    }
}
