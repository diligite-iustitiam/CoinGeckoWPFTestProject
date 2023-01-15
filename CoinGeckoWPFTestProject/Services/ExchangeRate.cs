using CoinGeckoWPFTestProject.Models;
using CoinGeckoWPFTestProject.Services.Intefraces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.Services
{
    public class ExchangeRate : IExchangeRate
    {
        private const string data_url = @"https://api.coingecko.com/api/v3/exchange_rates";
        public async Task<Root> GetExchangeRate()
        {
            using (HttpClient _client = new())
            {
                HttpResponseMessage response = await _client.GetAsync(data_url);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Root root = JsonConvert.DeserializeObject<Root>(jsonResponse);

                return root;
            }
        }
        public async Task<Btc> GetBitcoin()
        {
            var data = GetExchangeRate();
            Btc btc = new Btc();
            await data.ContinueWith(x =>
            {
                btc.name = x.Result.Rates.Btc.name;
                btc.type = x.Result.Rates.Btc.type;
                btc.unit = x.Result.Rates.Btc.unit;
                btc.value = x.Result.Rates.Btc.value;
            });


            return btc;
        }

    }
}
