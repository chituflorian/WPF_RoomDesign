using System.Windows;
using WPF_Design.DataProvider;
using WPF_Design.ViewModels;

namespace WPF_Design.Views
{
    public partial class SelectRoomWindow : Window
    {
        private readonly SelectedRoomViewModel _selectedRoomViewModel;


        public SelectRoomWindow()
        {
            InitializeComponent();
            _selectedRoomViewModel = new(new SelectedRoomDataProvider());
            DataContext = _selectedRoomViewModel;
        }

        private void OpenRoom1Click(object sender, RoutedEventArgs e)
        {
            _selectedRoomViewModel.RoomObjects.SelectedRoomType = "room1";
            _selectedRoomViewModel.LoadDefaultRoom();

            LoadRoomDesignWindow();
        }

        private void OpenRoom2Click(object sender, RoutedEventArgs e)
        {
            _selectedRoomViewModel.RoomObjects.SelectedRoomType = "room2";
            _selectedRoomViewModel.LoadDefaultRoom();

            LoadRoomDesignWindow();
        }

        private void OpenRoom3Click(object sender, RoutedEventArgs e)
        {
            _selectedRoomViewModel.RoomObjects.SelectedRoomType = "room3";
            _selectedRoomViewModel.LoadDefaultRoom();

            LoadRoomDesignWindow();
        }

        private void CreateCustomRoomClick(object sender, RoutedEventArgs e)
        {
            _selectedRoomViewModel.RoomObjects.SelectedRoomType = "custom";

            DrawingWindow drawingWindow = new();
            drawingWindow.Show();
            Close();
        }

        private void LoadRoomDesignWindow()
        {
            RoomDesignWindow roomDesignWindow = new(_selectedRoomViewModel);
            roomDesignWindow.Show();
            Close();
        }

        private void OpenExistingRoomClick(object sender, RoutedEventArgs e)
        {
            _selectedRoomViewModel.OpenSavedRoom();
            if (string.IsNullOrEmpty(_selectedRoomViewModel.RoomObjects.SelectedRoomType))
                return;

            LoadRoomDesignWindow();
        }
    }
}
