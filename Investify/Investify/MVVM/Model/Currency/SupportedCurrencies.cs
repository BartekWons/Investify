using Newtonsoft.Json;

namespace Investify.MVVM.Model.Currency
{
    public class SupportedCurrencies
    {
        [JsonProperty("supported_codes")]
        public List<List<string>>? SupportedCode { get; set; }
    }
}
