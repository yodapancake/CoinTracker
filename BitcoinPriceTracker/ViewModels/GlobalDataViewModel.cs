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
    public class GlobalDataViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Active_Cryptocurrencies { get; set; } = 0;
        public int Active_Markets { get; set; } = 0;
        public double Bitcoin_Percentage_Of_Market_Cap { get; set; } = 0;
        public int Last_Updated { get; set; } = 0;
        public double Total_Market_Cap { get; set; } = 0;
        public double Total_Volume_24h { get; set; } = 0;
    }
}
