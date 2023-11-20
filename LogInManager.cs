using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    internal class LogInManager 
    {
        private int Attempts { get; set; }
        private int MaxAttempt { get; set; }
        private List<AbstractUser> BankUsers { get; set; }

        public LogInManager(List<AbstractUser> bankUsers, int maxAttemts = 3)
        {
            Attempts = 0;
            MaxAttempt = maxAttemts;
            BankUsers = bankUsers;

        }
        
        public AbstractUser LogInUser(string inputUserName, string inputPassword)
        {
            return BankUsers.Find(user => user.UserName == inputUserName && user.PassWord == inputPassword); 

        }

        public void TryToLogin()
        {
            while (Attempts <= MaxAttempt)
            {
                
                Attempts++;
                Console.WriteLine("***Login***\n");
                Console.Write("Username: ");
                string inputUserName = Console.ReadLine();
                Console.Write("Password: ");
                string inputPassword = Console.ReadLine();
                var user = LogInUser(inputUserName, inputPassword);
                if (user != null)
                {
                    if (user is Admin admin)
                    {
                        admin.AdministratorMenu(BankUsers);
                    }
                    if (user is BankCustomer customer)
                    {
                        customer.CustomerMenu();
                    }
                }
                else
                {
                    Console.WriteLine("Username or password is incorrect!");
                }
                Console.Clear();
            }

        }
        
    }
}
