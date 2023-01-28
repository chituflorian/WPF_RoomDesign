using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;
using WPF_Design.BusinessLogicLayer;

namespace WPF_Design.Models
{
    [XmlInclude(typeof(ArmChair)),
        XmlInclude(typeof(BathroomSink)),
        XmlInclude(typeof(Bathtub)),
        XmlInclude(typeof(Bed)),
        XmlInclude(typeof(Carpet)),
        XmlInclude(typeof(Chair)),
        XmlInclude(typeof(Cooker)),
        XmlInclude(typeof(Couch)),
        XmlInclude(typeof(Desk)),
        XmlInclude(typeof(Door)),
        XmlInclude(typeof(Flower)),
        XmlInclude(typeof(Glass)),
        XmlInclude(typeof(KitchenSink)),
        XmlInclude(typeof(LivingRoomTable)),
        XmlInclude(typeof(Nightstand)),
        XmlInclude(typeof(RoundStairs)),
        XmlInclude(typeof(Shower)),
        XmlInclude(typeof(StraightStairs)),
        XmlInclude(typeof(Table)),
        XmlInclude(typeof(Toilet)),
        XmlInclude(typeof(TV)),
        XmlInclude(typeof(Wall)),
        XmlInclude(typeof(Wardrobe))]

    [Serializable]
    public abstract class BaseFurniture : PropertyChange
    {
        [XmlIgnore]
        public abstract Geometry OriginalGeometry { get; set; }


        private int _id = 0;
        [XmlElement]
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                NotifyPropertyChanged(nameof(Id));
            }
        }


        private string _name = string.Empty;
        [XmlElement]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }


        private string _description = "An object.";
        [XmlElement]
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                NotifyPropertyChanged(nameof(Description));
            }
        }


        private string _color = "White";
        [XmlElement]
        public string Color
        {
            get => _color;
            set
            {
                _color = value;
                NotifyPropertyChanged(nameof(Color));
            }
        }


        private double _width;
        [XmlElement]
        public double Width
        {
            get => _width;
            set
            {
                _width = value;

                UpdateTransform();

                NotifyPropertyChanged(nameof(Width));
            }
        }


        private double _height;
        [XmlElement]
        public double Height
        {
            get => _height;
            set
            {
                _height = value;

                UpdateTransform();

                NotifyPropertyChanged(nameof(Height));
            }
        }


        private double _coordinateX;
        [XmlElement]
        public double CoordinateX
        {
            get => _coordinateX;
            set
            {
                _coordinateX = value;

                UpdateTransform();

                NotifyPropertyChanged(nameof(CoordinateX));
            }
        }


        private double _coordinateY;
        [XmlElement]
        public double CoordinateY
        {
            get => _coordinateY;
            set
            {
                _coordinateY = value;

                UpdateTransform();

                NotifyPropertyChanged(nameof(CoordinateY));
            }
        }


        private double _angle;
        [XmlElement]
        public double Angle
        {
            get => _angle;
            set
            {
                _angle = value;

                UpdateTransform();

                NotifyPropertyChanged(nameof(Angle));
            }
        }


        private void UpdateTransform()
        {
            Point center = (Name == "Wall" || Name == "Door" || Name == "Glass window")
                           ? new(0, 0)
                           : new(Width / 2, Height / 2);

            OriginalGeometry.Transform = new ScaleTransform();

            OriginalGeometry.Transform = new TransformGroup
            {
                Children = new TransformCollection(new Transform[]
                {
                    new ScaleTransform(Width / OriginalGeometry.Bounds.Width, Height / OriginalGeometry.Bounds.Height),
                    new RotateTransform(Angle, center.X , center.Y),
                    new TranslateTransform(CoordinateX, CoordinateY),
                })
            };
        }
    }
}
