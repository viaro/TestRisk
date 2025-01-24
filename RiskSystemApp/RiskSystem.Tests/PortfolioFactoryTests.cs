using FluentAssertions;
using RiskSystem.Domain;
using RiskSystem.Domain.Factories;
using RiskSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystem.Tests
{
    [TestFixture]
    public class PortfolioFactoryTests
    {
        public IPortfolioFactory _portfolioFactory;
        private static CultureInfo culture = new CultureInfo("en-US");

        [SetUp]
        public void Setup()
        {
            _portfolioFactory = new PortfolioFactory();
        }

        [Test]
        public void TestShouldAssertFactoryCreation()
        {
            //Arrange
            string date = "12/11/2020";
            DateTime parsedDate = DateTime.Parse(date, culture);

            //Act
            var result = _portfolioFactory.CreateIPortfolio(date);

            //Assert
            result.Should().NotBeNull();
            result.ReferenceDate.Should().Be(parsedDate);
        }

        [Test]
        public void TestShouldThrowException_DateValidation()
        {
            //Arrange
            string date = "20/01/2020";

            //Act
            Action act = () => _portfolioFactory.CreateIPortfolio(date);

            //Assert
            act.Should().Throw<Exception>()
                .WithMessage(ExceptionMessages.InvalidReferenceDate);
        }
    }
}
