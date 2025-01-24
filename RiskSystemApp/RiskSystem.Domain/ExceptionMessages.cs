using System;
using System.Diagnostics.CodeAnalysis;

namespace RiskSystem.Domain
{
    [ExcludeFromCodeCoverage]
    public static class ExceptionMessages
    {
        public static string IncorrectInput(int index) => $"Input is incorrect at {index}";

        public static string IncorrectTradeValue(int index) => $"Trade value is incorrect at {index}";

        public static string EmptyClientSector(int index) => $"Client Sector is empty at {index}";

        public static string InvalidClientSector(int index) => $"Client Sector is invalid at {index}";

        public static string InvalidReferenceDate { get; } = "Invalid date format";

        public static string InvalidPaymentDate(int index) => $"Payment Date is incorrect at {index}";
    }
}
