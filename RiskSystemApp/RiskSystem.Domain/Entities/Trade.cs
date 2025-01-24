using RiskSystem.Domain.Entities.Categories;
using RiskSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystem.Domain.Entities
{
    public class Trade : ITrade
    {
        public double Value { get; }

        public ClientSectorEnum ClientSector { get; } = ClientSectorEnum.Undefined;

        public DateTime NextPaymentDate { get; }

        private readonly List<ICategory> Categories = new List<ICategory>
            {
                new Expired(),
                new HighRisk(),
                new MediumRisk()
            };

        public Trade(double value, ClientSectorEnum clientSector, DateTime nextPaymentDate)
        {
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
        }

        public string AssesRisk(DateTime referenceDate)
        {
            string result = "NotFound";
            foreach (var item in Categories)
            {
                if (item.IsRisk(this, referenceDate))
                {
                    result = item.Name;                    
                    break;
                }
            }
            return result;
        }
    }
}
