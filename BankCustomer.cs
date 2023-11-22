using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public class BankCustomer : AbstractUser
    {
        //List to store bank accounts.
        public List<Account> accounts = new List<Account>();
        public List<Loan> loans = new List<Loan>();


        //Constructor
        public BankCustomer(string username, string password, string name, int personalnumber, bool isadmin = false)
            : base(username, password, name, personalnumber, isadmin)
        {
            
        }

        //Override method to print customer info.
        public override void PrintInfo()
        {
            Console.WriteLine($"Name {Name}\nID: {ID}\nPersonal Number: {PersonalNumber}");
            
        }

        public void CheckBalance(List<Account> accounts)
        {
            
            if(accounts.Count == 0)
            {
                Console.WriteLine($"There is no active accounts");
            }
            else
            {
                foreach (var Account in accounts)
                {
                    Console.WriteLine($"Bankaccount: {Account.BankAccountNumber} Balance: {Account.Balance}");
                }
            }
            Console.WriteLine($"Press enter to return to menu");
            Console.ReadKey();
        }
        public void CheckLoan(List<Loan> loans)
        {
            
            if(loans.Count == 0)
            {
                Console.WriteLine($"There is no active loans");
            }
            else
            {
                foreach (var Loan in loans)
                {
                    Console.WriteLine($"Loan: {Loan.LoanNumber} Balance: {Loan.BankLoan} ");
                }
            }
            Console.WriteLine($"Press enter to return to menu");
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

            BankLogo bankLogo = new();
            bankLogo.DragonBank();
            Savings saving = new();
            PrintInfo();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*** Bank Customer Menu ***");
                Console.WriteLine("Select option (1-8):");
                Console.WriteLine("1. View bankaccounts and balance\n2. Transfer money between accounts\n" +
                    "3. Transfer money to other customers\n4. Open new account\n5. Savings 6. View transfer log\n7. My Loans\n8. Apply for a loan\n9. Log out");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CheckBalance(accounts);
                        break;
                    case 2:

                        Account.ShowMenuTransferMoneyBetWeenAccounts(accounts);
                        break;
                    case 3:
                        Account.ShowMenuTransferMoneyBetweenCustomers(accounts);

                        break;
                    case 4:
                        accounts.Add(Account.AddNewAccount());
                        break;
                    case 5:
                        saving.SavingMenu();
                        break;
                    case 6:
                       foreach (var account in accounts)
                        {
                            account.PrintTransferLogs();
                            Console.ReadKey();
                        }
                        break;
                    case 7:
                        CheckLoan(loans);
                        break;
                    case 8:
                        Loan NewLoan = new(totalLoans);
                        NewLoan.ApplyForALoan(accounts, loans);
                        break;
                    case 9:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;

                }
            } 
        } 
    }
}
