// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using RiskSystem.Application.Interfaces;
using RiskSystem.Console;
using RiskSystem.Infrastructure;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;

internal class Program
{
    private static CultureInfo culture = new CultureInfo("en-US");

    private static void Main(string[] args)
    {
        Console.WriteLine("Initializing");

        var serviceProvider = new ServiceCollection()
            .AddInfrastructureServices()
            .BuildServiceProvider();

        var service = serviceProvider.GetRequiredService<IRiskSystemService>();

        bool running = true;

        while (running)
        {
            List<string> trades = new List<string>();
            try
            {
                Console.WriteLine(ConsoleMessages.SetPortfolio);
                string referenceDate = GetReferenceDate();
                int tradeNumber = GetOperationsNumber();
                trades = GetTrades(tradeNumber);

                Console.WriteLine(ConsoleMessages.AssessRisk);

                var result = service.AssessPortfolioRisk(referenceDate, trades);

                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine(ConsoleMessages.Restart);
                Console.ReadLine();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ConsoleMessages.Restart);
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    private static string GetReferenceDate()
    {
        Console.WriteLine(ConsoleMessages.ReferenceDate);
        string referenceDateInput = Console.ReadLine();

        return referenceDateInput;
    }

    private static int GetOperationsNumber()
    {
        Console.WriteLine(ConsoleMessages.TradeNumber);
        if (!int.TryParse(Console.ReadLine(), out int number) || number <= 0)
        {
            throw new Exception(ConsoleMessages.InvalidTradeNumber);
        }
        return number;
    }

    private static List<string> GetTrades(int number)
    {
        Console.WriteLine(ConsoleMessages.TradeInstructions);
        List<string> result = new List<string>();
        string tradeInput = String.Empty;

        for (int i = 0; i < number; i++)
        {
            tradeInput = Console.ReadLine();
            result.Add(tradeInput);
        }

        return result;
    }

}