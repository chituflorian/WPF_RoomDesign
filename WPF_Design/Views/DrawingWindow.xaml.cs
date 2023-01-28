using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF_Design.Models;
using WPF_Design.ViewModels;

namespace WPF_Design.Views
{
    public partial class DrawingWindow : Window
    {
        private Path _path = null;
        public Point _startPoint;
        private bool _isMouseDown = false;
        private ObjectEnum _objectType = ObjectEnum.NULL;
        private readonly DrawingViewModel _drawingViewModel;

        public enum ObjectEnum
        {
            NULL = 0,
            DOOR,
            GLASS,
            WALL
        }

        public DrawingWindow()
        {
            InitializeComponent();
            _drawingViewModel = new();
            DataContext = _drawingViewModel;
        }

        private void DrawGlassButton(object sender, RoutedEventArgs e)
        {
            _objectType = ObjectEnum.GLASS;
        }

        private void DrawDoorButton(object sender, RoutedEventArgs e)
        {
            _objectType = ObjectEnum.DOOR;
        }

        private void DrawWallButton(object sender, RoutedEventArgs e)
        {
            _objectType = ObjectEnum.WALL;
        }

        private void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(canvas);
            _isMouseDown = true;
            deleteButton.Visibility = Visibility.Hidden;
        }

        private void CanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = false;
            _path = new();
        }

        private void SelectAnObjectOnCanvas(object sender, MouseButtonEventArgs e)
        {
            HitTestResult hitTestResult = VisualTreeHelper.HitTest(canvas, e.GetPosition(canvas));
            if (hitTestResult is null)
                return;

            if (canvas.Children.Count == 0)
                label.Visibility = Visibility.Hidden;

            if (hitTestResult.VisualHit is Path path)
            {
                (DataContext as DrawingViewModel).SelectedObject = path;
                deleteButton.Visibility = Visibility.Visible;
                label.Visibility = Visibility.Hidden;
            }
            else if (hitTestResult.VisualHit is not Path)
            {
                deleteButton.Visibility = Visibility.Hidden;
                label.Visibility = Visibility.Visible;
            }
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            var itemToRemove = (DataContext as DrawingViewModel).SelectedObject;

            canvas.Children.Remove((UIElement)itemToRemove);
            deleteButton.Visibility = Visibility.Hidden;
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {         
            if (_isMouseDown)
            { 
                if (canvas.Children is not null)
                    label.Visibility = Visibility.Visible;                                  

                Brush brush = GetObjectColor();

                if (_path == null)
                {
                    _path = new();
                    canvas.Children.Add(_path);
                }

                _path.Stroke = brush;
                _path.StrokeThickness = 7;

                if (_path != null)
                {
                    canvas.Children.Remove(_path);
                    _path.Data = new LineGeometry(_startPoint, e.GetPosition(canvas));
                    canvas.Children.Add(_path);
                }   
            }
        }

        private Brush GetObjectColor()
        {
            if (_objectType == ObjectEnum.DOOR)
                return (Brush)(new BrushConverter().ConvertFrom("#7FFF0000"));

            if (_objectType == ObjectEnum.GLASS)
                return (Brush)(new BrushConverter().ConvertFrom("#FF7790F5"));

            if (_objectType == ObjectEnum.WALL)
                return (Brush)(new BrushConverter().ConvertFrom("#FF000000"));

            return new SolidColorBrush();
        }

        private void CreateRoomGeometry(Path myPath)
        {
            double height = Math.Sqrt(Math.Pow(myPath.Data.Bounds.Width, 2) + Math.Pow(myPath.Data.Bounds.Height, 2));
            double width = 20;
            double coordinateX;
            if ((myPath.Data as LineGeometry).StartPoint.X > canvas.Width - 15
                 && (myPath.Data as LineGeometry).StartPoint.Y < (myPath.Data as LineGeometry).EndPoint.Y)
            {
                coordinateX = canvas.Width - 15;
            }
            else
                coordinateX = (myPath.Data as LineGeometry).StartPoint.X;

            double coordinateY;
            if ((myPath.Data as LineGeometry).StartPoint.Y < 25
                 && (myPath.Data as LineGeometry).StartPoint.X < (myPath.Data as LineGeometry).EndPoint.X)
            {
                coordinateY = 25;
            }
            else
                coordinateY = (myPath.Data as LineGeometry).StartPoint.Y;

            double angle = (180 / Math.PI) * Math.Atan2(myPath.Data.Bounds.BottomRight.Y - myPath.Data.Bounds.Y,
                                                        myPath.Data.Bounds.BottomRight.X - myPath.Data.Bounds.X) - 90;

            LineGeometry lineGeometry = (LineGeometry)myPath.Data;

            if ((lineGeometry.StartPoint.Y <= lineGeometry.EndPoint.Y && lineGeometry.StartPoint.X >= lineGeometry.EndPoint.X) ||
                 lineGeometry.StartPoint.Y >= lineGeometry.EndPoint.Y && lineGeometry.StartPoint.X <= lineGeometry.EndPoint.X)
            {
                angle *= -1;  //if angle is between [0,90] or [180,270] 
            }

            if (lineGeometry.StartPoint.Y >= lineGeometry.EndPoint.Y && lineGeometry.StartPoint.X >= lineGeometry.EndPoint.X)
            {
                angle += 180; //if angle is between [90,180]
            }
            else if (lineGeometry.StartPoint.Y >= lineGeometry.EndPoint.Y && lineGeometry.StartPoint.X <= lineGeometry.EndPoint.X)
            {
                angle += 180; //if angle is between [180,270]
            }
            else if (lineGeometry.StartPoint.Y <= lineGeometry.EndPoint.Y && lineGeometry.StartPoint.X <= lineGeometry.EndPoint.X)
            {
                angle += 360; //if angle is between [270,360]
            }

            switch (myPath.Stroke.ToString())
            {
                case "#7FFF0000":
                    (DataContext as DrawingViewModel).RoomObjects.AuxiliaryObjects.Add(
                            new Door()
                            {
                                CoordinateX = coordinateX,
                                CoordinateY = coordinateY,
                                Width = width,
                                Height = height,
                                Angle = angle,
                            });
                    break;

                case "#FF7790F5":
                    (DataContext as DrawingViewModel).RoomObjects.AuxiliaryObjects.Add(
                            new Glass()
                            {
                                CoordinateX = coordinateX,
                                CoordinateY = coordinateY,
                                Width = width,
                                Height = height,
                                Angle = angle,
                            });
                    break;

                case "#FF000000":
                    (DataContext as DrawingViewModel).RoomObjects.AuxiliaryObjects.Add(
                            new Wall()
                            {
                                CoordinateX = coordinateX,
                                CoordinateY = coordinateY,
                                Width = width,
                                Height = height,
                                Angle = angle,
                            });
                    break;

                default:
                    break;
            }
        }

        private void SaveCanvasButton(object sender, RoutedEventArgs e)
        {
            foreach (var item in canvas.Children)
            {
                if (item is Path myPath)
                {
                    CreateRoomGeometry(myPath);
                }
            }

            RoomDesignWindow roomDesignWindow = new(_drawingViewModel);
            roomDesignWindow.Show();
            Close();
        }

        private void ClearCanvasButton(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
        }

        private void ReturnMainWindow(object sender, RoutedEventArgs e)
        {
            SelectRoomWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }        

    }
}
