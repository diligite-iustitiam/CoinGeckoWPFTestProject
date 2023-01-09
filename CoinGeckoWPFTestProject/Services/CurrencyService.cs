using CoinGeckoWPFTestProject.Models;
using CoinGeckoWPFTestProject.Services.Intefraces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.Services
{
    internal class CurrencyService : ICurrencyService
    {
        public Task<CryptoCurrencies> GetCryptoCurrencyID()
        {
            throw new NotImplementedException();
        }
    }
}
