using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public class Admin : AbstractUser
    {


        public Admin(string username, string password, string name, int personalnumber, bool isadmin = true)
            : base(username, password, name, personalnumber, isadmin)
        {

        }

        public override void PrintInfo() //Override the method PrintInfo() 
        {
            Console.WriteLine($"Name: {Name}, ID: {ID}");
        }

        //Creates a method to add admin which is saved in the list of bankUsers from abstractuser
        public void AddAdmin(List<AbstractUser> bankUsers)
        {
            Console.WriteLine("Enter a administrator username: ");
            string administratorName = Console.ReadLine();
            Console.WriteLine("Enter a password");
            string adminPassword = Console.ReadLine();
            Console.WriteLine("Enter first and last name: ");
            string adminFirstLastName = Console.ReadLine();
            Console.WriteLine("Enter personalnumber: ");
            bool adminWrongInput = !int.TryParse(Console.ReadLine(), out int adminPersonNumber);
            while (adminWrongInput)
            {
                Console.WriteLine("Wrong input. Try Again.");
                adminWrongInput = !int.TryParse(Console.ReadLine(), out adminPersonNumber);
            }

            Admin newAdmin = new Admin(administratorName, adminPassword, adminFirstLastName, adminPersonNumber);
            Console.WriteLine("Administrator added!");
            bankUsers.Add(newAdmin);
        }

        //Creates a method to add customer which is saved in the list of bankUsers from abstractuser
        public void AddCustomer(List<AbstractUser> bankUsers)
        {
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();
            Console.WriteLine("Enter a password: ");
            string customerPassword = Console.ReadLine();
            Console.WriteLine("Enter first and last name: ");
            string customerFirstLastName = Console.ReadLine();
            Console.WriteLine("Enter personalnumber: ");
            bool customerWrongInput = !int.TryParse(Console.ReadLine(), out int customerPersonNumber);
            while (customerWrongInput)
            {
                Console.WriteLine("Wrong input. Try Again.");
                customerWrongInput = !int.TryParse(Console.ReadLine(), out customerPersonNumber);
            }


            Console.WriteLine("Customer added!");
            Admin newCustomer = new Admin(customerName, customerPassword, customerFirstLastName, customerPersonNumber, false);
            bankUsers.Add(newCustomer);
            return;
            
            

        }
        //Method for the admin menu
        public void AdministratorMenu(List<AbstractUser> bankUsers)
        {

            while (true)
            {
                PrintInfo();

                Console.Clear();
                Console.WriteLine("*** Administrator Menu ***\n" +
                    "Select option (1-4)");
                Console.WriteLine("1. Add a new administrator\n2. Add a new customer\n3. Update Exchange Rate\n4. Log out");

                //Create a variable for the administrators choice
                string adminSelection = Console.ReadLine();

                //A switch that goes to the case that admin selects
                switch (adminSelection)
                {
                    case "1":
                        this.AddAdmin(bankUsers);
                        break;
                    case "2":
                        this.AddCustomer(bankUsers);
                        break;
                    case "3":
                        UpdateCurrencyExchange updatedExchange = new();
                        updatedExchange.UpdateExchangeRate();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            }

        }

    }
}
