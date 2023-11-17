using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    internal class App
    {
        private LogInManager LogInManager { get; set; }
        private List<AbstractUser> BankUsers { get; set; }

        public App()
        {
            List<AbstractUser> bankUsers = new()
            {
                new Admin("Test", 1, 1, true),
                new BankCustomer("Test", "abc123", "Test Teston", 2000000),
            };
            BankUsers = bankUsers;
            LogInManager = new(BankUsers);
        }
        static void LogInPage()
        {
            LogInManager logInCheck = new LogInManager();
            logInCheck.TryToLogin();

        }

        
 
}
