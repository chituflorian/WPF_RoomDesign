using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class TV : BaseFurniture
    {
        private string brand = string.Empty;
        public string Brand
        {
            get => brand;
            set
            {
                brand = value;
                NotifyPropertyChanged(nameof(Brand));
            }
        }

        private Geometry _originalGeometry;
        [XmlIgnore]
        public override Geometry OriginalGeometry
        {
            get => _originalGeometry;
            set
            {
                _originalGeometry = value;
                NotifyPropertyChanged(nameof(OriginalGeometry));
            }
        }


        public TV()
        {
            Name = "TV";
            Brand = "Sony";
            Color = "Gray";          
            Description = "A smart tv.";
            OriginalGeometry = CreateGeometry();
            Width = 20;
            Height = 60;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure figure = new()
            {
                StartPoint = new Point(20, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (20, 50) },
                    new LineSegment() { Point = new (40, 50) },
                    new LineSegment() { Point = new (40, 0) },
                    new LineSegment() { Point = new (20, 0) },
                    new LineSegment() { Point = new (20, 15) },
                    new LineSegment() { Point = new (20, 35) },
                    new LineSegment() { Point = new (0, 35) },
                    new LineSegment() { Point = new (0, 15) },
                    new LineSegment() { Point = new (20, 15) },
                    new LineSegment() { Point = new (20, 0) },
                }
            };

            figuresCollection.Add(figure);
            _originalGeometry = new PathGeometry(figuresCollection);

            return _originalGeometry;
        }
    }
}
