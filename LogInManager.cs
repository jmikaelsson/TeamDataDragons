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
        private int MaxAttempts { get; set; }
        private List<AbstractUser> BankUsers { get; set; }

        public LogInManager(List<AbstractUser> bankUsers, int maxAttemts = 3)
        {
            Attempts = 0;
            MaxAttempts = maxAttemts;
            BankUsers = bankUsers;
        }
        
        public AbstractUser LogInUser(string inputUserName, string inputPassword)
        {
            return BankUsers.Find(user => user.UserName == inputUserName && user.PassWord == inputPassword); 
        }

        public void TryToLogin()
        {
            while (true)
            {
                BankLogo.DragonBank();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────\n");
                Console.ResetColor();
                Console.WriteLine("1. Login \n2. Exit");
                Console.ResetColor();
                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }

                while (Attempts < MaxAttempts)
                {
                    Console.Clear();
                    BankLogo.DragonBank();
                    Attempts++;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("─── Login ───────────────────────────────────────────────────────────────────────────────────");
                    Console.ResetColor();
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
                            Attempts = 0;
                            break;
                        }
                        if (user is BankCustomer customer)
                        {
                            customer.CustomerMenu();
                            Attempts = 0;
                            break;
                        }
                    }
                    else if (Attempts < MaxAttempts)
                    {
                        Console.WriteLine("\n──────────────────────────────\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Username or password is incorrect!");
                        Console.ResetColor();
                        Console.WriteLine("\nPress Enter to try again");
                        Console.ReadKey();
                    }
                }
                if (Attempts >= MaxAttempts)
                {
                    Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Too many incorrect attempts");
                    Console.ResetColor();
                    Console.WriteLine("\nPress Enter to exit");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }
    }
}
