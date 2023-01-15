using CoinGeckoWPFTestProject.Infrastructure.Commands;
using CoinGeckoWPFTestProject.Services;
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
    public class ConverterViewModel : BaseViewModel
    {

        private readonly NavigationStore _navigation;

        public ConverterViewModel(NavigationStore navigation)
        {
            _navigation = navigation;
        }
    }
}
