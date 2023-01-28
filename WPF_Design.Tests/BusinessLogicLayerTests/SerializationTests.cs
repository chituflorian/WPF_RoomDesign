using Moq;
using NUnit.Framework;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using WPF_Design.DataProvider;
using WPF_Design.Models;

namespace WPF_Design.Tests.BusinessLogicLayerTests
{
    public class SerializationTests
    {
        private readonly Mock<IFileDialog> _fileDialog;

        public SerializationTests()
        {
            Directory.SetCurrentDirectory(@"../../../../WPF_Design/");

            string initialDirectory = Environment.CurrentDirectory;
            string defaultExt = ".xml";
            string filter = "XML Files (*.xml) | *.xml";
            string fileName = Environment.CurrentDirectory + @"/Resources/TestRooms/savedRoomTest.xml";

            _fileDialog = new();
            _fileDialog.Setup(_ => _.InitialDirectory).Returns(initialDirectory);
            _fileDialog.Setup(_ => _.DefaultExt).Returns(defaultExt);
            _fileDialog.Setup(_ => _.Filter).Returns(filter);
            _fileDialog.Setup(_ => _.FileName).Returns(fileName);
            _fileDialog.Setup(_ => _.ShowDialog()).Returns(true);
        }

        [Test]
        public void ShouldLoadDefaultRoom()
        {
            RoomObjects roomObjects = new()
            {
                AuxiliaryObjects = new()
                {
                    new Wall() { Id = 0, Width = 20, Height = 540, CoordinateX = 0, CoordinateY = 0 },
                    new Wall() { Id = 0, Width = 200, Height = 20, CoordinateX = 20, CoordinateY = 0 },
                    new Glass() { Id = 0, Width = 20, Height = 150, CoordinateX = 220, CoordinateY = 20, Angle = -90 },
                    new Wall() { Id = 0, Width = 450, Height = 20, CoordinateX = 370, CoordinateY = 0 },
                    new Door() { Id = 0, Width = 20, Height = 100, CoordinateX = 820, CoordinateY = 20, Angle = -90 },
                    new Wall() { Id = 0, Width = 130, Height = 20, CoordinateX = 920, CoordinateY = 0 },
                    new Wall() { Id = 0, Width = 20, Height = 150, CoordinateX = 1030, CoordinateY = 20 },
                    new Glass() { Id = 0, Width = 20, Height = 150, CoordinateX = 1030, CoordinateY = 170 },
                    new Wall() { Id = 0, Width = 20, Height = 220, CoordinateX = 1030, CoordinateY = 320 },
                    new Wall() { Id = 0, Width = 150, Height = 20, CoordinateX = 0, CoordinateY = 520 },
                    new Glass() { Id = 0, Width = 20, Height = 200, CoordinateX = 150, CoordinateY = 540, Angle = -90 },
                    new Wall() { Id = 0, Width = 300, Height = 20, CoordinateX = 350, CoordinateY = 520 },
                    new Glass() { Id = 0, Width = 20, Height = 220, CoordinateX = 650, CoordinateY = 540, Angle = -90 },
                    new Wall() { Id = 0, Width = 180, Height = 20, CoordinateX = 870, CoordinateY = 520 },
                    new Wall() { Id = 0, Width = 420, Height = 20, CoordinateX = 20, CoordinateY = 250 },
                    new Wall() { Id = 0, Width = 20, Height = 120, CoordinateX = 420, CoordinateY = 20 },
                    new Door() { Id = 0, Width = 20, Height = 110, CoordinateX = 420, CoordinateY = 140 },
                    new Wall() { Id = 0, Width = 20, Height = 140, CoordinateX = 420, CoordinateY = 270 },
                    new Door() { Id = 0, Width = 20, Height = 110, CoordinateX = 420, CoordinateY = 410 }
                }
            };

            XmlSerializer serializer = new(roomObjects.AuxiliaryObjects.GetType());
            string fileName = Environment.CurrentDirectory + @"/Resources/DefaultRooms/room2.xml";
            using Stream reader = new FileStream(fileName, FileMode.Open);

            var actualResult = (ObservableCollection<BaseFurniture>)serializer.Deserialize(reader);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(actualResult != null);
                Assert.AreEqual(roomObjects.AuxiliaryObjects.Count, actualResult.Count);
                Assert.AreEqual(roomObjects.AuxiliaryObjects[0].GetType(), actualResult[0].GetType());
            });
        }

        [Test]
        public void FileDialogShouldOpenCorrectly()
        {
            Assert.IsTrue(_fileDialog.Object.ShowDialog());
        }

        [Test]
        public void FileDialogShouldOpenOnlyOnce()
        {
            _fileDialog.Verify(fd => fd.ShowDialog(), Times.Once);
        }

        [Test]
        public void FileDialogShouldSelectCorrectFile()
        {
            string fileName = Environment.CurrentDirectory + @"/Resources/TestRooms/savedRoomTest.xml";

            Assert.AreEqual(fileName, _fileDialog.Object.FileName);
        }

        [Test]
        public void ShouldOpenSavedRoom()
        {
            RoomObjects roomObjects = new()
            {
                AddedObjects = new()
                {
                    new Flower() { Id = 1, Width = 60, Height = 60, CoordinateX = 523.6091984231275, CoordinateY = 42.00788436268063 },
                    new Desk() { Id = 2, Width = 100, Height = 100, CoordinateX = 894.1584756898819, CoordinateY = 397.6557161629436}
                },
                AuxiliaryObjects = new()
            };

            string fileName = Environment.CurrentDirectory + @"/Resources/TestRooms/savedRoomTest.xml";

            XmlSerializer serializer = new(roomObjects.GetType());

            using Stream reader = new FileStream(fileName, FileMode.Open);
            var actualResult = (RoomObjects)serializer.Deserialize(reader);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(actualResult != null);
                Assert.AreEqual(roomObjects.AddedObjects.Count, actualResult.AddedObjects.Count);
                Assert.AreEqual(roomObjects.AddedObjects[0].GetType(), actualResult.AddedObjects[0].GetType());
            });
        }

        [Test]
        public void ShouldSaveRoomAndOmitAuxiliaryObjectsWhenRoomTypeIsDefault()
        {
            RoomObjects roomObjects = new()
            {
                AddedObjects = new()
                {
                    new Flower() { Id = 1, Width = 60, Height = 60, CoordinateX = 523.6091984231275, CoordinateY = 42.00788436268063 },
                    new Desk() { Id = 2, Width = 100, Height = 100, CoordinateX = 894.1584756898819, CoordinateY = 397.6557161629436}
                },
                AuxiliaryObjects = new(),
                SelectedRoomType = "room2"
            };

            string fileName = Environment.CurrentDirectory + @"/Resources/TestRooms/savedRoomTest.xml";

            using StreamWriter streamWriter = new(fileName);
            var ws = new XmlWriterSettings { Indent = true, NewLineOnAttributes = true, OmitXmlDeclaration = true };

            XmlWriter writer = XmlWriter.Create(streamWriter, ws);
            XmlSerializer serializer = new(roomObjects.GetType());

            serializer.Serialize(writer, new RoomObjects()
            {
                AuxiliaryObjects = roomObjects.AuxiliaryObjects,
                AddedObjects = roomObjects.AddedObjects,
                SelectedRoomType = roomObjects.SelectedRoomType
            });

            writer.Dispose();
            streamWriter.Dispose();

            using Stream reader = new FileStream(fileName, FileMode.Open);
            var actualResult = (RoomObjects)serializer.Deserialize(reader);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(actualResult != null);
                Assert.AreEqual(roomObjects.SelectedRoomType, "room2");
                Assert.AreEqual(roomObjects.AuxiliaryObjects.Count, 0);
                Assert.AreEqual(roomObjects.AddedObjects.Count, actualResult.AddedObjects.Count);
                Assert.AreEqual(roomObjects.AddedObjects[0].GetType(), actualResult.AddedObjects[0].GetType());
            });
        }

        [Test]
        public void ShouldSaveRoomAndIncludeAuxiliaryObjectsWhenRoomTypeIsCustom()
        {
            RoomObjects roomObjects = new()
            {
                AddedObjects = new()
                {
                    new Carpet() { Id = 1, Width = 100, Height = 50, CoordinateX = 252.40289093298287, CoordinateY = 150.29172141918525 },
                    new Table() { Id = 2, Width = 100, Height = 70, CoordinateX = 757.0651773981604, CoordinateY = 252.6149802890933}
                },
                AuxiliaryObjects = new()
                {
                    new Wall() { Id = 0, Width = 908, Height = 20, CoordinateX = 38, CoordinateY = 13.5 },
                    new Wall() { Id = 0, Width = 987, Height = 20, CoordinateX = 36, CoordinateY = 523.5 },
                },
                SelectedRoomType = "custom"
            };

            string fileName = Environment.CurrentDirectory + @"/Resources/TestRooms/customRoomTest.xml";
            using StreamWriter streamWriter = new(fileName);
            var ws = new XmlWriterSettings { Indent = true, NewLineOnAttributes = true, OmitXmlDeclaration = true };

            XmlWriter writer = XmlWriter.Create(streamWriter, ws);
            XmlSerializer serializer = new(roomObjects.GetType());

            serializer.Serialize(writer, new RoomObjects()
            {
                AuxiliaryObjects = roomObjects.AuxiliaryObjects,
                AddedObjects = roomObjects.AddedObjects,
                SelectedRoomType = roomObjects.SelectedRoomType
            });

            writer.Dispose();
            streamWriter.Dispose();

            using Stream reader = new FileStream(fileName, FileMode.Open);
            var actualResult = (RoomObjects)serializer.Deserialize(reader);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(actualResult != null);
                Assert.AreEqual(roomObjects.SelectedRoomType, "custom");
                Assert.AreEqual(roomObjects.AuxiliaryObjects.Count, actualResult.AuxiliaryObjects.Count);
                Assert.AreEqual(roomObjects.AuxiliaryObjects[0].GetType(), actualResult.AuxiliaryObjects[0].GetType());
                Assert.AreEqual(roomObjects.AddedObjects.Count, actualResult.AddedObjects.Count);
                Assert.AreEqual(roomObjects.AddedObjects[0].GetType(), actualResult.AddedObjects[0].GetType());
            });
        }
    }
}