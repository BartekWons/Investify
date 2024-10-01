using Investify.Core;
using Investify.MVVM.Model;
using Investify.Services;
using System.Windows;

namespace Investify.MVVM.ViewModel.Account
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

            var users = await Database.GetUsers();

            if (!CheckIfUserExists(users))
            {
                MessageBox.Show("This account does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var user = users.FirstOrDefault(u => u.Login == this.Login);

            if (!IsPasswordCorrect(user, User.SHA512Hashing(Password, user.Salt)))
            {
                MessageBox.Show("Wrong password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Singleton.Instance.LoggedUser = user;
            CloseAction?.Invoke();
        }

        private bool CheckIfUserExists(IEnumerable<User> users)
        {
            return users.Any(u => u.Login == this.Login);
        }
        
        private bool IsPasswordCorrect(User user, string password)
        {
            return user != null && password.Equals(user.Password);
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
