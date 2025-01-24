using RiskSystem.Domain.Entities;
using RiskSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystem.Domain.Factories
{
    public class TradeFactory : ITradeFactory
    {
        private static CultureInfo culture = new CultureInfo("en-US");
        private readonly List<string> ClientSectors = new List<string>() { "PRIVATE", "PUBLIC" };

        public ITrade CreateTrade(string tradeInput, int index)
        {
            tradeInput = tradeInput.Trim();
            string[] tradeValues = tradeInput.Split(' ');

            if (tradeValues.Length != 3)
            {
                throw new Exception(ExceptionMessages.IncorrectInput(index));
            }

            if (!double.TryParse(tradeValues[0], out double value))
            {
                throw new Exception(ExceptionMessages.IncorrectTradeValue(index));
            }

            if (String.IsNullOrEmpty(tradeValues[1]))
            {
                throw new Exception(ExceptionMessages.EmptyClientSector(index));
            }
            string strClientSector = tradeValues[1];

            if (!ClientSectors.Contains(strClientSector.ToUpper()))
            {
                throw new Exception(ExceptionMessages.InvalidClientSector(index));
            }
            Enum.TryParse(strClientSector, out ClientSectorEnum clientSector);

            if (!DateTime.TryParseExact(tradeValues[2], "MM/dd/yyyy", culture, DateTimeStyles.None, out DateTime nextPaymentDate))
            {
                throw new Exception(ExceptionMessages.InvalidPaymentDate(index));
            }

            ITrade trade = new Trade(value, clientSector, nextPaymentDate);

            return trade;
        }
    }
}
