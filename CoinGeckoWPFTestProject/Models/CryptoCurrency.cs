using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.Models
{
    public class CryptoCurrency
    {
        public string? id { get; set; }
        public string? symbol { get; set; }

        public string? name { get; set; }

        public decimal current_price { get; set; }

        public double price_change_24h { get; set; }

        public double total_volume { get; set; }

        public double market_cap { get; set; }

        public int market_cap_rank { get; set; }

        public DateTime? last_updated { get; set; }

    }
}
