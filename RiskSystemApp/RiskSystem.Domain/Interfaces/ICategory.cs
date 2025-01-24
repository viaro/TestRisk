using RiskSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystem.Domain.Interfaces
{
    public interface ICategory
    {
        string Name { get; }
        bool IsRisk(ITrade trade, DateTime referenceDate);
    }
}
