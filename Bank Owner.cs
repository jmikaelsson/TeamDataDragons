using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public class Bank
    {
        public class Account
        {
            public float Balance { get; set; }

            public void CheckBalance()
            {
                Console.WriteLine($"Current balance: {Balance}");
            }

            public void TransferMoney(Account recipient, float amount)
            {
                if (amount > 0 && Balance >= amount)
                {
                    Balance -= amount;
                    recipient.Balance += amount;

                    Console.WriteLine($"Transferred {amount} to recipient's account.");
                    Console.WriteLine($"Remaining balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Invalid transfer. Insufficient funds or invalid amount.");
                }
            }
        }

        public List<Account> accounts;

        public Bank()
        {
            accounts = new List<Account>();
        }

        public void AddNewAccount(float initialBalance)
        {
            Account newAccount = new Account { Balance = initialBalance };
            accounts.Add(newAccount);
            Console.WriteLine($"New account added with initial balance: {initialBalance}");
        }

        public void TransferLog()
        {
            Console.WriteLine("Transfer log:");

            foreach (var account in accounts)
            {
                Console.WriteLine($"Account balance: {account.Balance}");
            }
        }
    }

}
