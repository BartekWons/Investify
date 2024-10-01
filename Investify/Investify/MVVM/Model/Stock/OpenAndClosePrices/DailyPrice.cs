using Newtonsoft.Json;

namespace Investify.MVVM.Model.Stock.OpenAndClosePrices
{
    public class DailyPrice
    {
        [JsonProperty("1. open")]
        public double? OpenPrice { get; set; }
        [JsonProperty("2. high")]
        public double? HighestPrice { get; set; }
        [JsonProperty("3. low")]
        public double? LowestPrice { get; set; }
        [JsonProperty("4. close")]
        public double? ClosePrice { get; set; }
        [JsonProperty("5. volume")]
        public int? Volume { get; set; }
    }
}
