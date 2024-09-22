using Newtonsoft.Json;

namespace Investify.MVVM.Model.Search
{
    public class SearchResponse
    {
        [JsonProperty("bestMatches")]
        public List<BestMatch> BestMatches { get; set; }

        public override string ToString()
        {
            if (BestMatches == null || BestMatches.Count == 0)
                return "No matches found.";
            string result = "Best Matches:\n";
            foreach (var match in BestMatches)
            {
                result += match.ToString() + "\n";
            }
            return result;
        }
    }
}
