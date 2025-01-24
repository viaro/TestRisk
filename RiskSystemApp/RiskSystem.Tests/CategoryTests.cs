using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RiskSystem.Domain;
using RiskSystem.Domain.Entities.Categories;
using RiskSystem.Domain.Interfaces;

namespace RiskSystem.Tests
{
    [TestFixture]
    public class CategoryTests
    {
        public Expired _expired;
        public HighRisk _highRisk;
        public MediumRisk _mediumRisk;
        public Mock<ITrade> _trade;

        [SetUp]
        public void Setup()
        {
            _trade = new Mock<ITrade>();
        }

        [Test]
        public void TestShouldAssertCategoryName_Expired()
        {
            //Arrange
            _expired = new Expired();

            //Act

            //Assert
            _expired.Name.Should().Be("EXPIRED");
        }
        [Test]
        public void TestShouldAssertCategoryName_HighRisk()
        {
            //Arrange
            _highRisk = new HighRisk();

            //Act

            //Assert
            _highRisk.Name.Should().Be("HIGHRISK");
        }
        [Test]
        public void TestShouldAssertCategoryName_MediumRisk()
        {
            //Arrange
            _mediumRisk = new MediumRisk();

            //Act

            //Assert
            _mediumRisk.Name.Should().Be("MEDIUMRISK");
        }

        [TestCase("12/11/2020", "07/01/2020", true)]
        [TestCase("12/11/2020", "12/29/2025", false)]
        public void TestShouldAssertCategoryRisk_Expired(DateTime referenceDate, DateTime nextPaymentDate, bool result)
        {
            //Arrange
            _trade.Setup(x => x.NextPaymentDate).Returns(nextPaymentDate);

            //Act
            var risk = _expired.IsRisk(_trade.Object, referenceDate);

            //Assert
            risk.Should().Be(result);
        }

        [TestCase("2000000", ClientSectorEnum.Private, true)]
        [TestCase("999999", ClientSectorEnum.Private, false)]
        [TestCase("2000000", ClientSectorEnum.Public, false)]
        public void TestShouldAssertCategoryRisk_HighRisk(double tradeValue, ClientSectorEnum clientSector, bool result)
        {
            //Arrange
            _trade.Setup(x => x.Value).Returns(tradeValue);
            _trade.Setup(x => x.ClientSector).Returns(clientSector);
            var anyReferenceDate = DateTime.Now;

            //Act
            var risk = _highRisk.IsRisk(_trade.Object, anyReferenceDate);

            //Assert
            risk.Should().Be(result);

        }

        [TestCase("2000000", ClientSectorEnum.Public, true)]
        [TestCase("999999", ClientSectorEnum.Public, false)]
        [TestCase("2000000", ClientSectorEnum.Private, false)]
        public void TestShouldAssertCategoryRisk_MediumRisk(double tradeValue, ClientSectorEnum clientSector, bool result)
        {
            //Arrange
            _trade.Setup(x => x.Value).Returns(tradeValue);
            _trade.Setup(x => x.ClientSector).Returns(clientSector);
            var anyReferenceDate = DateTime.Now;

            //Act
            var risk = _mediumRisk.IsRisk(_trade.Object, anyReferenceDate);

            //Assert
            risk.Should().Be(result);
        }


    }
}
