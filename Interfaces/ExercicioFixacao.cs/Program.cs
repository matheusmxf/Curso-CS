using System;
using System.Globalization;
using Course.Entities;
using Course.Services;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Enter contract data ");
            System.Console.Write("Number: ");
            int contractNumber = int.Parse(Console.ReadLine()!);
            System.Console.Write("Date (dd/MM/yyyy): ");
            DateTime contractDate = DateTime.ParseExact(Console.ReadLine()!, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            System.Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            System.Console.WriteLine("Enter number of installments:  ");
            int months = int.Parse(Console.ReadLine()!);

            Contract myContract = new Contract(contractNumber, contractDate, contractValue);

            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(myContract, months);

            System.Console.WriteLine("Installments: ");
            foreach (Installment installment in myContract.Installments)
            {
                System.Console.WriteLine(installment);
            }
        }
    }
}