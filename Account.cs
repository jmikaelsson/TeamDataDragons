using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public class Account
    {
        // Bankkontoattribut
        public double Balance { get; set; }
        public string BankAccountNumber { get; set; }

        // Konstruktor
        public Account(string bankAccountNumber)
        {
            BankAccountNumber = bankAccountNumber;
            Balance = 0.0;
        }

        // Metod för att beräkna ränta och visa resultatet
        public void Interest()
        {
            // Implementera din logik för att beräkna och visa ränta här
            double interestRate = 0.05; // Exempelräntesats på 5%
            double interest = Balance * interestRate;

            Console.WriteLine($"For account {BankAccountNumber}, the interest will be: {interest}");
        }

        // Metod för att öppna ett nytt konto
        public void AddNewAccount()
        {
            // Implementera din logik för att öppna ett nytt konto här
            Console.WriteLine("Enter the initial balance for the new account:");
            double initialBalance = double.Parse(Console.ReadLine());

            Balance = initialBalance;

            // Generate a unique 8-digit random bank account number
            GenerateRandomAccountNumber();

            Console.WriteLine($"New account {BankAccountNumber} opened with initial balance: {initialBalance}");
        }

        // Helper method to generate a unique 8-digit random bank account number
        private void GenerateRandomAccountNumber()
        {
            Random random = new Random();
            bool isUnique = false;

            while (!isUnique)
            {
                // Generate an 8-digit random number
                int randomNumber = random.Next(10000000, 99999999);
                BankAccountNumber = randomNumber.ToString();

                isUnique = true;
            }
        }
    }

    // Övriga metoder (TransferMoney, TransferLog, CheckBalance) kan implementeras här enligt behov.
    // Se till att uppdatera switch-satsen i CustomerMenu-metoden i BankCustomer-klassen för att använda dessa metoder.
}
