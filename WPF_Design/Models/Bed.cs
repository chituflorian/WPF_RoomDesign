using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Bed : BaseFurniture
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


        public Bed()
        {
            Name = "Bed";
            Description = "A king size bed.";
            Color = "LightGray";
            OriginalGeometry = CreateGeometry();
            Width = 80;
            Height = 100;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figureCollection = new();

            PathFigure Bed = new()
            {
                IsClosed = true,
                StartPoint = new Point(0, 0),
                IsFilled = true,
                Segments = new PathSegmentCollection()
                {
                   new LineSegment(){ Point=new(0,700)},
                   new LineSegment(){ Point=new(500,700)},
                   new LineSegment(){ Point=new(500,200)},
                   new LineSegment(){ Point=new(0,250)},
                   new LineSegment(){ Point=new(0,250)},
                   new LineSegment(){ Point=new(500,200)},
                   new LineSegment(){ Point=new(500,0)},
                }
            };
            
            PathFigure LeftBigPillow = new()
            {
                StartPoint = new Point(500, 0),
                Segments = new PathSegmentCollection()
                {
                   new LineSegment(){ Point=new(0,700), IsStroked=false},
                   new LineSegment(){ Point=new(500,0), IsStroked=false},
                   new LineSegment(){ Point=new(170,10), IsStroked=false},

                   new LineSegment(){ Point=new(80,10)},
                   new ArcSegment() {
                       Point=new(80,110),
                       SweepDirection=SweepDirection.Counterclockwise,
                       RotationAngle=0,
                       IsLargeArc=false,
                       Size=new(30,30)
                   },
                   new LineSegment(){ Point=new(170,110)},
                   new ArcSegment() {
                       Point=new(170,10),
                       SweepDirection=SweepDirection.Counterclockwise,
                       RotationAngle=0,
                       IsLargeArc=false,
                       Size=new(30,30)
                   },
                   new LineSegment(){ Point=new(170,10), IsStroked=false},
                }
            };
           
            PathFigure RightBigPillow = new()
            {
                StartPoint = new Point(500, 0),
                Segments = new PathSegmentCollection()
                {
                   new LineSegment(){ Point=new(0,700), IsStroked=false},
                   new LineSegment(){ Point=new(500,0), IsStroked=false},
                   new LineSegment(){ Point=new(420,10), IsStroked=false},

                   new LineSegment(){ Point=new(330,10)},
                   new ArcSegment() {
                       Point=new(330,110),
                       SweepDirection=SweepDirection.Counterclockwise,
                       RotationAngle=0,
                       IsLargeArc=false,
                       Size=new(30,30)
                   },
                   new LineSegment(){ Point=new(420,110)},
                   new ArcSegment() {
                       Point=new(420,10),
                       SweepDirection=SweepDirection.Counterclockwise,
                       RotationAngle=0,
                       IsLargeArc=false,
                       Size=new(30,30)
                   },
                   new LineSegment(){ Point=new(420,10), IsStroked=false},
                }
            };

            figureCollection.Add(Bed);
            figureCollection.Add(LeftBigPillow);
            figureCollection.Add(RightBigPillow);

            _originalGeometry = new PathGeometry(figureCollection) { FillRule=FillRule.Nonzero};

            return _originalGeometry;
        }        
    }
}
