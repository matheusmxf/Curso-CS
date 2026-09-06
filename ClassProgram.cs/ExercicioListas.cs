using System;
using System.Globalization;
using Class9;
using System.Collections.Generic;

namespace Class9 {
    class Employee{

    public int Id { get; set; }
    public string Name { get; set; }
    public double Salary { get; private set; }

    public Employee(int id, string name, double salary) {
            Id = id;
            Name = name;
            Salary = salary;
    }
    public void increaseSalary(double percentage){
        Salary += Salary * percentage / 100;
        
    }
        public override string ToString(){
            return Id
                + ", "
                + Name
                + ", "
                + Salary.ToString("F2", CultureInfo.InvariantCulture);
        }

    }

}

    class Program {
        static void Main(string[] args) {

            System.Console.Write("How many employees will be resgistered? ");
            int n = int.Parse(Console.ReadLine());

            List<Employee> list = new List<Employee> {};

            for(int i = 1;i <= n; i++){
                System.Console.WriteLine("Employee #" + i + ":");
                System.Console.Write("Id: ");
                int Id = int.Parse(Console.ReadLine());
                System.Console.Write("Name: ");
                string name = Console.ReadLine();
                System.Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                list.Add(new Employee(Id, name, salary));
                System.Console.WriteLine();
            }

            System.Console.Write("Enter the employee id that will have salary increase: ");
            int searchId = int.Parse(Console.ReadLine());

            Employee emp = list.Find(x => x.Id == searchId);
            if(emp != null){
                System.Console.Write("Enter the percentage: ");
                double percentage = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                emp.increaseSalary(percentage);
            }
            else{
                System.Console.WriteLine("This Id does not exist.");
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Update List of employees: ");
            foreach(Employee obj in list){
                System.Console.WriteLine(obj);
            
                }

            }
    }