using System;
using System.Text;

namespace Course.Entities1
{
    abstract class TaxPayer
    {
        public string? Name { get; set; }
        public double AnualIncome { get; set; }

        public TaxPayer(string name, double anualIncome)
        {
            Name = name;
            AnualIncome = anualIncome;
        }

        public abstract double Tax();
    }
}