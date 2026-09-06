using System;
using System.Collections.Generic;
using Course.Entities;
using Course.Entities.Enums;
using System.Globalization;

namespace Course
{
    class Program
    {
        static void Main1(string[] args)
        {
            List<Shape> list = new List<Shape>();

            System.Console.Write("Enter the number of shapes: ");
            int n = int.Parse(Console.ReadLine()!);

            for(int i = 1; i <= n; i++)
            {
                System.Console.WriteLine($"Shape #{i} data: ");
                System.Console.Write("Rectangle or Circle (r/c)? ");
                char ch = char.Parse(Console.ReadLine()!);
                System.Console.Write("Color (Black/Blue/red): ");
                Color color = Enum.Parse<Color>(Console.ReadLine()!);

                if(ch == 'r')
                {
                   System.Console.Write("Widht: ");
                   double widht = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                   System.Console.WriteLine("Height: ");
                   double height = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                   list.Add(new Rectangle(widht, height, color));
                }
                else
                {
                    System.Console.WriteLine("Radius: ");
                    double radius = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                    list.Add(new Circle(radius, color));
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine("SHAPE AREAS: ");
            foreach(Shape shape in list)
            {
                System.Console.WriteLine(shape.Area().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}