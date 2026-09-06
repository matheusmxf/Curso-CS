using System;
using System.Globalization;

namespace Class5 {
    class Aluno {
        
        public string Nome;
        public double Nota1;
        public double Nota2;
        public double Nota3;

        public double NotaFinal(){
            return Nota1 + Nota2 + Nota3;
        }


        }

        class Program {
        static void Main(string[] args) {

            Aluno a = new Aluno();

            System.Console.Write("Digite o nome do aluno: ");
            a.Nome = Console.ReadLine();
            System.Console.WriteLine("Digite as notas que o aluno obteve em cada um dos tres trimestres");
            System.Console.Write("Primeiro trimestre: ");
            a.Nota1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            System.Console.Write("Segundo trimestre: ");
            a.Nota2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            System.Console.Write("Terceiro trimestre: ");
            a.Nota3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            System.Console.WriteLine("Nota final: " + a.NotaFinal().ToString("F2", CultureInfo.InvariantCulture));

            if (a.NotaFinal() < 60.00){
                System.Console.WriteLine("O aluno foi reprovado ");
                System.Console.WriteLine("Faltaram " + (60.00 - a.NotaFinal()).ToString("F2", CultureInfo.InvariantCulture) + " pontos");
            }
            else {
                System.Console.WriteLine("O aluno foi aprovado ");
            }

            



           
    }
        }
}