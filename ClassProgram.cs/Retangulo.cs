using System;
using System.Globalization;

namespace Class3 {
    class Retangulo {

       public double Largura;
       public double Altura;

       public double ValorDaArea(){
            return Altura * Largura;
        }
       public double ValorDoPerimetro(){
            return (Altura * 2) + (Largura * 2);
        }
       public double ValorDaDiagonal(){
            return Math.Sqrt((Altura * Altura) + (Largura * Largura));
        }

        }

        class Program {
        static void Main(string[] args) {

            Retangulo r = new Retangulo();

            System.Console.WriteLine("Digite a altura e a largura do retangulo: ");
            System.Console.WriteLine("Altura: ");
            r.Altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            System.Console.WriteLine("Largura: ");
            r.Largura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            System.Console.WriteLine("A area do retangulo é: " + r.ValorDaArea());
            System.Console.WriteLine("O perimetro do retangulo é: " + r.ValorDoPerimetro());
            System.Console.WriteLine("A diagonal retangulo é: " + r.ValorDaDiagonal());

           
    }
        }
}