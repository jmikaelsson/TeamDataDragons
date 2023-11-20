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

    public class AccountCurrency
    {
        public double Sek { get; set; }
        public double Dollar { get; set; }
        public double ExchangeRate { get; private set; }

        public AccountCurrency(double sek, double dollar)
        {
            Sek = sek;
            Dollar = dollar;
            UpdateExchangeRate(); // Initialize exchange rate
        }

        public void UpdateExchangeRate()
        {
            // Your logic to update the exchange rate goes here
            // For simplicity, let's set it to a fixed value for now
            ExchangeRate = 1.0;
        }
    }

    public class Account
    {
        public double Balance { get; private set; }
        public string BankAccountNumber { get; private set; }
        public AccountCurrency UserCurrency { get; private set; }

        public Account(string bankAccountNumber, double initialBalance, CurrencyType currencyType)
        {
            BankAccountNumber = bankAccountNumber;
            UserCurrency = new AccountCurrency(0, 0);
            SetInitialBalance(initialBalance, currencyType);
        }

        public void Interest()
        {
            double interestRate = 0.05;
            double interest = Balance * interestRate;
            Console.WriteLine($"For account {BankAccountNumber}, the interest will be: {interest}");
        }

        public static Account AddNewAccount()
        {
            Console.WriteLine("Enter the initial balance for the new account:");

            if (!double.TryParse(Console.ReadLine(), out double initialBalance))
            {
                Console.WriteLine("Invalid input for initial balance.");

                // Return a default Account instance
                return new Account("", 0, CurrencyType.SEK);

                return null;

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

            Account newAccount = new Account("", 0, CurrencyType.SEK);
            newAccount.SetInitialBalance(initialBalance, chosenCurrency);
            newAccount.GenerateRandomAccountNumber();

            Console.WriteLine($"New account {newAccount.BankAccountNumber} opened with initial balance: {initialBalance} {chosenCurrency}");

            return newAccount;
        }

        private void SetInitialBalance(double initialBalance, CurrencyType currencyType)
        {
            UserCurrency = new AccountCurrency(0, 0);
            UserCurrency.UpdateExchangeRate();

            if (currencyType == CurrencyType.SEK)
            {
                UserCurrency.Sek = initialBalance;
                Balance = initialBalance;
            }
            else
            {
                if (UserCurrency.ExchangeRate != 0)
                {
                    Balance = initialBalance / UserCurrency.ExchangeRate;
                }
                else
                {
                    Console.WriteLine("Error: Exchange rate is zero.");
                }

                UserCurrency.Dollar = initialBalance;
            }
        }

        private void GenerateRandomAccountNumber()
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

            BankAccountNumber = generatedAccountNumber;
        }
    }
}


