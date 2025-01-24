using FluentAssertions;
using RiskSystem.Domain;
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
    public class TradeTests
    {
        public ITrade _trade;

        [TestCase(2000000, ClientSectorEnum.Private, "12/29/2025")]
        [TestCase(2000000, ClientSectorEnum.Public, "07/01/2020")]
        public void TestShouldAssertTradeCreation(double value, ClientSectorEnum clientSector, DateTime nextPaymentDate)
        {
            //Arrange

            //Act
            _trade = new Trade(value, clientSector, nextPaymentDate);

            //Assert
            _trade.Value.Should().Be(value);
            _trade.ClientSector.Should().Be(clientSector);
            _trade.NextPaymentDate.Should().Be(nextPaymentDate); 
        }

        [TestCase(2000000, ClientSectorEnum.Private, "12/29/2025", "HIGHRISK")]
        [TestCase(5000000, ClientSectorEnum.Public, "01/02/2024", "MEDIUMRISK")]
        [TestCase(400000, ClientSectorEnum.Public, "07/01/2020", "EXPIRED")]
        [TestCase(1234, ClientSectorEnum.Undefined, "12/29/2025", "NotFound")]
        public void TestShouldAssertTradeRisk(double value, ClientSectorEnum clientSector, DateTime nextPaymentDate, string risk)
        {
            //Arrange
            _trade = new Trade(value, clientSector, nextPaymentDate);
            DateTime referenceDate = DateTime.Parse("12/11/2020");

            //Act
            var result = _trade.AssesRisk(referenceDate);

            //Assert
            result.Should().Be(risk);
        }
    }
}
