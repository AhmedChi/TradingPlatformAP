using System;
using System.Collections.Generic;

namespace TradingPlatformAPI.Models
{
    public partial class Currencies
    {
        public Currencies()
        {
            EquityTrades = new HashSet<EquityTrades>();
            FxTradesBaseCurrency = new HashSet<FxTrades>();
            FxTradesUnderlyingCurrency = new HashSet<FxTrades>();
        }

        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<EquityTrades> EquityTrades { get; set; }
        public virtual ICollection<FxTrades> FxTradesBaseCurrency { get; set; }
        public virtual ICollection<FxTrades> FxTradesUnderlyingCurrency { get; set; }
    }
}
