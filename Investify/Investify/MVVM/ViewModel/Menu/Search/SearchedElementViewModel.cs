using Investify.Core;
using Investify.MVVM.Model.API;
using Investify.MVVM.Model.Config;
using Investify.MVVM.Model.Stock.OpenAndClosePrices;
using Investify.MVVM.ViewModel.Stock;
using Investify.Services;
using System.Diagnostics;

namespace Investify.MVVM.ViewModel.Menu.Search
{
    public class SearchedElementViewModel
    {

        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Currency { get; set; }

        public RelayCommand OpenStockSiteCommand { get; set; }

        public SearchedElementViewModel()
        {
            
            OpenStockSiteCommand = new RelayCommand(async o => await OpenStockSite());
        }

        private async Task OpenStockSite()
        {
            DailyTimeSeriesData parsedData = await GetCompanyData();
            
            Singleton.Instance.CurrentView = new StockViewModel()
            {
                //Data = parsedData
                Symbol = this.Symbol,
                Name = this.Name,
                Region = this.Region,
                Currency = this.Currency,
            };
        }

        private async Task<DailyTimeSeriesData> GetCompanyData()
        {
            DailyTimeSeriesData parsedData;
            Config config = ConfigManager.ReadXML();
            try
            {
                parsedData = await APIManager.GetBasicStockData<DailyTimeSeriesData>(Symbol, config.ApiKeys.AlphaVantaageApiKey);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new ();
            }
            return parsedData;
        }
    }
}
