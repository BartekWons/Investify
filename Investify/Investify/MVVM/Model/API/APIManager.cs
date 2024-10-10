using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace Investify.MVVM.Model.API
{
    public static class APIManager
    {
        public static async Task<T> SearchAsync<T>(string searchString, string apiKey)
        {
            string queryURL = $"https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords={searchString}&apikey={apiKey}";
            return await GetDataAsync<T>(queryURL);
        }

        public static async Task<T> GetBasicStockData<T>(string companySymbol, string apiKey)
        {
            string queryURL = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={companySymbol}&outputsize=compact&apikey={apiKey}";
            return await GetDataAsync<T>(queryURL);
        }

        public static async Task<T> GetSupportedCurrencies<T>(string apiKey) where T : new()
        {
            string queryURL = $"https://v6.exchangerate-api.com/v6/{apiKey}/codes";
            if (await GetDataAsync<T>(queryURL) is T tmp) 
                return tmp;
            else 
                return new T();

        }

        private static async Task<T> GetDataAsync<T>(string queryURL)
        {
            try
            {
                T parsedData;
                using (HttpClient client = new())
                {
                    HttpResponseMessage response = await client.GetAsync(queryURL);
                    response.EnsureSuccessStatusCode();

                    string jsonsData = await response.Content.ReadAsStringAsync();

                    parsedData = JsonConvert.DeserializeObject<T>(jsonsData);
                }
                return parsedData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
