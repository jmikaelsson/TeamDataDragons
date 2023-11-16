using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public class Admin
    { 

        //Create Lists of administrators and customers
        private List<string> administrators = new List<string>();
        private List<string> customers = new List<string>();

        //Method to add administrators
        public void AddAdministrator(string administratorName)
        {
            administrators.Add(administratorName);
        }
        //Method to add customers
        public void AddCustomer(string custumerName)
        {
            customers.Add(custumerName);
        }

        //Method to get administrators
        public List<string> GetAdministrators()
        {
            return administrators;
        }
        
        //Method to get customers
        public List<string> GetCustomers()
        {
            return customers;
        }

        //Method for unlock user
        public void UnlockUser(string userName)
        {
            if (administrators.Contains(userName))
            {
                Console.WriteLine("");
            }

        }

        //Method for the admin menu
        private void AdministratorMenu()
        {
            Admin adminManager = new Admin();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("*** Administrator Menu ***");
                Console.WriteLine("1. Add a new administrator\n2. View administrators information\n" +
                    "3. Add a new customer\n4. View customers information\n 5. Update Exchange Rate\n6. Unlock User\n7. Log out");

                //Create a variable for the administrators choice
                string adminSelection = Console.ReadLine();

                //A switch that goes to the case that admin selects
                switch (adminSelection)
                {
                    case "1":
                        Console.WriteLine("Enter administrator name: ");
                        string administratorName = Console.ReadLine();
                        adminManager.AddAdministrator(administratorName);
                        Console.WriteLine("Administrator added!");
                        break;
                    case "2":
                        Console.WriteLine("Administrators:");
                        foreach (var admin in adminManager.GetAdministrators())
                        {
                            Console.WriteLine(admin);
                        }
                        break;
                    case "3":
                        Console.Write("Enter customer name: ");
                        string customerName = Console.ReadLine();
                        adminManager.AddCustomer(customerName);
                        Console.WriteLine("Customer added!");
                        break;
                    case "4":
                        Console.WriteLine("Customers:");
                        foreach (var customer in adminManager.GetCustomers())
                        {
                            Console.WriteLine(customer);
                        }
                        break;
                    case "5":
                        Console.WriteLine("Exchange rate");
                        break;
                    case "6":
                        Console.WriteLine("Unlock user");
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } 

        }

    }
}
