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

        // ... (existing code)

        // Metod för att öppna ett nytt konto
        public static void AddNewAccount()
        {
            Console.WriteLine("Enter the initial balance for the new account:");
            if (!double.TryParse(Console.ReadLine(), out double initialBalance))
            {
                Console.WriteLine("Invalid input for initial balance.");
                return;
            }

            Console.WriteLine("Choose a currency: Enter 'SEK' for Swedish Krona or 'Dollar' for US Dollar");
            string currencyChoice = Console.ReadLine()?.ToLower() ?? ""; // Handling null reference here

            CurrencyType chosenCurrency;
            switch (currencyChoice)
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

            // Create an instance of the Account class
            Account newAccount = new Account("", 0, CurrencyType.SEK);

            // Here the chosen currency is set to the initial balance
            newAccount.SetInitialBalance(initialBalance, chosenCurrency);

            // Generate a unique 8-digit random bank account number
            string generatedAccountNumber = GenerateRandomAccountNumber();

            Console.WriteLine($"New account {generatedAccountNumber} opened with initial balance: {initialBalance} {chosenCurrency}");
        }

        // Helper method to set the initial balance based on the chosen currency
        private void SetInitialBalance(double initialBalance, CurrencyType currencyType)
        {
            if (UserCurrency == null)
            {
                Console.WriteLine("Error: UserCurrency is null.");
                return;
            }

            UserCurrency = new Currency(0, 0); // initialize with 0 balance
            UserCurrency.UpdateExchangeRate(); // ask for initial exchange rate

            // Set the balance based on the chosen currency
            if (currencyType == CurrencyType.SEK)
            {
                Balance = initialBalance;
            }
            else
            {
                if (UserCurrency.ExchangeRate != 0) // Handling potential divide by zero
                {
                    Balance = initialBalance / UserCurrency.ExchangeRate;
                }
                else
                {
                    Console.WriteLine("Error: Exchange rate is zero.");
                }
            }
        }

        // Helper method to generate a unique 8-digit random bank account number
        private static string GenerateRandomAccountNumber()
        {
            Random random = new Random();
            bool isUnique = false;
            string generatedAccountNumber = string.Empty;

            while (!isUnique)
            {
                int randomNumber = random.Next(10000000, 99999999);
                generatedAccountNumber = randomNumber.ToString();

                // Check if the generated number is unique (you need to implement this logic)
                // For simplicity, assuming it's always unique in this example
                isUnique = true;
            }

            return generatedAccountNumber;
        }
    }
}

