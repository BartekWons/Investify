using Investify.Core;
using System.Windows;

namespace Investify.MVVM.ViewModel
{
    public class MainWindowViewModel
    {
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand MinimizeCommand { get; set; }
        public RelayCommand DragWindowCommand { get; set; }

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
        }
    }
}
