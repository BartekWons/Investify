namespace Investify.MVVM.Model.API
{
    public class ApiKeys
    {
        private string _alphaVantageApiKey;

        public string AlphaVantaageApiKey
        {
            get { return _alphaVantageApiKey; }
            set
            {
                _alphaVantageApiKey = string.IsNullOrEmpty(value)
                    || string.IsNullOrWhiteSpace(value) ? "demo" : value;
            }
        }

        private string _exchangeRateApiKey;

        public string ExchangeRateApiKey
        {
            get { return _exchangeRateApiKey; }
            set 
            {
                _exchangeRateApiKey = string.IsNullOrEmpty(value)
                    || string.IsNullOrWhiteSpace(value) ? "demo" : value;
            }
        }

    }
}
