using System;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class ArmChair : BaseFurniture
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


        public ArmChair()
        {
            Name = "ArmChair";
            Description = "An armchair.";
            Color = "Chocolate";
            OriginalGeometry = CreateGeometry();
            Width = 70;
            Height = 70;
            OriginalGeometry.Transform = new ScaleTransform(Width / 220, Height / 185);
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure center = new()
            {
                IsClosed = true,
                StartPoint = new(0, 0),
                Segments = new()
                {
                    new LineSegment() { Point=new(0,40), IsStroked=false},
                    new LineSegment() { Point=new(0,180)},
                    new ArcSegment()  { Point=new(40,180), Size=new(17,10) },
                    new LineSegment() { Point=new(40,75) },
                    new LineSegment() { Point=new(40,75) },
                    new LineSegment() { Point=new(40,185) },
                    new ArcSegment()  { Point=new(180,185), Size=new(10,2) },
                    new LineSegment() { Point=new(180,75) },
                    new LineSegment() { Point=new(180,75) },
                    new LineSegment() { Point=new(180,180) },
                    new ArcSegment()  { Point=new(220,180), Size=new(17,10) },
                    new LineSegment() { Point=new(220,40) },
                    new ArcSegment()  { Point=new(200,35), Size=new(17,10) },
                    new LineSegment() { Point=new(180,65), IsStroked = false },
                    new LineSegment() { Point=new(155,65) },
                    new LineSegment() { Point=new(155,65) },
                    new LineSegment() { Point=new(180,65) },
                    new ArcSegment()  { Point=new(180,15), Size=new(10,12) },
                    new LineSegment() { Point=new(40,15) },
                    new ArcSegment()  { Point=new(40,65), Size=new(10,12) },
                    new LineSegment() { Point=new(60,65) },
                    new LineSegment() { Point=new(60,55), IsStroked = false },
                    new ArcSegment()  { Point=new(150,55), Size=new(18,2) },
                    new ArcSegment()  { Point=new(150,115), Size=new(2,18) },
                    new ArcSegment()  { Point=new(60,115), Size=new(18,2) },
                    new ArcSegment()  { Point=new(60,55), Size=new(2,18) },
                    new ArcSegment()  { Point=new(150,55), Size=new(18,2) },
                    new ArcSegment()  { Point=new(150,115), Size=new(2,18) },
                    new ArcSegment()  { Point=new(60,115), Size=new(18,2) },
                    new ArcSegment()  { Point=new(60,55), Size=new(2,18) },
                    new LineSegment() { Point=new(20,35), IsStroked = false },
                    new ArcSegment()  { Point=new(0,40), Size=new(17,10) },
                    new LineSegment() { Point=new(0,0), IsStroked=false}
               }
            };

            figuresCollection.Add(center);

            _originalGeometry = new PathGeometry(figuresCollection) { FillRule = FillRule.Nonzero };
            return _originalGeometry;
        }
    }
}
