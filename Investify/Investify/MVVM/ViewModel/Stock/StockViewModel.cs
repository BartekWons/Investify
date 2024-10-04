using Investify.MVVM.Model.Stock.OpenAndClosePrices;

namespace Investify.MVVM.ViewModel.Stock
{
    public class StockViewModel
    {
        public string Symbol { get; set; }
		public string Name { get; set; }
		public string Region { get; set; }
		public string Currency { get; set; }

        public double OpenPrice { get; set; }
		public double ClosePrice { get; set; }
		public double LowestPrice { get; set; }
		public double HighestPrice { get; set; }
		public int Volume { get; set; }

		private DailyTimeSeriesData _data;

		public DailyTimeSeriesData Data
		{
			get { return _data; }
			set 
			{ 
				_data = value;
				if (_data != null && Data.PriceList != null)
				{
					InitializeData();
				}
			}
		}

		public StockViewModel()
        {
			OpenPrice = 125.6;
			ClosePrice = 456.58;
			HighestPrice = 785.48;
			LowestPrice = 50.11;
			Volume = 123456;
        }

		private void InitializeData()
		{
            var stock = Data.PriceList.FirstOrDefault();
            OpenPrice = stock.Value.OpenPrice.HasValue ? (double) stock.Value.OpenPrice : 0;
            ClosePrice = stock.Value.ClosePrice.HasValue ? (double) stock.Value.ClosePrice : 0;
            HighestPrice = stock.Value.HighestPrice.HasValue ? (double)stock.Value.HighestPrice : 0;
            LowestPrice = stock.Value.LowestPrice.HasValue ? (double)stock.Value.LowestPrice : 0;
            Volume = stock.Value.Volume.HasValue ? (int) stock.Value.Volume : 0;
        }
    }
}
