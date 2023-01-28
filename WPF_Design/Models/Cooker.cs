using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Cooker : BaseFurniture
    {
        private string type = string.Empty;
        public string Type
        {
            get => type;
            set
            {
                type = value;
                NotifyPropertyChanged(nameof(Type));
            }
        }

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


        public Cooker()
        {
            Name = "Cooker";
            Type = "Gas";
            Color = "Gray";
            Description = "A cooker.";
            OriginalGeometry = CreateGeometry();
            Width = 80;
            Height = 80;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure cooker = new()
            {
                Segments = new()
                {
                    new LineSegment() { Point=new(300,0)},
                    new LineSegment() { Point=new(300,250)},
                    new LineSegment() { Point=new(240,250)},
                    new LineSegment() { Point=new(240,0)},
                    new LineSegment() { Point=new(235,0)},
                    new LineSegment() { Point=new(235,250)},
                    new LineSegment() { Point=new(235,250)},
                    new LineSegment() { Point=new(235,0)},
                    new LineSegment() { Point=new(240,0)},
                    new LineSegment() { Point=new(240,250)},

                    new LineSegment() { Point=new(165,250)},
                    new LineSegment() { Point=new(165,0)},
                    new LineSegment() { Point=new(165,0)},
                    new LineSegment() { Point=new(165,250)},
                    new LineSegment() { Point=new(60,250)},
                    new LineSegment() { Point=new(60,0)},
                    new LineSegment() { Point=new(60,0)},
                    new LineSegment() { Point=new(60,250)},
                    new LineSegment() { Point=new(0,250)},
                    new LineSegment() { Point=new(0,180)},
                    new LineSegment() { Point=new(235,180)},
                    new LineSegment() { Point=new(235,180)},
                    new LineSegment() { Point=new(0,180)},
                    new LineSegment() { Point=new(0,60)},
                    new LineSegment() { Point=new(235,60)},
                    new LineSegment() { Point=new(235,60)},
                    new LineSegment() { Point=new(0,60)},
                    new LineSegment() { Point=new(0,0)},

                   new LineSegment() { Point=new(130,180), IsStroked=false},
                   new ArcSegment() { Point=new(200,180), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new ArcSegment() { Point=new(130,180), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new LineSegment() { Point=new(30,180), IsStroked=false},
                   new ArcSegment() { Point=new(90,180), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new ArcSegment() { Point=new(30,180), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new LineSegment() { Point=new(20,60), IsStroked=false},
                   new ArcSegment() { Point=new(100,60), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new ArcSegment() { Point=new(20,60), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new LineSegment() { Point=new(130,60), IsStroked=false},
                   new ArcSegment() { Point=new(200,60), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new ArcSegment() { Point=new(130,60), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new LineSegment() { Point=new(260,35), IsStroked=false},
                   new ArcSegment() { Point=new(280,35), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new ArcSegment() { Point=new(260,35), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new LineSegment() { Point=new(260,85), IsStroked=false},
                   new ArcSegment() { Point=new(280,85), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new ArcSegment() { Point=new(260,85), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new LineSegment() { Point=new(260,135), IsStroked=false},
                   new ArcSegment() { Point=new(280,135), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new ArcSegment() { Point=new(260,135), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new LineSegment() { Point=new(260,185), IsStroked=false},
                   new ArcSegment() { Point=new(280,185), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new ArcSegment() { Point=new(260,185), Size=new(10,10), SweepDirection=SweepDirection.Clockwise},
                   new LineSegment() { Point=new(20,60), IsStroked=false},
                }
            };
            figuresCollection.Add(cooker);
            _originalGeometry = new PathGeometry(figuresCollection) { FillRule = FillRule.Nonzero };

            return _originalGeometry;
        }
    }
}
