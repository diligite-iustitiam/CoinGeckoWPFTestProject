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
using System.Windows;
using System.Windows.Input;

namespace CoinGeckoWPFTestProject.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigation;
        public CurrencyViewModel _currencyViewModel { get; }
       public BaseViewModel CurrentViewModel => _navigation.CurrentViewModel;
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

        


       
        public MainWindowViewModel(NavigationStore navigation, CurrencyViewModel currencyViewModel)
        {

            _currencyViewModel = currencyViewModel;
            currencyViewModel.MainModel = this;
            _navigation = navigation;
            _navigation.CurrentViewModel = currencyViewModel;
            _navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;


            
            #region Commands           
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecuted, CanChangeTabIndexCommandExecute);
           
            //RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);
            #endregion
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
