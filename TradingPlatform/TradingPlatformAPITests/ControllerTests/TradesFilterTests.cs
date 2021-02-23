using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TradingPlatformAPI.Models;
using TradingPlatformAPI.Repository.ControllerServices;
using TradingPlatformAPI.Repository.dtos;

namespace TradingPlatformAPITests.ControllerTests
{
    [TestClass]
    public class TradesFilterTests
    {
        [TestMethod]
        public void Actual_Results_Should_Be_Equivalent_To_Expected_List_Of_Filtered_Trades()
        {
            // Arrange
            var tradesService = new TradesControllerService();

            List<Trades> actualResults = new List<Trades>
            {
                new Trades
                {
                    Counterparty = new Counterparties {CounterpartyId = 12, CounterpartyName = "Morrison (WM.) Supermarkets PLC"},
                    DealPrice = 6.3444m,
                    TradeQuantity = 685854,
                    TradeTotal = 4351307.6417m,
                    Buy = false,
                    EquityTrade = new EquityTrades {EquityId = 1 }
                }
            };

            // Act

            List<TradesModel> results = tradesService.Filter(actualResults);


            // Assert
            List<TradesModel> expectedResults = new List<TradesModel>
            {
                new TradesModel
                {
                    Counterparty = new Counterparties {CounterpartyId = 12, CounterpartyName = "Morrison (WM.) Supermarkets PLC"},
                    DealPrice = 6.3444m,
                    TradeQuantity = 685854,
                    TradeTotal = 4351307.6417m,
                    Buy = false

                }
            };

            results.Should().BeEquivalentTo(expectedResults);

        }

        [TestMethod]
        public void Actual_Results_Should_Not_Be_Equivalent_To_Expected_List_Of_Filtered_Trades()
        {
            // Arrange
            var tradesService = new TradesControllerService();

            List<Trades> actualResults = new List<Trades>
            {
                new Trades
                {
                    Counterparty = new Counterparties {CounterpartyId = 12, CounterpartyName = "Morrison (WM.) Supermarkets PLC"},
                    Buy = false,
                    EquityTrade = new EquityTrades {EquityId = 1 }
                }
            };

            // Act
            List<TradesModel> results = tradesService.Filter(actualResults);

            // Assert

            List<TradesModel> expectedResults = new List<TradesModel>
            {
                new TradesModel
                {
                    Counterparty = new Counterparties {CounterpartyId = 12, CounterpartyName = "Morrison (WM.) Supermarkets PLC"},
                    DealPrice = 6.3444m,
                    TradeQuantity = 685854,
                    TradeTotal = 4351307.6417m,
                    Buy = false

                }
            };

            results.Should().NotBeEquivalentTo(expectedResults);

        }
    }
}
