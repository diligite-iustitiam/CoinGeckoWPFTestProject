using CoinGeckoWPFTestProject.Infrastructure.Commands.Base;
using CoinGeckoWPFTestProject.Services;
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
        private readonly NavigationService<TViewModel> _navigationService;

        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
           _navigationService = navigationService;
        }

        public override bool CanExecute(object? parameter) => true;
       

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
