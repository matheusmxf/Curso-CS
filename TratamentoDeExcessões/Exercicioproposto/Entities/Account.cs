using System;
using Course.Entities.Exceptions1;

namespace Course.Entities1
{
    class Account
    {
        public int Number { get; set; }
        public string? Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string? holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > WithdrawLimit)
            {
                throw new DomainException1("The amount exceeds withdraw limit");
            }
            if (amount > Balance)
            {
                throw new DomainException1("Not enough balance ");
            }
            Balance -= amount;
        }
    }
}