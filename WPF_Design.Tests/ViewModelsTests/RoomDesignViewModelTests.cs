using System;
using System.ComponentModel;
using System.IO;
using Moq;
using NUnit.Framework;
using WPF_Design.BusinessLogicLayer;
using WPF_Design.DataProvider;
using WPF_Design.Models;
using WPF_Design.ViewModels;

namespace WPF_Design.Tests.ViewModelsTests
{
    public class RoomDesignViewModelTests
    {
        private readonly RoomDesignViewModel _roomDesignViewModel;
        private readonly Mock<IRoomDesignDataProvider> _roomDesignDataProviderMock;

        public RoomDesignViewModelTests()
        {
            _roomDesignDataProviderMock = new Mock<IRoomDesignDataProvider>();
            _roomDesignViewModel = new(new SelectedRoomViewModel(new SelectedRoomDataProvider()), _roomDesignDataProviderMock.Object);
         
            GeometryManipulation _geometryManipulation = new(_roomDesignViewModel);

            _roomDesignDataProviderMock.Setup(dp => dp.RotateObject(It.IsAny<BaseFurniture>())).Callback((BaseFurniture baseFurniture) => { _geometryManipulation.RotateObject(baseFurniture); });
            _roomDesignDataProviderMock.Setup(dp => dp.DeleteObject(It.IsAny<BaseFurniture>())).Callback((BaseFurniture baseFurniture) => { _geometryManipulation.DeleteObject(baseFurniture); });
        }

        [Test]
        public void SelectedObjectShouldRaiseEvent()
        {
            bool eventForSelectedObjectIsCorrect = false;
            bool eventForIsObjectSelectedIsCorrect = false;
            bool eventForButtonIsEnabledIsCorrect = false;

            _roomDesignViewModel.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    if (e.PropertyName == "SelectedObject")
                        eventForSelectedObjectIsCorrect = true;
                    if (e.PropertyName == "IsObjectSelected")
                        eventForIsObjectSelectedIsCorrect = true;
                    if (e.PropertyName == "ButtonIsEnabled")
                        eventForButtonIsEnabledIsCorrect = true;
                };


            _roomDesignViewModel.SelectedObject = new Door();

            Assert.Multiple(() =>
            {
                Assert.That(
                  eventForSelectedObjectIsCorrect, Is.True,
                  "Setting SelectedObject to true did not raise PropertyChanged event correctly.");

                Assert.That(
                  eventForIsObjectSelectedIsCorrect, Is.True,
                  "Setting SelectedObject to true did not raise PropertyChanged event for IsObjectSelected correctly.");

                Assert.That(
                  eventForButtonIsEnabledIsCorrect, Is.True,
                  "Setting SelectedObject to true did not raise PropertyChanged event for ButtonIsEnabled correctly.");

                Assert.That(_roomDesignViewModel.SelectedObject, Is.TypeOf(typeof(Door)), "SelectedObject should return true now.");
            });
        }

        [Test]
        public void IsObjectSelectedShouldRaiseEvent()
        {
            Assert.That(_roomDesignViewModel.IsObjectSelected, Is.False, "IsObjectSelected should return false now.");

            bool eventIsCorrect = false;
            _roomDesignViewModel.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    eventIsCorrect = e.PropertyName == "IsObjectSelected";
                };

            _roomDesignViewModel.SelectedObject = new Door();

            Assert.Multiple(() =>
            {
                Assert.That(
                  eventIsCorrect, Is.True,
                  "Setting IsObjectSelected to true did not raise PropertyChanged event correctly.");

                Assert.That(_roomDesignViewModel.IsObjectSelected, Is.True, "IsObjectSelected should return true now.");
            });
        }

        [Test]
        public void ButtonIsEnabledShouldRaiseEvent()
        {
            Assert.That(_roomDesignViewModel.ButtonIsEnabled, Is.False, "ButtonIsEnabled should return false now.");

            bool eventIsCorrect = false;
            _roomDesignViewModel.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    eventIsCorrect = e.PropertyName == "ButtonIsEnabled";
                };

            _roomDesignViewModel.ButtonIsEnabled = true;

            Assert.Multiple(() =>
            {
                Assert.That(
                  eventIsCorrect, Is.True,
                  "Setting ButtonIsEnabled to true did not raise PropertyChanged event correctly.");

                Assert.That(_roomDesignViewModel.ButtonIsEnabled, Is.True, "ButtonIsEnabled should return true now.");
            });
        }

        [Test]
        public void VisibilityShouldRaiseEvent()
        {
            Assert.That(_roomDesignViewModel.Visibility, Is.EqualTo("Hidden"), "Visibility should be \"Hidden\" now.");

            bool eventIsCorrect = false;
            _roomDesignViewModel.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    eventIsCorrect = e.PropertyName == "Visibility";
                };

            _roomDesignViewModel.Visibility = "Visible";

            Assert.Multiple(() =>
            {
                Assert.That(
                  eventIsCorrect, Is.True,
                  "Setting Visibility to \"Visible\" did not raise PropertyChanged event correctly.");

                Assert.That(_roomDesignViewModel.Visibility, Is.EqualTo("Visible"), "Visibility should be \"Visible\" now.");
            });
        }

        [Test]
        public void RoomObjectsShouldRaiseEvent()
        {
            bool eventIsCorrect = false;
            _roomDesignViewModel.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    eventIsCorrect = e.PropertyName == "RoomObjects";
                };

            _roomDesignViewModel.RoomObjects = new();


            Assert.That(eventIsCorrect, Is.True,
                "Setting RoomObjects did not raise PropertyChanged event correctly.");
        }

        [Test]
        public void AvailableObjectsShouldRaiseEvent()
        {
            bool eventIsCorrect = false;
            _roomDesignViewModel.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    eventIsCorrect = e.PropertyName == "AvailableObjects";
                };

            _roomDesignViewModel.AvailableObjects = new();

            Assert.That(eventIsCorrect, Is.True,
                "Setting AvailableObjects did not raise PropertyChanged event correctly.");
        }
        [Test]
        public void ShouldDisableButtonsWhenNoObjectIsSelected()
        {
            _roomDesignViewModel.SelectedObject = null;

            Assert.That(_roomDesignViewModel.ButtonIsEnabled, Is.False, "Setting SelectedObject to null did not disabled the buttons.");
        }

        [Test]
        public void ShouldEnableButtonsWhenAnObjectIsSelected()
        {
            _roomDesignViewModel.SelectedObject = new Wall();

            Assert.That(_roomDesignViewModel.ButtonIsEnabled, Is.True, "Setting SelectedObject to a new object did not enable the buttons.");
        }

        [Test]
        public void ShouldCallDeleteObjectMethodWhenDeleteCommandIsExecuted()
        {
            _roomDesignViewModel.RoomObjects.AddedObjects.Add(new Wall());

            _roomDesignViewModel.DeleteCommand.Execute(_roomDesignViewModel.RoomObjects.AddedObjects[0]); 
            _roomDesignDataProviderMock.Verify(dp => dp.DeleteObject(_roomDesignViewModel.RoomObjects.AddedObjects[0]), Times.Once);

        }

        [Test]
        public void ShouldCallRotateObjectMethodWhenRotateCommandIsExecuted()
        {
            _roomDesignViewModel.RoomObjects.AddedObjects.Add(new Cooker());

            _roomDesignViewModel.RotateCommand.Execute(_roomDesignViewModel.RoomObjects.AddedObjects[0]); 
            _roomDesignDataProviderMock.Verify(dp => dp.RotateObject(_roomDesignViewModel.RoomObjects.AddedObjects[0]), Times.Once);
        }
    }
}

