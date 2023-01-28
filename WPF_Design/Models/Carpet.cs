using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Carpet : BaseFurniture
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


        public Carpet()
        {
            Name = "Carpet";
            Description = "An old carpet.";
            OriginalGeometry = CreateGeometry();
            Color = "Red";
            Width = 100;
            Height = 50;
        }

        private Geometry CreateGeometry() 
        {
            PathFigureCollection figuresCollection = new();

            PathFigure pathFigure = new()
            {
                StartPoint = new Point(0, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment(){ Point = new (0, 20), IsStroked = false},
                    new LineSegment(){ Point = new (5, 20), IsStroked = false},
                    new LineSegment(){ Point = new (500, 20)},
                    new LineSegment(){ Point = new (480,20), IsStroked=false },
                    new LineSegment(){ Point = new (480,280) },
                    new LineSegment(){ Point = new (480,300), IsStroked=false },
                    new LineSegment(){ Point = new (480,280) },
                    new LineSegment(){ Point = new (30,280) },
                    new LineSegment(){ Point = new (30,20) },
                    new LineSegment(){ Point = new (60,20) },
                    new LineSegment(){ Point = new (60,0) },
                    new LineSegment(){ Point = new (60,0) },
                    new LineSegment(){ Point = new (60,20) },
                    new LineSegment(){ Point = new (90,20) },
                    new LineSegment(){ Point = new (90,0) },
                    new LineSegment(){ Point = new (90,0) },
                    new LineSegment(){ Point = new (90,20) },
                    new LineSegment(){ Point = new (120,20) },
                    new LineSegment(){ Point = new (120,0) },
                    new LineSegment(){ Point = new (120,0) },
                    new LineSegment(){ Point = new (120,20) },
                    new LineSegment(){ Point = new (150,20) },
                    new LineSegment(){ Point = new (150,0) },
                    new LineSegment(){ Point = new (150,0) },
                    new LineSegment(){ Point = new (150,20) },
                    new LineSegment(){ Point = new (180,20) },
                    new LineSegment(){ Point = new (180,0) },
                    new LineSegment(){ Point = new (180,0) },
                    new LineSegment(){ Point = new (180,20) },
                    new LineSegment(){ Point = new (210,20) },
                    new LineSegment(){ Point = new (210,0) },
                    new LineSegment(){ Point = new (210,0) },
                    new LineSegment(){ Point = new (210,20) },
                    new LineSegment(){ Point = new (240,20) },
                    new LineSegment(){ Point = new (240,0) },
                    new LineSegment(){ Point = new (240,0) },
                    new LineSegment(){ Point = new (240,20) },
                    new LineSegment(){ Point = new (270,20) },
                    new LineSegment(){ Point = new (270,0) },
                    new LineSegment(){ Point = new (270,0) },
                    new LineSegment(){ Point = new (270,20) },
                    new LineSegment(){ Point = new (300,20) },
                    new LineSegment(){ Point = new (300,0) },
                    new LineSegment(){ Point = new (300,0) },
                    new LineSegment(){ Point = new (300,20) },
                    new LineSegment(){ Point = new (330,20) },
                    new LineSegment(){ Point = new (330,0) },
                    new LineSegment(){ Point = new (330,0) },
                    new LineSegment(){ Point = new (330,20) },
                    new LineSegment(){ Point = new (360,20) },
                    new LineSegment(){ Point = new (360,0) },
                    new LineSegment(){ Point = new (360,0) },
                    new LineSegment(){ Point = new (360,20) },
                    new LineSegment(){ Point = new (390,20) },
                    new LineSegment(){ Point = new (390,0) },
                    new LineSegment(){ Point = new (390,0) },
                    new LineSegment(){ Point = new (390,20) },
                    new LineSegment(){ Point = new (420,20) },
                    new LineSegment(){ Point = new (420,0) },
                    new LineSegment(){ Point = new (420,0) },
                    new LineSegment(){ Point = new (420,20) },
                    new LineSegment(){ Point = new (450,20) },
                    new LineSegment(){ Point = new (450,0) },
                    new LineSegment(){ Point = new (450,0) },
                    new LineSegment(){ Point = new (450,20) },
                    new LineSegment(){ Point = new (480,20) },
                    new LineSegment(){ Point = new (480,0) },
                    new LineSegment(){ Point = new (480,0) },
                    new LineSegment(){ Point = new (480,20) },

                    new LineSegment(){ Point = new (480,20) },
                    new LineSegment(){ Point = new (500,20) },
                    new LineSegment(){ Point = new (500,20) },
                    new LineSegment(){ Point = new (480,20) },
                    new LineSegment(){ Point = new (480,50) },
                    new LineSegment(){ Point = new (500,50) },
                    new LineSegment(){ Point = new (500,50) },
                    new LineSegment(){ Point = new (480,50) },
                    new LineSegment(){ Point = new (480,90) },
                    new LineSegment(){ Point = new (500,90) },
                    new LineSegment(){ Point = new (500,90) },
                    new LineSegment(){ Point = new (480,90) },
                    new LineSegment(){ Point = new (480,130) },
                    new LineSegment(){ Point = new (500,130) },
                    new LineSegment(){ Point = new (500,130) },
                    new LineSegment(){ Point = new (480,130) },
                    new LineSegment(){ Point = new (480,170) },
                    new LineSegment(){ Point = new (500,170) },
                    new LineSegment(){ Point = new (500,170) },
                    new LineSegment(){ Point = new (480,170) },
                    new LineSegment(){ Point = new (480,210) },
                    new LineSegment(){ Point = new (500,210) },
                    new LineSegment(){ Point = new (500,210) },
                    new LineSegment(){ Point = new (480,210) },
                    new LineSegment(){ Point = new (480,250) },
                    new LineSegment(){ Point = new (500,250) },
                    new LineSegment(){ Point = new (500,250) },
                    new LineSegment(){ Point = new (480,250) },
                    new LineSegment(){ Point = new (480,280) },
                    new LineSegment(){ Point = new (500,280) },
                    new LineSegment(){ Point = new (500,280) },
                    new LineSegment(){ Point = new (480,280) },


                    new LineSegment(){ Point = new (480,280) },
                    new LineSegment(){ Point = new (480,305) },
                    new LineSegment(){ Point = new (480,305) },
                    new LineSegment(){ Point = new (480,280) },
                    new LineSegment(){ Point = new (450,280) },
                    new LineSegment(){ Point = new (450,305) },
                    new LineSegment(){ Point = new (450,305) },
                    new LineSegment(){ Point = new (450,280) },
                    new LineSegment(){ Point = new (420,280) },
                    new LineSegment(){ Point = new (420,305) },
                    new LineSegment(){ Point = new (420,305) },
                    new LineSegment(){ Point = new (420,280) },
                    new LineSegment(){ Point = new (390,280) },
                    new LineSegment(){ Point = new (390,305) },
                    new LineSegment(){ Point = new (390,305) },
                    new LineSegment(){ Point = new (390,280) },
                    new LineSegment(){ Point = new (360,280) },
                    new LineSegment(){ Point = new (360,305) },
                    new LineSegment(){ Point = new (360,305) },
                    new LineSegment(){ Point = new (360,280) },
                    new LineSegment(){ Point = new (330,280) },
                    new LineSegment(){ Point = new (330,305) },
                    new LineSegment(){ Point = new (330,305) },
                    new LineSegment(){ Point = new (330,280) },
                    new LineSegment(){ Point = new (300,280) },
                    new LineSegment(){ Point = new (300,305) },
                    new LineSegment(){ Point = new (300,305) },
                    new LineSegment(){ Point = new (300,280) },
                    new LineSegment(){ Point = new (270,280) },
                    new LineSegment(){ Point = new (270,305) },
                    new LineSegment(){ Point = new (270,305) },
                    new LineSegment(){ Point = new (270,280) },
                    new LineSegment(){ Point = new (240,280) },
                    new LineSegment(){ Point = new (240,305) },
                    new LineSegment(){ Point = new (240,305) },
                    new LineSegment(){ Point = new (240,280) },
                    new LineSegment(){ Point = new (210,280) },
                    new LineSegment(){ Point = new (210,305) },
                    new LineSegment(){ Point = new (210,305) },
                    new LineSegment(){ Point = new (210,280) },
                    new LineSegment(){ Point = new (180,280) },
                    new LineSegment(){ Point = new (180,305) },
                    new LineSegment(){ Point = new (180,305) },
                    new LineSegment(){ Point = new (180,280) },
                    new LineSegment(){ Point = new (150,280) },
                    new LineSegment(){ Point = new (150,305) },
                    new LineSegment(){ Point = new (150,305) },
                    new LineSegment(){ Point = new (150,280) },
                    new LineSegment(){ Point = new (120,280) },
                    new LineSegment(){ Point = new (120,305) },
                    new LineSegment(){ Point = new (120,305) },
                    new LineSegment(){ Point = new (120,280) },
                    new LineSegment(){ Point = new (90,280) },
                    new LineSegment(){ Point = new (90,305) },
                    new LineSegment(){ Point = new (90,305) },
                    new LineSegment(){ Point = new (90,280) },
                    new LineSegment(){ Point = new (60,280) },
                    new LineSegment(){ Point = new (60,305) },
                    new LineSegment(){ Point = new (60,305) },
                    new LineSegment(){ Point = new (60,280) },
                    new LineSegment(){ Point = new (30,280) },
                    new LineSegment(){ Point = new (30,305) },
                    new LineSegment(){ Point = new (30,305) },
                    new LineSegment(){ Point = new (30,280) },

                    new LineSegment(){ Point = new (30,280), IsStroked=false},
                    new LineSegment(){ Point = new (10,280) },
                    new LineSegment(){ Point = new (10,280) },
                    new LineSegment(){ Point = new (30,280) },
                    new LineSegment(){ Point = new (30,250) },
                    new LineSegment(){ Point = new (10,250) },
                    new LineSegment(){ Point = new (10,250) },
                    new LineSegment(){ Point = new (30,250) },
                    new LineSegment(){ Point = new (30,210) },
                    new LineSegment(){ Point = new (10,210) },
                    new LineSegment(){ Point = new (10,210) },
                    new LineSegment(){ Point = new (30,210) },
                    new LineSegment(){ Point = new (30,170) },
                    new LineSegment(){ Point = new (10,170) },
                    new LineSegment(){ Point = new (10,170) },
                    new LineSegment(){ Point = new (30,170) },
                    new LineSegment(){ Point = new (30,130) },
                    new LineSegment(){ Point = new (10,130) },
                    new LineSegment(){ Point = new (10,130) },
                    new LineSegment(){ Point = new (30,130) },
                    new LineSegment(){ Point = new (30,90) },
                    new LineSegment(){ Point = new (10,90) },
                    new LineSegment(){ Point = new (10,90) },
                    new LineSegment(){ Point = new (30,90) },
                    new LineSegment(){ Point = new (30,50) },
                    new LineSegment(){ Point = new (10,50) },
                    new LineSegment(){ Point = new (10,50) },
                    new LineSegment(){ Point = new (30,50) },
                    new LineSegment(){ Point = new (30,20) },
                    new LineSegment(){ Point = new (30,0) },
                    new LineSegment(){ Point = new (30,0) },
                    new LineSegment(){ Point = new (30,20) },
                    new LineSegment(){ Point = new (30,280) },
                    new LineSegment(){ Point = new (480,280) },
                    new LineSegment(){ Point = new (480,20) },
                    new LineSegment(){ Point = new (10,20) },
                    new LineSegment(){ Point = new (10,20) },
                    new LineSegment(){ Point = new (0,20), IsStroked=false},
                    new LineSegment(){ Point = new (0,0), IsStroked=false},

                }
            };

            figuresCollection.Add(pathFigure);
            _originalGeometry = new PathGeometry(figuresCollection);
            return _originalGeometry;
        }
    }
}
