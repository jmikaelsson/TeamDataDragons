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
        public List<Account> Accounts = new List<Account>();

        //Properties for BankCustomer
        public double BankLoan { get; set; }
        public bool LockedOut { get; set; }

        public float Balance { get; set; }

        //Constructor
        public BankCustomer(string name, int id, int personalnumber, bool isadmin, double bankloan, bool lockedout, float balance) 
            : base(name, id, personalnumber, isadmin)
        {
            BankLoan = bankloan;
            LockedOut = lockedout;
            Balance = balance;
        }

        //Override method to print customer info.
        public override void PrintInfo()
        {
            Console.WriteLine($"Name {Name}\nID: {ID}\nPersonal Number: {PersonalNumber}\nIs Admin: {IsAdmin}");
            
        }

        //Method to display the customer menu.
        public void CustomerMenu()
        {
            while (true)
            {
                Console.WriteLine("*** Bank Customer Menu ***");
                Console.WriteLine("1. View bankaccounts and balance\n2. Transfer money between accounts\n" +
                    "3. Transfer money to other customers\n4. Open new account\n5.View transfer log\n6. Log out");

                Console.WriteLine("Select option (1-6):");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //List<Account> Accounts();
                        break;
                    case 2:
                        //TransferMoneyBetWeenAccounts();
                        break;
                    case 3:
                        //TransferMoneyBetweenCustomers();
                        break;
                    case 4:
                        //AddNewAccount();
                        break;
                    case 5:
                        TransferLog();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;

                }
            }
        }
        //Method to display transfer log.
        public void TransferLog()
        {
            Console.WriteLine("*** Transfer Log ***");

            Console.WriteLine($"Bank Accounts: ");
            //Loops through and displays info for each account.
            foreach (var account in Accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}, Balance: {account.Balance}");
            }
        }
        //Method to check balance.
        public void CheckBalance()
        {
            Console.WriteLine($"Your current balance in account {Accounts} is {Balance}");
        }
    }
}
