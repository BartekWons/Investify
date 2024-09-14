using Investify.Core;
using System.Diagnostics;

namespace Investify.MVVM.ViewModel.Menu
{
    public class SettingsViewModel : ObservableObject
    {
        public RelayCommand ChangeServerCommand { get; set; }

        private string _serverName;

        public string ServerName
        {
            get { return _serverName; }
            set 
            { 
                _serverName = value; 
                OnPropertyChanged();
            }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set 
            { 
                _userName = value; 
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

        private string _databaseName;

        public string DatabaseName
        {
            get { return _databaseName; }
            set 
            { 
                _databaseName = value; 
                OnPropertyChanged();
            }
        }

        public SettingsViewModel()
        {
            ChangeServerCommand = new RelayCommand(o =>
            {
                Debug.WriteLine(ServerName);
                Debug.WriteLine(UserName);
                Debug.WriteLine(Password);
                Debug.WriteLine(DatabaseName);
            });
        }

    }
}
