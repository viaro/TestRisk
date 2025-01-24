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
    public class PortfolioFactory: IPortfolioFactory
    {
        private static CultureInfo culture = new CultureInfo("en-US");

        public IPortfolio CreateIPortfolio(string date)
        {
            DateTime referenceDate;
            if (!DateTime.TryParseExact(date, "MM/dd/yyyy", culture, DateTimeStyles.None, out referenceDate))
            {
                throw new Exception(ExceptionMessages.InvalidReferenceDate);
            }

            IPortfolio portfolio = new Portfolio(referenceDate);
            return portfolio;
        }
    }
}
