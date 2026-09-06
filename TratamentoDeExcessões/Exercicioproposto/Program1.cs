using System;
using System.Globalization;
using Course.Entities1;
using Course.Entities.Exceptions1;

namespace Course1
{
    class Program1
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Enter account data");
            System.Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine()!);
            System.Console.Write("Holder: ");
            string holder = Console.ReadLine()!;
            System.Console.WriteLine("Initial balance: ");
            double balance = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            System.Console.WriteLine("Withdraw limit: ");
            double withdrawLimit = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

            Account acc = new Account(number, holder, balance, withdrawLimit);

            System.Console.WriteLine();
            System.Console.Write("Enter amount for withdraw: ");
            double amount = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

            try
            {
                acc.Withdraw(amount);
                System.Console.Write("New balance: " + acc.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (DomainException1 e)
            {
                System.Console.WriteLine("Withdraw error: " + e.Message);
            }

        }
    }
}