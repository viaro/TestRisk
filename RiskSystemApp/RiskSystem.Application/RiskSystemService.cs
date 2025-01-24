using RiskSystem.Application.Interfaces;
using RiskSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystem.Application
{
    public class RiskSystemService : IRiskSystemService
    {
        private readonly IPortfolioFactory _portfolioFactory;
        private readonly ITradeFactory _tradeFactory;

        public RiskSystemService(IPortfolioFactory portfolioFactory, ITradeFactory tradeFactory)
        {
            _portfolioFactory = portfolioFactory;
            _tradeFactory = tradeFactory;
        }

        public List<string> AssessPortfolioRisk(string referenceDate, List<string> trades)
        {
            List<string> result = new List<string>();

            IPortfolio portfolio = _portfolioFactory.CreateIPortfolio(referenceDate);

            int index = 1;
            foreach (var item in trades)
            {
                ITrade trade = _tradeFactory.CreateTrade(item, index);
                portfolio.AddTrade(trade);
            }

            foreach (var item in portfolio.Trades)
            {
                result.Add(item.AssesRisk(portfolio.ReferenceDate));
            }

            return result;
        }
    }
}
