namespace Investify.MVVM.Model.Config
{
    public class ApiKeys
    {
		private string _alphaVantageApiKey;

		public string AlphaVantaageApiKey
        {
			get { return _alphaVantageApiKey; }
			set
			{
				_alphaVantageApiKey = String.IsNullOrEmpty(value) 
					|| String.IsNullOrWhiteSpace(value) ? "demo" : value;
			}
		}
    }
}
