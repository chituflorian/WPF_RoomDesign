using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Table : BaseFurniture
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


        public Table()
        {
            Name = "Table";          
            Material = "Wood";
            Color = "Brown";
            OriginalGeometry = CreateGeometry();
            Width = 100;
            Height = 70;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            // Chairs
            PathFigure figure1 = new()
            {
                StartPoint = new Point(100, 0),
                IsClosed = true,
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (0, 0), IsStroked = false },
                    new LineSegment() { Point = new (100, 0), IsStroked = false },
                    new LineSegment() { Point = new (100, 120), IsStroked = false },
                    new LineSegment() { Point = new (100, 350) },
                    new LineSegment() { Point = new (100, 900), IsStroked = false },
                    new LineSegment() { Point = new (100, 350), IsStroked = false },
                    new LineSegment() { Point = new (500, 350)},
                    new LineSegment() { Point = new (1100, 350), IsStroked = false },
                    new LineSegment() { Point = new (500, 350), IsStroked = false },
                    new LineSegment() { Point = new (500, 120) },
                    new ArcSegment() { Size = new(11.6, 7), Point = new (100, 120), SweepDirection = SweepDirection.Counterclockwise},
                    new LineSegment() { Point = new (100, 0), IsStroked = false }
                }
            };

            PathFigure figure2 = new()
            {
                IsClosed = true,
                StartPoint = new Point(600, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (0, 0), IsStroked = false },
                    new LineSegment() { Point = new (600, 0), IsStroked = false },
                    new LineSegment() { Point = new (600, 120), IsStroked = false },
                    new LineSegment() { Point = new (600, 350) },
                    new LineSegment() { Point = new (600, 900), IsStroked = false },
                    new LineSegment() { Point = new (600, 350), IsStroked = false },
                    new LineSegment() { Point = new (1000, 350) },
                    new LineSegment() { Point = new (1100, 350), IsStroked = false },
                    new LineSegment() { Point = new (1000, 350), IsStroked = false },
                    new LineSegment() { Point = new (1000, 120)},

                    new ArcSegment() { Size = new(11.6, 7), Point = new (600, 120), SweepDirection = SweepDirection.Counterclockwise},
                    new LineSegment() { Point = new (600, 0), IsStroked = false },
                }
            };

            PathFigure figure3 = new()
            {
                IsClosed = true,
                StartPoint = new Point(100, 900),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (0, 900), IsStroked = false },
                    new LineSegment() { Point = new (100, 900), IsStroked = false },
                    new LineSegment() { Point = new (100, 780), IsStroked = false },
                    new LineSegment() { Point = new (100, 550) },
                    new LineSegment() { Point = new (100, 0), IsStroked = false },
                    new LineSegment() { Point = new (100, 550), IsStroked = false },
                    new LineSegment() { Point = new (500, 550) },
                    new LineSegment() { Point = new (1100, 550), IsStroked = false },
                    new LineSegment() { Point = new (500, 550), IsStroked = false },
                    new LineSegment() { Point = new (500, 780) },

                    new ArcSegment() { Size = new(11.6, 7), Point = new (100, 780), SweepDirection = SweepDirection.Clockwise},
                    new LineSegment() { Point = new (100, 900), IsStroked = false },
                }
            };

            PathFigure figure4 = new()
            {
                IsClosed = true,
                StartPoint = new Point(600, 900),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (0, 900), IsStroked = false },
                    new LineSegment() { Point = new (600, 900), IsStroked = false },
                    new LineSegment() { Point = new (600, 780), IsStroked = false },
                    new LineSegment() { Point = new (600, 550) },
                    new LineSegment() { Point = new (600, 0), IsStroked = false },
                    new LineSegment() { Point = new (600, 550), IsStroked = false },
                    new LineSegment() { Point = new (1000, 550) },
                    new LineSegment() { Point = new (1100, 550), IsStroked = false },
                    new LineSegment() { Point = new (1000, 550), IsStroked = false },
                    new LineSegment() { Point = new (1000, 780) },

                    new ArcSegment() { Size = new(11.6, 7), Point = new (600, 780), SweepDirection = SweepDirection.Clockwise},
                    new LineSegment() { Point = new (600, 900), IsStroked = false },
                }
            };

            // Table
            PathFigure figure5 = new()
            {
                IsClosed = true,
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (0, 0), IsStroked = false },
                    new LineSegment() { Point = new (0, 200), IsStroked = false },
                    new LineSegment() { Point = new (1100, 200) },
                    new LineSegment() { Point = new (1100, 700) },
                    new LineSegment() { Point = new (1100, 900), IsStroked = false },
                    new LineSegment() { Point = new (1100, 700), IsStroked = false },
                    new LineSegment() { Point = new (0, 700) },
                    new LineSegment() { Point = new (0, 200) },
                    new LineSegment() { Point = new (0, 0), IsStroked = false },
                }
            };

            // Points
            PathFigure figure6 = new()
            {
                IsClosed = true,
                StartPoint = new Point(0, 220),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (20, 220), IsStroked = false },
                    new LineSegment() { Point = new (20, 270) },
                    new LineSegment() { Point = new (20, 900), IsStroked = false },
                    new LineSegment() { Point = new (20, 270), IsStroked = false },
                    new LineSegment() { Point = new (70, 270) },
                    new LineSegment() { Point = new (1100, 270), IsStroked = false },
                    new LineSegment() { Point = new (70, 270), IsStroked = false },
                    new LineSegment() { Point = new (70, 220) },
                    new LineSegment() { Point = new (70, 0), IsStroked = false },
                    new LineSegment() { Point = new (70, 220), IsStroked = false },
                    new LineSegment() { Point = new (70, 220) },
                    new LineSegment() { Point = new (20, 220) },
                    new LineSegment() { Point = new (0, 220), IsStroked = false },
                }
            };

            PathFigure figure7 = new()
            {
                IsClosed = true,
                StartPoint = new Point(1030, 220),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (0, 220), IsStroked = false },
                    new LineSegment() { Point = new (1030, 220), IsStroked = false },
                    new LineSegment() { Point = new (1030, 270) },
                    new LineSegment() { Point = new (1030, 900), IsStroked = false },
                    new LineSegment() { Point = new (1030, 270), IsStroked = false },
                    new LineSegment() { Point = new (1080, 270) },
                    new LineSegment() { Point = new (1100, 270), IsStroked = false },
                    new LineSegment() { Point = new (1080, 270), IsStroked = false },
                    new LineSegment() { Point = new (1080, 220) },
                    new LineSegment() { Point = new (1080, 0), IsStroked = false },
                    new LineSegment() { Point = new (1080, 220), IsStroked = false },
                    new LineSegment() { Point = new (1030, 220) },
                }
            };

            PathFigure figure8 = new()
            {
                IsClosed = true,
                StartPoint = new Point(0, 630),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (20, 630), IsStroked = false },
                    new LineSegment() { Point = new (20, 680) },
                    new LineSegment() { Point = new (20, 900), IsStroked = false },
                    new LineSegment() { Point = new (20, 680), IsStroked = false },
                    new LineSegment() { Point = new (70, 680) },
                    new LineSegment() { Point = new (1100, 680), IsStroked = false },
                    new LineSegment() { Point = new (70, 680), IsStroked = false },
                    new LineSegment() { Point = new (70, 630) },
                    new LineSegment() { Point = new (70, 0), IsStroked = false },
                    new LineSegment() { Point = new (70, 630), IsStroked = false },
                    new LineSegment() { Point = new (70, 630) },
                    new LineSegment() { Point = new (20, 630) },
                    new LineSegment() { Point = new (0, 630), IsStroked = false },
                }
            };

            PathFigure figure9 = new()
            {
                IsClosed = true,
                StartPoint = new Point(1030, 630),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new (0, 630), IsStroked = false },
                    new LineSegment() { Point = new (1030, 630), IsStroked = false },
                    new LineSegment() { Point = new (1030, 680) },
                    new LineSegment() { Point = new (1030, 900), IsStroked = false },
                    new LineSegment() { Point = new (1030, 680), IsStroked = false },
                    new LineSegment() { Point = new (1080, 680) },
                    new LineSegment() { Point = new (1100, 680), IsStroked = false },
                    new LineSegment() { Point = new (1080, 680), IsStroked = false },
                    new LineSegment() { Point = new (1080, 630) },
                    new LineSegment() { Point = new (1080, 0), IsStroked = false },
                    new LineSegment() { Point = new (1080, 630), IsStroked = false },
                    new LineSegment() { Point = new (1080, 630) },

                }
            };

            figuresCollection.Add(figure1);
            figuresCollection.Add(figure2);
            figuresCollection.Add(figure3);
            figuresCollection.Add(figure4);
            figuresCollection.Add(figure5);
            figuresCollection.Add(figure6);
            figuresCollection.Add(figure7);
            figuresCollection.Add(figure8);
            figuresCollection.Add(figure9);

            _originalGeometry = new PathGeometry(figuresCollection);

            return _originalGeometry;
        }
    }
}