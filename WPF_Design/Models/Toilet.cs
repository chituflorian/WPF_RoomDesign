using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Toilet : BaseFurniture
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


        public Toilet()
        {
            Name = "Toilet";
            Description = "A toilet.";
            OriginalGeometry = CreateGeometry();
            Width = 50;
            Height = 70;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure figure = new()
            {
                StartPoint = new Point(0, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (60, 0)},
                    new LineSegment() { Point = new (55, 5), IsStroked = false },
                    new LineSegment() { Point = new (55, 20)},
                    new LineSegment() { Point = new (5, 20)},
                    new LineSegment() { Point = new (5, 5)},
                    new LineSegment() { Point = new (55, 5)},
                    new LineSegment() { Point = new (60, 0), IsStroked= false },
                    new LineSegment() { Point = new (60, 25)},
                    new LineSegment() { Point = new (0, 25)},
                    new LineSegment() { Point = new (0, 0)},
                    new LineSegment() { Point = new (29, 7), IsStroked = false},
                    new ArcSegment()  { Point = new (29.5, 7), Size = new(2,2), IsLargeArc = true},
                    new LineSegment() { Point = new (29, 7)},
                    new LineSegment() { Point = new (29, 15), IsStroked = false},
                    new ArcSegment()  { Point = new (29.5, 15), Size = new(16,21), IsLargeArc = true},
                    new LineSegment() { Point = new (29, 15)},
                    new ArcSegment()  { Point = new (29.5, 15), Size = new(19,24), IsLargeArc = true},
                    new LineSegment() { Point = new (29, 15)},
                    new LineSegment() { Point = new (0, 0), IsStroked = false},
                }
            };
        
            figuresCollection.Add(figure);

            _originalGeometry = new PathGeometry(figuresCollection) { FillRule= FillRule.Nonzero};

            return _originalGeometry;
        }
    }
}
