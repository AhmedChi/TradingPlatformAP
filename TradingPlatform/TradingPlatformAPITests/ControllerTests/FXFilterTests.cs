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
        public void Should_Return_Filtered_List_Of_FXTrades_When_Filter_FX_Trades_Called()
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
                    BaseCurrencyId = 1,
                    UnderlyingCurrencyId = 6
                }
            };

            List<Currencies> currencies = new List<Currencies>
            {
                new Currencies {CurrencyId = 1, CurrencyName = "US Dollar"},
                new Currencies {CurrencyId = 6, CurrencyName = "Swiss Franc"}
            };

            // Act

            List<FXTradesModel> results = FXService.Filter(actualResults, currencies);


            // Assert
            List<FXTradesModel> expectedResults = new List<FXTradesModel>
            {
                new FXTradesModel
                {
                    FxTradeId = 1,
                    BaseNominal = 1,
                    UnderlyingNominal = 10.3943m,
                    BaseQuotation = false,
                    BaseCurrencyId = 1,
                    BaseCurrency = new Currencies {CurrencyId = 1, CurrencyName = "US Dollar"},
                    UnderlyingCurrencyId = 6,
                    UnderlyingCurrency = new Currencies {CurrencyId = 6, CurrencyName = "Swiss Franc"}
                }
            };

            results.Should().BeEquivalentTo(expectedResults);
        }

        [TestMethod]
        public void Should_Not_Return_Filtered_List_Of_FXTrades_When_Filter_FX_Trades_Called()
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
                    BaseCurrencyId = 1,
                    UnderlyingCurrencyId = 6
                }
            };

            List<Currencies> currencies = new List<Currencies>
            {
                new Currencies {CurrencyId = 1, CurrencyName = "US Dollar"},
                new Currencies {CurrencyId = 6, CurrencyName = "Swiss Franc"}
            };

            // Act

            List<FXTradesModel> results = FXService.Filter(actualResults, currencies);

            // Assert
            List<FXTradesModel> expectedResults = new List<FXTradesModel>
            {
                new FXTradesModel
                {
                    FxTradeId = 1,
                    BaseNominal = 1,
                    UnderlyingNominal = 10.3943m,
                    BaseQuotation = false,
                    BaseCurrencyId = 1,
                    UnderlyingCurrency = new Currencies {CurrencyId = 1, CurrencyName = "US Dollar"},
                    UnderlyingCurrencyId = 6,
                    BaseCurrency = new Currencies {CurrencyId = 6, CurrencyName = "Swiss Franc"}
                }
            };

            results.Should().NotBeEquivalentTo(expectedResults);
        }

    }
}
