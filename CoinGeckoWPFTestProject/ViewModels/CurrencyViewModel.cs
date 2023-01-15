using CoinGeckoWPFTestProject.Infrastructure.Commands;
using CoinGeckoWPFTestProject.Models;
using CoinGeckoWPFTestProject.Services;
using CoinGeckoWPFTestProject.Services.Intefraces;
using CoinGeckoWPFTestProject.Stores;
using CoinGeckoWPFTestProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace CoinGeckoWPFTestProject.ViewModels
{
    internal class CurrencyViewModel : BaseViewModel
    {
        private readonly ICurrencyService _currencyService;
        public MainWindowViewModel MainModel { get; internal set; }
        private readonly CollectionViewSource _SelectedCrypto = new CollectionViewSource();
        public ICollectionView CryptoCollectionView { get; }
        public ICommand NavigateToConverterCommand { get; }
        public ICommand NavigateToExchangeRateCommand { get; }


        #region ObservableCollection<CryptoCurrency> ItemsSourceForDataGrid
        public ObservableCollection<CryptoCurrency> ItemsSourceForDataGrid { get; }
        
      
        private async Task GenerateDataItemsAsync(IAsyncEnumerable<CryptoCurrency> asyncDataStream)
        {
            // Keep the GUI responsive while consuming an e.g. CPU intensive generator
            await foreach (CryptoCurrency item in asyncDataStream)
            {
                this.ItemsSourceForDataGrid.Add(item);
            }
        }
        #endregion

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion
        #region CryptoCurrencies : IEnumerable<CryptoCurrencies> 


        private IAsyncEnumerable<CryptoCurrency> _cryptoCurrencies;


        public IAsyncEnumerable<CryptoCurrency> CryptoCurrencies
        {
            get => _cryptoCurrencies;
            private set => Set(ref _cryptoCurrencies, value);
        }

        #endregion

        #region CryptoFilterText : string 


        private string _CryptoFilterText = string.Empty;


        public string CryptoFilterText
        {
            get => _CryptoFilterText;
            set
            {
                _CryptoFilterText = value;
                OnPropertyChanged(nameof(CryptoFilterText));
                CryptoCollectionView.Refresh();
            }
        }

        #endregion


        public CurrencyViewModel(ICurrencyService currencyService, NavigationStore navigation)
        {
            
            _currencyService = currencyService;
            _currencyService.Currency = "usd";
            CryptoCurrencies = _currencyService.GetAllCryptoCurrencies();
            
            ItemsSourceForDataGrid = new ObservableCollection<CryptoCurrency>();

            GenerateDataItemsAsync(CryptoCurrencies);
            CryptoCollectionView = CollectionViewSource.GetDefaultView(ItemsSourceForDataGrid);
            CryptoCollectionView.Filter = FilterCrypto;
            CryptoCollectionView.SortDescriptions.Add(new SortDescription(nameof(CryptoCurrency.market_cap_rank), ListSortDirection.Ascending));
            NavigateToConverterCommand = new NavigateCommand<ConverterViewModel>(navigation, () => new ConverterViewModel(navigation));
            NavigateToExchangeRateCommand = new NavigateCommand<ExchangeRateViewModel>(navigation, () => new ExchangeRateViewModel(new ExchangeRate(),navigation));
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

        }
        private bool FilterCrypto(object obj)
        {
            if (obj is CryptoCurrency crypto)
            {
                return crypto.name.Contains(CryptoFilterText, StringComparison.InvariantCultureIgnoreCase) ||
                   crypto.symbol.Contains(CryptoFilterText, StringComparison.InvariantCultureIgnoreCase) ||
                   crypto.id.Contains(CryptoFilterText, StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }
    }
}

