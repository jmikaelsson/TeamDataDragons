using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public class Loan 
    {
        public static int RefrenceLoanNumber = 1;
        public int LoanNumber { get; set; }
        public float BankLoan { get; set; }
        public float MaximumLoan { get; set; }
        public float TotalLoan { get; set; }
        public Loan(float totalLoan)
        {
            //BankLoan = bankLoan;
            LoanNumber = RefrenceLoanNumber++;
            TotalLoan = totalLoan;
        }

        public void ApplyForALoan(List<Account> Accounts)
        {
            
            float currentBalance = 0;
            foreach(var account in Accounts)
            {
                currentBalance += (float)account.Balance;
            }
            float maximumLoan = currentBalance * 5 - BankLoan;

            Console.WriteLine($"Your maximum loan amount is: {maximumLoan}\n" +
                $"Enter how much you want to loan:");
            bool wrongInput =! float.TryParse(Console.ReadLine(), out float customerLoanApply);

            while (wrongInput)
            {
                Console.WriteLine($"Wrong input, try again");
                wrongInput = !float.TryParse(Console.ReadLine(), out customerLoanApply);
            }

            if (currentBalance <= 0)
            {
                Console.WriteLine($"Your balance is to low to apply for a loan.");
            }
            else if(customerLoanApply > maximumLoan)
            {
                Console.WriteLine($"You are applying over the maximum loan limit.\n" +
                    $"Your maximum loan amount is: {maximumLoan}");
            }
            else
            {
                List<Loan> loans = new();
                Loan newLoan = new Loan(customerLoanApply);
                loans.Add(newLoan);
                Console.WriteLine($"Your bank loan of {customerLoanApply} is approved.");
            }
        }

    }
}
