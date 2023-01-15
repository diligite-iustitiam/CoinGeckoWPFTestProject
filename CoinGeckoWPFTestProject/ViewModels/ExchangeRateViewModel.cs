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

namespace CoinGeckoWPFTestProject.ViewModels
{
    public class ExchangeRateViewModel : BaseViewModel
    {
        private readonly IExchangeRate _exchangeRate;
        private readonly NavigationStore _navigation;
        public ObservableCollection<Btc> Btcs { get; }
        public ICollectionView ExchangeRateCollectionView { get; }
        
        private async Task AddRootMember(Task<Btc> btc)
        {
            Btc btc1 = await _exchangeRate.GetBitcoin();
            this.Btcs.Add(btc1);
        }

        #region GetBitcoin : Task<Btc> 


        private Task<Btc> _root;


        public Task<Btc> Root
        {
            get => _root;
            private set => Set(ref _root, value);
        }

        #endregion
        public ExchangeRateViewModel(IExchangeRate exchangeRate, NavigationStore navigation)
        {
            
            _exchangeRate = exchangeRate;
            _navigation = navigation;
            Root = _exchangeRate.GetBitcoin();
            Btcs = new ObservableCollection<Btc>();
            AddRootMember(Root);
            ExchangeRateCollectionView = CollectionViewSource.GetDefaultView(Btcs);
        }
    }
}
