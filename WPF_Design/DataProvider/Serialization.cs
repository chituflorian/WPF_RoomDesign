using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using WPF_Design.Models;

namespace WPF_Design.DataProvider
{
    public class Serialization : ISerialize
    {
        public ObservableCollection<BaseFurniture> LoadDefaultRoom(string fileName, Type type)
        {
            XmlSerializer serializer = new(type);
            fileName = Environment.CurrentDirectory + "\\Resources\\DefaultRooms\\" + fileName + ".xml";

            if (!File.Exists(fileName))
                return null;

            using Stream reader = new FileStream(fileName, FileMode.Open);

            return (ObservableCollection<BaseFurniture>)serializer.Deserialize(reader);
        }

        public void OpenSavedRoom(RoomObjects roomObjects)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new()
            {
                InitialDirectory = Environment.CurrentDirectory + "\\SavedFloorplans",
                DefaultExt = ".xml",
                Filter = "XML Files (*.xml) | *.xml",
                Title = "Load Room"
            };

            if (openFileDialog.ShowDialog() == false)
                return;

            string fileName = openFileDialog.FileName;
            if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
                return;

            using Stream reader = new FileStream(fileName, FileMode.Open);
            XmlSerializer serializer = new(roomObjects.GetType());
            var copy = (RoomObjects)serializer.Deserialize(reader);

            roomObjects.AddedObjects = new(copy.AddedObjects);
            roomObjects.SelectedRoomType = copy.SelectedRoomType;

            if (roomObjects.SelectedRoomType == "custom")
            {
                roomObjects.AuxiliaryObjects = new(copy.AuxiliaryObjects);
            }
            else
            {
                roomObjects.AuxiliaryObjects = LoadDefaultRoom(roomObjects.SelectedRoomType, roomObjects.AuxiliaryObjects.GetType());
            }

            reader.Dispose();
        }

        public void SaveRoom(RoomObjects roomObjects)
        {
            if (MessageBox.Show("Would you like to save this room?", "Save", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Microsoft.Win32.SaveFileDialog saveFileDialog = new()
                {
                    InitialDirectory = Environment.CurrentDirectory + "\\SavedFloorplans",
                    DefaultExt = ".xml",
                    Filter = "XML Files (*.xml) | *.xml",
                    Title = "Save Room Layout"
                };

                if (saveFileDialog.ShowDialog() == false)
                    return;

                if (saveFileDialog.FileName == null)
                    return;

                string fileName = saveFileDialog.FileName;
                if (string.IsNullOrEmpty(fileName))
                    return;

                using StreamWriter streamWriter = new(fileName);
                var ws = new XmlWriterSettings { Indent = true, NewLineOnAttributes = true, OmitXmlDeclaration = true };

                XmlWriter writer = XmlWriter.Create(streamWriter, ws);
                XmlSerializer serializer = new(roomObjects.GetType());

                if (roomObjects.SelectedRoomType == "custom")
                {
                    serializer.Serialize(writer, new RoomObjects()
                    {
                        AddedObjects = roomObjects.AddedObjects,
                        AuxiliaryObjects = roomObjects.AuxiliaryObjects,
                        SelectedRoomType = roomObjects.SelectedRoomType
                    });
                }
                else
                {
                    serializer.Serialize(writer, new RoomObjects()
                    {
                        AddedObjects = roomObjects.AddedObjects,
                        AuxiliaryObjects = new ObservableCollection<BaseFurniture>(),
                        SelectedRoomType = roomObjects.SelectedRoomType
                    });
                }

                writer.Dispose();
                streamWriter.Dispose();
            }
        }
    }
}