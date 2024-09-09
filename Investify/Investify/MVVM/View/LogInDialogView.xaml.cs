using Investify.MVVM.ViewModel;
using System.Windows;

namespace Investify.MVVM.View
{
    /// <summary>
    /// Logika interakcji dla klasy LogInDialogView.xaml
    /// </summary>
    public partial class LogInDialogView : Window
    {
        public LogInDialogView()
        {
            InitializeComponent();
            if (DataContext is LogInViewModel viewModel)
            {
                viewModel.CloseAction = new Action(() => {this.Close();});
            }
        }
    }
}
