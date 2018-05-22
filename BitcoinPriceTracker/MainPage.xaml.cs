using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using BitcoinPriceTracker.ViewModels;
using BitcoinPriceTracker.Models;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BitcoinPriceTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<TopTenViewModel> Top_ten_viewmodels = new List<TopTenViewModel>();
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await GetInfo();
        }
        private async Task GetInfo()
        {
            Top10CoinsDetailsRetriever details = new Top10CoinsDetailsRetriever();
            Top10RootObject Top10Root = await details.GetTop10Details();
     
            foreach(var v in Top10Root.data)
            {
                TopTenViewModel temp = new TopTenViewModel();
                temp.Coin_Name = v.Value.name;
                temp.Coin_Ticker_Tape = v.Value.symbol;
                temp.Coin_Price_USD = v.Value.quotes.USD.price.ToString();
                temp.Coin_picture = "ms-appx:///Assets/CryptoSVG/PNG/" + temp.Coin_Ticker_Tape + ".PNG";
                Top_ten_viewmodels.Add(temp);
            }

        }        
    } 
}

