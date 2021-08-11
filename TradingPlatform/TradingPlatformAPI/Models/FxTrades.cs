using System;
using System.Collections.Generic;

namespace TradingPlatformAPI.Models
{
    public partial class FxTrades
    {
        public FxTrades()
        {
            Trades = new HashSet<Trades>();
        }

        public int FxTradeId { get; set; }
        public int BaseCurrencyId { get; set; }
        public int UnderlyingCurrencyId { get; set; }
        public bool BaseQuotation { get; set; }
        public decimal BaseNominal { get; set; }
        public decimal UnderlyingNominal { get; set; }

        public virtual Currencies BaseCurrency { get; set; }
        public virtual Currencies UnderlyingCurrency { get; set; }
        public virtual ICollection<Trades> Trades { get; set; }
    }
}
