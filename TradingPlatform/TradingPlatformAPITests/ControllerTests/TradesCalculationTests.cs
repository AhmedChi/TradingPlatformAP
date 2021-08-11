using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TradingPlatformAPI.Models;
using TradingPlatformAPI.Repository.CalculationServicies;
using TradingPlatformAPI.Repository.ControllerServices;
using TradingPlatformAPI.Repository.dtos;

namespace TradingPlatformAPITests.ControllerTests
{
    [TestClass]
    public class TradesCalculationTests
    {
        private ITradesCalculationService _calculationService;

        [TestInitialize]
        public void InitializeTests()
        {
            _calculationService = new TradesCalculationService();
        }


        [TestMethod]
        public void Should_Return_Calculated_List_Of_Trades_Sold_When_List_Of_Trades_Sold_Used()
        {
            // Arrange
            var tradesService = new TradesControllerService(_calculationService);

            List<Trades> actualResults = new List<Trades>
            {
                new Trades
                {
                    Counterparty = new Counterparties {CounterpartyId = 12, CounterpartyName = "Morrison (WM.) Supermarkets PLC"},
                    DealPrice = 6.3444m,
                    TradeQuantity = 685854,
                    TradeTotal = 4351307.6417m,
                    Buy = false
                }
            };

            // Act

            List<TradesModel> results = tradesService.Calculate(actualResults);


            // Assert
            List<TradesModel> expectedResults = new List<TradesModel>
            {
                new TradesModel
                {
                    Counterparty = new Counterparties {CounterpartyId = 12, CounterpartyName = "Morrison (WM.) Supermarkets PLC"},
                    DealPrice = 5m,
                    TradeQuantity = 685854,
                    TradeTotal =  3429270m,
                    OldTradeTotal = 4351307.6417m,
                    ProfitOrLoss = -9220.376417m,
                    Buy = false

                }
            };

            results.Should().BeEquivalentTo(expectedResults);

        }

        [TestMethod]
        public void Should_Not_Return_List_Of_Trades_Sold_When_List_Of_Trades_Bought_Used()
        {
            // Arrange
            var tradesService = new TradesControllerService(_calculationService);

            List<Trades> actualResults = new List<Trades>
            {
                new Trades
                {
                    Counterparty = new Counterparties {CounterpartyId = 12, CounterpartyName = "Morrison (WM.) Supermarkets PLC"},
                    DealPrice = 6.3444m,
                    TradeQuantity = 685854,
                    TradeTotal = 4351307.6417m,
                    Buy = true
                }
            };

            // Act
            List<TradesModel> results = tradesService.Calculate(actualResults);

            // Assert
            results.Should().BeEmpty();
        }
    }
}
