using System.Linq;
using System.Windows;
using System.Windows.Media;
using WPF_Design.Models;
using WPF_Design.ViewModels;

namespace WPF_Design.BusinessLogicLayer
{
    public class ObjectsOverlap
    {
        private IRoomDesignViewModel _roomDesignViewModel;

        public ObjectsOverlap(IRoomDesignViewModel roomDesignViewModel)
        {
            _roomDesignViewModel = roomDesignViewModel;
        }

        public Geometry Clone(BaseFurniture furniture, double angle, Point newPosition)
        {
            Geometry clone = furniture.OriginalGeometry.Clone();

            clone.Transform = new ScaleTransform();
            clone.Transform = new TransformGroup
            {
                Children = new TransformCollection(new Transform[]
                {
                    new ScaleTransform(furniture.Width / clone.Bounds.Width,
                                       furniture.Height / clone.Bounds.Height),
                    new RotateTransform(angle, furniture.Width / 2, furniture.Height / 2),
                    new TranslateTransform(newPosition.X, newPosition.Y),
                })
            };
            return clone;
        }

        public bool CheckIfObjectsOverlap(BaseFurniture movedFurniture, Geometry clone)
        {
            bool intersects = _roomDesignViewModel.RoomObjects.AddedObjects.Any(furniture => furniture != movedFurniture &&
                             clone.FillContainsWithDetail(furniture.OriginalGeometry)
                             is IntersectionDetail.Intersects);
            if (intersects)
                return true;

            intersects = _roomDesignViewModel.RoomObjects.AuxiliaryObjects.Any(furniture =>
                              clone.FillContainsWithDetail(furniture.OriginalGeometry)
                              is IntersectionDetail.Intersects);
            return intersects;
        }
    }
}
