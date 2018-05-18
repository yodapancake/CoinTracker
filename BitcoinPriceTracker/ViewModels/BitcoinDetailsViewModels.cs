using System.ComponentModel;
using PropertyChanged;

namespace BitcoinPriceTracker.ViewModels
{
    [ImplementPropertyChanged]
    public class BitcoinDetailsViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Coin { get; set; }
        public string Currency { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
    }
}
