using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using Course.Entities1;

namespace Course1
{
    class Program1
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            System.Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine()!);

            for(int i = 1; i <= n; i++)
            {
                System.Console.WriteLine($"Tax payer #{i} data: ");
                System.Console.Write("Individual or company (i/c)? ");
                char ch = char.Parse(Console.ReadLine()!);
                System.Console.Write("Name: ");
                string name = Console.ReadLine()!;
                System.Console.Write("Anual Income: ");
                double anualIncome = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

                if(ch == 'i')
                {
                    System.Console.WriteLine("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    System.Console.WriteLine("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine()!);
                    list.Add(new Company(name, anualIncome, numberOfEmployees));
                }
            }

            double sum = 0.0;
            System.Console.WriteLine();
            System.Console.WriteLine("TAXES PAID: ");
            foreach(TaxPayer tp in list)
            {
                double tax = tp.Tax();
                System.Console.WriteLine(tp.Name + ": $ " + tax.ToString("F2", CultureInfo.InvariantCulture));
                sum += tax;
            }
            System.Console.WriteLine();
            System.Console.Write("TOTAL TAXES: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}