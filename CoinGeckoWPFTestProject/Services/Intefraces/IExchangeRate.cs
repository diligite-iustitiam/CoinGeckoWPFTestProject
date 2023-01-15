using CoinGeckoWPFTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.Services.Intefraces
{
    public interface IExchangeRate
    {
        public Task<Root> GetExchangeRate();
        public Task<Btc> GetBitcoin();
    }
}
