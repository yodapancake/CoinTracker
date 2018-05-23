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
    class GlobalDetailsRetriever
    {
        public async Task<GlobalData.GlobalDataRootObject> GetGlobalDataDetails()
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"https://api.coinmarketcap.com/v2/global/";
            string responseString = await httpClient.GetStringAsync(apiUrl);
            GlobalData.GlobalDataRootObject details = JsonConvert.DeserializeObject<GlobalData.GlobalDataRootObject>(responseString);
            return details;
        }
    }
}
