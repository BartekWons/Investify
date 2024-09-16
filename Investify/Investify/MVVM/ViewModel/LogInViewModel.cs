using Investify.Core;
using Investify.MVVM.Model;
using System.CodeDom;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Windows;

namespace Investify.MVVM.ViewModel
{
    public class LogInViewModel : ObservableObject
    {
        public Action CloseAction { get; set; }

        public RelayCommand CloseCommand { get; set; }
        public RelayCommand ExecuteLogInCommand { get; set; }

        private string _login;

        public string Login
        {
            get { return _login; }
            set 
            { 
                _login = value;
                OnPropertyChanged();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set 
            {
               _password = value; 
                OnPropertyChanged();
            }
        }

        public LogInViewModel()
        {
            CloseCommand = new RelayCommand(o =>
            {
                CloseAction?.Invoke();
            });

            ExecuteLogInCommand = new RelayCommand(async o => await LogIn());
        }

        private async Task LogIn()
        {
            try
            {
                bool AreComponentsValid = Validation();
                if (!AreComponentsValid)
                {
                    MessageBox.Show("One of components is empty or contains only a whitespace.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var data = await Database.GetUsers();

            foreach (var user in data)
            {
                Debug.WriteLine(user);
            }
        }

        public bool Validation()
        {
            if (Login == null || Password == null)
            {
                throw new ArgumentException("One of components' content is null");
            }
            if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            return true;
        }
    }
}
