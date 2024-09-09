using Investify.Core;
using Investify.MVVM.View;
using System.Windows;
using System.Windows.Media.Effects;

namespace Investify.MVVM.ViewModel
{
    public class MainWindowViewModel
    {
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand MinimizeCommand { get; set; }
        public RelayCommand DragWindowCommand { get; set; }
        public RelayCommand LogInCommand { get; set; }

        public MainWindowViewModel()
        {
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

                LogInDialogView window = new LogInDialogView();
                window.Owner = Application.Current.MainWindow;
                window.ShowDialog();

                mainWindow.Effect = null;
            });
        }
    }
}
