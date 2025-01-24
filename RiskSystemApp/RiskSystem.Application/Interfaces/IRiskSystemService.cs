using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystem.Application.Interfaces
{
    public interface IRiskSystemService
    {
        List<string> AssessPortfolioRisk(string referenceDate, List<string> Trades);
    }
}
