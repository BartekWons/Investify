using Investify.MVVM.ViewModel;
using System.Windows;

namespace Investify.MVVM.View
{
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
