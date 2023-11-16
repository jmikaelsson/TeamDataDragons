using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public abstract class SystemOwner
    {

        int attempts = 3;

        public void UserMenu()
        {
            Console.WriteLine("1. Log in as administrator\n2. Log in as costumer\nSelect option (1-2)");

            string userSelection = Console.ReadLine();

            if (userSelection == "1")
            {
                AdminLogin();
            }
            else if (userSelection == "2")
            {
                CustomerLogin();
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
                UserMenu();
            }
        }
    }
}
