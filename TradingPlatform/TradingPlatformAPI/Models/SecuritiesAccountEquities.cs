using System;
using System.Collections.Generic;

namespace TradingPlatformAPI.Models
{
    public partial class SecuritiesAccountEquities
    {
        public int SecuritiesAccountEquityId { get; set; }
        public int? CounterpartyId { get; set; }
        public int SecuritiesAccountId { get; set; }
        public int EquityId { get; set; }
        public decimal? SecuritiesQuantity { get; set; }
        public DateTime Created { get; set; }

        public virtual Counterparties Counterparty { get; set; }
        public virtual Equities Equity { get; set; }
    }
}
