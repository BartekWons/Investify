using Newtonsoft.Json;
using System;

namespace Investify.MVVM.Model.Search
{
    public class BestMatch
    {
        [JsonProperty("1. symbol")]
        public string Symbol { get; set; }

        [JsonProperty("2. name")]
        public string Name { get; set; }

        [JsonProperty("3. type")]
        public string Type { get; set; }

        [JsonProperty("4. region")]
        public string Region { get; set; }

        [JsonProperty("5. marketOpen")]
        public string MarketOpen { get; set; }

        [JsonProperty("6. marketClose")]
        public string MarketClose { get; set; }

        [JsonProperty("7. timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("8. currency")]
        public string Currency {  get; set; }

        [JsonProperty("9. matchScore")]
        public string MatchScore { get; set; }

        public override string ToString()
        {
            return $"Symbol: {Symbol},\n" +
                $"Name: {Name},\n" +
                $"Type: {Type},\n" +
                $"Region: {Region},\n" +
                $"Market Open: {MarketOpen},\n" +
                $"Market Close: {MarketClose},\n" +
                $"Timezone: {TimeZone},\n" +
                $"Currency: {Currency},\n" +
                $"Match Score: {MatchScore}\n";
        }
    }
}
