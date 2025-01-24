using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystem.Domain.Interfaces
{
    public interface IPortfolio
    {
        DateTime ReferenceDate { get; }
        List<ITrade> Trades { get; }
        void AddTrade(ITrade trade);
        
    }
}
