using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TeamDataDragons
{
    public class Savings
    {
        public double SavingSaldo { get; set; }
        

        public Savings()
        {
 
        }

        public void SavingMenu(List<Account> accounts)
        {
            //Account savingAccount = accounts.FirstOrDefault(account => account.Type == AccountType.Savings);
            //bool listContain = accounts.Contains(savingAccount);

            foreach (Account account in accounts.FindAll(account => account.Type == AccountType.Savings).ToList())
            {
                SavingSaldo += (float)account.Balance;
            }

            bool menu = true;
            while(menu)
            {
                Console.Clear();
                Console.WriteLine("*** Savings Menu ***\n" +
                    "Select option (1-4)\n1. Deposit money.\n2. Withdraw money.\n3. View savings balance.\n4. Go back in the menu.");

                string savingSelection = Console.ReadLine();

                //A switch that goes to the case that admin selects
                switch (savingSelection)
                {
                    case "1":
                        DepositMoney(accounts);
                        break;
                    case "2":
                        WithdrawMoney(accounts);
                        break;
                    case "3":
                        ShowSavingsBalance(accounts);
                        break;
                    case "4":
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
           
        }
        public void DepositMoney(List<Account> accounts)
        {
            

            Account savingAccount = accounts.FirstOrDefault(account => account.Type == AccountType.Savings);
            bool listContain = accounts.Contains(savingAccount);

            if (listContain)
            {
                Console.Write("Enter amount to deposit: ");
                if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
                {
                    SavingSaldo += amount;
                    Console.WriteLine($"{amount} SEK has been deposited into the account. The new balance is {SavingSaldo} SEK.\n" +
                        $"The interest on your savings account is: {UpdateCurrencyExchange.Interest} ");
                }
                else
                {
                    Console.WriteLine("Invalid amount, deposit failed.");
                }
            }
            else
            {
                Console.WriteLine("There are no savings accounts found.");
            }

            Console.WriteLine("Press enter to return to menu.");
            Console.ReadKey();
            
        }


        public void WithdrawMoney(List<Account> accounts)
        {
            Account savingAccount = accounts.FirstOrDefault(account => account.Type == AccountType.Savings);
            bool listContain = accounts.Contains(savingAccount);

            if (listContain)
            {
                Console.Write("Enter amount to withdraw: ");
                if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
                {
                    if (amount <= SavingSaldo)
                    {
                        SavingSaldo -= amount;
                        Console.WriteLine($"{amount} SEK has been withdrawn from the account. The new balance is {SavingSaldo} SEK.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance to complete the withdrawal.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount. Withdrawal failed.");
                }
            }

            Console.WriteLine("Press enter to return to menu.");
            Console.ReadKey();
            return;
        }

        public void ShowSavingsBalance(List<Account> accounts)
        {
            Account savingAccount = accounts.FirstOrDefault(account => account.Type == AccountType.Savings);
            bool listContain = accounts.Contains(savingAccount);

            if (listContain)
            {
                Console.WriteLine($"Current Balance is: {SavingSaldo}");
            }
            else
            {
                Console.WriteLine("There is no account to display. ");
            }

            Console.WriteLine("Press enter to return to menu.");
            Console.ReadKey();
            
        }
    }
}
