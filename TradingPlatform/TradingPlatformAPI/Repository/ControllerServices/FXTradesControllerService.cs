using System.Collections.Generic;
using System.Linq;
using TradingPlatformAPI.Models;
using TradingPlatformAPI.Repository.dtos;

namespace TradingPlatformAPI.Repository.ControllerServices
{
    public class FXTradesControllerService : IFXTradesControllerService
    {
        public List<FXTradesModel> Filter(List<FxTrades> actualResults)
        {
            return actualResults
                .Select(fx => new FXTradesModel
                {
                    FxTradeId = fx.FxTradeId,
                    BaseNominal = fx.BaseNominal,
                    UnderlyingNominal = fx.UnderlyingNominal,
                    BaseQuotation = fx.BaseQuotation,
                    BaseCurrency = fx.BaseCurrency,
                    UnderlyingCurrency = fx.UnderlyingCurrency
                })
                .ToList();
        }
    }
}
