using Newtonsoft.Json;

namespace Investify.MVVM.Model.Currency
{
    public class Currency
    {
        [JsonProperty("base_code")]
        public string? Name { get; set; }
        [JsonProperty("time_last_update_utc")]
        public DateTime TimeLastUpdate { get; set; }
        [JsonProperty("time_next_update_utc")]
        public DateTime TimeNextUpdate { get; set; }
        [JsonProperty("conversion_rates")]
        public List<ConversionRate>? ConversionRates { get; set; }

    }
}
