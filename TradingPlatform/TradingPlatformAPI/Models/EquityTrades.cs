using System;
using System.Collections.Generic;

namespace TradingPlatformAPI.Models
{
    public partial class EquityTrades
    {
        public EquityTrades()
        {
            Trades = new HashSet<Trades>();
        }

        public int EquityTradeId { get; set; }
        public int EquityId { get; set; }
        public int CurrencyId { get; set; }

        public virtual Currencies Currency { get; set; }
        public virtual Equities Equity { get; set; }
        public virtual ICollection<Trades> Trades { get; set; }
    }
}
