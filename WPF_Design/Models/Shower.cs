using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Shower : BaseFurniture
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


        public Shower()
        {
            Name = "Shower";
            OriginalGeometry = CreateGeometry();
            Color = "#FF78E5D5";
            Width = 80;
            Height = 80;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figureCollection = new();

            PathFigure Shower = new()
            {
                StartPoint = new Point(0, 0),
                Segments = new PathSegmentCollection()
                {
                    //Borders
                    new LineSegment() { Point = new(0,700) },
                    new LineSegment() { Point = new(700,700) },
                    new LineSegment() { Point = new(700,400) },
                    new LineSegment() { Point = new(600,120) },
                    new LineSegment() { Point = new(300,0) },
                    new LineSegment() { Point = new(0,0) },

                    //Inner big circle
                    new LineSegment() { Point = new(140,250), IsStroked=false },
                    new ArcSegment(){
                      Point = new(560,450),
                      Size = new(30,29.7),
                      SweepDirection = SweepDirection.Clockwise,
                      IsLargeArc = false
                    },
                    new ArcSegment(){
                      Point = new(140,250),
                      Size = new(30,29.7),
                      SweepDirection = SweepDirection.Clockwise,
                      IsLargeArc = false
                    },
                    new LineSegment() { Point = new(150,260), IsStroked=false },

                    //Inner small circle
                    new ArcSegment(){
                      Point = new(550,440),
                      Size = new(30,32),
                      SweepDirection = SweepDirection.Clockwise,
                      IsLargeArc = false
                    },
                    new ArcSegment(){
                      Point = new(150,260),
                      Size = new(30,32),
                      SweepDirection = SweepDirection.Clockwise,
                      IsLargeArc = false
                    },
                    new LineSegment() { Point = new(140,250), IsStroked=false },

                    //First line
                    new LineSegment() { Point = new(200,480), IsStroked=false },
                    new LineSegment() { Point = new(250,180) },
                    new LineSegment() { Point = new(250,180) },
                    new LineSegment() { Point = new(200,480) },

                    //Second line
                    new LineSegment() { Point = new(210,490) },
                    new LineSegment() { Point = new(430,170) },
                    new LineSegment() { Point = new(430,170) },
                    new LineSegment() { Point = new(210,490) },

                    //Third line
                    new LineSegment() { Point = new(220,500) },
                    new LineSegment() { Point = new(500,330) },
                    new LineSegment() { Point = new(500,330) },
                    new LineSegment() { Point = new(220,500) },

                    //4th line
                    new LineSegment() { Point = new(230,510) },
                    new LineSegment() { Point = new(470,470) },
                    new LineSegment() { Point = new(470,470) },
                    new LineSegment() { Point = new(230,510) },

                    new LineSegment() { Point = new(200,480) },

                    new LineSegment() { Point = new(140,250), IsStroked=false },
                    new LineSegment() { Point = new(0,500), IsStroked=false },
                    new LineSegment() { Point = new(200,700) },
                    new LineSegment() { Point = new(200,700) },
                    new LineSegment() { Point = new(200,700) },
                    new LineSegment() { Point = new(0,500) },
                    new LineSegment() { Point = new(140,250), IsStroked=false }
                }
            };

            figureCollection.Add(Shower);

            _originalGeometry = new PathGeometry(figureCollection);

            return _originalGeometry;
        }
    }
}
