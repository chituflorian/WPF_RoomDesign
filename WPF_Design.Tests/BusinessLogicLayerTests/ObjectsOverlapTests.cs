using Moq;
using NUnit.Framework;
using System.Windows;
using System.Windows.Media;
using WPF_Design.DataProvider;
using WPF_Design.Models;
using WPF_Design.ViewModels;

namespace WPF_Design.Tests.BusinessLogicLayerTests
{
    public class ObjectsOverlapTests
    {
        private readonly IRoomDesignViewModel _roomDesignViewModel;
        private readonly Mock<IRoomDesignDataProvider> _roomDesignDataProviderMock;

        public ObjectsOverlapTests()
        {
            var selectedRoomViewModelMock = new Mock<ISelectedRoomViewModel>();
            _roomDesignDataProviderMock = new Mock<IRoomDesignDataProvider>();

            _roomDesignViewModel = new RoomDesignViewModel(selectedRoomViewModelMock.Object, _roomDesignDataProviderMock.Object);
        }

        [Test]
        public void CloneMethodReturnsClonedObject()
        {
            BaseFurniture furniture = new Chair();
            double angle = 10;
            Point newPosition = new(100, 100);

            Geometry expectedResult = furniture.OriginalGeometry.Clone();
            expectedResult.Transform = new ScaleTransform();
            expectedResult.Transform = new TransformGroup
            {
                Children = new TransformCollection(new Transform[]
                {
                    new ScaleTransform(furniture.Width / expectedResult.Bounds.Width,
                                       furniture.Height / expectedResult.Bounds.Height),
                    new RotateTransform(angle, furniture.Width / 2, furniture.Height / 2),
                    new TranslateTransform(newPosition.X, newPosition.Y),
                })
            };

            _roomDesignDataProviderMock.Setup(dp => dp.Clone(furniture, angle, newPosition)).Returns(expectedResult);

            Geometry actualResult = _roomDesignDataProviderMock.Object.Clone(furniture, angle, newPosition);

            Assert.AreEqual(expectedResult.Bounds, actualResult.Bounds);
        }

        [Test]
        public void CheckIfObjectsOverlapShouldReturnTrueIfTheMovedObjectIntersectsWithAnAddedObject()
        {
            BaseFurniture movedFurniture = new Chair();
            BaseFurniture furniture = new Chair();

            _roomDesignViewModel.RoomObjects = new()
            {
                AddedObjects = new()
                {
                    movedFurniture,
                    furniture
                }
            };

            Geometry clone = furniture.OriginalGeometry.Clone();

            _roomDesignDataProviderMock.Setup(dp => dp.CheckIfObjectsOverlap(movedFurniture, clone)).Returns(true);

            var result = _roomDesignDataProviderMock.Object.CheckIfObjectsOverlap(movedFurniture, clone);

            Assert.True(result);
        }

        [Test]
        public void CheckIfObjectsOverlapShouldReturnFalseIfThereAreNoAddedObjects()
        {
            BaseFurniture movedFurniture = new Chair();
            BaseFurniture furniture = new Chair();

            _roomDesignViewModel.RoomObjects = new()
            {
                AddedObjects = new() { }
            };

            Geometry clone = furniture.OriginalGeometry.Clone();

            _roomDesignDataProviderMock.Setup(dp => dp.CheckIfObjectsOverlap(movedFurniture, clone)).Returns(false);

            var result = _roomDesignDataProviderMock.Object.CheckIfObjectsOverlap(movedFurniture, clone);

            Assert.False(result);
        }

        [Test]
        public void CheckIfObjectsOverlapShouldReturnTrueIfTheMovedObjectIntersectsWithAnAuxiliaryObject()
        {
            BaseFurniture movedFurniture = new Chair();

            _roomDesignViewModel.RoomObjects = new()
            {
                AddedObjects = new()
                {
                    movedFurniture
                },
                AuxiliaryObjects = new()
                {
                    new Wall()
                }
            };

            Geometry clone = movedFurniture.OriginalGeometry.Clone();

            _roomDesignDataProviderMock.Setup(dp => dp.CheckIfObjectsOverlap(movedFurniture, clone)).Returns(true);

            var result = _roomDesignDataProviderMock.Object.CheckIfObjectsOverlap(movedFurniture, clone);

            Assert.True(result);
        }

        [Test]
        public void CheckIfObjectsOverlapShouldReturnFalseIfThereAreNoAuxiliaryObjects()
        {
            BaseFurniture movedFurniture = new Chair();

            _roomDesignViewModel.RoomObjects = new()
            {
                AddedObjects = new()
                {
                    movedFurniture
                },
                AuxiliaryObjects = new() { }
            };

            Geometry clone = movedFurniture.OriginalGeometry.Clone();

            _roomDesignDataProviderMock.Setup(dp => dp.CheckIfObjectsOverlap(movedFurniture, clone)).Returns(false);

            var result = _roomDesignDataProviderMock.Object.CheckIfObjectsOverlap(movedFurniture, clone);

            Assert.False(result);
        }

        [Test]
        public void CheckIfObjectsOverlapShouldReturnFalseIfTheirIsNoIntersection()
        {
            BaseFurniture movedFurniture = new Chair();
            BaseFurniture furniture = new Chair();

            furniture.OriginalGeometry.Transform = new TranslateTransform(100, 100);

            _roomDesignViewModel.RoomObjects = new()
            {
                AddedObjects = new()
                {
                    movedFurniture,
                    furniture
                },
                AuxiliaryObjects = new()
                {
                    new Wall()
                    {
                        CoordinateY = 200,
                        CoordinateX = 200
                    }
                }
            };

            Geometry clone = movedFurniture.OriginalGeometry.Clone();

            _roomDesignDataProviderMock.Setup(dp => dp.CheckIfObjectsOverlap(movedFurniture, clone)).Returns(false);

            var result = _roomDesignDataProviderMock.Object.CheckIfObjectsOverlap(movedFurniture, clone);

            Assert.False(result);
        }
    }
}
