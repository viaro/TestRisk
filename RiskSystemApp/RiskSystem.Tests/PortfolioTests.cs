using FluentAssertions;
using Moq;
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
    public class PortfolioTests
    {
        public IPortfolio _portfolio;
        public Mock<ITrade> _trade;

        [SetUp]
        public void Setup()
        {
            _trade = new Mock<ITrade>();
        }

        [Test]
        public void TestShouldAssertPortfolioCreation()
        {
            //Arrange
            DateTime anyDateTime = DateTime.Now;

            //Act
            _portfolio = new Portfolio(anyDateTime);

            //Assert
            _portfolio.Should().NotBeNull();
            _portfolio.ReferenceDate.Should().Be(anyDateTime);
        }

        [Test]
        public void TestShouldAssertTradeCount()
        {
            //Arrange
            DateTime anyDateTime = DateTime.Now;
            _trade = new Mock<ITrade>();

            //Act
            _portfolio = new Portfolio(anyDateTime);
            _portfolio.AddTrade(_trade.Object);

            //Assert
            _portfolio.Should().NotBeNull();
            _portfolio.ReferenceDate.Should().Be(anyDateTime);
            _portfolio.Trades.Count.Should().Be(1);
        }


    }
}
