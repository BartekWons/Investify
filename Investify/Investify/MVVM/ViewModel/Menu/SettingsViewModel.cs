using Investify.Core;
using Investify.MVVM.Model;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;

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

        public string CurrentServer { get; set; }
        public string CurrentUser { get; set; }
        public string CurrentDatabase {  get; set; }

        public SettingsViewModel()
        {
            //GetCurrentServerData();
            ChangeServerCommand = new RelayCommand(async o => await ChangeServer());
        }

        private async Task ChangeServer()
        {
            await Database.ChangeServerData(ServerName, UserName, Password, DatabaseName);
            ServerName = CurrentServer;
            UserName = CurrentUser;
            DatabaseName = CurrentDatabase;
        }

        private void GetCurrentServerData()
        {
            var connectionString = Database.ReadServerData();

            if (connectionString == null)
            {
                return;
            }

            Regex pattern = new Regex(@"server=(\w*);users=(\w*);pwd=(\w*);database=(\w*)");

            if (!pattern.IsMatch(connectionString.ToString()))
            {
                MessageBox.Show("In valid connection string in serverConfig", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            var match = pattern.Match(connectionString.ToString());
            CurrentServer = match.Groups[1].Value;
            CurrentServer = match.Groups[2].Value;
            CurrentDatabase = match.Groups[3].Value;
        }
    }
}
