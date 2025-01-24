using RiskSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystem.Domain.Entities.Categories
{
    public class HighRisk : ICategory
    {
        public string Name => "HIGHRISK";

        public bool IsRisk(ITrade trade, DateTime referenceDate)
        {
            return trade.Value > 1000000 && trade.ClientSector.Equals(ClientSectorEnum.Private);
        }
    }
}
