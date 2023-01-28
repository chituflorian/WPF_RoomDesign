using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Glass : BaseFurniture
    {
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


        public Glass()
        {
            Name = "Glass window";
            Description = "A description";    
            Color = "Blue";
            OriginalGeometry = CreateGeometry();
            Width = 20;
            Height = 50;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure figure = new()
            {
                StartPoint = new Point(0, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (0, 60) },
                    new LineSegment() { Point = new (10, 60) },
                    new LineSegment() { Point = new (10, 0) },
                    new LineSegment() { Point = new (0, 0) },
                    new LineSegment() { Point = new (0, 3) },
                    new LineSegment() { Point = new (10, 3) },
                    new LineSegment() { Point = new (10, 3) },
                    new LineSegment() { Point = new (0, 3) },
                    new LineSegment() { Point = new (0, 57) },
                    new LineSegment() { Point = new (10, 57) },
                    new LineSegment() { Point = new (10, 57) },
                    new LineSegment() { Point = new (7, 57) },
                    new LineSegment() { Point = new (7, 3) },
                    new LineSegment() { Point = new (7, 3) },
                    new LineSegment() { Point = new (7, 57) },
                    new LineSegment() { Point = new (3, 57) },
                    new LineSegment() { Point = new (3, 3) },
                    new LineSegment() { Point = new (3, 3) },
                    new LineSegment() { Point = new (3, 57) },
                    new LineSegment() { Point = new (0, 57) },
                }
            };

            figuresCollection.Add(figure);
            _originalGeometry = new PathGeometry(figuresCollection);

            return _originalGeometry;
        }
    }
}
