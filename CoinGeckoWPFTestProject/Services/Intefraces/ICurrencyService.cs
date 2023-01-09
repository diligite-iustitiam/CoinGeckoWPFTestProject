using CoinGeckoWPFTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.Services.Intefraces
{
    internal interface ICurrencyService
    {
        public Task<CryptoCurrencies> GetCryptoCurrencyID();
    }
}
