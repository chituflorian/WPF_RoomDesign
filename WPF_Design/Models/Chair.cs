using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Chair : BaseFurniture
    {
        private string material = string.Empty;
        public string Material
        {
            get => material;
            set
            {
                material = value;
                NotifyPropertyChanged(nameof(Material));
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


        public Chair()
        {
            Name = "Chair";
            Description = "A chair.";  
            Color = "Black";
            Material = "Wood";
            OriginalGeometry = CreateGeometry();
            Height = 70;
            Width = 50;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure pathFigure = new()
            {
                IsClosed = true,
                StartPoint = new Point(0, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (0,30), IsStroked=false },
                    new LineSegment() { Point = new (0,120)},
                    new ArcSegment() { Point = new (40,120), Size = new (17,10)},
                    new LineSegment() { Point = new (40,10)},
                    new ArcSegment(){ Point = new (180,10), Size = new (19,3), SweepDirection= SweepDirection.Clockwise},
                    new LineSegment() { Point = new (180,30)},
                    new ArcSegment(){ Point = new (220,30), Size = new (17,10), SweepDirection= SweepDirection.Clockwise},
                    new LineSegment() { Point = new (220,120)},
                    new ArcSegment(){ Point = new (180,120), Size = new (17,10), SweepDirection= SweepDirection.Clockwise},
                    new LineSegment() { Point = new (180,20)},
                    new LineSegment() { Point = new (180,20)},
                    new LineSegment() { Point = new (180,140)},
                    new ArcSegment(){ Point = new (40,140), Size = new (19,2), SweepDirection= SweepDirection.Clockwise},
                    new LineSegment() { Point = new (90,147), IsStroked=false},
                    new LineSegment() { Point = new (140,147), IsStroked=false},
                    new LineSegment() { Point = new (140,155)},
                    new LineSegment() { Point = new (190,155)},
                    new ArcSegment(){ Point = new (190,175), Size = new (4,2), SweepDirection= SweepDirection.Clockwise},
                    new LineSegment() { Point = new (35,175)},
                    new ArcSegment(){ Point = new (35,155), Size = new (4,2), SweepDirection=SweepDirection.Clockwise },
                    new LineSegment() { Point = new (130,155)},
                    new LineSegment() { Point = new (90,155)},
                    new LineSegment() { Point = new (90,147)},
                    new LineSegment() { Point = new (40,140), IsStroked=false},
                    new LineSegment() { Point = new (40,30)},
                    new ArcSegment(){ Point = new (0,30), Size = new (17,10)},
                    new LineSegment() { Point = new (0,0), IsStroked=false},
                }
            };

            figuresCollection.Add(pathFigure);
            _originalGeometry = new PathGeometry(figuresCollection);
            return _originalGeometry;
        }
    }
}
