namespace Investify.MVVM.Model.Stock
{
    public class StockOperations
    {
        public static double CountPercentageChange(double previousClose, double currentPrice)
        {
            double result = ((currentPrice - previousClose) / previousClose) * 100;
            return Math.Round(result, 2);
        }
    }
}
