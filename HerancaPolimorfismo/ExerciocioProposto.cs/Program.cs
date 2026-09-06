using System;
using System.Globalization;
using System.Collections.Generic;
using Course.Entities1;

namespace Entities1
{
    class Program1
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            System.Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine()!);

            for(int i = 1; i <= n; i++)
            {
                System.Console.WriteLine($"Product #{i} data: ");
                System.Console.Write("Commom, used or import (c/u/i)? ");
                char ch = char.Parse(Console.ReadLine()!);
                System.Console.Write("Name: ");
                string name = Console.ReadLine()!;
                System.Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

                if(ch == 'c')
                {
                    list.Add(new Product(name, price));
                }
                else if(ch == 'u')
                {
                    System.Console.WriteLine("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine()!);
                    list.Add(new UsedProduct(name, price, date));
                }
                else
                {
                    System.Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price , customsFee));
                }
            }

            System.Console.WriteLine();
            System.Console.WriteLine("PRICE TAGS: ");
            foreach (Product prod in list)
            {
                System.Console.WriteLine(prod.PriceTag());
            }
        }
    }
}