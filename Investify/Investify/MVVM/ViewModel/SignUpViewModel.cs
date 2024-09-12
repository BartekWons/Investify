using Investify.Core;

namespace Investify.MVVM.ViewModel
{
    public class SignUpViewModel
    {
        public Action CloseAction { get; set; }

        public RelayCommand CloseCommand { get; set; }

        public string[] Months { get; set; }

        public int SelectedMonth { get; set; }


        public SignUpViewModel()
        {
            Months = new string[]
            {
                "January", "February", "March",
                "April", "May", "June",
                "July", "August", "September",
                "October", "November", "December"
            };

            SelectedMonth = 0;

            CloseCommand = new RelayCommand(o =>
            {
                CloseAction?.Invoke();
            });
        }
    }
}
