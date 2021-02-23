using System;
using System.Collections.Generic;

namespace TradingPlatformAPI.Models
{
    public partial class Equities
    {
        public Equities()
        {
            EquityTrades = new HashSet<EquityTrades>();
            SecuritiesAccountEquities = new HashSet<SecuritiesAccountEquities>();
        }

        public int EquityId { get; set; }
        public int? CounterpartyId { get; set; }
        public int SectorId { get; set; }
        public int CurrencyId { get; set; }
        public string EquityCode { get; set; }
        public string EquityName { get; set; }
        public decimal? EquityPrice { get; set; }
        public decimal? EquityVariance { get; set; }
        public DateTime Created { get; set; }

        public virtual Counterparties Counterparty { get; set; }
        public virtual Sectors Sector { get; set; }
        public virtual ICollection<EquityTrades> EquityTrades { get; set; }
        public virtual ICollection<SecuritiesAccountEquities> SecuritiesAccountEquities { get; set; }
    }
}
