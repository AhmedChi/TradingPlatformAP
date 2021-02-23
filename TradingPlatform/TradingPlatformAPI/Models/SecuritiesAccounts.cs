using System;
using System.Collections.Generic;

namespace TradingPlatformAPI.Models
{
    public partial class SecuritiesAccounts
    {
        public SecuritiesAccounts()
        {
            TradesCounterpartySecurityAccount = new HashSet<Trades>();
            TradesTradeSecurityAccount = new HashSet<Trades>();
        }

        public int SecurityAccountId { get; set; }
        public int? CounterpartyId { get; set; }
        public string SecurityAccountName { get; set; }
        public string SecurityAccountNumber { get; set; }
        public string SecurityAccountSortCode { get; set; }
        public DateTime Created { get; set; }

        public virtual Counterparties Counterparty { get; set; }
        public virtual ICollection<Trades> TradesCounterpartySecurityAccount { get; set; }
        public virtual ICollection<Trades> TradesTradeSecurityAccount { get; set; }
    }
}
