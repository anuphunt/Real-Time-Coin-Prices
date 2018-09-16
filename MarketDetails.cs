using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper3._0
{
    public class MarketDetails : INotifyPropertyChanged
    {
        private string _marketcap = null;
        private string _btcdominance = null;
        public string MarketCap
        {
            get { return _marketcap; }
            set
            {
                if (_marketcap != value)
                {
                    _marketcap = value;
                    OnChange("MarketCap");
                }
            }
        }
        public string BTCDominance
        {
            get { return _btcdominance; }
            set
            {
                if(_btcdominance != value)
                {
                    _btcdominance = value;
                    OnChange("BTCDominance");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnChange(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
