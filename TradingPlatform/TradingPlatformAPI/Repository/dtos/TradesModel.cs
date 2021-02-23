using TradingPlatformAPI.Models;

namespace TradingPlatformAPI.Repository.dtos
{
    public class TradesModel
    {
        public decimal? DealPrice { get; set; }
        public int? TradeQuantity { get; set; }
        public decimal? TradeTotal { get; set; }

        public bool? Buy { get; set; }
        public virtual Counterparties Counterparty { get; set; }

        public decimal? OldTradeTotal { get; set; }
        public decimal? ProfitOrLoss { get; set; }
    }
}
