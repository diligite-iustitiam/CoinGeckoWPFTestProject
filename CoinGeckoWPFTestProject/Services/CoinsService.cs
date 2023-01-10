using CoinGeckoWPFTestProject.Models;
using CoinGeckoWPFTestProject.Services.Intefraces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.Services
{
    internal class CoinsService : ICoinsService
    {
        private const string data_url = @"https://api.coingecko.com/api/v3/coins/list";

        public async Task<List<Coin>> GetData()
        {
            using (HttpClient _client = new())
            {
                HttpResponseMessage response = await _client.GetAsync(data_url);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<Coin> coinList = JsonConvert.DeserializeObject<List<Coin>>(jsonResponse);
                return coinList;
                
            }
        }
       
        public IEnumerable<Coin> GetAllCoins()
        {
            var data = (SynchronizationContext.Current is null ? GetData() : Task.Run(GetData)).Result;
            foreach (var coin_info in data)
            {
                var coin = new Coin
                {
                    id = coin_info.id,
                    symbol = coin_info.symbol,
                    name = coin_info.name
                };
                yield return coin;
            }
        }



        
    }
}
