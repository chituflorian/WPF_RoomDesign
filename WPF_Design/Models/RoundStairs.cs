using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class RoundStairs : BaseFurniture
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


        public RoundStairs()
        {
            Name = "Round stairs";
            Description = "Round stairs model";
            OriginalGeometry = CreateGeometry();
            Width = 100;
            Height = 100;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure Stairs = new()
            {
                IsClosed = true,
                StartPoint = new Point(250, 0),
                Segments = new PathSegmentCollection()
                {
                    //Borders
                    new LineSegment() { Point = new (500, 0), IsStroked = false },
                    new LineSegment() { Point = new (250, 0), IsStroked = false },
                    new LineSegment() { Point = new (0, 500), IsStroked = false },
                    new LineSegment() { Point = new (250, 0), IsStroked = false },
                    new LineSegment() { Point = new (250, 250) },
                    new LineSegment() { Point = new (500, 250) },
                    new ArcSegment() { 
                        Size = new(20, 20), 
                        Point = new(0, 250), 
                        SweepDirection = SweepDirection.Clockwise, 
                        IsLargeArc = true, 
                    },
                    new LineSegment() { Point = new (250, 500), IsStroked = false },
                    new ArcSegment() { 
                        Size = new(20, 20), 
                        Point = new(250, 0),
                        SweepDirection = SweepDirection.Clockwise, 
                        IsLargeArc = true, 
                    },
                    new LineSegment() { Point = new (250, 250), IsStroked = false },
                    new LineSegment() { Point = new (250, 240), IsStroked = false },

                    //Small circle
                    new ArcSegment() { 
                        Size = new(13, 13), 
                        Point = new(260, 250), 
                        SweepDirection = SweepDirection.Counterclockwise, 
                        IsLargeArc = true, 
                    },
                    new LineSegment() { Point = new (250, 250)},

                    //Line 1
                    new LineSegment() { Point = new (260, 260) },
                    new LineSegment() { Point = new (475, 350) },
                    new LineSegment() { Point = new (475, 350) },
                    new LineSegment() { Point = new (260, 260) },

                    //Line 2
                    new LineSegment() { Point = new (255, 263) },
                    new LineSegment() { Point = new (400, 450) },
                    new LineSegment() { Point = new (400, 450) },
                    new LineSegment() { Point = new (255, 263) },

                    //Line 3
                    new LineSegment() { Point = new (250, 263) },
                    new LineSegment() { Point = new (300, 490) },
                    new LineSegment() { Point = new (300, 490) },
                    new LineSegment() { Point = new (250, 263) },

                    //Line 4
                    new LineSegment() { Point = new (244, 262) },
                    new LineSegment() { Point = new (200, 490) },
                    new LineSegment() { Point = new (200, 490) },
                    new LineSegment() { Point = new (244, 262) },

                    //Line 5
                    new LineSegment() { Point = new (240, 258) },
                    new LineSegment() { Point = new (110, 450) },
                    new LineSegment() { Point = new (110, 450) },
                    new LineSegment() { Point = new (240, 258) },

                    //Line 6
                    new LineSegment() { Point = new (236, 253) },
                    new LineSegment() { Point = new (40, 380) },
                    new LineSegment() { Point = new (40, 380) },
                    new LineSegment() { Point = new (236, 253) },

                    //Line 7
                    new LineSegment() { Point = new (236, 248) },
                    new LineSegment() { Point = new (10, 295) },
                    new LineSegment() { Point = new (10, 295) },
                    new LineSegment() { Point = new (236, 248) },

                    //Line 8
                    new LineSegment() { Point = new (236, 245) },
                    new LineSegment() { Point = new (7, 220) },
                    new LineSegment() { Point = new (7, 220) },
                    new LineSegment() { Point = new (236, 245) },

                    //Line 9
                    new LineSegment() { Point = new (238, 242) },
                    new LineSegment() { Point = new (30, 140) },
                    new LineSegment() { Point = new (30, 140) },
                    new LineSegment() { Point = new (238, 242) },

                    //Line 10
                    new LineSegment() { Point = new (242, 238) },
                    new LineSegment() { Point = new (90, 60) },
                    new LineSegment() { Point = new (90, 60) },
                    new LineSegment() { Point = new (242, 238) },

                    //Line 11
                    new LineSegment() { Point = new (247, 238) },
                    new LineSegment() { Point = new (170, 20) },
                    new LineSegment() { Point = new (170, 20) },
                    new LineSegment() { Point = new (247, 238) },

                    new LineSegment() { Point = new (240, 250) },
                    new LineSegment() { Point = new (240, 260) },
                    new LineSegment() { Point = new (260, 260) },
                    new LineSegment() { Point = new (240, 250) },
                    new LineSegment() { Point = new (250, 250) }
                }
            };

            figuresCollection.Add(Stairs);

            _originalGeometry = new PathGeometry(figuresCollection) { FillRule=FillRule.Nonzero};

            return _originalGeometry;
        }
    }
}
