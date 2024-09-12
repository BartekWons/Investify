using Investify.MVVM.ViewModel;
using System.Windows;

namespace Investify.MVVM.View
{
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();

            if (DataContext is SignUpViewModel viewModel)
            {
                viewModel.CloseAction = new Action(() =>
                {
                    this.Close();
                });
            }
        }
    }
}
