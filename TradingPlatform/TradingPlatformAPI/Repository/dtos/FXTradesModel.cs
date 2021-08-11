using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatformAPI.Models;

namespace TradingPlatformAPI.Repository.dtos
{
    public class FXTradesModel
    {
        public int FxTradeId { get; set; }
        public decimal BaseNominal { get; set; }
        public decimal UnderlyingNominal { get; set; }
        public bool BaseQuotation { get; set; }
        public int BaseCurrencyId { get; set; }
        public int UnderlyingCurrencyId { get; set; }

        public virtual Currencies BaseCurrency { get; set; }
        public virtual Currencies UnderlyingCurrency { get; set; }
    }
}
