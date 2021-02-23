using System.Collections.Generic;
using System.Linq;
using TradingPlatformAPI.Models;
using TradingPlatformAPI.Repository.CalculationServicies;
using TradingPlatformAPI.Repository.dtos;

namespace TradingPlatformAPI.Repository.ControllerServices
{
    public class TradesControllerService : ITradesControllerService
    {
        private readonly ITradesCalculationService _calculationService;

        public TradesControllerService(ITradesCalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public TradesControllerService()
        {
        }

        public List<TradesModel> Filter(List<Trades> trades)
        {
            var filteredList = trades
                .Select(s => new TradesModel
                {
                    Buy = s.Buy,
                    DealPrice = s.DealPrice,
                    TradeQuantity = s.TradeQuantity,
                    TradeTotal = s.TradeTotal,
                    Counterparty = s.Counterparty                    
                })                
                .ToList();

            return filteredList;
        }

        public List<TradesModel> Calculate(List<Trades> actualResults)
        {
            var currentDealPrice = _calculationService.GetLiveDealPrice();

            var sellingTradeList = GetTradesSold(actualResults);

            foreach (var trade in sellingTradeList)
            {
                trade.OldTradeTotal = trade.TradeTotal;
                trade.DealPrice = currentDealPrice;
                trade.TradeTotal = trade.TradeQuantity * currentDealPrice;
                trade.ProfitOrLoss = ( trade.TradeTotal - trade.OldTradeTotal ) / 100;
            }

            return sellingTradeList;
        }

        private List<TradesModel> GetTradesSold(List<Trades> actualResults)
        {
            var filteredResults = Filter(actualResults);

            return filteredResults
                .Where(s => s.Buy != true)
                .ToList();
        }



    }
}
