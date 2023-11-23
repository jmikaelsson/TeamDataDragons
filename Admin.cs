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
            Console.WriteLine($"Name: {Name} \nID: {ID}\n");
        }

        //Creates a method to add admin which is saved in the list of bankUsers from abstractuser
        public void AddAdmin(List<AbstractUser> bankUsers)
        {
            Console.WriteLine("─── Add new administrator ───────────────────────────────────────────────────────────────────\n");
            Console.Write("Enter a administrator username: ");
            string administratorName = Console.ReadLine();
            Console.Write("Enter a password: ");
            string adminPassword = Console.ReadLine();
            Console.Write("Enter first and last name: ");
            string adminFirstLastName = Console.ReadLine();
            Console.Write("Enter personalnumber: ");
            bool adminWrongInput = !int.TryParse(Console.ReadLine(), out int adminPersonNumber);
            while (adminWrongInput)
            {
                Console.WriteLine("─── Wrong input. Try Again. ───");
                Console.Write("Enter personalnumber: ");
                adminWrongInput = !int.TryParse(Console.ReadLine(), out adminPersonNumber);
            }
            Console.WriteLine("\n─── Following admin is now added: ───\n");
            Admin newAdmin = new Admin(administratorName, adminPassword, adminFirstLastName, adminPersonNumber);
            bankUsers.Add(newAdmin);
            Console.WriteLine($"Username: {administratorName}\nAdmin name: {adminFirstLastName}\nAdmin social security number: {adminPersonNumber}\n");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadKey();
            return;
        }

        //Creates a method to add customer which is saved in the list of bankUsers from abstractuser
        public void AddCustomer(List<AbstractUser> bankUsers)
        {
            Console.WriteLine("\n─── Add new customer ────────────────────────────────────────────────────────────────────────\n");
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter a password: ");
            string customerPassword = Console.ReadLine();
            Console.Write("Enter first and last name: ");
            string customerFirstLastName = Console.ReadLine();
            Console.Write("Enter personalnumber: ");
            bool customerWrongInput = !int.TryParse(Console.ReadLine(), out int customerPersonNumber);
            while (customerWrongInput)
            {
                Console.WriteLine("─── Wrong input. Try Again. ───");
                Console.Write("Enter personalnumber: ");
                customerWrongInput = !int.TryParse(Console.ReadLine(), out customerPersonNumber);
            }

            Console.WriteLine("\n─── Following customer is now added: ───\n");

            BankCustomer newCustomer = new BankCustomer(customerName, customerPassword, customerFirstLastName, customerPersonNumber, false);
            bankUsers.Add(newCustomer);
            Console.WriteLine($"Username: {customerName}\nCustomer name: {customerFirstLastName}\nCustomer social security number: {customerPersonNumber}\n");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadKey();
            return;


        }
        //Method for the admin menu
        public void AdministratorMenu(List<AbstractUser> bankUsers)
        {

            while (true)
            {
                Console.Clear();
                BankLogo.DragonBank();
                Console.WriteLine("─── User information ────────────────────────────────────────────────────────────────────────\n");
                PrintInfo();
                Console.WriteLine("\n─── Administrator Menu ──────────────────────────────────────────────────────────────────────\n"+
                    "Select option (1-5)\n");
                Console.WriteLine("1. Add a new administrator\n2. Add a new customer\n3. Update Exchange Rate\n4. Update interest.\n5. Log out.");

                //Create a variable for the administrators choice
                string adminSelection = Console.ReadLine();

                //A switch that goes to the case that admin selects
                switch (adminSelection)
                {
                    case "1":
                        Console.Clear();
                        AddAdmin(bankUsers);
                        break;
                    case "2":
                        Console.Clear();
                        AddCustomer(bankUsers);
                        break;
                    case "3":
                        Console.Clear();
                        UpdateCurrencyExchange.UpdateExchangeRate();
                        break;
                    case "4":
                        Console.Clear();
                        UpdateCurrencyExchange.InterestRate();
                        break;
                    case "5":
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            }

        }

    }
}
