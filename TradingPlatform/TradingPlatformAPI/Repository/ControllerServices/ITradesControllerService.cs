using System.Collections.Generic;
using TradingPlatformAPI.Models;
using TradingPlatformAPI.Repository.dtos;

namespace TradingPlatformAPI.Repository.ControllerServices
{
    public interface ITradesControllerService
    {
        List<TradesModel> Filter(List<Trades> trades);

        List<TradesModel> Calculate(List<Trades> actualResults);
    }
}