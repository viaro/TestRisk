using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskSystem.Domain.Interfaces
{
    public interface ITrade
    {
        double Value { get; } //indicates the transaction amount in dollars
        ClientSectorEnum ClientSector { get; } //indicates the client´s sector which can be "Public" or "Private"
        DateTime NextPaymentDate { get; } //indicates when the next payment from the client to the bank is expected

        string AssesRisk(DateTime referenceDate);
    }
}
