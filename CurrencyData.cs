using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper3._0
{
    public class CurrencyData:INotifyPropertyChanged
    {
        private string _coinname;
        private string _coinprice;
        private int _coinrank;
        private string _change24;

        public string CoinName { get
            {
                return _coinname;
            }
            set
            {
                if(_coinname != value)
                {
                    _coinname = value;
                    OnChange("CoinName");
                }
            }
        }
        public string CoinPrice
        {
            get
            {
                return _coinprice;
            }
            set
            {
                if (_coinprice != value)
                {
                    _coinprice = value;
                    OnChange("CoinPrice");
                }
            }
        }
        public int CoinRank
        {
            get
            {
                return _coinrank;
            }
            set
            {
                if (_coinrank != value)
                {
                    _coinrank = value;
                    OnChange("CoinRank");
                }
            }
        }

        public string Change24
        {
            get
            {
                return _change24;
            }
            set
            {
                if (_change24 != value)
                {
                    _change24 = value;
                    OnChange("Change24");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnChange(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
