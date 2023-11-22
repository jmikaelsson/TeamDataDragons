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
            Console.WriteLine("Enter the updated exchange rate: ");
            ExchangeRate = double.Parse(Console.ReadLine());
            Console.WriteLine($"the interest have been updated to all customers by {ExchangeRate} \n press enter to go back ");
            Console.ReadKey();
        }
        public static void InterestRate() // updates interest
        {
            Console.WriteLine("Enter the updated Intrest rate: ");
            Interest = double.Parse(Console.ReadLine());
            Console.WriteLine($"the interest have been updated to all customers by {Interest}  \n press enter to go back");
            Console.ReadKey();
        }
    }
}
