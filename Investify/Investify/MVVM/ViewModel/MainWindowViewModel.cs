using Investify.Core;
using Investify.MVVM.View;
using Investify.MVVM.ViewModel.Menu;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Effects;

namespace Investify.MVVM.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public HomeViewModel HomeViewModel { get; set; }
        public SearchViewModel SearchViewModel { get; set; }
        public FavouriteViewModel FavouriteViewModel { get; set; }
        public SettingsViewModel SettingsViewModel { get; set; }

        public RelayCommand SwitchToHomeViewCommand { get; set; }
        public RelayCommand SwitchToSearchViewCommand { get; set; }
        public RelayCommand SwitchToFavouriteViewCommand { get; set; }
        public RelayCommand SwitchToSettingsViewCommand { get; set; }

        public RelayCommand CloseCommand { get; set; }
        public RelayCommand MinimizeCommand { get; set; }
        public RelayCommand DragWindowCommand { get; set; }
        public RelayCommand LogInCommand { get; set; }
        public RelayCommand SignUpCommand { get; set; }
        

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value; 
                OnPropertyChanged();
            }
        }


        public MainWindowViewModel()
        {
            HomeViewModel = new HomeViewModel();
            SearchViewModel = new SearchViewModel();
            FavouriteViewModel = new FavouriteViewModel();
            SettingsViewModel = new SettingsViewModel();

            CurrentView = HomeViewModel;

            CloseCommand = new RelayCommand(o =>
            {
                Application.Current.MainWindow.Close();
            });

            MinimizeCommand = new RelayCommand(o =>
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            });

            DragWindowCommand = new RelayCommand(o =>
            {
                Application.Current.MainWindow.DragMove();
            });

            LogInCommand = new RelayCommand(o =>
            {
                var mainWindow = Application.Current.MainWindow;
                var blurEffect = new BlurEffect();
                blurEffect.Radius = 5;
                mainWindow.Effect = blurEffect;

                LogInView window = new LogInView();
                window.Owner = Application.Current.MainWindow;
                window.ShowDialog();

                mainWindow.Effect = null;
            });

            SignUpCommand = new RelayCommand(o =>
            {
                var mainWindow = Application.Current.MainWindow;
                var blurEffect = new BlurEffect();
                blurEffect.Radius = 5;
                mainWindow.Effect = blurEffect;

                SignUpWindow window = new SignUpWindow();
                window.Owner = mainWindow;
                window.ShowDialog();

                mainWindow.Effect = null;
            });

            SwitchToHomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeViewModel;
            });

            SwitchToSearchViewCommand = new RelayCommand(o =>
            {
                CurrentView = SearchViewModel;
            });

            SwitchToFavouriteViewCommand = new RelayCommand(o =>
            {
                CurrentView = FavouriteViewModel;
            });

            SwitchToSettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsViewModel;
            });
        }
    }
}
