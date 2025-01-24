using System.Diagnostics.CodeAnalysis;

namespace RiskSystem.Console
{
    [ExcludeFromCodeCoverage]
    public static class ConsoleMessages
    {
        public static string SetPortfolio { get; } = "Please, set the Portfolio";
        public static string ReferenceDate { get; } = "The first line of the input is the reference date(mm/dd/yyyy).";
        public static string TradeNumber { get; } = "The second line contains an integer n, the number of trades in the portfolio";
        public static string TradeInstructions { get; } = @"The next n lines contain 3 elements each (separated by a space):
First a double that represents trade amount
Second a string that represents the client’s sector (Public or Private)
Third a date that represents the next pending payment. (mm/dd/yyyy)";
        public static string AssessRisk { get; } = "Assessing Portfolio Risk";

        public static string Restart { get; } = "Hit enter to restart!";

        public static string InvalidTradeNumber { get; } = "Invalid number of operations!";
    }
}
