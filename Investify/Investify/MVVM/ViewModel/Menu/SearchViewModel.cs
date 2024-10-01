using Investify.Core;
using Investify.MVVM.Model.API;
using Investify.MVVM.Model.Search;
using Investify.MVVM.ViewModel.Menu.Search;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Investify.MVVM.ViewModel.Menu
{
    public class SearchViewModel : ObservableObject
    {
        public RelayCommand EnterCommand { get; set; }

        private string _searchString;

        public string SearchString
        {
            get { return _searchString; }
            set 
            { 
                _searchString = value; 
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SearchedElementViewModel> _searchedElements;

        public ObservableCollection<SearchedElementViewModel> SearchedElements
        {
            get { return _searchedElements; }
            set 
            { 
                _searchedElements = value; 
                OnPropertyChanged();
            }
        }

        public SearchViewModel()
        {
            SearchedElements = new ObservableCollection<SearchedElementViewModel>();

            EnterCommand = new RelayCommand(async o => await GetStocks());
        }

        private async Task GetStocks()
        {
            SearchedElements.Clear();
            SearchResponse parsedData;
            try
            {
                parsedData = await APIManager.Search<SearchResponse>(SearchString, "demo");
                if (parsedData == null || parsedData.BestMatches == null) 
                    return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }
            ShowSearchedElements(parsedData);
        }
        private void ShowSearchedElements(SearchResponse parsedData)
        {
            for (int i = 0; i < parsedData.BestMatches.Count; i++)
            {
                SearchedElements.Add(new SearchedElementViewModel
                {
                    Symbol = parsedData.BestMatches[i].Symbol,
                    Name = parsedData.BestMatches[i].Name,
                    Region = parsedData.BestMatches[i].Region,
                    Currency = parsedData.BestMatches[i].Currency
                });
            }
        }
    }
}
