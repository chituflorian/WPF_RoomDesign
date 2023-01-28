using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;
using WPF_Design.BusinessLogicLayer;
using WPF_Design.Models;
using WPF_Design.ViewModels;
using Brushes = System.Windows.Media.Brushes;
using MyPath = System.Windows.Shapes.Path;
using Point = System.Windows.Point;
using WPF_Design.DataProvider;

namespace WPF_Design.Views
{
    public partial class RoomDesignWindow : Window
    {
        private MyPath _path;
        private MyPath _tempPath;
        private Label _tempLabel;
        private Point _startPoint;
        private Point _mousePosition;
        private bool _isClicked = false;
        private int _rightClickCount = 0;
        private BaseFurniture _draggedObject;
        private int _countDistanceBtnClicks = 0;
        private readonly DrawingViewModel _drawingViewModel;
        private readonly SelectedRoomViewModel _selectedRoomViewModel;

        public RoomDesignWindow(SelectedRoomViewModel selectedRoomViewModel)
        {
            InitializeComponent();
            _selectedRoomViewModel = selectedRoomViewModel;
            DataContext = new RoomDesignViewModel(_selectedRoomViewModel, null);
        }


        public RoomDesignWindow(DrawingViewModel drawingViewModel)
        {
            InitializeComponent();
            _drawingViewModel = drawingViewModel;
            DataContext = new RoomDesignViewModel(_drawingViewModel, null);
        }


        private static BaseFurniture Clone(object element)
        {
            string cloneXaml = XamlWriter.Save(element);
            StringReader stringReader = new(cloneXaml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            var newItem = (BaseFurniture)XamlReader.Load(xmlReader);

            return newItem;
        }


        private void ListViewMouseScroll(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }


        private void OpenSelectRoomWindow(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to start a new project?", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                SelectRoomWindow selectRoomWindow = new();
                selectRoomWindow.Show();
                Close();
            }
        }


        private void DrawingAreaDragObject(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton is MouseButtonState.Pressed)
            {
                (sender as UIElement).CaptureMouse();
                _mousePosition = Mouse.GetPosition(sender as UIElement);

                BaseFurniture furniture = ((ContentPresenter)sender).Content as BaseFurniture;
                ((RoomDesignViewModel)DataContext).Visibility = "Visible";

                ((RoomDesignViewModel)DataContext).SelectedObject = furniture;
                _draggedObject = furniture;
            }
        }


        private void DrawingAreaMoveObject(object sender, MouseEventArgs e)
        {
            if (e.LeftButton is MouseButtonState.Pressed)
            {
                var newPoint = e.GetPosition(sender as UIElement);

                if (newPoint == _mousePosition)
                    return;

                if (_draggedObject is null)
                    return;

                if (!((RoomDesignViewModel)DataContext).CheckIfObjectsOverlap(newPoint, _draggedObject, drawingArea.Width, drawingArea.Height))
                {
                    _draggedObject.CoordinateX = newPoint.X;
                    _draggedObject.CoordinateY = newPoint.Y;
                }
            }
        }


        private void DrawingAreaDropObject(object sender, MouseButtonEventArgs e)
        {
            (sender as UIElement).ReleaseMouseCapture();
            _draggedObject = null;
        }


        private void DrawingAreaClick(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Canvas)
            {
                ((RoomDesignViewModel)DataContext).SelectedObject = null;
            }
            else
            {
                if (e.OriginalSource is MyPath myPath)
                {
                    ((RoomDesignViewModel)DataContext).SelectedObject = myPath.DataContext as BaseFurniture;
                    ((RoomDesignViewModel)DataContext).Visibility = "Visible";
                }
            }
        }


        private void ListViewDragElement(object sender, MouseEventArgs e)
        {
            if (sender is null)
                return;

            ListView listView = (ListView)sender;

            if (listView is null)
                return;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                BaseFurniture geometry = (BaseFurniture)listView.SelectedItem;
                ((RoomDesignViewModel)DataContext).SelectedObject = geometry;
                ((RoomDesignViewModel)DataContext).Visibility = "Hidden";

                if (geometry is null)
                    return;

                if (geometry.OriginalGeometry is null)
                    return;

                MyPath path = new()
                {
                    Data = geometry.OriginalGeometry,
                };

                _draggedObject = Clone(geometry);

                DragDrop.DoDragDrop(path, path, DragDropEffects.Move);
            }
        }


        private void DrawingAreaDropElementFromListView(object sender, DragEventArgs e)
        {
            if (_draggedObject == null)
                return;

            if (_draggedObject.Id == 0)
            {
                var newPoint = e.GetPosition(sender as UIElement);

                ((RoomDesignViewModel)DataContext).AddObject(_draggedObject, newPoint, drawingArea.Width, drawingArea.Height);
            }

            (sender as UIElement).ReleaseMouseCapture();
            _draggedObject = null;
        }


        private void ListViewClick(object sender, MouseButtonEventArgs e)
        {
            ListView listView = (ListView)sender;
            ((RoomDesignViewModel)DataContext).SelectedObject = (BaseFurniture)listView.SelectedItem;
            ((RoomDesignViewModel)DataContext).Visibility = "Hidden";
        }


        private void DrawingAreaMeasureDistance(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is not Canvas)
            {
                if (_isClicked == true)
                {
                    if (e.OriginalSource is not MyPath myPath)
                        return;

                    if (myPath.DataContext is not BaseFurniture myObject)
                        return;

                    var point = new Point(myObject.OriginalGeometry.Bounds.X + myObject.OriginalGeometry.Bounds.Width / 2,
                                          myObject.OriginalGeometry.Bounds.Y + myObject.OriginalGeometry.Bounds.Height / 2);

                    _rightClickCount++;

                    if (_rightClickCount == 1)
                    {
                        _startPoint = point;
                        drawingArea.Children.Remove(_tempPath);
                        drawingArea.Children.Remove(_tempLabel);
                    }
                    if (_rightClickCount == 2)
                    {
                        BuildLine(_startPoint, point);
                        drawingArea.Children.Add(_path);

                        double distance = DistanceManipulation.CalculateDistance(_startPoint, point);
                        _tempLabel = DistanceManipulation.DisplayDistance(_startPoint, point, distance);
                        drawingArea.Children.Add(_tempLabel);

                        _rightClickCount = 0;
                    }
                }
            }
        }


        public void BuildLine(Point start, Point end)
        {
            _path = new()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 3,
                Data = new LineGeometry(start, end)
            };
            _tempPath = _path;
        }


        private void DistanceButtonClick(object sender, RoutedEventArgs e)
        {
            _isClicked = true;
            distanceBtn.Background = Brushes.LightGray;
            _countDistanceBtnClicks++;
            if (_countDistanceBtnClicks == 2)
            {
                _isClicked = false;
                _countDistanceBtnClicks = 0;
                drawingArea.Children.Remove(_tempPath);
                drawingArea.Children.Remove(_tempLabel);
                distanceBtn.Background = null;
            }
        }
    }
}
