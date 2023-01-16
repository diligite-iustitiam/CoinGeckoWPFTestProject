using CoinGeckoWPFTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.Services.Intefraces
{
    public interface IExchangeRateService
    {       
        Task<Btc> GetBitcoin();
    }
}
