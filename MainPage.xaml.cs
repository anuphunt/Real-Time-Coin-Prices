using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml.Media;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WebScraper3._0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        System.Threading.Timer _timer = null;

        public MainPage()
        {
            this.InitializeComponent();

        }

        ObservableCollection<CurrencyData> CurrencyPrices = new ObservableCollection<CurrencyData>();
        MarketDetails MarketCapAndBTCDominance = new MarketDetails();

        public async void DataStream(object state)
        {

            var marketcap = "https://s2.coinmarketcap.com/generated/stats/global.json";
            var currencyprices = "https://coinmarketcap.com/";

            HttpClient client = new HttpClient();
            string marketcapstring = await client.GetStringAsync(marketcap);
            string currencypricesstring = await client.GetStringAsync(currencyprices);

            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
           {
               Scraper.GetMarketCapAndBTCPercent(marketcapstring, ref MarketCapAndBTCDominance);
               Scraper.GetCurrentPrices(currencypricesstring, ref CurrencyPrices);
           });

        }
        private void Container_Loaded(object sender, RoutedEventArgs e)
        {
            
            TableData.ItemsSource = CurrencyPrices;
            TotalMarketCap.DataContext = MarketCapAndBTCDominance;
            BTCDominance.DataContext = MarketCapAndBTCDominance;
            _timer = new System.Threading.Timer(DataStream, null, 0, 30 * 1000);
        }

        private void Change24_Loaded(object sender, RoutedEventArgs e)
        {
            var change24 = (TextBlock)sender;
            ChangetoRed(change24);
        }

        private static void ChangetoRed(TextBlock change24)
        {
            if (change24.Text.Length > 0)
            {
                if (change24.Text[0] == '-')
                {
                    change24.Foreground = new SolidColorBrush(Colors.Red);
                }
                else change24.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
    }
}
