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
                new Admin("Josefin", "12345", "Josefin Mikaelsson", 950810, true),
                new Admin("Viktoria", "12345", "Viktora Wallström", 000000, true),
                new Admin("Jana", "12345", "Jana Johansson", 000000, true),
                new Admin("Mohamed", "12345", "Mohamed Mohamud", 000000, true),
                new Admin("Morgan", "12354", "Morgan Westin", 000000, true),

                new BankCustomer("Test", "abc123", "Test Teston", 2000000),
            };
            LogInManager = new(BankUsers);

        }
        public void LogInPage()
        {

            BankLogo bankLogo = new();
            bankLogo.DragonBank();
            LogInManager.TryToLogin();
            
        }





    }
}
