using CoinGeckoWPFTestProject.Stores;
using CoinGeckoWPFTestProject.ViewModels.Base;
using CoinGeckoWPFTestProject.Services.Intefraces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinGeckoWPFTestProject.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using CoinGeckoWPFTestProject.Infrastructure.Commands;
using CoinGeckoWPFTestProject.Services;
using System.Windows;

namespace CoinGeckoWPFTestProject.ViewModels
{
    public class ExchangeRateViewModel : BaseViewModel
    {
        private readonly IExchangeRate _exchangeRate;
        private readonly NavigationStore _navigation;
        public ObservableCollection<Btc> Btcs { get; }
        public ICollectionView ExchangeRateCollectionView { get; }
        public ICommand NavigateToAllCurrencyCommand { get; }
        public ICommand NavigateToConverterCommand { get; }
        private async Task AddRootMember(Task<Btc> btc)
        {
            Btc btc1 = await _exchangeRate.GetBitcoin();
            this.Btcs.Add(btc1);
        }
        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion
        #region GetBitcoin : Task<Btc> 


        private Task<Btc> _btc;


        public Task<Btc> Btc
        {
            get => _btc;
            private set => Set(ref _btc, value);
        }

        #endregion
        public ExchangeRateViewModel(IExchangeRate exchangeRate, NavigationStore navigation)
        {
            
            _exchangeRate = exchangeRate;
            _navigation = navigation;
            Btc = _exchangeRate.GetBitcoin();
            Btcs = new ObservableCollection<Btc>();
            AddRootMember(Btc);
            ExchangeRateCollectionView = CollectionViewSource.GetDefaultView(Btcs);
            #region Commands
            NavigateToAllCurrencyCommand = new NavigateCommand<CurrencyViewModel>(new NavigationService<CurrencyViewModel>(navigation, () => new CurrencyViewModel(new CurrencyService(), navigation)));
            NavigateToConverterCommand = new NavigateCommand<ConverterViewModel>(new NavigationService<ConverterViewModel>(navigation, () => new ConverterViewModel(navigation)));
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            #endregion
        }
    }
}
