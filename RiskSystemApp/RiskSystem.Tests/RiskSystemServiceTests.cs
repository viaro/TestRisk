using FluentAssertions;
using Moq;
using RiskSystem.Application;
using RiskSystem.Application.Interfaces;
using RiskSystem.Domain.Entities;
using RiskSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystem.Tests
{
    [TestFixture]
    public class RiskSystemServiceTests
    {
        public IRiskSystemService _riskSystemService;
        public Mock<IPortfolioFactory> _portfolioFactory;
        public Mock<ITradeFactory> _tradeFactory;

        [SetUp]
        public void Setup()
        {
            _portfolioFactory = new Mock<IPortfolioFactory>();
            _tradeFactory = new Mock<ITradeFactory>();

            _riskSystemService = new RiskSystemService(_portfolioFactory.Object, _tradeFactory.Object);
        }

        [Test]
        public void TestShouldAssertAssessPortfolioRisk()
        {
            //Arrange
            var inputList = new List<string>() { "2000000 Private 12/29/2025" };
            var referenceDate = "12/11/2020";

            var portFolio = new Mock<IPortfolio>();
            var trade = new Mock<ITrade>();
            trade.Setup(x => x.AssesRisk(It.IsAny<DateTime>())).Returns("HIGHRISK");
            List<ITrade> trades = new List<ITrade>() { trade.Object };
            portFolio.Setup(x => x.Trades).Returns(trades);

            _portfolioFactory.Setup(x => x.CreateIPortfolio(It.IsAny<string>())).Returns(portFolio.Object);
            _tradeFactory.Setup(x => x.CreateTrade(It.IsAny<string>(), It.IsAny<int>())).Returns(trade.Object);

            //Act
            var result = _riskSystemService.AssessPortfolioRisk(referenceDate, inputList);

            //Assert
            result.Count.Should().Be(1);
            result.Should().Contain("HIGHRISK");
        }
    }
}
