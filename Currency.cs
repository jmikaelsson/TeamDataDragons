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
            Dollar += amountInSek / UpdateCurrencyExchange.ExchangeRate;
            Console.WriteLine($"Exchanged {amountInSek} SEK to {amountInSek / UpdateCurrencyExchange.ExchangeRate} USD");
        }

        public void ExchangeToSEK(double amountInUSD)
        {

            Dollar -= amountInUSD;
            Sek += amountInUSD * UpdateCurrencyExchange.ExchangeRate;
            Console.WriteLine($"Exchanged {amountInUSD} Dollar to {amountInUSD * UpdateCurrencyExchange.ExchangeRate} SEK");
        }
       

        public void CurrencyRun(Account balance)
        {
            

            Currency userCurrency = new Currency(balance.Balance, 0); // users Balance from Acount class
            Console.WriteLine($"your balance: {userCurrency.Sek} SEK and {userCurrency.Dollar} USD");


            
            bool KeepExchanging = true;
            while (KeepExchanging)
            {
                Console.Write("To exchange SEK to USD tap 1, to exchange USD to SEK tap 2, or type 'exit' to stop: ");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        Console.WriteLine("How much SEK do you want to exchange to USD?");
                        double exchangeAmount = double.Parse(Console.ReadLine());
                        userCurrency.ExchangeToUSD(exchangeAmount);  // User exchanges SEK to USD
                        Console.WriteLine($"Updated balance: {userCurrency.Sek} sek and {userCurrency.Dollar} usd");  // Display updated balance
                        break;
                    case "2":
                        Console.WriteLine("How much USD do you want to exchange to SEK?");
                        double exchangeAmount1 = double.Parse(Console.ReadLine());
                        userCurrency.ExchangeToSEK(exchangeAmount1);   // User exchanges USD to SEK
                        Console.WriteLine($"Updated balance: {userCurrency.Sek} sek and {userCurrency.Dollar} usd");  // Display updated balance
                        break;
                    case "exit":
                        // return to menu
                        KeepExchanging = false;
                        break;
                    default:
                        // wrong input
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter 1, 2, or 'exit'.");
                        Console.ResetColor();
                        break;

                }
            }

                
        }
    }
}
