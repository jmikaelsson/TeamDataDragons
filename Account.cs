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

    public enum AccountType
    {
        Savings,
        Salary
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
        public double Balance { get;  set; }
        public string BankAccountNumber { get;  set; }
        public AccountCurrency UserCurrency { get;  set; }
        public AccountType Type { get;  set; }

        public Account(string bankAccountNumber, double initialBalance, CurrencyType currencyType, AccountType accountType)
        {
            BankAccountNumber = bankAccountNumber;
            UserCurrency = new AccountCurrency(0, 0);
            SetInitialBalance(initialBalance, currencyType);
            Type = accountType;
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
                return new Account("", 0, CurrencyType.SEK, AccountType.Savings);
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

            Console.WriteLine("Choose the account type: Enter 'Savings' or 'Salary'");
            string accountTypeChoice = Console.ReadLine()?.ToLower() ?? "";

            AccountType chosenAccountType;
            switch (accountTypeChoice)
            {
                case "savings":
                    chosenAccountType = AccountType.Savings;
                    break;
                case "salary":
                    chosenAccountType = AccountType.Salary;
                    break;
                default:
                    Console.WriteLine("Invalid account type. Defaulting to Savings.");
                    chosenAccountType = AccountType.Savings;
                    break;
            }

            Account newAccount = new Account("", 0, CurrencyType.SEK, AccountType.Savings);
            newAccount.SetInitialBalance(initialBalance, chosenCurrency);
            newAccount.GenerateRandomAccountNumber();
            newAccount.Type = chosenAccountType;

            Console.WriteLine($"New {chosenAccountType} account {newAccount.BankAccountNumber} opened with initial balance: {initialBalance} {chosenCurrency}");

            return newAccount;
        }

        public void TransferMoneyBetweenAccounts(Account recipientAccount, double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid transfer amount.");
                return;
            }

            if (Balance < amount)
            {
                Console.WriteLine("Insufficient funds for the transfer.");
                return;
            }

            // Transfer money
            Balance -= amount;
            recipientAccount.Balance += amount;

            Console.WriteLine($"Transfer successful. New balance for {BankAccountNumber}: {Balance}, New balance for {recipientAccount.BankAccountNumber}: {recipientAccount.Balance}");
        }

        public static void ShowMenu(List<Account> accounts)
        {
            Console.WriteLine("Accounts:");
            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {accounts[i].BankAccountNumber} ({accounts[i].Type})");
            }

            Console.WriteLine("Choose the source account (enter the corresponding number):");
            if (!int.TryParse(Console.ReadLine(), out int sourceIndex) || sourceIndex < 1 || sourceIndex > accounts.Count)
            {
                Console.WriteLine("Invalid input. Aborting operation.");
                return;
            }

            Console.WriteLine("Choose the destination account (enter the corresponding number):");
            if (!int.TryParse(Console.ReadLine(), out int destinationIndex) || destinationIndex < 1 || destinationIndex > accounts.Count || destinationIndex == sourceIndex)
            {
                Console.WriteLine("Invalid input. Aborting operation.");
                return;
            }

            Console.WriteLine("Enter the amount to transfer:");
            if (!double.TryParse(Console.ReadLine(), out double transferAmount) || transferAmount <= 0)
            {
                Console.WriteLine("Invalid transfer amount. Aborting operation.");
                return;
            }

            Account sourceAccount = accounts[sourceIndex - 1];
            Account destinationAccount = accounts[destinationIndex - 1];

            sourceAccount.TransferMoneyBetweenAccounts(destinationAccount, transferAmount);
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
