using Investify.Core;
using Investify.Services;
using System.ComponentModel;

namespace Investify.MVVM.ViewModel.Menu
{
    public class HomeViewModel : ObservableObject
    {
        private string _helloMessage;

        public string HelloMessage
        {
            get { return _helloMessage; }
            set 
            { 
                _helloMessage = value; 
                OnPropertyChanged();
            }
        }


        public HomeViewModel()
        {
            Singleton.Instance.PropertyChanged += OnLoggedUserPropertyChanged;
            HelloMessage = (Singleton.Instance.LoggedUser != null) ? $"{Singleton.Instance.LoggedUser.Firstname}" : String.Empty;
        }

        private void  OnLoggedUserPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Singleton.LoggedUser))
            {
                HelloMessage = (Singleton.Instance.LoggedUser != null)
                    ? $"{Singleton.Instance.LoggedUser.Firstname}" : String.Empty;
            }
        }
    }
}
