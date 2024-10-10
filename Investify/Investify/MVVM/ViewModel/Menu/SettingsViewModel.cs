using Investify.Core;
using Investify.MVVM.Model.API;
using Investify.MVVM.Model.Config;
using Investify.MVVM.Model.Currency;
using Investify.MVVM.Model.Json;
using Investify.Services;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;

namespace Investify.MVVM.ViewModel.Menu
{
    public class SettingsViewModel : ObservableObject
    {
        public RelayCommand ChangeCurrencyCommand {  get; set; }
        public RelayCommand ChangeServerCommand { get; set; }
        public RelayCommand ChangeAlphaVantageApiKeyCommand {  get; set; }
        public RelayCommand ChangeExchangeRateApiKeyCommand {  get; set; }

        public RelayCommand GetApiKeyCommand { get; set; }

        private SupportedCurrencies _currencies;

        private string[] _currenciesList;

        public string[] CurrenciesList
        {
            get { return _currenciesList; }
            set 
            { 
                _currenciesList = value;
                OnPropertyChanged();
            }
        }


        private string _selectedCurrency;

        public string SelectedCurrency
        {
            get { return _selectedCurrency; }
            set 
            { 
                _selectedCurrency = value;
                OnPropertyChanged();
            }
        }

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


        private string _alphaVantageApiKey;

        public string AlphaVantageApiKey
        {
            get { return _alphaVantageApiKey; }
            set 
            { 
                _alphaVantageApiKey = value; 
                OnPropertyChanged();
            }
        }

        private string _exchangeRateApiKey;

        public string ExchangeRateApiKey
        {
            get { return _exchangeRateApiKey; }
            set 
            { 
                _exchangeRateApiKey = value;
                OnPropertyChanged();
            }
        }



        public SettingsViewModel()
        {
            InitializeCurrenciesComboBox();

            ChangeCurrencyCommand = new RelayCommand(o => ChangeCurrency());

            ChangeServerCommand = new RelayCommand(o => ChangeServer());

            ChangeAlphaVantageApiKeyCommand = new RelayCommand(o => ChangeAlphaVantageApiKey());

            ChangeExchangeRateApiKeyCommand = new RelayCommand(o => ChangeExchangeRateApiKey());

            GetApiKeyCommand = new RelayCommand(o => OpenUrl(o));
        }

        private void ChangeCurrency()
        {
            if (CurrenciesList == null || !CurrenciesList.Any(curriency => curriency.Equals(SelectedCurrency)))
            {
                MessageBox.Show("This currency does not exits.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Regex pattern = new(@"(\w*)");
            Singleton.Instance.CurrencySymbol = pattern.Match(SelectedCurrency).Value;
            MessageBox.Show("Currency has been changed.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public async void InitializeCurrenciesComboBox()
        {
            Config config = ConfigManager.ReadXML();
            _currencies = await Json.ReadFromFile<SupportedCurrencies>();
            if (_currencies.SupportedCode == null)
                return;
            CurrenciesList = _currencies.SupportedCode
                                        .Select(code => $"{code[0]} - {code[1]}")
                                        .ToArray();
            var symbol = Singleton.Instance.CurrencySymbol;
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
                    AlphaVantaageApiKey = previousConfig.ApiKeys.AlphaVantaageApiKey,
                    ExchangeRateApiKey = previousConfig.ApiKeys.ExchangeRateApiKey
                }
            };
            ChangeConfig(newConfig, "Server has been changed.");
        }

        private void ChangeAlphaVantageApiKey()
        {
            var config = ConfigManager.ReadXML();
            config.ApiKeys.AlphaVantaageApiKey = this.AlphaVantageApiKey;
            ChangeConfig(config, "Api Key has been changed.");
        }

        private void ChangeExchangeRateApiKey()
        {
            var config = ConfigManager.ReadXML();
            config.ApiKeys.ExchangeRateApiKey = this.ExchangeRateApiKey;
            ChangeConfig(config, "Api Key has been changed.");
        }

        private void ChangeConfig(Config config, string message)
        {
            ConfigManager.SaveXML(config);
            MessageBox.Show(message, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
