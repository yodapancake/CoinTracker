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
        public string Coin_Name { get; set; } = "";
        public double Coin_Price_USD { get; set; } = 0;
        public double Coin_24_Hour_Change { get; set; } = 0;
        public double Coin_24_Hour_Volume { get; set; } = 0;
        public double Coin_Market_Cap { get; set; } = 0;
        public double Coin_Circulating_Supply { get; set; } = 0;
        public int Coin_Rank { get; set; } = 0;
        public string Coin_Ticker_Tape { get; set; } = "";
        public string Coin_Picture { get; set; } = "";
        public int Coin_Picture_Scale { get; set; } = 0;
        
        public string Coin_CMC_String { get; set; }
        public string Coin_Circ_String { get; set; }
        public string Coin_Volume_String { get; set; }
    }
}
