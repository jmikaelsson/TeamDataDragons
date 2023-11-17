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
        private LoginManager LogInManager { get; set; }
        private List<AbstractUser> BankUsers { get; set; }

        public App()
        {
            List<AbstractUser> bankUsers = new()
            {
                new Admin(),
                new BankCustomer(),
            };
            BankUsers = bankUsers;
            LogInManager = new(BankUsers);
        }
        static void LogInPage()
        {
            
                LoginManager logInCheck = new LogInManager();
                         
        }

        
    }
}
