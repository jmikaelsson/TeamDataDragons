using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TeamDataDragons
{
    public class Savings
    {
        public double SavingSaldo { get; set; }
        public double Interest;

        public Savings(double savingSaldo)
        {
            SavingSaldo = savingSaldo;
        }

        public void SavingMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Savings Menu ***\n" +
                "Select option (1-4)\n1. Deposit money.\n2. Withdraw money.\n3. View savings balance.\n4. Go back in the menu.");

            string savingSelection = Console.ReadLine();

            //A switch that goes to the case that admin selects
            switch (savingSelection)
            {
                case "1":
                    DepositMoney();
                    break;
                case "2":
                    WithdrawMoney();
                    break;
                case "3":
                    ShowSavingsBalance();
                    break;
                case "4":
                //Gå tillbaka till account?
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
        public void DepositMoney()
        {
            Console.Write("Enter amount to deposit: ");
            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
            {
                SavingSaldo += amount;
                Console.WriteLine($"{amount} SEK has been deposited into the account. The new balance is {SavingSaldo} SEK.\n" +
                    $"The interest on your savings account is: {Interest} ");
            }
            else
            {
                Console.WriteLine("Invalid amount, deposit failed.");
            }
        }

        public void WithdrawMoney()
        {
            Console.Write("Enter amount to withdraw: ");
            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
            {
                if (amount <= SavingSaldo)
                {
                    SavingSaldo -= amount;
                    Console.WriteLine($"{amount} SEK has been withdrawn from the account. The new balance is {SavingSaldo} SEK.");
                }
                else
                {
                    Console.WriteLine("Insufficient balance to complete the withdrawal.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount. Withdrawal failed.");
            }
        }

        public void ShowSavingsBalance()
        {
            Console.WriteLine($"Current Balance is: {SavingSaldo}");
        }
    }
}
