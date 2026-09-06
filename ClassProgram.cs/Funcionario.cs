using System;
using System.Globalization;

namespace Class4 {
    class Funcionario {

        public string Nome;
        public double SalarioBruto;
        public double Imposto;

        public double SalarioLiquido(){
            return SalarioBruto - Imposto;
        }
    
        public void AumentarSalario(double porcentagem){
            SalarioBruto = SalarioBruto + (SalarioBruto * porcentagem / 100);
        }


        }

        class Program {
        static void Main(string[] args) {

            Funcionario f = new Funcionario();

            System.Console.WriteLine("Digite os dados do funcionario ");
            System.Console.Write("Nome: ");
            f.Nome = Console.ReadLine();
            System.Console.Write("Salario Bruto: ");
            f.SalarioBruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            System.Console.Write("Imposto: ");
            f.Imposto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            System.Console.WriteLine("Funcionario: " + f.Nome + ", " + f.SalarioLiquido().ToString("F2", CultureInfo.InvariantCulture));
            System.Console.WriteLine();
            System.Console.WriteLine("Digite a porcentagem que deseja aumentar o salario: ");
            double porcentagem = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            f.AumentarSalario(porcentagem);
            System.Console.WriteLine();
            System.Console.WriteLine("Dados atualizados: "  + f.Nome + ", " + f.SalarioLiquido().ToString("F2", CultureInfo.InvariantCulture));




           
    }
        }
}