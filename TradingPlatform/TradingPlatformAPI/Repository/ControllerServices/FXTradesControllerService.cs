using System.Collections.Generic;
using System.Linq;
using TradingPlatformAPI.Models;
using TradingPlatformAPI.Repository.dtos;

namespace TradingPlatformAPI.Repository.ControllerServices
{
    public class FXTradesControllerService : IFXTradesControllerService
    {
        public List<FXTradesModel> Filter(List<FxTrades> fxTrades, List<Currencies> currencies)
        {
            return fxTrades.AsEnumerable()
                .Join(currencies.AsEnumerable(), fxb => fxb.BaseCurrencyId, bc => bc.CurrencyId,
                (fxb, bc) => new { fxb, bc })
                .Join(currencies.AsEnumerable(), fxu => fxu.fxb.UnderlyingCurrencyId, uc => uc.CurrencyId,
                (fxu, uc) => new { fxu, uc })
                .Select(m => new FXTradesModel
                {  
                    FxTradeId = m.fxu.fxb.FxTradeId,
                    BaseNominal = m.fxu.fxb.BaseNominal,
                    UnderlyingNominal = m.fxu.fxb.UnderlyingNominal,
                    BaseQuotation = m.fxu.fxb.BaseQuotation,
                    BaseCurrencyId = m.fxu.fxb.BaseCurrencyId,
                    BaseCurrency = new Currencies
                    {
                        CurrencyId = m.fxu.bc.CurrencyId,
                        CurrencyCode = m.fxu.bc.CurrencyCode,
                        CurrencyName = m.fxu.bc.CurrencyName,
                        Created = m.fxu.bc.Created
                    },
                    UnderlyingCurrencyId = m.fxu.fxb.UnderlyingCurrencyId,
                    UnderlyingCurrency = new Currencies
                    {
                        CurrencyId = m.uc.CurrencyId,
                        CurrencyCode = m.uc.CurrencyCode,
                        CurrencyName = m.uc.CurrencyName,
                        Created = m.uc.Created
                    }
                })
                .ToList();
        }
    }
}
