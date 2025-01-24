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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RiskSystem.Tests
{
    [TestFixture]
    public class TradeFactoryTests
    {
        public ITradeFactory _tradeFactory;
        private static CultureInfo culture = new CultureInfo("en-US");

        [SetUp]
        public void Setup()
        {
            _tradeFactory = new TradeFactory();
        }

        [TestCase("2000000 Private 12/29/2025", 1, "12/29/2025", ClientSectorEnum.Private)]
        [TestCase("2000000 Private 12/29/2025 ", 1, "12/29/2025", ClientSectorEnum.Private)]
        [TestCase(" 2000000 Public 12/29/2025", 1, "12/29/2025", ClientSectorEnum.Public)]
        public void TestShouldAssertFactoryCreation(string tradeInput, int index,string strDate, ClientSectorEnum clientSector)
        {
            //Arrange
            DateTime parsedDate = DateTime.Parse(strDate, culture);

            //Act
            var result = _tradeFactory.CreateTrade(tradeInput,index);

            //Assert
            result.Should().NotBeNull();
            result.Value.Should().Be(2000000);
            result.ClientSector.Should().Be(clientSector);
            result.NextPaymentDate.Should().Be(parsedDate);
        }

        [TestCase("Private 12/29/2025")]
        [TestCase("2000000 Private")]
        public void TestShouldThrowException_InputLength(string tradeInput)
        {
            //Arrange

            //Act
            Action act = () => _tradeFactory.CreateTrade(tradeInput, 1);

            //Assert
            act.Should().Throw<Exception>()
                .WithMessage(ExceptionMessages.IncorrectInput(1));
        }

        [Test]
        public void TestShouldThrowException_ValueParse()
        {
            //Arrange
            string tradeInput = "NotAValue Private 12/29/2025";

            //Act
            Action act = () => _tradeFactory.CreateTrade(tradeInput, 1);

            //Assert
            act.Should().Throw<Exception>()
                .WithMessage(ExceptionMessages.IncorrectTradeValue(1));
        }

        [Test]
        public void TestShouldThrowException_EmptySector()
        {
            //Arrange
            string tradeInput = "2000000  12/29/2025";

            //Act
            Action act = () => _tradeFactory.CreateTrade(tradeInput, 1);

            //Assert
            act.Should().Throw<Exception>()
                .WithMessage(ExceptionMessages.EmptyClientSector(1));
        }

        [Test]
        public void TestShouldThrowExceptionInvalidSector()
        {
            //Arrange
            string tradeInput = "2000000 NotASector 12/29/2025";

            //Act
            Action act = () => _tradeFactory.CreateTrade(tradeInput, 1);

            //Assert
            act.Should().Throw<Exception>()
                .WithMessage(ExceptionMessages.InvalidClientSector(1));
        }

        [Test]
        public void TestShouldThrowException_DateValidation()
        {
            //Arrange
            string tradeInput = "2000000 Private 29/12/2025";

            //Act
            Action act = () => _tradeFactory.CreateTrade(tradeInput, 1);

            //Assert
            act.Should().Throw<Exception>()
                .WithMessage(ExceptionMessages.InvalidPaymentDate(1));
        }
    }
}
