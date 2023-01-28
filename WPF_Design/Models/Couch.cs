using System;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Couch : BaseFurniture
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


        public Couch()
        {
            Name = "Couch";
            Description = "A couch.";
            Color = "Chocolate";
            OriginalGeometry = CreateGeometry();
            Width = 200;
            Height = 80;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure center = new()
            {
                StartPoint = new(8, 45),
                IsClosed = true,
                Segments = new()
                {
                    new ArcSegment() { Point=new(8,100), Size=new(2,8)},
                    new ArcSegment() { Point=new(8,120), Size=new(35,19)},
                    new LineSegment() { Point=new(296,120)},
                    new ArcSegment() { Point=new(296,100), Size=new(35,19)},
                    new ArcSegment() { Point=new(296,45), Size=new(2,8)},
                    new LineSegment() { Point=new(284,45)},
                    new ArcSegment() { Point=new(284,100), Size=new(12,18)},
                    new LineSegment() { Point=new(284,100)},
                    new LineSegment() { Point=new(8,100)},
                    new LineSegment() { Point=new(8,100)},
                    new LineSegment() { Point=new(296,100)},
                    new LineSegment() { Point=new(296,100)},
                    new LineSegment() { Point=new(284,100)},
                    new ArcSegment() { Point=new(284,45), Size=new(12,18), SweepDirection = SweepDirection.Clockwise},
                    new LineSegment() { Point=new(290,45)},
                    new ArcSegment() { Point=new(200,45), Size=new(39,17)},
                    new ArcSegment() { Point=new(110,45), Size=new(39,17)},
                    new ArcSegment() { Point=new(10,45), Size=new(39,17)},
                    new LineSegment() { Point=new(18,45)},
                    new ArcSegment() { Point=new(18,100), Size=new(12,18), SweepDirection = SweepDirection.Clockwise},
                    new LineSegment() { Point=new(18,100)},
                    new ArcSegment() { Point=new(18,45), Size=new(12,18)},
                    new LineSegment() { Point=new(8,45)},
                }
            };

            figuresCollection.Add(center);
            _originalGeometry = new PathGeometry(figuresCollection) { FillRule = FillRule.Nonzero };

            return _originalGeometry;
        }
    }
}
