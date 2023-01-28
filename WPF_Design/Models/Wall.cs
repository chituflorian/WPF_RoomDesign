using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;
namespace WPF_Design.Models
{
    [Serializable]
    public class Wall : BaseFurniture
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


        public Wall()
        {
            Name = "Wall";
            Description = "A wall.";
            Color = "Gray";
            OriginalGeometry = CreateGeometry();
            Width = 20;
            Height = 60;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure figure = new()
            {
                StartPoint = new Point(0, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new(0, 60) },
                    new LineSegment() { Point = new(10, 60) },
                    new LineSegment() { Point = new(10, 0) },
                    new LineSegment() { Point = new(0, 0) },
                },
                IsClosed = true
            };
            
            figuresCollection.Add(figure);
          
            _originalGeometry = new PathGeometry(figuresCollection);
            return _originalGeometry;
        }
    }
}
