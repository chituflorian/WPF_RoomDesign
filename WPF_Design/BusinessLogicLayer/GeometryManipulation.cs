using System.Windows;
using System.Windows.Media;
using WPF_Design.Models;
using WPF_Design.ViewModels;

namespace WPF_Design.BusinessLogicLayer
{
    public class GeometryManipulation
    {
        private readonly ObjectsOverlap _objectsOverlap;
        private readonly IRoomDesignViewModel _roomDesignViewModel;

        public GeometryManipulation(IRoomDesignViewModel roomDesignVM)
        {
            _roomDesignViewModel = roomDesignVM;
            _objectsOverlap = new(_roomDesignViewModel);
        }

        public void RotateObject(BaseFurniture objectToRotate)
        {
            if (objectToRotate is Wall || objectToRotate is Glass || objectToRotate is Door)
                return;

            var angle = (objectToRotate.Angle == 350) ? 0 : objectToRotate.Angle + 10;

            Geometry clone = _objectsOverlap.Clone(objectToRotate, angle, new Point(objectToRotate.CoordinateX, objectToRotate.CoordinateY));

            if (!_objectsOverlap.CheckIfObjectsOverlap(objectToRotate, clone))
            {
                objectToRotate.Angle = angle;
            }
        }

        public void DeleteObject(BaseFurniture objectToDelete)
        {
            if (MessageBox.Show("This object will be lost forever.", "Delete", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                if (objectToDelete is Wall || objectToDelete is Glass || objectToDelete is Door)
                    return;

                _roomDesignViewModel.RoomObjects.AddedObjects.Remove(objectToDelete);
                _roomDesignViewModel.SelectedObject = null;
            }
        }
    }
}
