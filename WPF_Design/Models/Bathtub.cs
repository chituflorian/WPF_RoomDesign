using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Bathtub : BaseFurniture
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


        public Bathtub()
        {
            Name = "Bathtub";
            Description = "A bathtub.";
            OriginalGeometry = CreateGeometry();
            Width = 150;
            Height = 60;
        }
        
        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure figure = new()
            {
                StartPoint = new Point(0, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new(20, 0), IsStroked=false },
                    new ArcSegment() { Point = new(20, 90), Size = new (2,4) },
                    new LineSegment() { Point = new(140, 90) },
                    new LineSegment() { Point = new(170, 90), IsStroked=false },
                    new LineSegment() { Point = new(140, 90), IsStroked=false },
                    new ArcSegment() { Point = new(140, 0), Size = new (3,5) },
                    new LineSegment() { Point = new(20, 0) },
                    new LineSegment() { Point = new(20, 10), IsStroked = false },
                    new LineSegment() { Point = new(20, 80) },
                    new LineSegment() { Point = new(135, 80) },
                    new ArcSegment() { Point = new(135, 10), Size = new (3,5) },
                    new LineSegment() { Point = new(20, 10) },
                    new LineSegment() { Point = new(10, 25), IsStroked = false},
                    new ArcSegment() { Point = new(10.5, 25), Size = new (3,5), IsLargeArc = true },
                    new LineSegment() { Point = new(10, 25) },
                    new LineSegment() { Point = new(10, 55), IsStroked=false },
                    new ArcSegment() { Point = new(10.5, 55), Size = new (3,5), IsLargeArc = true },
                    new LineSegment() { Point = new(10, 55) },
                    new LineSegment() { Point = new(10, 25), IsStroked=false },
                    new LineSegment() { Point = new(20, 40), IsStroked=false },
                    new LineSegment() { Point = new(35, 40)},
                    new LineSegment() { Point = new(35, 50)},
                    new LineSegment() { Point = new(43, 40), IsStroked=false},
                    new ArcSegment() { Point = new(43.5, 40), Size = new (3,5), IsLargeArc = true },
                    new LineSegment() { Point = new(43, 40)},
                    new LineSegment() { Point = new(35, 50), IsStroked=false },
                    new LineSegment() { Point = new(20, 50)},
                    new LineSegment() { Point = new(20, 0), IsStroked=false},
                    new LineSegment() { Point = new(0, 0), IsStroked=false},
                },
                IsClosed = true
            };

            figuresCollection.Add(figure);
            _originalGeometry = new PathGeometry(figuresCollection) { FillRule = FillRule.Nonzero };

            return _originalGeometry;
        }
    }
}