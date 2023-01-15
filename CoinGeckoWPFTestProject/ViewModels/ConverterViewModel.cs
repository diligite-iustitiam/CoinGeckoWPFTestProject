using CoinGeckoWPFTestProject.Infrastructure.Commands;
using CoinGeckoWPFTestProject.Services;
using CoinGeckoWPFTestProject.Stores;
using CoinGeckoWPFTestProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace CoinGeckoWPFTestProject.ViewModels
{
    public class ConverterViewModel : BaseViewModel
    {

        private readonly NavigationStore _navigation;
        public ICommand NavigateToExchangeRateCommand { get; }
        public ICommand NavigateToAllCurrencyCommand { get; }

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion
        public ConverterViewModel(NavigationStore navigation)
        {
            _navigation = navigation;
            NavigateToExchangeRateCommand = new NavigateCommand<ExchangeRateViewModel>(navigation, () => new ExchangeRateViewModel(new ExchangeRate(), navigation));
            NavigateToAllCurrencyCommand = new NavigateCommand<CurrencyViewModel>(new NavigationStore(),()=> new CurrencyViewModel(new CurrencyService(),navigation));

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        }
    }
}
