﻿using Investify.Core;
using Investify.MVVM.Model;
using System.Diagnostics;

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

            ExecuteLogInCommand = new RelayCommand(async o => await LogIn());
        }

        private async Task LogIn()
        {
            var data = await Database.GetUsers();

            foreach (var user in data)
            {
                Debug.WriteLine(user);
            }
        }
    }
}
