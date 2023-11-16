using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public class Currency
    {
        public double Dollar { get; set; }
        public double Sek { get; set; }
        public Currency(double sek, double dollar)
        {
            Dollar = dollar;
            Sek = sek;
        }
        public void ExchangeToUSD(double amountInSek)
        {
            Sek -= amountInSek;
            Dollar += amountInSek * 0.1;
            Console.WriteLine($"Exchanged {amountInSek} SEK to {amountInSek * 0.1} USD");
        }

        public void ExchangeToSEK(double amountInUSD)
        {

            Dollar -= amountInUSD;
            Sek += amountInUSD * 10;
            Console.WriteLine($"Exchanged {amountInUSD} Dollar to {amountInUSD * 10} SEK");
        }

        public void CurrencyRun()
        {
            double amountSek = double.Parse(Console.ReadLine()); // users balance in SEK

            double amountDollar = double.Parse(Console.ReadLine()); // users balance in dollar

            Currency userCurrency = new Currency(amountSek, amountDollar);
            Console.WriteLine($"your balance: {userCurrency.Sek} SEK and {userCurrency.Dollar} USD");


            Console.Write("to exchange SEK to USD tap 1 , to exchange USD to SEK tap 2? (1/2): ");
            string response = Console.ReadLine();

            if (response.ToLower() == "2")
            {
                Console.WriteLine("how much USD do you want to exchange to SEK?");
                double exchangeAamount = double.Parse(Console.ReadLine());
                userCurrency.ExchangeToSEK(exchangeAamount);   // User exchanges USD to SEK
            }
            else if (response.ToLower() == "1")
            {
                Console.WriteLine("");
                Console.WriteLine("how much SEK do you want to exchange to USD?");
                double exchangeAamount = double.Parse(Console.ReadLine());
                userCurrency.ExchangeToUSD(exchangeAamount);  // User exchanges SEK to USD
            }

  


            Console.WriteLine($"Updated balance: {userCurrency.Sek} sek and {userCurrency.Dollar} usd");  // Display updated balance
        }
    }
}
