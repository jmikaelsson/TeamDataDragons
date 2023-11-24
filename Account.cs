using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            UpdateExchangeRate();
        }

        public void UpdateExchangeRate()
        {
            ExchangeRate = 1.0;
        }
    }

    public class Account
    {
        public double Balance { get;  set; }
        public string BankAccountNumber { get;  set; }
        public AccountCurrency UserCurrency { get;  set; }
        public AccountType Type { get;  set; }
        private List<string> transferLogs;

        public Account(string bankAccountNumber, double initialBalance, CurrencyType currencyType, AccountType accountType)
        {
            BankAccountNumber = bankAccountNumber;
            UserCurrency = new AccountCurrency(0, 0);
            SetInitialBalance(initialBalance, currencyType);
            Type = accountType;
            transferLogs = new List<string>();
        }

        public void Interest()
        {
            double interestRate = UpdateCurrencyExchange.Interest; // interest is updated by Admin
            double interest = Balance * interestRate;
            Console.WriteLine($"For account {BankAccountNumber}, the interest will be: {interest}");
            Console.WriteLine("Press enter to return to menu.");
            Console.ReadKey();
        }

        public static Account AddNewAccount()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("─── Add new account ─────────────────────────────────────────────────────────────────────────\n");
            Console.ResetColor();
            Console.WriteLine("Enter the initial balance for the new account:");

            if (!double.TryParse(Console.ReadLine(), out double initialBalance))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("─── Invalid input for initial balance. ───");
                Console.ResetColor();
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("─── Invalid currency choice. Defaulting to SEK. ───");
                    Console.ResetColor();
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("─── Invalid account type. Defaulting to Savings ───");
                    Console.ResetColor();
                    chosenAccountType = AccountType.Savings;
                    break;
            }

            Account newAccount = new Account("", 0, CurrencyType.SEK, AccountType.Savings);
            newAccount.SetInitialBalance(initialBalance, chosenCurrency);
            newAccount.GenerateRandomAccountNumber();
            newAccount.Type = chosenAccountType;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n─── New {chosenAccountType} account ───");
            Console.ResetColor();
            Console.WriteLine($"\n{newAccount.BankAccountNumber} opened with initial balance: {initialBalance} {chosenCurrency}");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
            Console.ResetColor();
            Console.WriteLine("Press enter to return to menu.");
            Console.ReadKey();
            return newAccount;
        }

        public void TransferMoneyBetweenAccounts(Account recipientAccount, double amount)
        {
            if (amount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("─── Invalid transfer amount. ───");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                Console.ResetColor();
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadKey();
                return;
            }

            if (Balance < amount)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("─── Insufficient funds for the transfer. ───");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                Console.ResetColor();
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadKey();
                return;
            }

            // Transfer money
            Balance -= amount;
            recipientAccount.Balance += amount;

            // Log the transfer
            string transferInfo = $" {amount} {UserCurrency} transferred from {BankAccountNumber} to {recipientAccount.BankAccountNumber}";
            transferLogs.Add(transferInfo);

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("\n─── Transfer successful. ───\n");
            Console.ResetColor();
            Console.WriteLine($"New balance for {BankAccountNumber}: {Balance} \nNew balance for {recipientAccount.BankAccountNumber}: {recipientAccount.Balance}");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
            Console.ResetColor();
            Console.WriteLine("Press enter to return to menu.");
            Console.ReadKey();
        }


        public static void ShowMenuTransferMoneyBetWeenAccounts(List<Account> accounts)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("─── Transfer money ──────────────────────────────────────────────────────────────────────────\n");
            Console.ResetColor();
            Console.WriteLine("Accounts:");
            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {accounts[i].Type}: {accounts[i].BankAccountNumber}, Balance:{accounts[i].Balance}");
            }

            Console.WriteLine("Choose the source account (enter the corresponding number):");
            if (!int.TryParse(Console.ReadLine(), out int sourceIndex) || sourceIndex < 1 || sourceIndex > accounts.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("─── Invalid input. Aborting operation. ───");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                Console.ResetColor();
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Choose the destination account (enter the corresponding number):");
            if (!int.TryParse(Console.ReadLine(), out int destinationIndex) || destinationIndex < 1 || destinationIndex > accounts.Count || destinationIndex == sourceIndex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("─── Invalid input. Aborting operation. ───");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                Console.ResetColor();
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter the amount to transfer:");
            if (!double.TryParse(Console.ReadLine(), out double transferAmount) || transferAmount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("─── Invalid transfer amount. Aborting operation. ───");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                Console.ResetColor();
                Console.WriteLine("Press enter to return to menu.");

                Console.ReadKey();
                return;
            }

            Account sourceAccount = accounts[sourceIndex - 1];
            Account destinationAccount = accounts[destinationIndex - 1];

            sourceAccount.TransferMoneyBetweenAccounts(destinationAccount, transferAmount);
        }

        public static void ShowMenuTransferMoneyBetweenCustomers(List<Account> accounts)
        {
            Console.WriteLine("Accounts:");
            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{accounts[i].Type}: {accounts[i].BankAccountNumber}, Balance:{accounts[i].Balance}");
                //Console.WriteLine("Press enter to return to menu.");
                //Console.ReadKey();
            }

            Console.WriteLine("Choose the source account (enter the corresponding number):");
            if (!int.TryParse(Console.ReadLine(), out int sourceIndex) || sourceIndex < 1 || sourceIndex > accounts.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("─── Invalid input. Aborting operation. ───");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                Console.ResetColor();
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Choose the destination account (enter the corresponding number):");
            if (!int.TryParse(Console.ReadLine(), out int destinationIndex) || destinationIndex < 1 || destinationIndex > accounts.Count || destinationIndex == sourceIndex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("─── Invalid input. Aborting operation. ───");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                Console.ResetColor();
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter the amount to transfer:");
            if (!double.TryParse(Console.ReadLine(), out double transferAmount) || transferAmount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("─── Invalid transfer amount. Aborting operation. ───");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                Console.ResetColor();
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadKey();
                return;
            }

            Account sourceAccount = accounts[sourceIndex - 1];
            Account destinationAccount = accounts[destinationIndex - 1];

            if (sourceAccount.Balance < transferAmount)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("─── Insufficient funds for the transfer. Aborting operation. ───");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                Console.ResetColor();
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadKey();
                return;
            }

            sourceAccount.TransferMoneyBetweenAccounts(destinationAccount, transferAmount);
        }

        public static void PrintTransferLogs(List<Account> accounts)

        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("─── Transfer log ───────────────────────────────────────────────────────────────────────────\n");
            Console.ResetColor();
            foreach (var account in accounts)
            {
                if (account.transferLogs.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n─── No transfer logs available for account {account.BankAccountNumber}. ───");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"Transfer Logs for account {account.BankAccountNumber}:");
                    foreach (var log in account.transferLogs)
                    {
                        Console.WriteLine(log);
                        Console.WriteLine();
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                Console.ResetColor();
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadKey();
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" ─── Error: Exchange rate is zero. ───");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.ResetColor();
                    Console.WriteLine("Press enter to return to menu.");
                    Console.ReadKey();
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
                isUnique = true;
            }

            BankAccountNumber = generatedAccountNumber;
        }
    }
}
