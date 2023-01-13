using CoinGeckoWPFTestProject.Infrastructure.Commands.Base;
using CoinGeckoWPFTestProject.Stores;
using CoinGeckoWPFTestProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.Infrastructure.Commands
{
    public class NavigateCommand<TViewModel> : Command
        where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigation;
        private readonly Func<TViewModel> _viewModel;    

        public NavigateCommand(NavigationStore navigation,Func<TViewModel> viewModel)
        {
            _navigation = navigation;
            _viewModel = viewModel;
        }

        public override bool CanExecute(object? parameter) => true;
       

        public override void Execute(object? parameter)
        {
            _navigation.CurrentViewModel = _viewModel();
        }
    }
}
