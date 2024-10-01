using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace Investify.MVVM.Model.API
{
    public static class APIManager
    {
        public static async Task<T> Search<T>(string SearchString, string apiKey)
        {
            string queryURL = $"https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords={SearchString}&apikey={apiKey}";
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
    }
}
