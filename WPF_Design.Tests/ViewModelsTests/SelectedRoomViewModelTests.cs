using Moq;
using NUnit.Framework;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using WPF_Design.DataProvider;
using WPF_Design.Models;
using WPF_Design.ViewModels;

namespace WPF_Design.Tests.ViewModelsTests
{
    public class SelectedRoomViewModelTests
    {
        private readonly SelectedRoomViewModel _viewModel;

        public SelectedRoomViewModelTests()
        {
            var selectedRoomDataProviderMock = new Mock<ISelectedRoomDataProvider>();

            selectedRoomDataProviderMock.Setup(dp => dp.LoadDefaultRoom(It.IsAny<string>(), It.IsAny<Type>()))
                .Returns(new ObservableCollection<BaseFurniture>() {
                    new Wall() { Id = 0, Name = "Wall", Width = 20, Height = 540, CoordinateX = 0, CoordinateY = 0, Angle = 0 },
                    new Wall() { Id = 1, Name = "Wall", Width = 20, Height = 50, CoordinateX = 0, CoordinateY = 0, Angle = 0 },
                    new Wall() { Id = 2, Name = "Wall", Width = 20, Height = 90, CoordinateX = 0, CoordinateY = 0, Angle = 0 }
                });

            selectedRoomDataProviderMock.Setup(dp => dp.OpenSavedRoom(It.IsAny<RoomObjects>()))
               .Callback((RoomObjects roomObjects) => {
                   roomObjects.SelectedRoomType = "room1";
                   roomObjects.AddedObjects = new(){
                            new Cooker() { Id = 1, Name = "Cooker", Width = 50, Height = 50, CoordinateX=0,CoordinateY=0,Angle=0},
                            new Wardrobe() { Id = 2, Name = "Wardrobe", Width = 100, Height = 50, CoordinateX=0,CoordinateY=0,Angle=0},
                            new Flower() { Id = 3, Name = "Wardrobe", Width = 50, Height = 50, CoordinateX=0,CoordinateY=0,Angle=0}
                   };
                   roomObjects.AuxiliaryObjects = selectedRoomDataProviderMock.Object.LoadDefaultRoom(
                       roomObjects.SelectedRoomType, roomObjects.AuxiliaryObjects.GetType());
               });

            _viewModel = new SelectedRoomViewModel(selectedRoomDataProviderMock.Object);
        }

        [Test]
        public void ShouldLoadDefaultRoom()
        {
            _viewModel.LoadDefaultRoom();

            //Test that the number of objects loaded is correct 
            Assert.AreEqual(3, _viewModel.RoomObjects.AuxiliaryObjects.Count);


            //Test that the BaseFurniture with the Id=0 has Height=540
            var obj = _viewModel.RoomObjects.AuxiliaryObjects.FirstOrDefault(item => item.Id == 0);
            Assert.NotNull(obj);
            Assert.AreEqual(540, obj.Height);


            //Test that the BaseFurniture with the Id=1 has Height=50
            obj = _viewModel.RoomObjects.AuxiliaryObjects.FirstOrDefault(item => item.Id == 1);
            Assert.NotNull(obj);
            Assert.AreEqual(50, obj.Height);
        }

        [Test]
        public void ShouldLoadSavedDefaultRoom()
        {
            _viewModel.OpenSavedRoom();

            //Test that the number of furniture loaded is correct 
            Assert.AreEqual(3, _viewModel.RoomObjects.AddedObjects.Count);

            //Test that the room type is correct
            Assert.AreEqual("room1", _viewModel.RoomObjects.SelectedRoomType);

            //Test that the number of auxiliary objects loaded is correct 
            Assert.AreEqual(3, _viewModel.RoomObjects.AuxiliaryObjects.Count);
        }
    }
}
