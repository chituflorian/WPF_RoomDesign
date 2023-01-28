using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class LivingRoomTable : BaseFurniture
    {
        private string material = string.Empty;
        public string Material
        {
            get => material;
            set
            {
                material = value;
                NotifyPropertyChanged(nameof(Material));
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


        public LivingRoomTable()
        {
            Name = "Living Room Table";
            Description = "A living room table";
            Color = "Gray";
            Material = "Glass";
            OriginalGeometry = CreateGeometry();
            Width = 100;
            Height = 60;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure table = new()
            {
                IsClosed = true,
                StartPoint = new Point(0, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (200, 0) },
                    new LineSegment() { Point = new (200, 170) },
                    new LineSegment() { Point = new (0, 170) },
                    new LineSegment() { Point = new (0, 0) },
                }
            };

            PathFigure magazines = new()
            {
                IsClosed = true,
                StartPoint = new(0, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (20, 100), IsStroked = false },
                    new LineSegment() { Point = new (200, 200), IsStroked = false },
                    new LineSegment() { Point = new (20, 100), IsStroked = false },
                    new LineSegment() { Point = new (50, 80) },
                    new LineSegment() { Point = new (55, 90) },
                    new LineSegment() { Point = new (80, 85) },
                    new LineSegment() { Point = new (82, 95) },
                    new LineSegment() { Point = new (110, 100) },
                    new LineSegment() { Point = new (105, 148) },
                    new LineSegment() { Point = new (77, 143) },
                    new LineSegment() { Point = new (82, 95) },
                    new LineSegment() { Point = new (82, 95), IsStroked = false },
                    new LineSegment() { Point = new (78, 135) },
                    new LineSegment() { Point = new (62, 138) },
                    new LineSegment() { Point = new (55, 90) },
                    new LineSegment() { Point = new (55, 90), IsStroked = false },
                    new LineSegment() { Point = new (60, 125) },
                    new LineSegment() { Point = new (38, 138) },
                    new LineSegment() { Point = new (20, 100) },
                    new LineSegment() { Point = new (0, 0), IsStroked = false },
                }
            };

            figuresCollection.Add(table);
            figuresCollection.Add(magazines);

            _originalGeometry = new PathGeometry(figuresCollection) { FillRule = FillRule.Nonzero };

            return _originalGeometry;
        }
    }
}
