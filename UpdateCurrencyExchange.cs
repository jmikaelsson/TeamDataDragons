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


            bool check = false;

            do
            {
                Console.WriteLine("Enter the updated exchange rate: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out double newExchangeRate))
                {
                    ExchangeRate = newExchangeRate;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n─── New exchange rate ───");
                    Console.ResetColor();
                    Console.WriteLine($"\nThe exchange rate has been updated to {ExchangeRate}.");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.ResetColor();
                    Console.WriteLine("Press Enter to return to the menu.");
                    check = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("─── Invalid input. Please enter a valid number. ───");
                    Console.ResetColor();
                }

            } while (!check);
 
            Console.ReadKey();
        }
        public static void InterestRate() // updates interest
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("─── Update inetrest rate ────────────────────────────────────────────────────────────────────\n");
            Console.ResetColor();


            bool check = false;

            do
            {
                Console.WriteLine("Enter the updated interest rate: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out double newInterest))
                {
                    Interest = newInterest;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n─── New intrest rate ───");
                    Console.ResetColor();
                    Console.WriteLine($"\nThe interest rate has been updated to {Interest}.");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.ResetColor();
                    Console.WriteLine("Press Enter to return to the menu.");
                    check = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("─── Invalid input. Please enter a valid number. ───");
                    Console.ResetColor();

                }

            } while (!check);


            Console.ReadKey();
        }
    }
}
