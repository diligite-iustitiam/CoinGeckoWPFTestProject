using CoinGeckoWPFTestProject.Models;
using CoinGeckoWPFTestProject.Services.Intefraces;
using CoinGeckoWPFTestProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.ViewModels
{
    internal class CoinsViewModel : BaseViewModel
    {
        private readonly ICoinsService _coinsService;
        public MainWindowViewModel MainModel { get; internal set; }
        #region Coins : IEnumerable<Coins> 


        private IEnumerable<Coin> _Coins;


        public IEnumerable<Coin> Coins
        {
            get => _Coins;
            private set => Set(ref _Coins, value);
        }

        #endregion
        #region SelectedCoin 


        private Coin _SelectedCoin;


        public Coin SelectedCoin { get => _SelectedCoin; set => Set(ref _SelectedCoin, value); }

        #endregion

        public CoinsViewModel(ICoinsService coinsService)
        {
            _coinsService = coinsService;
            Coins = _coinsService.GetAllCoins();
        }
    }
}
