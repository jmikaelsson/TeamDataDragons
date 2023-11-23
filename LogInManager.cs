using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TeamDataDragons
{
    internal class LogInManager 
    {
        private int Attempts { get; set; }
        private int MaxAttempts { get; set; }
        private List<AbstractUser> BankUsers { get; set; } //get the list of users in the system

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
                Console.Clear();
                BankLogo.DragonBank();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────\n");
                Console.ResetColor();
                Console.WriteLine("1. Login \n2. Exit");
                Console.ResetColor();
                string choise = Console.ReadLine();
                //menu for user to choose to login or exit the program
                switch (choise) 
                {
                    case "1":
                        break;
                    case "2":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("─── Invalid input, press enter to try again ───");
                        Console.ResetColor();
                        Console.ReadKey();
                        TryToLogin();
                        break;
                }

                while (Attempts < MaxAttempts) //user has a maximun attemts to try to login
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
                        //if the username and password is correct with an user thats is regersterd as admin 
                        if (user is Admin admin) 
                        {
                            admin.AdministratorMenu(BankUsers);
                            Attempts = 0;
                            break;
                        }
                        //if the username and password is correct with an user that is regesterd as customer
                        if (user is BankCustomer customer)
                        {
                            customer.CustomerMenu();
                            Attempts = 0;
                            break;
                        }
                    }
                    //if the username or password isnt in the system, but the user has tryd less than maximun attemts
                    else if (Attempts < MaxAttempts)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("─── Username or password is incorrect! ───");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                        Console.ResetColor();
                        Console.WriteLine("Press Enter to try again");
                        Console.ReadKey();
                    }
                }
                //if user has try to login more than maximunattets
                if (Attempts >= MaxAttempts)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Too many incorrect attempts");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.ResetColor();
                    Console.WriteLine("\nPress Enter to exit");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }
    }
}
