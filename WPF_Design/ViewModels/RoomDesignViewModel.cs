using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WPF_Design.BusinessLogicLayer;
using WPF_Design.DataProvider;
using WPF_Design.Models;
using WPF_Design.ViewModels.Commands;

namespace WPF_Design.ViewModels
{
    public class RoomDesignViewModel : PropertyChange, IRoomDesignViewModel
    {
        private readonly ISelectedRoomViewModel _selectedRoomViewModel;
        private readonly DrawingViewModel _drawingViewModel;
        private readonly IRoomDesignDataProvider _roomDesignDataProvider;


        #region Data Members
        public bool IsObjectSelected => SelectedObject is not null;


        private ObservableCollection<BaseFurniture> _availableObjects;
        public ObservableCollection<BaseFurniture> AvailableObjects
        {
            get => _availableObjects;
            set
            {
                _availableObjects = value;
                NotifyPropertyChanged(nameof(AvailableObjects));
            }
        }


        private BaseFurniture _selectedObject;
        public BaseFurniture SelectedObject
        {
            get => _selectedObject;
            set
            {
                _selectedObject = value;
                ButtonIsEnabled = _selectedObject != null;

                NotifyPropertyChanged(nameof(SelectedObject));
                NotifyPropertyChanged(nameof(IsObjectSelected));
            }
        }


        /// <summary>
        ///  For delete and rotate buttons
        ///  Visible when an object is selected, Collapsed otherwise
        /// </summary>
        private bool _buttonIsEnabled;
        public bool ButtonIsEnabled
        {
            get => _buttonIsEnabled;
            set
            {
                _buttonIsEnabled = value;

                NotifyPropertyChanged(nameof(ButtonIsEnabled));
            }
        }


        /// <summary>
        ///  Display an object properties
        ///  Visible when an object is selected, Hidden otherwise
        /// </summary>
        private string _visibility = "Hidden";
        public string Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                NotifyPropertyChanged(nameof(Visibility));
            }
        }


        private RoomObjects _roomObjects;
        public RoomObjects RoomObjects

        {
            get => _roomObjects;
            set
            {
                _roomObjects = value;
                NotifyPropertyChanged(nameof(RoomObjects));
            }
        }

        #endregion


        public RoomDesignViewModel(ISelectedRoomViewModel selectedRoomViewModel, IRoomDesignDataProvider roomDesignDataProvider)
        { 
            _selectedRoomViewModel = selectedRoomViewModel;
            RoomObjects = _selectedRoomViewModel.RoomObjects;
            _roomDesignDataProvider = roomDesignDataProvider is not null ? roomDesignDataProvider : new RoomDesignDataProvider(this);

            Initialize();
        }

        public RoomDesignViewModel(DrawingViewModel drawingViewModel, IRoomDesignDataProvider roomDesignDataProvider)
        {
            _drawingViewModel = drawingViewModel;
            RoomObjects = _drawingViewModel.RoomObjects;
            _roomDesignDataProvider = roomDesignDataProvider is not null ? roomDesignDataProvider : new RoomDesignDataProvider(this);

            Initialize();
        }

        public void Initialize()
        {
            AvailableObjects = new ObservableCollection<BaseFurniture>()
            {
                new ArmChair(),
                new BathroomSink(),
                new Bathtub(),
                new Bed(),
                new Carpet(),
                new Chair(),
                new Cooker(),
                new Couch(),
                new Desk(),
                new Flower(),
                new KitchenSink(),
                new LivingRoomTable(),
                new Nightstand(),
                new RoundStairs(),
                new Shower(),
                new StraightStairs(),
                new Table(),
                new Toilet(),
                new TV(),
                new Wardrobe()
            }; 
        }

        public void AddObject(BaseFurniture objectToAdd, Point dropPosition, double canvasWidth, double canvasHeight)
        {
            objectToAdd.Id = RoomObjects.AddedObjects.Count + 1;

            if (CheckIfObjectsOverlap(dropPosition, objectToAdd, canvasWidth, canvasHeight))
            {
                SelectedObject = null;
            }
            else
            {
                objectToAdd.CoordinateX = dropPosition.X;
                objectToAdd.CoordinateY = dropPosition.Y;

                RoomObjects.AddedObjects.Add(objectToAdd);
                SelectedObject = objectToAdd;
                Visibility = "Visible";
            }
        }

        public bool CheckIfObjectsOverlap(Point newPosition, BaseFurniture _draggedObject, double canvasWidth, double canvasHeight)
        {
            Geometry clone = _roomDesignDataProvider.Clone(_draggedObject, _draggedObject.Angle, newPosition);

            if (_roomDesignDataProvider.CheckIfObjectsOverlap(_draggedObject, clone))
                return true;

            if (newPosition.X < 0 || newPosition.X + _draggedObject.Width > canvasWidth ||
                newPosition.Y < 0 || newPosition.Y + _draggedObject.Height > canvasHeight)
                return true;

            return false;
        }

       
        #region Commands

        private ICommand _rotateCommand;
        public ICommand RotateCommand
        {
            get
            {
                _rotateCommand ??= new GeometryManipulationCommand(_roomDesignDataProvider.RotateObject);
                return _rotateCommand;
            }
        }


        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                _deleteCommand ??= new GeometryManipulationCommand(_roomDesignDataProvider.DeleteObject);
                return _deleteCommand;
            }
        }


        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                _saveCommand ??= new FileManipulationCommand(_roomDesignDataProvider.SaveRoom);
                return _saveCommand;
            }
        }


        private ICommand _openCommand;
        public ICommand OpenCommand
        {
            get
            {
                _openCommand ??= new FileManipulationCommand(_roomDesignDataProvider.OpenSavedRoom);
                return _openCommand;
            }
        }

        #endregion
    }
}