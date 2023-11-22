using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public class UpdateCurrencyExchange
    {
        public double Interest;

        public double ExchangeRate;
        public void UpdateExchangeRate()  // updates the exchange rate
        {
            Console.WriteLine("Enter the updated exchange rate: ");
            ExchangeRate = double.Parse(Console.ReadLine());
            Console.WriteLine($"the interest have been updated to all customers by {ExchangeRate} \n press enter to go back ");
            Console.ReadKey();
        }
        public void InterestRate() // updates interest
        {
            Console.WriteLine("Enter the updated Intrest rate: ");
            Interest = double.Parse(Console.ReadLine());
            Console.WriteLine($"the interest have been updated to all customers by {Interest}  \n press enter to go back");
            Console.ReadKey();
        }
    }
}
