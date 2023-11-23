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
                Console.WriteLine("─── Savings Menu ────────────────────────────────────────────────────────────────────────────" +
                    "\nSelect option (1-4)");

                Console.WriteLine("\n1. Deposit money.\n2. Withdraw money.\n3. View savings balance.\n4. Go back to customer menu.");

                string savingSelection = Console.ReadLine();

                //A switch that goes to the case that admin selects
                switch (savingSelection)
                {
                    case "1":
                        Console.Clear();
                        DepositMoney(accounts);
                        break;
                    case "2":
                        Console.Clear();
                        WithdrawMoney(accounts);
                        break;
                    case "3":
                        Console.Clear();
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
            Console.WriteLine("─── Deposit Money ───────────────────────────────────────────────────────────────────────────\n");

            Account savingAccount = accounts.FirstOrDefault(account => account.Type == AccountType.Savings);
            bool listContain = accounts.Contains(savingAccount);

            if (listContain)
            {
                Console.Write("Enter amount to deposit: ");
                if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
                {
                    SavingSaldo += amount;
                    Console.WriteLine("─── Following amount has been deposited: ───\n");

                    Console.WriteLine($"Amount: {amount} SEK .\n The new balance is {SavingSaldo} SEK.\n" +
                        $"The interest on your savings account is: {UpdateCurrencyExchange.Interest} ");
                }
                else
                {
                    
                    Console.WriteLine("─── Invalid amount, deposit failed. ───");
                }
            }
            else
            {
                Console.WriteLine("─── There are no savings accounts found. ───");
            }
            Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadKey();
            
        }


        public void WithdrawMoney(List<Account> accounts)
        {
            Account savingAccount = accounts.FirstOrDefault(account => account.Type == AccountType.Savings);
            bool listContain = accounts.Contains(savingAccount);

            Console.WriteLine("─── Withdraw Money ──────────────────────────────────────────────────────────────────────────\n");
            if (listContain)
            {
                Console.Write("Enter amount to withdraw: ");
                if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
                {
                    if (amount <= SavingSaldo)
                    {
                        SavingSaldo -= amount;
                        Console.WriteLine("─── Following amount has been withdrawn ───\n");
                        Console.WriteLine($"Amount: {amount} SEK \nThe new balance is {SavingSaldo} SEK.");
                    }
                    else
                    {
                        Console.WriteLine("─── Insufficient balance to complete the withdrawal. ───");
                    }
                }
                else
                {
                    Console.WriteLine("─── Invalid amount. Withdrawal failed. ───");
                }
            }
            Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadKey();
            return;
        }

        public void ShowSavingsBalance(List<Account> accounts)
        {
            Account savingAccount = accounts.FirstOrDefault(account => account.Type == AccountType.Savings);
            bool listContain = accounts.Contains(savingAccount);
            Console.WriteLine("─── Savings ─────────────────────────────────────────────────────────────────────────────────\n");
            if (listContain)
            {
                Console.WriteLine($"Current Balance is: {SavingSaldo}");
            }
            else
            {
                Console.WriteLine("─── There is no account to display. ───");
            }
            Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadKey();
            
        }
    }
}
