using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Flower : BaseFurniture
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


        public Flower()
        {
            Name = "Flower";
            Description = "A flower in a pot.";
            Color = "Green";
            OriginalGeometry = CreateGeometry();
            Width = 60;
            Height = 60;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figureCollection = new();

            PathFigure Flower = new()
            {
                StartPoint = new Point(0, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new(220,230), IsStroked=false},
                    new LineSegment() { Point = new(220,280) },
                    new LineSegment() { Point = new(220,500), IsStroked=false},
                    new LineSegment() { Point = new(220,280), IsStroked=false},
                    new LineSegment() { Point = new(230,280) },
                    new LineSegment() { Point = new(230,230) },
                    new LineSegment() { Point = new(230,230) },
                    new LineSegment() { Point = new(230,280) },
                    new LineSegment() { Point = new(240,280) },
                    new LineSegment() { Point = new(240,230) },
                    new LineSegment() { Point = new(240,230) },
                    new LineSegment() { Point = new(240,280) },
                    new LineSegment() { Point = new(250,280) },
                    new LineSegment() { Point = new(250,230) },
                    new LineSegment() { Point = new(250,230) },
                    new LineSegment() { Point = new(250,280) },
                    new LineSegment() { Point = new(260,280) },
                    new LineSegment() { Point = new(260,230) },
                    new LineSegment() { Point = new(260,230) },
                    new LineSegment() { Point = new(260,280) },
                    new LineSegment() { Point = new(270,280) },
                    new LineSegment() { Point = new(270,230) },
                    new LineSegment() { Point = new(270,230) },
                    new LineSegment() { Point = new(270,280) },
                    new LineSegment() { Point = new(500,280), IsStroked=false},
                    new LineSegment() { Point = new(280,280), IsStroked=false},
                    new LineSegment() { Point = new(280,230) },
                    new LineSegment() { Point = new(220,230) },

                    new ArcSegment()
                    {
                      Point = new(50,200),
                      Size = new(4,2),
                      RotationAngle = 17,
                      SweepDirection = SweepDirection.Counterclockwise,
                      IsLargeArc = false
                    },
                    new ArcSegment()
                    {
                      Point = new(220,230),
                      Size = new(4,2),
                      RotationAngle = 19,
                      SweepDirection = SweepDirection.Counterclockwise,
                      IsLargeArc = false
                    },

                    new LineSegment() { Point = new(220, 230) },
                    new LineSegment() { Point = new(220, 250) },
                    new LineSegment() { Point = new(120, 220) },
                    new LineSegment() { Point = new(120, 220) },
                    new LineSegment() { Point = new(220, 250) },
                    new LineSegment() { Point = new(270, 220) },

                    new ArcSegment()
                    {
                      Point = new(270,30),
                      Size = new(1,2),
                      RotationAngle = 3,
                      SweepDirection = SweepDirection.Clockwise,
                      IsLargeArc = false
                    },
                    new ArcSegment()
                    {
                      Point = new(270,220),
                      Size = new(1,2),
                      RotationAngle = 3,
                      SweepDirection = SweepDirection.Clockwise,
                      IsLargeArc = false
                    },

                    new LineSegment() { Point = new(275, 90) },
                    new LineSegment() { Point = new(275, 90) },
                    new LineSegment() { Point = new(270, 220) },
                    new LineSegment() { Point = new(250, 250) },
                    new LineSegment() { Point = new(290, 300) },

                    new ArcSegment()
                    {
                      Point = new(380,470),
                      Size = new(5,3.5),
                      RotationAngle = 40,
                      SweepDirection = SweepDirection.Clockwise,
                      IsLargeArc = false
                    },
                    new ArcSegment()
                    {
                      Point = new(290,300),
                      Size = new(9,6),
                      RotationAngle = 60,
                      SweepDirection = SweepDirection.Clockwise,
                      IsLargeArc = false
                    },

                    new LineSegment() { Point = new(360, 400) },
                    new LineSegment() { Point = new(360, 400) },
                    new LineSegment() { Point = new(290, 300) },
                    new LineSegment() { Point = new(220, 230) },
                    new LineSegment() { Point = new(220, 230) },
                    new LineSegment() { Point = new(240, 250) },
                    new LineSegment() { Point = new(230, 320) },

                    new ArcSegment()
                    {
                      Point = new(160,470),
                      Size = new(6,7),
                      RotationAngle = 17,
                      SweepDirection = SweepDirection.Clockwise,
                      IsLargeArc = false
                    },
                    new ArcSegment()
                    {
                      Point = new(230,320),
                      Size = new(4,7),
                      RotationAngle = 19,
                      SweepDirection = SweepDirection.Clockwise,
                      IsLargeArc = false
                    },

                    new LineSegment() { Point = new(200, 400) },
                    new LineSegment() { Point = new(200, 400) },
                    new LineSegment() { Point = new(230, 320) },
                    new LineSegment() { Point = new(245, 260) },
                    new LineSegment() { Point = new(320, 240) },

                    new ArcSegment()
                    {
                      Point = new(470,110),
                      Size = new(12,20),
                      RotationAngle = 50,
                      SweepDirection = SweepDirection.Clockwise,
                      IsLargeArc = false
                    },
                    new ArcSegment()
                    {
                      Point = new(320,240),
                      Size = new(12,20),
                      RotationAngle = 55,
                      SweepDirection = SweepDirection.Clockwise,
                      IsLargeArc = false
                    },

                    new LineSegment() { Point = new(380, 190) },
                    new LineSegment() { Point = new(380, 190) },
                    new LineSegment() { Point = new(320, 240) },
                    new LineSegment() { Point = new(250, 261.5) },
                }
            };

            figureCollection.Add(Flower);

            _originalGeometry = new PathGeometry(figureCollection) { FillRule = FillRule.Nonzero };

            return _originalGeometry;
        }
    }
}

