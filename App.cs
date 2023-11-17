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
            BankUsers = new()
            {
                new Admin("Test", 1, 1, true),
                new BankCustomer("Test", "abc123", "Test Teston", 2000000),
            };
            LogInManager = new(BankUsers);

        }
        public void LogInPage()
        {
            LogInManager.TryToLogin();

        }





    }
}
