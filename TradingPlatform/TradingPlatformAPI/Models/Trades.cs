using System;
using System.Collections.Generic;

namespace TradingPlatformAPI.Models
{
    public partial class Trades
    {
        public int TradeId { get; set; }
        public int? EquityTradeId { get; set; }
        public int? FxTradeId { get; set; }
        public int CounterpartyId { get; set; }
        public int UserAccountId { get; set; }
        public int TradeCashAccountId { get; set; }
        public int CounterpartyCashAccountId { get; set; }
        public int TradeSecurityAccountId { get; set; }
        public int CounterpartySecurityAccountId { get; set; }
        public decimal? DealPrice { get; set; }
        public int? TradeQuantity { get; set; }
        public decimal? TradeTotal { get; set; }
        public DateTime? TradeDate { get; set; }
        public bool? Buy { get; set; }

        public virtual Counterparties Counterparty { get; set; }
        public virtual CashAccounts CounterpartyCashAccount { get; set; }
        public virtual SecuritiesAccounts CounterpartySecurityAccount { get; set; }
        public virtual EquityTrades EquityTrade { get; set; }
        public virtual FxTrades FxTrade { get; set; }
        public virtual CashAccounts TradeCashAccount { get; set; }
        public virtual SecuritiesAccounts TradeSecurityAccount { get; set; }
        public virtual UserAccounts UserAccount { get; set; }
    }
}
