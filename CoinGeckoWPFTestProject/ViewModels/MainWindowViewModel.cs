using CoinGeckoWPFTestProject.Infrastructure.Commands;
using CoinGeckoWPFTestProject.Models;
using CoinGeckoWPFTestProject.Services.Intefraces;
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
    internal class MainWindowViewModel : BaseViewModel
    {
        public CoinsViewModel CoinsViewModel { get; }
       
        #region ChangeTabIndexCommand

        private int _SelectedPageIndex = 1;

        public int SelectedPageIndex { get => _SelectedPageIndex; set => Set(ref _SelectedPageIndex, value); }



        public ICommand ChangeTabIndexCommand { get; }

        private bool CanChangeTabIndexCommandExecute(object p) => _SelectedPageIndex >= 0;

        private void OnChangeTabIndexCommandExecuted(object p)
        {
            if (p is null) return;
            SelectedPageIndex += Convert.ToInt32(p);
        }
        #endregion
        #region Title
        private string _Title = "CoinGeckoWPFTestProject";
        /// <summary>Window title</summary>
        public string Title
        {
            get { return _Title; }
            set => Set(ref _Title, value);
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

        //#region Coins : IEnumerable<Coins> 


        //private IEnumerable<Coin> _Coins;


        //public IEnumerable<Coin> Coins
        //{
        //    get => _Coins;
        //    private set => Set(ref _Coins, value);
        //}

        //#endregion
        //#region SelectedCoin 


        //private Coin _SelectedCoin;


        //public Coin SelectedCoin { get => _SelectedCoin; set => Set(ref _SelectedCoin, value); }

        //#endregion


       
        public MainWindowViewModel(CoinsViewModel coinsViewModel)
        {

            CoinsViewModel = coinsViewModel;
            coinsViewModel.MainModel = this;

            //Coins = _coinsService.GetAllCoins();
            #region Commands           
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecuted, CanChangeTabIndexCommandExecute);
           
            //RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);
            #endregion
        }

    }
}
