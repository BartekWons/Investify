using Investify.Core;
using Investify.MVVM.Model;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;

namespace Investify.MVVM.ViewModel
{
    public class SignUpViewModel : ObservableObject
    {
        public Action CloseAction { get; set; }

        public RelayCommand CloseCommand { get; set; }
        public RelayCommand SignUpCommand { get; set; }

        private string _firstname;

        public string Firstname
        {
            get { return _firstname; }
            set 
            { 
                _firstname = value; 
                OnPropertyChanged();
            }
        }

        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set 
            { 
                _lastname = value; 
                OnPropertyChanged();
            }
        }

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


        private string _email;

        public string Email
        {
            get { return _email; }
            set 
            { 
                _email = value; 
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

        private string _dayOfBirth;

        public string DayOfBirth
        {
            get { return _dayOfBirth; }
            set 
            { 
                _dayOfBirth = value; 
                OnPropertyChanged();
            }
        }

        public string[] Months { get; set; }

        public int MonthOfBirth { get; set; }

        private string _yearOfBirth;

        public string YearOfBirth
        {
            get { return _yearOfBirth; }
            set 
            {
                _yearOfBirth = value; 
                OnPropertyChanged();
            }
        }


        public SignUpViewModel()
        {
            Months = new string[]
            {
                "January", "February", "March",
                "April", "May", "June",
                "July", "August", "September",
                "October", "November", "December"
            };

            MonthOfBirth = 0;

            CloseCommand = new RelayCommand(o =>
            {
                CloseAction?.Invoke();
            });

            SignUpCommand = new RelayCommand(async o => await SignUp());
        }

        private async Task SignUp()
        {
            try
            {
                Validation();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            var salt = User.GetSalt(16);
            var hashedPassword = User.SHA512Hashing(Password, salt);
            User user = new User()
            {
                Firstname = this.Firstname,
                Lastname = this.Lastname,
                Login = this.Login,
                Email = this.Email,
                Password = hashedPassword,
                Salt = salt,
                BirthDate = new DateTime(
                    Convert.ToInt16(YearOfBirth),
                    MonthOfBirth + 1,
                    Convert.ToInt16(DayOfBirth))
            };

            Debug.WriteLine(user);

            await Database.AddUser(user);
        }

        public bool Validation()
        {
            if (AreComponentsNull())
            {
                throw new ArgumentException("One of components' content is null");
            }

            if (AreComponentsEmpty())
            {
                //MessageBox.Show("One of components is empty or contains only a whitespace.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!IsDateConvertibleToIntegerAndBiggerThanZero())
            {
                return false;
            }

            if (!IsBirthDateEarlierThanTodaysDay())
            {
                //MessageBox.Show("Birthdate is later than today's day.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            if (!IsBirthDateInTolerance())
            {
                return false;
            };

            if (!IsEmailFormatValid())
            {
                return false;
            }
            return true;
        }

        private bool AreComponentsNull()
        {
            return Firstname == null || Lastname == null
                || Login == null || Email == null
                || Password == null || DayOfBirth == null 
                || YearOfBirth == null;
        }

        private bool AreComponentsEmpty()
        {
            return String.IsNullOrWhiteSpace(Firstname) || String.IsNullOrWhiteSpace(Lastname)
                || String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Email)
                || String.IsNullOrWhiteSpace(Password) || String.IsNullOrWhiteSpace(DayOfBirth) 
                || String.IsNullOrWhiteSpace(YearOfBirth);
        }

        private bool IsBirthDateInTolerance()
        {
            var lowerBound = DateTime.Today.AddYears(-120);
            var date = new DateTime(Convert.ToInt16(YearOfBirth), MonthOfBirth, Convert.ToInt16(DayOfBirth));
            return lowerBound < date;
        }

        private bool IsDateConvertibleToIntegerAndBiggerThanZero()
        {
            return int.TryParse(DayOfBirth, out _) && int.TryParse(YearOfBirth, out _) 
                && Convert.ToInt16(DayOfBirth) > 0 && Convert.ToInt16(YearOfBirth) > 0;
        }

        private bool IsBirthDateEarlierThanTodaysDay()
        {
            var today = DateTime.Today;
            var date = new DateTime(Convert.ToInt16(YearOfBirth), MonthOfBirth, Convert.ToInt16(DayOfBirth));
            return date <= today;
        }

        private bool IsEmailFormatValid()
        {
            Regex regex = new Regex(@"([a-zA-Z]+[\w+.]*[a-zA-Z]*)@([a-zA-Z]+[\w.]*[a-zA-Z]*)");
            return regex.IsMatch(Email);
        }
    }
}
