using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinPriceTracker.Models
{
    public class BitcoinDetails
    {
        public class Data
        {
            public string Base { get; set; }
            public string Currency { get; set; }
            public string Amount { get; set; }
        }
        public class BitcoinDetailsRootObject
        {
            public Data Data { get; set; }
        }
    }
}
