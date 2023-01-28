using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Wardrobe : BaseFurniture
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


        public Wardrobe()
        {
            Name = "Wardrobe";
            Description = "Space for clothes.";
            Color = "Brown";
            OriginalGeometry = CreateGeometry();
            Width = 100;
            Height = 60;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure figure = new()
            {
                StartPoint = new Point(400, 300),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (400, 0) },
                    new LineSegment() { Point = new (0, 0) },
                    new LineSegment() { Point = new (0, 300) },
                    new LineSegment() { Point = new (400, 300) },
                    new LineSegment() { Point = new (400, 400), IsStroked = false },
                    new LineSegment() { Point = new (400, 300), IsStroked = false },
                    new LineSegment() { Point = new (220, 400) },
                    new LineSegment() { Point = new (220, 380) },
                    new LineSegment() { Point = new (370, 300) },
                    new LineSegment() { Point = new (0, 300) },
                    new LineSegment() { Point = new (0, 300) },
                    new LineSegment() { Point = new (180, 400) },
                    new LineSegment() { Point = new (180, 380) },
                    new LineSegment() { Point = new (30, 300) },
                }
            };

            figuresCollection.Add(figure);
            _originalGeometry = new PathGeometry(figuresCollection) { FillRule = FillRule.Nonzero };

            return _originalGeometry;
        }
    }
}