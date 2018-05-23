using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinPriceTracker.Models
{
    class GlobalData
    {
        public class USD
        {
            public double total_market_cap { get; set; }
            public double total_volume_24h { get; set; }
        }

        public class Quotes
        {
            public USD USD { get; set; }
        }

        public class Data
        {
            public int active_cryptocurrencies { get; set; }
            public int active_markets { get; set; }
            public double bitcoin_percentage_of_market_cap { get; set; }
            public Quotes quotes { get; set; }
            public int last_updated { get; set; }
        }

        public class Metadata
        {
            public int timestamp { get; set; }
            public object error { get; set; }
        }

        public class GlobalDataRootObject
        {
            public Data data { get; set; }
            public Metadata metadata { get; set; }
        }
    }
}
