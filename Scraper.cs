using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System;

namespace WebScraper3._0
{
    public class Scraper
    {
        public static void GetMarketCapAndBTCPercent(string text, ref MarketDetails data)
        {

            string pattern = @"{""bitcoin_percentage_of_market_cap"":\s(?<btcpercent>\d+\.\d{2}).*""total_market_cap_by_available_supply_usd"":\s(?<MarketCap>\d*).\d*}";

            var MarketCap = Regex.Match(text, pattern).Groups["MarketCap"].Value;
            var BtcPercent = Regex.Match(text, pattern).Groups["btcpercent"].Value;
            MarketCap = MarketCap.Insert(3, ",");
            MarketCap = MarketCap.Insert(7, ",");
            MarketCap = MarketCap.Insert(11, ",");
            MarketCap = MarketCap.Insert(0, "$");

            BtcPercent = BtcPercent + "%";

            data.BTCDominance = BtcPercent;
            data.MarketCap = MarketCap;
        }

        public static void GetCurrentPrices(string text, ref ObservableCollection<CurrencyData> result)
        {
            result.Clear();
            string btc = @"\<a\shref\=\""\/currencies\/bitcoin\/\#markets""\sclass\=\""price\""\sdata-usd\=\""(?<btc>\d+\.+\d{2,4})";
            string BTCChange24Pattern = @"data\-symbol\=\""BTC\""\sdata\-sort\=\"".+""\>(?<change24>.+\%)\<\/td\>";

            var btcprice = Regex.Match(text, btc).Groups["btc"].Value;
            var btcchange24 = Regex.Match(text, BTCChange24Pattern).Groups["change24"].Value;

            var item1 = new CurrencyData
            {
                CoinRank = 1,
                CoinName = "BTC",
                CoinPrice = btcprice,
                Change24 = btcchange24
            };
            result.Add(item1);

            string ethereum = @"\<a\shref\=\""\/currencies\/ethereum\/\#markets""\sclass\=\""price\""\sdata-usd\=\""(?<etc>\d+\.+\d{2,4})";
            string EthereumChange24Pattern = @"data\-symbol\=\""ETH\""\sdata\-sort\=\"".+""\>(?<EthereumChange24>.+\%)\<\/td\>";

            var EthereumChange24 = Regex.Match(text, EthereumChange24Pattern).Groups["EthereumChange24"].Value;
            var EthereumPrice = Regex.Match(text, ethereum).Groups["etc"].Value;
            var item2 = new CurrencyData
            {
                CoinRank = 2,
                CoinName = "Ethereum",
                CoinPrice = EthereumPrice,
                Change24 = EthereumChange24
            };
            result.Add(item2);

            string xrp = @"\<a\shref\=\""\/currencies\/ripple\/\#markets""\sclass\=\""price\""\sdata-usd\=\""(?<xrp>\d+\.+\d{2,4})";
            string XrpChange24Pattern = @"data\-symbol\=\""XRP\""\sdata\-sort\=\"".+""\>(?<xrp>.+\%)\<\/td\>";

            var xrpprice = Regex.Match(text, xrp).Groups["xrp"].Value;
            var XrpChange24 = Regex.Match(text, XrpChange24Pattern).Groups["xrp"].Value;

            var item3 = new CurrencyData
            {
                CoinRank = 3,
                CoinName = "XRP",
                CoinPrice = xrpprice,
                Change24 = XrpChange24
            };
            result.Add(item3);

            string btccash = @"\<a\shref\=\""\/currencies\/bitcoin-cash\/\#markets""\sclass\=\""price\""\sdata-usd\=\""(?<bitcoincash>\d+\.+\d{2,4})";
            string BCHCashChange24Pattern = @"data\-symbol\=\""BCH""\sdata\-sort\=\"".+""\>(?<bch>.+\%)\<\/td\>";

            var btccashprice = Regex.Match(text, btccash).Groups["bitcoincash"].Value;
            var BCHCashChange24 = Regex.Match(text, BCHCashChange24Pattern).Groups["bch"].Value;

            var item4 = new CurrencyData
            {
                CoinRank = 4,
                CoinName = "Bitcoin Cash",
                CoinPrice = btccashprice,
                Change24 = BCHCashChange24
            };
            result.Add(item4);

            string eos = @"\<a\shref\=\""\/currencies\/eos\/\#markets""\sclass\=\""price\""\sdata-usd\=\""(?<eos>\d+\.+\d{2,4})";
            string EOSChange24Pattern = @"data\-symbol\=\""EOS""\sdata\-sort\=\"".+""\>(?<eos>.+\%)\<\/td\>";

            var eosprice = Regex.Match(text, eos).Groups["eos"].Value;
            var EOSChange24 = Regex.Match(text, EOSChange24Pattern).Groups["eos"].Value;

            var item5 = new CurrencyData
            {
                CoinRank = 5,
                CoinName = "EOS",
                CoinPrice = eosprice,
                Change24 = EOSChange24
            };
            result.Add(item5);

            string stellar = @"\<a\shref\=\""\/currencies\/stellar\/\#markets""\sclass\=\""price\""\sdata-usd\=\""(?<stellar>\d+\.+\d{2,4})";
            string StellarChange24Pattern = @"data\-symbol\=\""XLM""\sdata\-sort\=\"".+""\>(?<xlm>.+\%)\<\/td\>";

            var stellarprice = Regex.Match(text, stellar).Groups["stellar"].Value;
            var StellarChange24 = Regex.Match(text, StellarChange24Pattern).Groups["xlm"].Value;

            var item6 = new CurrencyData
            {
                CoinRank = 6,
                CoinName = "Stellar",
                CoinPrice = stellarprice,
                Change24 = StellarChange24
            };
            result.Add(item6);

            string ltc = @"\<a\shref\=\""\/currencies\/litecoin\/\#markets""\sclass\=\""price\""\sdata-usd\=\""(?<ltc>\d+\.+\d{2,4})";
            string LtcChange24Pattern = @"data\-symbol\=\""LTC""\sdata\-sort\=\"".+""\>(?<ltc>.+\%)\<\/td\>";
            var ltcprice = Regex.Match(text, ltc).Groups["ltc"].Value;
            var LTCChange24 = Regex.Match(text, LtcChange24Pattern).Groups["ltc"].Value;

            var item7 = new CurrencyData
            {
                CoinRank = 7,
                CoinName = "LiteCoin",
                CoinPrice = ltcprice,
                Change24 = LTCChange24
            };
            result.Add(item7);

            string Tether = @"\<a\shref\=\""\/currencies\/tether\/\#markets""\sclass\=\""price\""\sdata-usd\=\""(?<tether>\d+\.+\d{2,4})";
            string TetherChange24Pattern = @"data\-symbol\=\""USDT""\sdata\-sort\=\"".+""\>(?<USDT>.+\%)\<\/td\>";


            var tetherprice = Regex.Match(text, Tether).Groups["tether"].Value;
            var TetherChange24 = Regex.Match(text, TetherChange24Pattern).Groups["USDT"].Value;
            var item8 = new CurrencyData
            {
                CoinRank = 8,
                CoinName = "Tether",
                CoinPrice = tetherprice,
                Change24 = TetherChange24
            };
            result.Add(item8);

            string cardano = @"\<a\shref\=\""\/currencies\/cardano\/\#markets""\sclass\=\""price\""\sdata-usd\=\""(?<cardano>\d+\.+\d{2,4})";
            string CardanoChange24Pattern = @"data\-symbol\=\""ADA""\sdata\-sort\=\"".+""\>(?<ada>.+\%)\<\/td\>";

            var cardanoprice = Regex.Match(text, cardano).Groups["cardano"].Value;
            var CardanoChange24 = Regex.Match(text, CardanoChange24Pattern).Groups["ada"].Value;

            var item9 = new CurrencyData
            {
                CoinRank = 9,
                CoinName = "Cardano",
                CoinPrice = cardanoprice,
                Change24 = CardanoChange24
            };
            result.Add(item9);

            string monero = @"\<a\shref\=\""\/currencies\/monero\/\#markets""\sclass\=\""price\""\sdata-usd\=\""(?<monero>\d+\.+\d{2,4})";
            string MoneroChange24Pattern = @"data\-symbol\=\""XMR""\sdata\-sort\=\"".+""\>(?<xmr>.+\%)\<\/td\>";

            var moneroprice = Regex.Match(text, monero).Groups["monero"].Value;
            var MoneroChange24 = Regex.Match(text, MoneroChange24Pattern).Groups["xmr"].Value;

            var item10 = new CurrencyData
            {
                CoinRank = 10,
                CoinName = "Monero",
                CoinPrice = moneroprice,
                Change24 = MoneroChange24
            };
            result.Add(item10);

            string iota = @"\<a\shref\=\""\/currencies\/iota\/\#markets""\sclass\=\""price\""\sdata-usd\=\""(?<iota>\d+\.+\d{2,4})";
            string IOTAChange24Pattern = @"data\-symbol\=\""MIOTA""\sdata\-sort\=\"".+""\>(?<IOTA>.+\%)\<\/td\>";

            var iotaprice = Regex.Match(text, iota).Groups["iota"].Value;
            var IOTAChange24 = Regex.Match(text, IOTAChange24Pattern).Groups["IOTA"].Value;

            var item11 = new CurrencyData
            {
                CoinRank = 11,
                CoinName = "IOTA",
                CoinPrice = iotaprice,
                Change24 = IOTAChange24
            };
            result.Add(item11);

        }
    }
}
