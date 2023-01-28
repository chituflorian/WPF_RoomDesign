using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class StraightStairs : BaseFurniture
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


        public StraightStairs()
        {
            Name = "Straight stairs";
            Description = "Straight stairs model";
            OriginalGeometry = CreateGeometry();
            Width = 60;
            Height = 150;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure figure = new()
            {
                IsClosed = true,
                StartPoint = new Point(0, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (200, 0), IsStroked = false },
                    new LineSegment() { Point = new (0, 0), IsStroked = false },
                    new LineSegment() { Point = new (0, 480) },
                    new LineSegment() { Point = new (200, 480) },
                    new LineSegment() { Point = new (200, 0) },
                    new LineSegment() { Point = new (0, 0) },

                    new LineSegment() { Point = new (0, 30) },
                    new LineSegment() { Point = new (200, 30) },
                    new LineSegment() { Point = new (200, 30), IsStroked = false },
                    new LineSegment() { Point = new (0, 30) },

                    new LineSegment() { Point = new (0, 60) },
                    new LineSegment() { Point = new (200, 60) },
                    new LineSegment() { Point = new (200, 60), IsStroked = false },
                    new LineSegment() { Point = new (0, 60) },

                    new LineSegment() { Point = new (0, 90) },
                    new LineSegment() { Point = new (200, 90) },
                    new LineSegment() { Point = new (200, 90), IsStroked = false },
                    new LineSegment() { Point = new (0, 90) },

                    new LineSegment() { Point = new (0, 120) },
                    new LineSegment() { Point = new (200, 120) },
                    new LineSegment() { Point = new (200, 120), IsStroked = false },
                    new LineSegment() { Point = new (0, 120) },

                    new LineSegment() { Point = new (0, 150) },
                    new LineSegment() { Point = new (200, 150) },
                    new LineSegment() { Point = new (200, 150), IsStroked = false },
                    new LineSegment() { Point = new (0, 150) },

                    new LineSegment() { Point = new (0, 180) },
                    new LineSegment() { Point = new (200, 180) },
                    new LineSegment() { Point = new (200, 180), IsStroked = false },
                    new LineSegment() { Point = new (0, 180) },

                    new LineSegment() { Point = new (0, 210) },
                    new LineSegment() { Point = new (200, 210) },
                    new LineSegment() { Point = new (200, 210), IsStroked = false },
                    new LineSegment() { Point = new (0, 210) },

                    new LineSegment() { Point = new (0, 240) },
                    new LineSegment() { Point = new (200, 240) },
                    new LineSegment() { Point = new (200, 240), IsStroked = false },
                    new LineSegment() { Point = new (0, 240) },

                    new LineSegment() { Point = new (0, 270) },
                    new LineSegment() { Point = new (200, 270) },
                    new LineSegment() { Point = new (200, 270), IsStroked = false },
                    new LineSegment() { Point = new (0, 270) },

                    new LineSegment() { Point = new (0, 300) },
                    new LineSegment() { Point = new (200, 300) },
                    new LineSegment() { Point = new (200, 300), IsStroked = false },
                    new LineSegment() { Point = new (0, 300) },

                    new LineSegment() { Point = new (0, 330) },
                    new LineSegment() { Point = new (200, 330) },
                    new LineSegment() { Point = new (200, 330), IsStroked = false },
                    new LineSegment() { Point = new (0, 330) },

                    new LineSegment() { Point = new (0, 360) },
                    new LineSegment() { Point = new (200, 360) },
                    new LineSegment() { Point = new (200, 360), IsStroked = false },
                    new LineSegment() { Point = new (0, 360) },

                    new LineSegment() { Point = new (0, 390) },
                    new LineSegment() { Point = new (200, 390) },
                    new LineSegment() { Point = new (200, 390), IsStroked = false },
                    new LineSegment() { Point = new (0, 390) },

                    new LineSegment() { Point = new (0, 420) },
                    new LineSegment() { Point = new (200, 420) },
                    new LineSegment() { Point = new (200, 420), IsStroked = false },
                    new LineSegment() { Point = new (0, 420) },

                    new LineSegment() { Point = new (0, 450) },
                    new LineSegment() { Point = new (200, 450) },
                    new LineSegment() { Point = new (200, 450), IsStroked = false },
                    new LineSegment() { Point = new (0, 450) },

                    new LineSegment() { Point = new (0, 480) },
                    new LineSegment() { Point = new (200, 480) },
                    new LineSegment() { Point = new (200, 480), IsStroked = false },
                    new LineSegment() { Point = new (0, 480) },
                }
            };

            figuresCollection.Add(figure);
            _originalGeometry = new PathGeometry(figuresCollection);

            return _originalGeometry;
        }
    }
}
