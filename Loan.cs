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
        private float BankLoan { get; set; }
        public float MaximumLoan { get; set; }
        public Loan(float bankLoan)
        {
            BankLoan = bankLoan;
            LoanNumber = RefrenceLoanNumber++; 
        }

        public void CheckLoan(List<Loan> loans)
        {
            foreach(var loan in loans)
            {
                Console.WriteLine($"Loan: {LoanNumber} Balance: {BankLoan} ");
            }
        }

        public void ApplyForALoan()
        {
            MaximumLoan = Account.Balance * 5 - BankLoan;

            Console.WriteLine($"Your maximum loan amount is: {MaximumLoan}\n" +
                $"Enter how much you want to loan:");
            bool wrongInput =! float.TryParse(Console.ReadLine(), out float customerLoanApply);

            while (wrongInput)
            {
                Console.WriteLine($"Wrong input, try again");
                wrongInput = !float.TryParse(Console.ReadLine(), out customerLoanApply);
            }

            if (Account.Balance <= 0)
            {
                Console.WriteLine($"Your balance is to low to apply for a loan.");
            }
            else if(customerLoanApply > MaximumLoan)
            {
                Console.WriteLine($"You are applying over the maximum loan limit.\n" +
                    $"Your maximum loan amount is: {MaximumLoan}");
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
