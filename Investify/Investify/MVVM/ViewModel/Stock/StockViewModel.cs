using Investify.MVVM.Model.Stock.OpenAndClosePrices;
using System.Windows.Markup;

namespace Investify.MVVM.ViewModel.Stock
{
    public class StockViewModel
    {
		private string _openPrice;

		public string OpenPrice
		{
			get { return _openPrice; }
			set { _openPrice = value; }
		}

		private string _closePrice;

		public string ClosePrice
		{
			get { return _closePrice; }
			set { _closePrice = value; }
		}

		private string _lowestPrice;

		public string LowestPrice
		{
			get { return _lowestPrice; }
			set { _lowestPrice = value; }
		}

		private string _highestPrice;

		public string HighestPrice
		{
			get { return _highestPrice; }
			set { _highestPrice = value; }
		}

		private string _volume;

		public string Volume
		{
			get { return _volume; }
			set { _volume = $"Volume: {value}"; }
		}

        public DailyTimeSeriesData Data { get; set; }
    }
}
