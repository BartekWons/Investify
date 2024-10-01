﻿using Investify.Core;
using Investify.MVVM.Model;
using System.Diagnostics;
using System.Text.RegularExpressions;
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
            ChangeServerCommand = new RelayCommand(async o => await ChangeServer());

            //ChangeApiKeyCommand = new RelayCommand(async o =>
            //{
            //    Config config = new Config()
            //    {
            //        ApiKey = this.ApiKey
            //    };
            //    //await config.SaveApiKeyAsync();
            //});

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

        private async Task ChangeServer()
        {
            Config config = new Config();
            config.Server = new Server()
            {
                ServerName = this.ServerName,
                UserName = this.UserName,
                Password = this.Password,
                DatabaseName = this.DatabaseName
            };

            await config.SaveServerDataAsync();

            MessageBox.Show("Server has changed.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void GetCurrentServerData()
        {
            Config config = new Config();
            var connectionString = config.ReadServerDataAsync();

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
