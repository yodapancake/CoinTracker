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
using System.Collections.ObjectModel;
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BitcoinPriceTracker
{
    public sealed partial class CoinDisplayPage : Page
    {
        private GlobalDataViewModel Global_Data_viewmodels = new GlobalDataViewModel();
        private ObservableCollection<TopTenViewModel> Top_ten_viewmodels = new ObservableCollection<TopTenViewModel>();
        public CoinDisplayPage()
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

            GlobalDetailsRetriever GlobalDetails = new GlobalDetailsRetriever();
            GlobalData.GlobalDataRootObject GlobalDataRoot = await GlobalDetails.GetGlobalDataDetails();

            Global_Data_viewmodels.Active_Cryptocurrencies = GlobalDataRoot.data.active_cryptocurrencies;
            Global_Data_viewmodels.Active_Markets = GlobalDataRoot.data.active_markets;
            Global_Data_viewmodels.Bitcoin_Percentage_Of_Market_Cap = GlobalDataRoot.data.bitcoin_percentage_of_market_cap;
            Global_Data_viewmodels.Total_Market_Cap = GlobalDataRoot.data.quotes.USD.total_market_cap;
            Global_Data_viewmodels.Total_Volume_24h = GlobalDataRoot.data.quotes.USD.total_volume_24h;

            foreach (var v in Top10Root.data)
            {
                TopTenViewModel temp = new TopTenViewModel();
                temp.Coin_Name = v.Value.name;
                temp.Coin_Rank = v.Value.rank;
                temp.Coin_Ticker_Tape = v.Value.symbol;
                temp.Coin_Price_USD = v.Value.quotes.USD.price;
                temp.Coin_24_Hour_Change = v.Value.quotes.USD.percent_change_24h;
                temp.Coin_24_Hour_Volume = v.Value.quotes.USD.volume_24h;
                temp.Coin_Circulating_Supply = v.Value.total_supply;
                temp.Coin_Market_Cap = v.Value.quotes.USD.market_cap;
                temp.Coin_Picture = "ms-appx:///Assets/CryptoSVG/PNG/" + temp.Coin_Ticker_Tape + ".png";

                temp.Coin_CMC_String = " $" + String.Format("{0:#,##0.##}", temp.Coin_Market_Cap);
                temp.Coin_Circ_String = " " + String.Format("{0:#,##0.##}", temp.Coin_Circulating_Supply);
                temp.Coin_Volume_String = "$" + String.Format("{0:#,##0.##}", temp.Coin_24_Hour_Volume);

                double Coin_Market_Share_Percent = ((double)(temp.Coin_Market_Cap) / (long)(Global_Data_viewmodels.Total_Market_Cap));
                int scale = (int)((Coin_Market_Share_Percent / Global_Data_viewmodels.Bitcoin_Percentage_Of_Market_Cap) * 65000);
                temp.Coin_Picture_Scale = (int)(Math.Sqrt(scale) * 13);

                if (temp.Coin_24_Hour_Change < 0)
                {
                    temp.Coin_Sign = new SolidColorBrush(Color.FromArgb(230, 201, 19, 19));
                }
                else
                {
                    temp.Coin_Sign = new SolidColorBrush(Color.FromArgb(230, 19, 201, 31));
                }

                Top_ten_viewmodels.Add(temp);
            }
        }
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        public void Flyout_menu_button_Click(object sender, RoutedEventArgs e)
        {

        }   
        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }
    }
}