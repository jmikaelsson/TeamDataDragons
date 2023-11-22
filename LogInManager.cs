﻿using System;
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
            while (true)
            {
                Console.WriteLine("1. Login  2. Exit");
                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }

                while (Attempts <= MaxAttempt)
                {
                    Attempts++;
                    Console.WriteLine("*** Login ***");
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
                            break;
                        }
                        if (user is BankCustomer customer)
                        {
                            customer.CustomerMenu();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Username or password is incorrect!");
                    }
                }
            }


        }
        
    }
}
