using Investify.Core;
using Investify.MVVM.Model.Config;
using System.Diagnostics;
using System.Windows;

namespace Investify.MVVM.ViewModel.Menu
{
    public class SettingsViewModel : ObservableObject
    {
        public RelayCommand ChangeServerCommand { get; set; }
        public RelayCommand ChangeApiKeyCommand {  get; set; }

        public RelayCommand GetApiKeyCommand { get; set; }

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


        private string _apiKey;

        public string ApiKey
        {
            get { return _apiKey; }
            set 
            { 
                _apiKey = value; 
                OnPropertyChanged();
            }
        }


        public SettingsViewModel()
        {
            ChangeServerCommand = new RelayCommand(o => ChangeServer());

            ChangeApiKeyCommand = new RelayCommand(o => ChangeApiKey());

            GetApiKeyCommand = new RelayCommand(o => OpenUrl(o));
        }

        private void OpenUrl(object o)
        {
            string? url = o as string;
            if (!String.IsNullOrEmpty(url))
            {
                OpenUrlInBrowser(url);
            }
        }

        private void OpenUrlInBrowser(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url)
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void ChangeServer()
        {
            Config previousConfig = ConfigManager.ReadXML();
            var newConfig = new Config()
            {
                ServerConfig = new ServerConfig()
                {
                    ServerName = this.ServerName,
                    UserName = this.UserName,
                    Password = this.Password,
                    DatabaseName = this.DatabaseName
                },
                ApiKeys = new ApiKeys()
                {
                    AlphaVantaageApiKey = previousConfig.ApiKeys.AlphaVantaageApiKey
                }
            };
            ConfigManager.SaveXML(newConfig);
            MessageBox.Show("Server has changed.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ChangeApiKey()
        {
            var config = ConfigManager.ReadXML();
            config.ApiKeys.AlphaVantaageApiKey = this.ApiKey;
            ConfigManager.SaveXML(config);
        }
    }
}
