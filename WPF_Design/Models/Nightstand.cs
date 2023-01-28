using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace WPF_Design.Models
{
    [Serializable]
    public class Nightstand : BaseFurniture
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


        public Nightstand()
        {
            Name = "Nightstand";          
            Color = "Brown";
            OriginalGeometry = CreateGeometry();
            Width = 90;
            Height = 70;
        }

        private Geometry CreateGeometry()
        {
            PathFigureCollection figuresCollection = new();

            PathFigure baseNightstand = new()
            {
                StartPoint = new Point(250, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new(500, 0), IsStroked = false },
                    new LineSegment() { Point = new(250, 0), IsStroked = false },
                    new LineSegment() { Point = new(0, 360), IsStroked = false },
                    new LineSegment() { Point = new(250, 0), IsStroked = false },
                    new LineSegment() { Point = new(500, 0) },
                    new LineSegment() { Point = new(500, 250) },
                    new ArcSegment() {
                        Point = new Point(0, 250),
                        SweepDirection = SweepDirection.Clockwise,
                        RotationAngle = 0,
                        IsLargeArc = true,
                        Size = new Size(40, 20)
                    },
                    new LineSegment() { Point = new(0, 0) },
                },
                IsClosed = true
            };

            PathFigure lamp = new()
            {
                StartPoint = new Point(300, 0),
                Segments = new PathSegmentCollection()
                {
                    new LineSegment() { Point = new(500, 0), IsStroked = false },
                    new LineSegment() { Point = new(300, 0), IsStroked = false },
                    new LineSegment() { Point = new(0, 500), IsStroked = false },
                    new LineSegment() { Point = new(300, 0), IsStroked = false },
                    new LineSegment() { Point = new(300, 150), IsStroked = false },
                    new ArcSegment() {
                        Point = new Point(250, 140),
                        SweepDirection = SweepDirection.Clockwise,
                        RotationAngle = 0,
                        IsLargeArc = true,
                        Size = new Size(10, 10)
                    },
                    new ArcSegment() {
                        Point = new Point(300, 150),
                        SweepDirection = SweepDirection.Clockwise,
                        RotationAngle = 0,
                        IsLargeArc = true,
                        Size = new Size(10, 10)
                    },
                    new LineSegment() { Point = new(300, 100) },
                    new ArcSegment() {
                        Point = new Point(250, 190),
                        SweepDirection = SweepDirection.Clockwise,
                        RotationAngle = 0,
                        IsLargeArc = true,
                        Size = new Size(10, 10)
                    },
                    new ArcSegment() {
                        Point = new Point(300, 100),
                        SweepDirection = SweepDirection.Clockwise,
                        RotationAngle = 0,
                        IsLargeArc = true,
                        Size = new Size(10, 10)
                    },
                    new LineSegment() { Point = new(300, 95) },
                    new ArcSegment() {
                        Point = new Point(250, 195),
                        SweepDirection = SweepDirection.Clockwise,
                        RotationAngle = 0,
                        IsLargeArc = true,
                        Size = new Size(10, 10)
                    },
                    new ArcSegment() {
                        Point = new Point(300, 95),
                        SweepDirection = SweepDirection.Clockwise,
                        RotationAngle = 0,
                        IsLargeArc = true,
                        Size = new Size(10, 10)
                    },
                    new LineSegment() { Point = new(300, 70) },
                    new ArcSegment() {
                        Point = new Point(250, 220),
                        SweepDirection = SweepDirection.Clockwise,
                        RotationAngle = 0,
                        IsLargeArc = true,
                        Size = new Size(10, 10)
                    },
                    new ArcSegment() {
                        Point = new Point(300, 70),
                        SweepDirection = SweepDirection.Clockwise,
                        RotationAngle = 0,
                        IsLargeArc = true,
                        Size = new Size(10, 10)
                    },
                    new LineSegment() { Point = new(275, 150) },
                    new LineSegment() { Point = new(200, 130) },
                    new LineSegment() { Point = new(200, 130) },
                    new LineSegment() { Point = new(275, 150) },
                    new LineSegment() { Point = new(260, 220) },
                    new LineSegment() { Point = new(260, 220) },
                    new LineSegment() { Point = new(275, 150) },
                    new LineSegment() { Point = new(350, 180) },
                    new LineSegment() { Point = new(350, 180) },
                    new LineSegment() { Point = new(275, 150) },
                    new LineSegment() { Point = new(300, 70) },
                    new LineSegment() { Point = new(300, 0), IsStroked= false },
                },
                IsClosed = true
            };

            figuresCollection.Add(baseNightstand);
            figuresCollection.Add(lamp);
            _originalGeometry = new PathGeometry(figuresCollection);

            return _originalGeometry;
        }
    }
}