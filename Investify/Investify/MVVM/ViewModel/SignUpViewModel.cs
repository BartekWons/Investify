using Investify.Core;
using System.Diagnostics;

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

            SignUpCommand = new RelayCommand(o => SignUp());
        }

        private void SignUp()
        {
            Debug.Write("dawdwa");
        }
    }
}
