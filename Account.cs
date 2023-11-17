using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public enum CurrencyType
    {
        SEK,
        Dollar
    }

    public class Account
    {
        // Bankkontoattribut
        public double Balance { get; set; }
        public string BankAccountNumber { get; set; }
        public Currency UserCurrency { get; private set; }

        // Konstruktor
        public Account(string bankAccountNumber, double initialBalance, CurrencyType currencyType)
        {
            BankAccountNumber = bankAccountNumber;
            UserCurrency = new Currency(0, 0); // initialize with 0 balance
            SetInitialBalance(initialBalance, currencyType);
        }

        // Metod för att beräkna ränta och visa resultatet
        public void Interest()
        {
            double interestRate = 0.05; // Exempelräntesats på 5%
            double interest = Balance * interestRate;
            Console.WriteLine($"For account {BankAccountNumber}, the interest will be: {interest}");
        }

        // Metod för att öppna ett nytt konto
        public void AddNewAccount()
        {
            Console.WriteLine("Enter the initial balance for the new account:");
            double initialBalance = double.Parse(Console.ReadLine());

            Console.WriteLine("Choose a currency: Enter 'SEK' for Swedish Krona or 'Dollar' for US Dollar");
            string currencyChoice = Console.ReadLine();

            CurrencyType chosenCurrency;
            switch (currencyChoice.ToLower())
            {
                case "sek":
                    chosenCurrency = CurrencyType.SEK;
                    break;
                case "dollar":
                    chosenCurrency = CurrencyType.Dollar;
                    break;
                default:
                    Console.WriteLine("Invalid currency choice. Defaulting to SEK.");
                    chosenCurrency = CurrencyType.SEK;
                    break;
            }

            // Here the chosen currency is set to the initial balance
            SetInitialBalance(initialBalance, chosenCurrency);

            // Generate a unique 8-digit random bank account number
            GenerateRandomAccountNumber();

            Console.WriteLine($"New account {BankAccountNumber} opened with initial balance: {initialBalance} {chosenCurrency}");
        }

        // Helper method to set the initial balance based on the chosen currency
        private void SetInitialBalance(double initialBalance, CurrencyType currencyType)
        {
            UserCurrency = new Currency(0, 0); // initialize with 0 balance
            UserCurrency.UpdateExchangeRate(); // ask for initial exchange rate

            // Set the balance based on the chosen currency
            if (currencyType == CurrencyType.SEK)
            {
                UserCurrency.Sek = initialBalance;
            }
            else
            {
                UserCurrency.Dollar = initialBalance;
            }
        }

        // Helper method to generate a unique 8-digit random bank account number
        private void GenerateRandomAccountNumber()
        {
            Random random = new Random();
            bool isUnique = false;

            while (!isUnique)
            {
                int randomNumber = random.Next(10000000, 99999999);
                BankAccountNumber = randomNumber.ToString();

                isUnique = true;
            }
        }
    }
}