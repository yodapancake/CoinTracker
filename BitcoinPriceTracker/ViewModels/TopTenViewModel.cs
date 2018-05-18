using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.ComponentModel;

namespace BitcoinPriceTracker.ViewModels
{
    [ImplementPropertyChanged]
    public class TopTenViewModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;        
        public string Coin_Name { get; set; }
        public string Coin_Price_USD { get; set; }
        public string Coin_24_Hour_Change { get; set; }
        public string Coin_24_Hour_Volume { get; set; }
        public string Coin_Market_Share { get; set; }
        public string Coin_Circulating_Supply { get; set; }
        public string Coin_Rank { get; set; }
        public string Coin_Ticker_Tape { get; set; }
        public string Coin_picture { get; set; }
    }
}
