using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    //Loan class represents loan with specific functionalities
    public class Loan
    {
        //Refrence number for loans.
        public static int RefrenceLoanNumber = 0;

        //Properties of the Loan class.
        public int LoanNumber { get; set; }
        public float BankLoan { get; set; }
        public float MaximumLoan { get; set; }
        public float TotalLoan { get; set; }
        public string LoanAccountNumber { get; set; }

        //Constructor to initialize a Loan object with the provided bank loan amount.
        public Loan(float bankLoan)
        {

            BankLoan = bankLoan;
            LoanNumber = RefrenceLoanNumber++;
        }

        //Method to apply for a loan, considering the customers balance and loan limits.
        public void ApplyForALoan(List<Account> accounts, List<Loan> loans)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("─── Apply for a Loan ────────────────────────────────────────────────────────────────────────\n");
            Console.ResetColor();
            float currentBalance = 0;

            //Calculates the total balance of customers accounts.
            foreach (var account in accounts)
            {
                currentBalance += (float)account.Balance;
            }
            //Calculates the maximum loan amount based on the customers balance.
            float maximumLoan = currentBalance * 5 - BankLoan;

            //Check if the customer is eligible for a loan.
            if (maximumLoan <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your balance is to low to apply for a loan.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Your maximum loan amount is: {maximumLoan}\n" +
                $"Enter the amount you want to apply for:");

                //Check for valid input for the loan amount.
                bool wrongInput = !float.TryParse(Console.ReadLine(), out float customerLoanApply);

                while (wrongInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"─── Wrong input, try again ───");
                    Console.ResetColor();
                    wrongInput = !float.TryParse(Console.ReadLine(), out customerLoanApply);
                }

                //Check if the requested loan amount excees the maximum loan limit.
                if (customerLoanApply > maximumLoan)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You are applying over the maximum loan limit.\n" +
                        $"Your maximum loan amount is: {maximumLoan}");
                    Console.ResetColor();

                }
                else
                {
                    //Create a new Loan object and add it to the list of loans.
                    Loan newLoan = new Loan(customerLoanApply);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.ResetColor();
                    Console.WriteLine($"Your bank loan of {customerLoanApply} is approved.");
                    loans.Add(newLoan);
                    //Generates a unique account number for the new loan aaccount.
                    string loanAccountNumber = GenerateRandomAccountNumber();
                    //Create a new Account object for the loan and add it to the list of accounts.
                    Account newLoanAccount = new Account(loanAccountNumber, customerLoanApply, CurrencyType.SEK, AccountType.Salary);
                    Console.WriteLine($"New account {loanAccountNumber} is opened with initial balance of: {customerLoanApply} SEK");
                    accounts.Add(newLoanAccount);
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────");
            Console.ResetColor();
            Console.WriteLine("Press Enter to return to menu");
            Console.ReadKey();
        }
        //Method to generate a unique account number for the new loan account.
        private string GenerateRandomAccountNumber()
        {
            Random random = new Random();
            bool isUnique = false;
            string generatedAccountNumber = string.Empty;

            while (!isUnique)
            {
                int randomNumber = random.Next(1000, 9999);
                generatedAccountNumber = randomNumber.ToString();
                isUnique = true;
            }

            return generatedAccountNumber;
        }

    }
}
