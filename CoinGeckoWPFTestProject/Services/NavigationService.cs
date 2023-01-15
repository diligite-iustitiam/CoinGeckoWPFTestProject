using CoinGeckoWPFTestProject.Stores;
using CoinGeckoWPFTestProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.Services
{
    public class NavigationService<TViewModel> where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _viewModel;
     
        public NavigationService(NavigationStore navigationStore, Func<TViewModel> viewModel)
        {
            _navigationStore = navigationStore;
            _viewModel = viewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _viewModel();
        }
    }
}
