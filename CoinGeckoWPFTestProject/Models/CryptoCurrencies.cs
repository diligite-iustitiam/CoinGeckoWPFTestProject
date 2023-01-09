using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.Models
{
    internal class CryptoCurrencies
    {
        public string? CurrencyID { get; set; }

        public string? CurrencyName { get; set; }

        public decimal CurrentPrice { get; set; }

        public double PriceChange { get; set; }

        public decimal TotalVolume { get; set; }

        public double MarketCap { get; set; }

        public int MarketCapRank { get; set; }

        public DateTime? LastUpdate { get; set; }

    }
}
