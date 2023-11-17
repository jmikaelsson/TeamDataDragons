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

        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, ID: {ID}, Personalnumber: {PersonalNumber}");
        }


        public void AddAdmin(List<AbstractUser> bankUsers)
        {
            Console.WriteLine("Enter a administrator username: ");
            string administratorName = Console.ReadLine();
            Console.WriteLine("Enter a password");
            string adminPassword = Console.ReadLine();
            Console.WriteLine("Enter administartors name: ");
            string adminFirstLastName = Console.ReadLine();
            Console.WriteLine("Enter personalnumber: ");
            bool adminWrongInput = !int.TryParse(Console.ReadLine(), out int adminPersonNumber);
            while (adminWrongInput)
            {
                Console.WriteLine("Wrong input. Try Again.");
                adminWrongInput = !int.TryParse(Console.ReadLine(), out adminPersonNumber);
            }

            Admin newAdmin = new Admin(administratorName, adminPassword, adminFirstLastName, adminPersonNumber, true);
            bankUsers.Add(newAdmin);
            Console.WriteLine("Administrator added!");
        }

        public void AddCustomer(List<AbstractUser> bankUsers)
        {
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();
            Console.WriteLine("Enter a password: ");
            string customerPassword = Console.ReadLine();
            Console.WriteLine("Enter administartors name: ");
            string customerFirstLastName = Console.ReadLine();
            Console.WriteLine("Enter personalnumber: ");
            bool customerWrongInput = !int.TryParse(Console.ReadLine(), out int customerPersonNumber);
            while (customerWrongInput)
            {
                Console.WriteLine("Wrong input. Try Again.");
                customerWrongInput = !int.TryParse(Console.ReadLine(), out customerPersonNumber);
            }
            Admin newCustomer = new Admin(customerName, customerPassword, customerFirstLastName, customerPersonNumber, false);
            bankUsers.Add(newCustomer);
            Console.WriteLine("Customer added!");
        }
        //Method for the admin menu
        public void AdministratorMenu(List<AbstractUser> bankUsers)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("*** Administrator Menu ***");
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
                        Console.WriteLine("Exchange rate");
                        break;
                    case "4":
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
