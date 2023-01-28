using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class KitchenSink : BaseFurniture
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


        public KitchenSink()
        {
            Name = "KitchenSink";
            Description = "A kitchen sink.";
            OriginalGeometry = CreateGeometry();
            Width = 110;
            Height = 70;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure BaseSink = new()
            {
                StartPoint = new Point(8, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (0,8) },
                    new LineSegment() { Point = new (0,142) },
                    new LineSegment() { Point = new (8,150) },
                    new LineSegment() { Point = new (292,150) },
                    new LineSegment() { Point = new (300,142) },
                    new LineSegment() { Point = new (300,8) },
                    new LineSegment() { Point = new (292,0) },
                    new LineSegment() { Point = new (8,0) }
               }
            };

            PathFigure The5Rectangles = new()
            {
                StartPoint = new(0, 0),
                Segments = new()
                {
                    new LineSegment() {Point=new(10,25), IsStroked=false },
                    new LineSegment() {Point=new(10,140) },
                    new LineSegment() {Point=new(10,150), IsStroked=false },
                    new LineSegment() {Point=new(10,140), IsStroked=false },
                    new LineSegment() {Point=new(100,140) },
                    new LineSegment() {Point=new(110,140), IsStroked=false},
                    new LineSegment() {Point=new(190,140)},
                    new LineSegment() {Point=new(200,140), IsStroked=false},
                    new LineSegment() {Point=new(290,140)},
                    new LineSegment() {Point=new(300,140), IsStroked=false},
                    new LineSegment() {Point=new(290,140), IsStroked=false},
                    new LineSegment() {Point=new(290,25)},
                    new LineSegment() {Point=new(200,25)},
                    new LineSegment() {Point=new(200,140)},
                    new LineSegment() {Point=new(190,140), IsStroked=false},
                    new LineSegment() {Point=new(190,50)},

                    new LineSegment() {Point=new(190,40), IsStroked=false},
                    new LineSegment() {Point=new(190,15)},
                    new LineSegment() {Point=new(160,15)},
                    new LineSegment() {Point=new(160,7)},
                    new LineSegment() {Point=new(140,7)},
                    new LineSegment() {Point=new(140,60)},
                    new LineSegment() {Point=new(160,60)},
                    new LineSegment() {Point=new(160,7)},
                    new LineSegment() {Point=new(140,7)},
                    new LineSegment() {Point=new(140,15)},
                    new LineSegment() {Point=new(110,15)},
                    new LineSegment() {Point=new(110,40)},
                    new LineSegment() {Point=new(140,40)},
                    new LineSegment() {Point=new(140,60)},
                    new LineSegment() {Point=new(160,60)},
                    new LineSegment() {Point=new(160,40)},
                    new LineSegment() {Point=new(190,40)},
                    new LineSegment() {Point=new(190,50), IsStroked=false},

                    new LineSegment() {Point=new(160,50)},
                    new LineSegment() {Point=new(160,60)},
                    new LineSegment() {Point=new(140,60)},
                    new LineSegment() {Point=new(140,50)},

                    new LineSegment() {Point=new(110,50)},
                    new LineSegment() {Point=new(110,140)},
                    new LineSegment() {Point=new(100,140), IsStroked=false},
                    new LineSegment() {Point=new(100,25)},
                    new LineSegment() {Point=new(10,25)},
                    new LineSegment() {Point=new(0,0), IsStroked=false}
               }
            };

            PathFigure SmallCircles = new()
            {
                StartPoint = new(0, 0),
                Segments = new()
                {
                    new LineSegment() {Point=new(60,75), IsStroked=false },
                    new LineSegment() {Point=new(60,150), IsStroked=false },
                    new LineSegment() {Point=new(60,75), IsStroked=false },
                    new LineSegment() {Point=new(300,75), IsStroked=false },
                    new LineSegment() {Point=new(60,75), IsStroked=false },
                    new ArcSegment()  {
                        Point=new(59.9,75),
                        Size=new(10,10),
                        IsLargeArc=true,
                        SweepDirection=SweepDirection.Clockwise
                    },
                    new LineSegment() {Point=new(60,75), IsStroked=false },
                    new LineSegment() {Point=new(150,90), IsStroked=false },
                    new ArcSegment()  {
                        Point=new(149.9,90),
                        Size=new(8,8),
                        IsLargeArc=true,
                        SweepDirection=SweepDirection.Clockwise
                    },
                    new LineSegment() {Point=new(150,90), IsStroked=false },
                    new LineSegment() {Point=new(240,75), IsStroked=false },
                    new ArcSegment()  {
                        Point=new(239.9,75),
                        Size=new(10,10),
                        IsLargeArc=true,
                        SweepDirection=SweepDirection.Clockwise
                    },
                    new LineSegment() {Point=new(240,75), IsStroked=false },
                    new LineSegment() {Point=new(150,90), IsStroked=false },
                    new LineSegment() {Point=new(60,75), IsStroked=false },
                    new LineSegment() {Point=new(0,0), IsStroked=false },
               }
            };

            figuresCollection.Add(BaseSink);
            figuresCollection.Add(The5Rectangles);
            figuresCollection.Add(SmallCircles);

            _originalGeometry = new PathGeometry(figuresCollection) { FillRule = FillRule.Nonzero };

            return _originalGeometry;
        }
    }
}
