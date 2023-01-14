using CoinGeckoWPFTestProject.Models;
using CoinGeckoWPFTestProject.Services.Intefraces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.Services
{
    internal class CurrencyService : ICurrencyService
    {
        public string? Currency { get; set; }
        private async Task<IEnumerable<CryptoCurrency>> GetData()
        {
            using (HttpClient _client = new())
            {
                HttpResponseMessage response = await _client.GetAsync($"https://api.coingecko.com/api/v3/coins/markets?vs_currency={Currency}&order=market_cap_desc&per_page=100&page=1&sparkline=false");
                string jsonResponse = await response.Content.ReadAsStringAsync();
                IEnumerable<CryptoCurrency> coinList = JsonConvert.DeserializeObject<IEnumerable<CryptoCurrency>>(jsonResponse);

                return coinList;
            }
        }

        public async IAsyncEnumerable<CryptoCurrency> GetAllCryptoCurrencies()
        {
            var data = await GetData();
            foreach (var currency_info in data)
            {
                var currency = new CryptoCurrency
                {
                    id = currency_info.id,
                    symbol = currency_info.symbol,
                    price_change_24h = currency_info.price_change_24h,
                    current_price = currency_info.current_price,
                    market_cap = currency_info.market_cap,
                    market_cap_rank = currency_info.market_cap_rank,
                    name = currency_info.name,
                    total_volume = currency_info.total_volume,
                    last_updated = currency_info.last_updated,
                };
                yield return currency;
            }
        }

        
    }
    }



