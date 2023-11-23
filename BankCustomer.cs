using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    //BankCustomer class represents a customer with specifik banking functionalities.
    public class BankCustomer : AbstractUser
    {
        //List to store bank accounts.
        public List<Account> accounts = new List<Account>();
        //List to store Loans
        public List<Loan> loans = new List<Loan>();


        //Constructor
        public BankCustomer(string username, string password, string name, int personalnumber, bool isadmin = false)
            : base(username, password, name, personalnumber, isadmin)
        {
        }

        //Override method to print customer info.
        public override void PrintInfo()
        {
            Console.WriteLine($"Name {Name}\nID: {ID}\nSocial security number: {PersonalNumber}");
            
        }
        //Method to check and display the balance of bank accounts.
        public void CheckBalance(List<Account> accounts)
        {
            Console.WriteLine("─── Accounts ────────────────────────────────────────────────────────────────────────────────\n");
            if (accounts.Count == 0)
            {
                Console.WriteLine($"There is no active accounts\n");
            }
            else
            {
                foreach (var Account in accounts)
                {
                    Console.WriteLine($"Bankaccount: {Account.BankAccountNumber}\nBalance: {Account.Balance}\n────────");
                }
            }
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────\n");
            Console.WriteLine($"Press Enter to return to menu");
            Console.ReadKey();
        }
        //Method to check and display loans.
        public void CheckLoan(List<Loan> loans)
        {
            Console.WriteLine("─── Loans ───────────────────────────────────────────────────────────────────────────────────\n");
            if (loans.Count == 0)
            {
                Console.WriteLine($"There is no active loans\n");
            }
            else
            {
                foreach (var Loan in loans)
                {
                    Console.WriteLine($"Loan: {Loan.LoanNumber} \nBalance: {Loan.BankLoan} \n────────");
                }
            }
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────\n");
            Console.WriteLine($"Press Enter to return to menu");
            Console.ReadKey();
        }

        //Method to display the customer menu.
        public void CustomerMenu()
        {
            List<Loan> loans = new();
            float totalLoans = 0;
            foreach(var Loan in loans)
            {
                totalLoans += Loan.TotalLoan;
            }

            while (true)
            {
                Console.Clear();
                BankLogo.DragonBank();
                Console.WriteLine("─── User information ────────────────────────────────────────────────────────────────────────\n");
                PrintInfo();
                Console.WriteLine("\n─── Bank Customer Menu ──────────────────────────────────────────────────────────────────────");
                Console.WriteLine("Select option (1-9):\n");
                Console.WriteLine("1. View bankaccounts and balance\n2. Transfer money between accounts\n" +
                    "3. Transfer money to other customers\n4. Open new account\n5. Savings\n6. View transfer log\n7. My Loans\n8. Apply for a loan\n9. Log out");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        CheckBalance(accounts);
                        break;
                    case 2:
                        Console.Clear();
                        Account.ShowMenuTransferMoneyBetWeenAccounts(accounts);
                        break;
                    case 3:
                        Console.Clear();
                        Account.ShowMenuTransferMoneyBetweenCustomers(accounts);
                        break;
                    case 4:
                        Console.Clear();
                        accounts.Add(Account.AddNewAccount());
                        break;
                    case 5:
                        Savings saving = new();
                        saving.SavingMenu(accounts);
                        break;
                    case 6:
                        Console.Clear();
                        Account.PrintTransferLogs(accounts);
                        break;
                    case 7:
                        Console.Clear();
                        CheckLoan(loans);
                        break;
                    case 8:
                        Console.Clear();
                        Loan NewLoan = new(totalLoans);
                        NewLoan.ApplyForALoan(accounts, loans);
                        break;
                    case 9:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } 
        } 
    }
}
