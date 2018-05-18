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
    class PriceRetriever
    {
        public async Task<BitcoinDetails.BitcoinDetailsRootObject> GetPrice()
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"https://api.coinbase.com/v2/prices/BTC-USD/buy";
            string responseString = await httpClient.GetStringAsync(apiUrl);
            BitcoinDetails.BitcoinDetailsRootObject price = JsonConvert.DeserializeObject<BitcoinDetails.BitcoinDetailsRootObject>(responseString);
            return price;
        }
    }
}
