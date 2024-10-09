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

        private static async Task<T> GetDataAsync<T>(string queryURL)
        {
            try
            {
                T parsedData;
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(queryURL);
                    response.EnsureSuccessStatusCode();

                    string jsonsData = await response.Content.ReadAsStringAsync();

                    parsedData = JsonConvert.DeserializeObject<T>(jsonsData);
                    Debug.WriteLine(parsedData);
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
