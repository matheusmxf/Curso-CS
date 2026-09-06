using System;
using System.Globalization;

namespace Class6 {
    class Dolar {
        
        public double Cotacao;

        public double ConversorDeMoeda(double qtd){
            return Cotacao * qtd +(Cotacao * qtd * 6 / 100);
        }


        }

        class Program {
        static void Main(string[] args) {

            Dolar d = new Dolar();

            System.Console.Write("Digite a cotação do Dolar: ");
            d.Cotacao = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            System.Console.Write("Quantos dolares voce vai comprar: ");
            double qtd = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            System.Console.Write("Valor a ser pago em reais: " + d.ConversorDeMoeda(qtd).ToString("F2", CultureInfo.InvariantCulture));


           
    }
        }
}