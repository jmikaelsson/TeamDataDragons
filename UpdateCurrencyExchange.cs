using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public static class UpdateCurrencyExchange
    {
        public static double Interest { get; set; } = 0.01;

        public static double ExchangeRate { get; set; } = 1.2;

        public static void UpdateExchangeRate()  // updates the exchange rate
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("─── Update exchange rate ────────────────────────────────────────────────────────────────────\n");
            Console.ResetColor();
            Console.WriteLine("Enter the updated exchange rate: ");
            ExchangeRate = double.Parse(Console.ReadLine());
            Console.WriteLine($"\nThe interest have been updated to all customers by {ExchangeRate} \nPress Enter to return to menu. ");
            Console.ReadKey();
        }
        public static void InterestRate() // updates interest
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("─── Update inetrest rate ────────────────────────────────────────────────────────────────────\n");
            Console.ResetColor();
            Console.WriteLine("Enter the updated Intrest rate: ");
            Interest = double.Parse(Console.ReadLine());
            Console.WriteLine($"\nThe interest have been updated to all customers by {Interest}  \nPress Enter to return to menu.");
            Console.ReadKey();
        }
    }
}
