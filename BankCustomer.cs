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

        //Method to display the customer menu.
        public void CustomerMenu()
        {
            while (true)
            {
                Console.WriteLine("*** Bank Customer Menu ***");
                Console.WriteLine("1. View bankaccounts and balance\n2. Transfer money between accounts\n" +
                    "3. Transfer money to other customers\n4. Open new account\n5.View transfer log\n6.My Loans\n7.Apply for a loan\n8. Log out");

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
                        //AddNewAccount(); //Välj SEK eller Dollar
                        break;
                    case 5:
                        //TransferLog();
                        break;
                    case 6:
                        //Myloans();
                        break;
                    case 7:
                        //ApplyLoan();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;

                }
            }
        }
    }
}
