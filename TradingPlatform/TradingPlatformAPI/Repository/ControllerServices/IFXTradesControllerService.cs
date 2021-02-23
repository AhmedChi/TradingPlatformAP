using System.Collections.Generic;
using TradingPlatformAPI.Models;
using TradingPlatformAPI.Repository.dtos;

namespace TradingPlatformAPI.Repository.ControllerServices
{
    public interface IFXTradesControllerService
    {
        List<FXTradesModel> Filter(List<FxTrades> actualResults);
    }
}