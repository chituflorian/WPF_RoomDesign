using Moq;
using NUnit.Framework;
using WPF_Design.BusinessLogicLayer;
using WPF_Design.DataProvider;
using WPF_Design.Models;
using WPF_Design.ViewModels;
using System.Windows;
using System.Windows.Media;

namespace WPF_Design.Tests.BusinessLogicLayerTests
{
    public class GeometryManipulationTests
    {
        private readonly IRoomDesignViewModel _roomDesignViewModel;
        private readonly Mock<IRoomDesignDataProvider> _roomDesignDataProviderMock;
        private readonly GeometryManipulation _geometryManipulation;

        private readonly BaseFurniture _chair;
        private readonly BaseFurniture _table;
        private readonly BaseFurniture _wall;

        public GeometryManipulationTests()
        {
            var selectedRoomViewModelMock = new Mock<ISelectedRoomViewModel>();
            _roomDesignDataProviderMock = new Mock<IRoomDesignDataProvider>();

            _roomDesignViewModel = new RoomDesignViewModel(selectedRoomViewModelMock.Object, _roomDesignDataProviderMock.Object);

            _chair = new Chair();
            _table = new Table();
            _wall = new Wall();

            _roomDesignViewModel.RoomObjects = new()
            {
                AddedObjects = new() { _chair, _table },
                AuxiliaryObjects = new() { _wall, new Door() }
            };
            ;
            _geometryManipulation = new(_roomDesignViewModel);
        }

        [Test]
        public void RotateObjectMethodShouldNotExecuteIfObjectIsDoorGlassOrWall()
        {
            double angle = 10;
            Point newPosition = new(100, 100);

            _geometryManipulation.RotateObject(_wall);

            _roomDesignDataProviderMock.Verify(dp => dp.Clone(_wall, angle, newPosition), Times.Never);
        }

        [Test]
        public void CloneMethodShouldExecuteOnceBeforeAnObjectIsRotated()
        {
            _table.Angle = 90;
            _table.CoordinateX = 100;
            _table.CoordinateY = 100;

            Geometry geometry = _roomDesignDataProviderMock.Object.Clone(_table, _table.Angle,
                                               new Point(_table.CoordinateX, _table.CoordinateY));

            _roomDesignDataProviderMock.Verify(dp => dp.Clone(_table, _table.Angle, 
                                               new Point(_table.CoordinateX, _table.CoordinateY)), Times.Once);
        }

        [Test]
        public void CheckIfObjectsOverlapMethodShouldExecuteAtLeastOnceBeforeAnObjectIsRotated()
        {
            Geometry clone = _chair.OriginalGeometry.Clone();

            bool isOverlap = _roomDesignDataProviderMock.Object.CheckIfObjectsOverlap(_table, clone);

            _roomDesignDataProviderMock.Verify(dp => dp.CheckIfObjectsOverlap(_table, clone), Times.AtLeastOnce);
        }

        [Test]
        public void RotateObjectShouldNotExecuteIfObjectsOverlap()
        {
            Geometry clone = _chair.OriginalGeometry.Clone();

            _roomDesignDataProviderMock.Setup(dp => dp.CheckIfObjectsOverlap(_chair, clone)).Returns(true);

            bool isOverlap = _roomDesignDataProviderMock.Object.CheckIfObjectsOverlap(_chair, clone);
            _geometryManipulation.RotateObject(_chair);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(isOverlap);
                Assert.AreEqual(_chair.OriginalGeometry.Bounds, clone.Bounds);
            });
        }

        [Test]
        public void SelectedObjectPropertyShouldNotBeNullBeforeDeletingAnObject()
        {
            _roomDesignViewModel.SelectedObject = _chair;

            Assert.IsNotNull(_roomDesignViewModel.SelectedObject);
        }

        [Test]
        public void DeleteObjectMethodShouldExecuteIfObjectIsNotDoorGlassOrWall()
        {
            _geometryManipulation.DeleteObject(_chair);

            Assert.AreEqual(1, _roomDesignViewModel.RoomObjects.AddedObjects.Count);
        }

        [Test]
        public void DeleteObjectMethodShouldNotExecuteIfObjectIsDoorGlassOrWall()
        {
            _geometryManipulation.DeleteObject(_wall);

            Assert.AreEqual(1, _roomDesignViewModel.RoomObjects.AddedObjects.Count);
        }

        [Test]
        public void SelectedObjectPropertyShouldBecomeNullAfterDeletingAnObject()
        {
            _geometryManipulation.DeleteObject(_table);

            Assert.IsNull(_roomDesignViewModel.SelectedObject);
        }
    }
}
