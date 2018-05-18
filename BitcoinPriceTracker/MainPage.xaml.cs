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
        List<TopTenViewModel> Top_ten_viewmodels = new List<TopTenViewModel>();
        private TopTenViewModel TopTenViewModel = new TopTenViewModel();
        private BitcoinDetailsViewModels v = new BitcoinDetailsViewModels();
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            TopTenViewModel temp = new TopTenViewModel(); 
            
            Top_ten_viewmodels.Add(new TopTenViewModel());
            v.Coin = "";
            v.Currency = "";
            v.Price = "";
            v.Image = "ms-appx:///Assets/CryptoSVG/PNG/BTC.png";
            await GetInfo();
        }
        private async Task GetInfo()
        {
            PriceRetriever p = new PriceRetriever();
            BitcoinDetails.BitcoinDetailsRootObject root = await p.GetPrice();

            Top10CoinsDetailsRetriever details = new Top10CoinsDetailsRetriever();
            Top10RootObject Top10Root = await details.GetTop10Details();

            TopTenViewModel temp2 = new TopTenViewModel();
            temp2.Coin_Name = Top10Root.data.__invalid_name__1027.name;
            temp2.Coin_Ticker_Tape = Top10Root.data.__invalid_name__1027.symbol;
            temp2.Coin_Price_USD = Top10Root.data.__invalid_name__1027.quotes.USD.price.ToString();
            Top_ten_viewmodels.Add(temp2);



            v.Coin = root.Data.Base;
            v.Currency = root.Data.Currency;
            v.Price = root.Data.Amount;
        }
    } 
}

