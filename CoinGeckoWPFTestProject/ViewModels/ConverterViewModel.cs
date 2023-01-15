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
            NavigateToAllCurrencyCommand = new NavigateCommand<CurrencyViewModel>(new NavigationService<CurrencyViewModel>(navigation, () => new CurrencyViewModel(new CurrencyService(), navigation)));
            NavigateToExchangeRateCommand = new NavigateCommand<ExchangeRateViewModel>(new NavigationService<ExchangeRateViewModel>(navigation, () => new ExchangeRateViewModel(new ExchangeRateService(), navigation)));
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        }
    }
}
