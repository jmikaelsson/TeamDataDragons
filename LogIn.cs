using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    internal class LogIn
    {
        private string UserName { get; set; }
        private string UserPassword { get; set; }
        public static int Attempts = 1;

        public LogIn(string userName, string userPassword)
        {
            UserName = userName;
            UserPassword = userPassword;

            
            static void LogInPage()
            {

                while (Attempts > 3)
                {
                    LogInManager logInCheck = new LogInManager();
                    //Kom ihåg antal login försök.
                    Console.WriteLine("Användarnamn");
                    string InputUserName = Console.ReadLine();
                    Console.WriteLine("Lösenord");
                    string InputPassword = Console.ReadLine();

                    bool success = logInCheck.LogInCostumer(InputUserName, InputPassword);
                    if (success)
                    {
                        //skickas till BankCostumers()

                    }
                    else
                    {
                        bool succeded = logInChek.LogInAdmin(InputUserName, InputPassword);
                        if (succeded)
                        {
                            Admin();
                        }
                        else
                        {
                            Console.WriteLine("Fel användarnamn eller lösenord...");
                        }
                    }

                    Attempts++;
                }
            }

        }
    }
}
