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

        public void CheckBalance()
        {
            foreach(var Account in Accounts)
            {
                Console.WriteLine($"Bankaccount: {Account.BankAccountNumber} Balance: {Account.Balance}");
            }
        }

        //Method to display the customer menu.

        public void CustomerMenu()
        {
            PrintInfo();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*** Bank Customer Menu ***");
                Console.WriteLine("Select option (1-8):");
                Console.WriteLine("1. View bankaccounts and balance\n2. Transfer money between accounts\n" +
                    "3. Transfer money to other customers\n4. Open new account\n5. View transfer log\n6. My Loans\n7. Apply for a loan\n8. Log out");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CheckBalance();
                        break;
                    case 2:
                        //TransferMoneyBetWeenAccounts();
                        break;
                    case 3:
                        //TransferMoneyBetweenCustomers();
                        break;
                    case 4:
                        Account.AddNewAccount();
                        break;
                    case 5:
                        //TransferLog();
                        break;
                    case 6:
                        Loan.CheckLoan();
                        break;
                    case 7:
                        Loan.ApplyForALoan();
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;

                }
            } 
        } 
    }
}
