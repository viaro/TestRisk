using RiskSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystem.Domain.Entities
{
    public class Portfolio : IPortfolio
    {
        public DateTime ReferenceDate { get; }
        public List<ITrade> Trades { get; } = new List<ITrade>();

        public Portfolio(DateTime referenceDate)
        {
            ReferenceDate = referenceDate;
        }

        public void AddTrade(ITrade trade)
        {
            Trades.Add(trade);
        }
    }
}
