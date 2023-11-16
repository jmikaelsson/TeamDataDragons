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
        
        LogIn tryLogIn = new LogIn();
        public bool LogInCostumer(List<string> costumers)
        {
            Admin logInCostumer = costumers.Find(logInCostumer => LogIn.UserName == InpuUserName && LogIn.Password == InputPassword);
            bool ListContain = costumers.Contains(logInCostumer);
            if (ListContain)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LogInAdmin(LogIn.LogInPage())
        {
            Admin logInAdmin = administaratiors.FirstOrDefaukt(logInAdmin => admin.UserName == InpuUserName && admin.Password == InputPassword);
            bool ListContain = administrators.Contains(logInAdmin);
            if (ListContain)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
