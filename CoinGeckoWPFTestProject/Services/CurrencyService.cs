using CoinGeckoWPFTestProject.Models;
using CoinGeckoWPFTestProject.Services.Intefraces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinGeckoWPFTestProject.Services
{
    internal class CurrencyService : ICurrencyService
    {      
        public async Task<List<CryptoCurrencies>> GetData()
        {
            using(HttpClient client = new())
            {
                HttpResponseMessage responseMessage = await client.GetAsync($"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false");
                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                List<CryptoCurrencies> cryptoList = JsonConvert.DeserializeObject<List<CryptoCurrencies>>(jsonResponse);

                return cryptoList;

            }
        }
        public IEnumerable<CryptoCurrencies> GetAllCryptoCurrencies()
        {
            throw new System.NotImplementedException();
        }

    }
}
