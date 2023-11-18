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

        // Constructor
        public Account(string bankAccountNumber, double initialBalance, CurrencyType currencyType)
        {
            BankAccountNumber = bankAccountNumber;
            UserCurrency = new Currency(0, 0); // initialize with 0 balance
            SetInitialBalance(initialBalance, currencyType);
        }

        // Method to calculate interest and display the result
        public void Interest()
        {
            double interestRate = 0.05; // Example interest rate of 5%
            double interest = Balance * interestRate;

            Console.WriteLine($"For account {BankAccountNumber}, the interest will be: {interest}");
        }

        // Public static method to add a new account
        public static void AddNewAccount()
        {
            Console.WriteLine("Enter the initial balance for the new account:");
            double initialBalance;

            while (!double.TryParse(Console.ReadLine(), out initialBalance))
            {
                Console.WriteLine("Invalid input. Please enter a valid initial balance:");
            }

            Console.WriteLine("Choose a currency: Enter 'SEK' for Swedish Krona or 'Dollar' for US Dollar");
            string currencyChoice = Console.ReadLine()?.ToLower() ?? "";

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

            // Generate a new account with a random and unique account number
            string generatedAccountNumber = GenerateRandomAccountNumber();
            Account newAccount = new Account(generatedAccountNumber, initialBalance, chosenCurrency);

            Console.WriteLine($"New account {newAccount.BankAccountNumber} opened with initial balance: {initialBalance} {chosenCurrency}");
        }

        // Helper method to set the initial balance based on the chosen currency
        private void SetInitialBalance(double initialBalance, CurrencyType currencyType)
        {
            UserCurrency = new Currency(0, 0); // initialize with 0 balance
            UserCurrency.UpdateExchangeRate(); // ask for initial exchange rate

            // Set the balance based on the chosen currency
            if (currencyType == CurrencyType.SEK)
            {
                Balance = initialBalance;
            }
            else
            {
                Balance = initialBalance / UserCurrency.ExchangeRate;
            }
        }

        // Helper method to generate a unique 8-digit random bank account number
        private static HashSet<string> usedAccountNumbers = new HashSet<string>();

        // Helper method to generate a unique 8-digit random bank account number
        private static string GenerateRandomAccountNumber()
        {
            Random random = new Random();
            string generatedAccountNumber;

            while (true)
            {
                int randomNumber = random.Next(10000000, 99999999);
                generatedAccountNumber = randomNumber.ToString();

                if (!usedAccountNumbers.Contains(generatedAccountNumber))
                {
                    usedAccountNumbers.Add(generatedAccountNumber);
                    break;
                }
            }

            return generatedAccountNumber;
        }
    }
}