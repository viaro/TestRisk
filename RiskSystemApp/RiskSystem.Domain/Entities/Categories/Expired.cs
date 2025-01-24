using RiskSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystem.Domain.Entities.Categories
{
    public class Expired : ICategory
    {
        public string Name => "EXPIRED";

        public bool IsRisk(ITrade trade, DateTime referenceDate)
        {
            return (referenceDate - trade.NextPaymentDate).TotalDays > 30;
        }
    }
}
