using System;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Desk : BaseFurniture
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
        
        
        public Desk()
        {
            Name = "Desk";
            Description = "A desk.";          
            Color = "#FF541111";
            Material = "Wood";
            OriginalGeometry = CreateGeometry();
            Width = 100;
            Height = 100;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure desk = new()
            {
                IsClosed = true,
                StartPoint = new(2, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (18, 0) },
                    new LineSegment() { Point = new (20, 4) },
                    new LineSegment() { Point = new (20, 30) },
                    new ArcSegment() { Size = new (17, 29), Point = new (38, 55), SweepDirection = SweepDirection.Counterclockwise},
                    new LineSegment() { Point = new (49, 55) },
                    new LineSegment() { Point = new (52, 59) },
                    new LineSegment() { Point = new (52, 96) },
                    new LineSegment() { Point = new (50, 100) },
                    new LineSegment() { Point = new (4, 100) },
                    new LineSegment() { Point = new (0, 92) },
                    new LineSegment() { Point = new (0, 4) },
                }
            };

            PathFigure objectsOnDesk = new()
            {
                IsClosed = true,
                StartPoint = new(12, 60),
                Segments = new PathSegmentCollection()
                {
                    // Keyboard
                    new LineSegment() { Point = new (12, 55), IsStroked = false },
                    new ArcSegment() { Size = new (1.5, 3), Point = new(12.1, 55), IsLargeArc = true, SweepDirection = SweepDirection.Clockwise },
                    new LineSegment() { Point = new (12, 55) },
                    new LineSegment() { Point = new (12, 60), IsStroked = false },
                    new LineSegment() { Point = new (16, 58) },
                    new LineSegment() { Point = new (26, 75) },
                    new LineSegment() { Point = new (50, 100), IsStroked = false },
                    new LineSegment() { Point = new (26, 75), IsStroked = false },
                    new LineSegment() { Point = new (0, 0), IsStroked = false },
                    new LineSegment() { Point = new (26, 75), IsStroked = false },
                    new LineSegment() { Point = new (22, 77) },
                    new LineSegment() { Point = new (12, 60) },

                    // PC
                    new LineSegment() { Point = new (8, 58), IsStroked = false },
                    new LineSegment() { Point = new (6, 57), IsStroked = false },
                    new LineSegment() { Point = new (3, 58) },
                    new LineSegment() { Point = new (20, 89) },
                    new LineSegment() { Point = new (17, 90) },
                    new LineSegment() { Point = new (3, 65) },
                    new LineSegment() { Point = new (6, 64) },
                    new LineSegment() { Point = new (22, 93) },
                    new LineSegment() { Point = new (25, 92) },
                    new LineSegment() { Point = new (6, 57) },
                    new LineSegment() { Point = new (8, 58), IsStroked = false },
                    new LineSegment() { Point = new (12, 60), IsStroked = false },
                    new LineSegment() { Point = new (12, 60), IsStroked = false },

                    // Notebook1
                    new LineSegment() { Point = new (37, 65), IsStroked = false },
                    new LineSegment() { Point = new (43, 65) },
                    new LineSegment() { Point = new (43, 90) },
                    new LineSegment() { Point = new (37, 90) },
                    new LineSegment() { Point = new (37, 65) },
                    new LineSegment() { Point = new (38, 67), IsStroked = false },
                    new LineSegment() { Point = new (42, 67) },
                    new LineSegment() { Point = new (42, 88) },
                    new LineSegment() { Point = new (38, 88) },
                    new LineSegment() { Point = new (38, 67) },
                    new LineSegment() { Point = new (37, 65), IsStroked = false },
                    new LineSegment() { Point = new (12, 60), IsStroked = false },

                    // Notebook2
                    new LineSegment() { Point = new (7, 50), IsStroked = false },
                    new LineSegment() { Point = new (3, 15) },
                    new LineSegment() { Point = new (10, 10) },
                    new LineSegment() { Point = new (14, 35) },
                    new LineSegment() { Point = new (7, 40) },
                    new LineSegment() { Point = new (12, 60), IsStroked = false },
                }
            };

            figuresCollection.Add(desk);
            figuresCollection.Add(objectsOnDesk);

            _originalGeometry = new PathGeometry(figuresCollection) { FillRule = FillRule.Nonzero };

            return _originalGeometry;
        }
    }
}
