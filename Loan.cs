using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public class Loan 
    {
        public static int RefrenceLoanNumber = 0;
        public int LoanNumber { get; set; }
        public float BankLoan { get; set; }
        public float MaximumLoan { get; set; }
        public float TotalLoan { get; set; }
        public string LoanAccountNumber { get; set; }
        public Loan(float bankLoan)
        {

            BankLoan = bankLoan;
            LoanNumber = RefrenceLoanNumber++;
            //TotalLoan = totalLoan;
            
        }

        public void ApplyForALoan(List<Account> accounts, List<Loan> loans)

        {
            float currentBalance = 0;
            foreach(var account in accounts)
            {
                currentBalance += (float)account.Balance;
            }
            float maximumLoan = currentBalance * 5 - BankLoan;


            if(maximumLoan <= 0)
            {
                Console.WriteLine("Your balance is to low to apply for a loan.");
            }
            else
            {
            Console.WriteLine($"Your maximum loan amount is: {maximumLoan}\n"+
            $"Enter how much you want to loan:");
            bool wrongInput =! float.TryParse(Console.ReadLine(), out float customerLoanApply);

            while (wrongInput)
            {
                Console.WriteLine($"Wrong input, try again");
                wrongInput = !float.TryParse(Console.ReadLine(), out customerLoanApply);
            }
            
            if(customerLoanApply > maximumLoan)
            {
                Console.WriteLine($"You are applying over the maximum loan limit.\n" +
                    $"Your maximum loan amount is: {maximumLoan}");
            }
            else
            {
 
                Loan newLoan = new Loan(customerLoanApply);
                
                Console.WriteLine($"Your bank loan of {customerLoanApply} is approved.");
                loans.Add(newLoan);
                    string loanAccountNumber = GenerateRandomAccountNumber();
                    Account newLoanAccount = new Account(loanAccountNumber,customerLoanApply, CurrencyType.SEK, AccountType.Salary);
                    Console.WriteLine($"New account {loanAccountNumber} opened with initial balance: {customerLoanApply} SEK");
                    accounts.Add(newLoanAccount);
            }
            }
            Console.WriteLine($"Press enter to return to menu");
            Console.ReadKey();

        }
        private string GenerateRandomAccountNumber()

        {
            Random random = new Random();
            bool isUnique = false;
            string generatedAccountNumber = string.Empty;

            while (!isUnique)
            {
                int randomNumber = random.Next(1000,9999 );
                generatedAccountNumber = randomNumber.ToString();

                // Check if the generated number is unique (you need to implement this logic)
                // For simplicity, assuming it's always unique in this example
                isUnique = true;
            }

            return generatedAccountNumber;
        }

    }
}
