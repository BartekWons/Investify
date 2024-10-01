using Newtonsoft.Json;

namespace Investify.MVVM.Model.Stock.OpenAndClosePrices
{
    public class DailyTimeSeriesData
    {
        [JsonProperty("Time Series (Daily)")]
        public Dictionary<string, DailyPrice> PriceList { get; set; }
    }
}
