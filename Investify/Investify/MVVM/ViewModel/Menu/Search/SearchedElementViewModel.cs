namespace Investify.MVVM.ViewModel.Menu.Search
{
    public class SearchedElementViewModel
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Currency { get; set; }

        public SearchedElementViewModel()
        {
            Symbol = "X";
            Name = "XX";
            Region = "XXX";
            Currency = "XXXX";
        }
    }
}
