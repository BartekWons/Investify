using Investify.MVVM.ViewModel;
using System.Windows;

namespace Investify.MVVM.View
{
    public partial class LogInView : Window
    {
        public LogInView()
        {
            InitializeComponent();
            if (DataContext is LogInViewModel viewModel)
            {
                viewModel.CloseAction = new Action(() => {this.Close();});
            }
        }
    }
}
