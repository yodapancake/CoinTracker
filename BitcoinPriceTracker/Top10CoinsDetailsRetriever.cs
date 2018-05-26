using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinPriceTracker.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace BitcoinPriceTracker
{
    class Top10CoinsDetailsRetriever
    {
        public async Task<Top10RootObject> GetTop10Details()
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"https://api.coinmarketcap.com/v2/ticker/?limit=25";
            string responseString = await httpClient.GetStringAsync(apiUrl);
            Top10RootObject details = JsonConvert.DeserializeObject<Top10RootObject>(responseString);
            return details;
        }
    }
}
