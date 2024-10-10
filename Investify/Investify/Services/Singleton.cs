using Investify.Core;
using Investify.MVVM.Model;

namespace Investify.Services
{
    public class Singleton : ObservableObject
    {
		private static Singleton _instance;

		public static Singleton Instance
		{
			get 
			{
				if (_instance == null)
				{
					_instance = new Singleton();
				}
				return _instance; 
			}
			set { _instance = value; }
		}

		private User _loggedUser;

		public User LoggedUser
		{
			get { return _loggedUser; }
			set 
			{ 
				_loggedUser = value; 
				OnPropertyChanged();
			}
		}

		private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set 
			{ 
				_currentView = value;
				OnPropertyChanged();
			}
		}


		private string _currencySymbol;

		public string CurrencySymbol
		{
			get { return _currencySymbol; }
			set 
			{ 
				_currencySymbol = value; 
				OnPropertyChanged();
			}
		}

	}
}
