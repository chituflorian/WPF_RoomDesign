using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class BathroomSink : BaseFurniture
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


        public BathroomSink()
        {
            Name = "Bathroom Sink";
            Description = "White sink with brown wood.";
            OriginalGeometry = CreateGeometry();
            Width = 100;
            Height = 50;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figureCollection = new();

            PathFigure SinkWood = new()
            {
                IsClosed = true,
                StartPoint = new Point(0, 0),
                Segments = new PathSegmentCollection()
                {
                   new LineSegment(){ Point=new(0,300)},
                   new LineSegment(){ Point=new(400,300)},
                   new LineSegment(){ Point=new(400,0)},
                   new LineSegment(){ Point=new(0,0)},

                   new LineSegment(){ Point=new(40,30), IsStroked=false},
                   new LineSegment(){ Point=new(40,270)},
                   new LineSegment(){ Point=new(360,270)},
                   new LineSegment(){ Point=new(360,30)},
                   new LineSegment(){ Point=new(40,30) },
                   new LineSegment(){ Point=new(40,270)},
                   new LineSegment(){ Point=new(360,270)},
                   new LineSegment(){ Point=new(360,30)},
                   new LineSegment(){ Point=new(40,30)},
                   new LineSegment(){ Point=new(0,0), IsStroked=false },
                }
            };

            PathFigure Sink = new()
            {
                IsClosed = true,
                Segments = new PathSegmentCollection()
                {
                   new LineSegment(){ Point=new(80,70), IsStroked=false},
                   new LineSegment(){ Point=new(320,70)},
                   new LineSegment(){ Point=new(320,260)},
                   new LineSegment(){ Point=new(80,260)},
                   new LineSegment(){ Point=new(80,70)},

                   new LineSegment(){ Point=new(190,70)},
                   new LineSegment(){ Point=new(190,40)},
                   new LineSegment(){ Point=new(240,40)},
                   new LineSegment(){ Point=new(240,55)},
                   new LineSegment(){ Point=new(210,55)},
                   new LineSegment(){ Point=new(210,130)},
                   new LineSegment(){ Point=new(190,130)},
                   new LineSegment(){ Point=new(190,70)},
                   new LineSegment(){ Point=new(80,70)},
                   new LineSegment(){ Point=new(0,0), IsStroked=false},
                }
            };

            figureCollection.Add(SinkWood);
            figureCollection.Add(Sink);

            _originalGeometry = new PathGeometry(figureCollection) { FillRule = FillRule.Nonzero };

            return _originalGeometry;
        }
    }
}
