using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TradingPlatformAPI.Models;
using TradingPlatformAPI.Repository.ControllerServices;
using TradingPlatformAPI.Repository.dtos;

namespace TradingPlatformAPITests.ControllerTests
{
    [TestClass]
    public class FXFilterTests
    {
        [TestMethod]
        public void Should_Return_Filtered_List_Of_FXTrades_When_FilterFXTrades_Called()
        {
            // Arrange
            var FXService = new FXTradesControllerService();

            List<FxTrades> actualResults = new List<FxTrades>
            {
                new FxTrades
                {
                    FxTradeId = 1,
                    BaseNominal = 1,
                    UnderlyingNominal = 10.3943m,
                    BaseQuotation = false,
                    BaseCurrency = new Currencies {CurrencyName = "US Dollar"},
                    UnderlyingCurrency = new Currencies {CurrencyName = "Swiss Franc"},
                    BaseCurrencyId = 1,
                    UnderlyingCurrencyId = 6
                }
            };

            // Act

            List<FXTradesModel> results = FXService.Filter(actualResults);


            // Assert
            List<FXTradesModel> expectedResults = new List<FXTradesModel>
            {
                new FXTradesModel
                {
                    FxTradeId = 1,
                    BaseNominal = 1,
                    UnderlyingNominal = 10.3943m,
                    BaseQuotation = false,
                    BaseCurrency = new Currencies {CurrencyName = "US Dollar"},
                    UnderlyingCurrency = new Currencies {CurrencyName = "Swiss Franc"}
                }
            };

            results.Should().BeEquivalentTo(expectedResults);
        }


    }
}
