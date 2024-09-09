using Investify.Core;
using Investify.MVVM.View;
using System.Diagnostics;
using System.Windows;

namespace Investify.MVVM.ViewModel
{
    public class LogInViewModel : ObservableObject
    {
        public Action CloseAction { get; set; }

        public RelayCommand CloseCommand { get; set; }
        public RelayCommand ExecuteLogInCommand { get; set; }

        private string email;

        public string Email
        {
            get { return email; }
            set 
            { 
                email = value;
                OnPropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set 
            {
               password = value; 
                OnPropertyChanged();
            }
        }

        public LogInViewModel()
        {
            CloseCommand = new RelayCommand(o =>
            {
                CloseAction?.Invoke();
            });

            ExecuteLogInCommand = new RelayCommand(o => LogIn());
        }

        private void LogIn()
        {
            Debug.WriteLine(email);
            Debug.WriteLine(password);
        }
    }
}
