using CoinGeckoWPFTestProject.Infrastructure.Commands;
using CoinGeckoWPFTestProject.Models;
using CoinGeckoWPFTestProject.Services.Intefraces;
using CoinGeckoWPFTestProject.Stores;
using CoinGeckoWPFTestProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoinGeckoWPFTestProject.ViewModels
{
    internal class CoinsViewModel : BaseViewModel
    {
        private readonly ICoinsService _coinsService;
        public string Welcome => "Welcome";
        public ICommand NavigateToConverterCommand { get; }
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

        public CoinsViewModel(ICoinsService coinsService, NavigationStore navigation)
        {

            _coinsService = coinsService;
            Coins = _coinsService.GetAllCoins();

            NavigateToConverterCommand = new NavigateCommand<ConverterViewModel>(navigation, () => new ConverterViewModel());


        }
    }
}
