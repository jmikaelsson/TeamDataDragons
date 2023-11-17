using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    internal class AbstractUser 
    {
        private int Attempts { get; set; }
        private int MaxAttempt { get; set; }
        private List<AbstractUser> BankUsers { get; set; }

        public AbstractUser(List<AbstractUser> bankUsers, int maxAttemts = 3)
        {
            Attempts = 0;
            MaxAttempt = maxAttemts;
            BankUsers = bankUsers;

        }
        //public bool LogInUser(string inputUserName, string Password)
        //{

        //    var user =  BankUsers.Find(user => user.UserName == inpuUserName && user.Password == inputPassword);
        //    bool ListContain = bankUsers.Contains(logInCostumer);
        //    if (ListContain)
        //    {
        //        if (true)
        //        {

        //        }
        //        else
        //        {

        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
       
        //}
        public AbstractUser LogInUser(string inputUserName, string inputPassword)
        {
            return BankUsers.Find(user => user.UserName == inputUserName && user.Password == inputPassword); 

        }

        public void TryToLogin()
        {
            Attempts++;
            
            Console.Write("Användarnamn: ");
            string inptUserName = Console.ReadLine();
            Console.Write("Lösenord: ");
            string inputPassword = Console.ReadLine();
            var user = LogInUser(inptUserName, inputPassword);
            if (user != null)
            {
                if(user is Admin admin)
                {
                    //admin.
                }
                if (user is BankCostumer costumer)
                {
                    //costumer
                }
            } 
            else
            {
                Console.WriteLine("Fel användarnam eller lösenord!");
            }

        }
        
    }
}
