using System;
using System.Collections.Generic;

namespace TradingPlatformAPI.Models
{
    public partial class CashAccounts
    {
        public CashAccounts()
        {
            TradesCounterpartyCashAccount = new HashSet<Trades>();
            TradesTradeCashAccount = new HashSet<Trades>();
        }

        public int CashAccountId { get; set; }
        public int? CounterpartyId { get; set; }
        public string CashAccountName { get; set; }
        public string CashAccountNumber { get; set; }
        public string CashAccountSortCode { get; set; }
        public decimal Balance { get; set; }
        public DateTime Created { get; set; }

        public virtual Counterparties Counterparty { get; set; }
        public virtual ICollection<Trades> TradesCounterpartyCashAccount { get; set; }
        public virtual ICollection<Trades> TradesTradeCashAccount { get; set; }
    }
}
