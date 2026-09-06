using System;
using System.Globalization;

namespace PrimeiroProjeto {
    class Program {
        static void Main1 (string[] args) {

           string produto1 = "computador";
           string produto2 = "Mesa de escritorio";

           byte idade = 30;
           int codigo = 5290;
           char genero ='M';

           double preco1 = 2100.0;
           double preco2 = 650.50;
           double medida = 53.234567;

           System.Console.WriteLine("Produtos: ");
           System.Console.WriteLine(produto1 + ", cujo preço é $ " + preco1);
           System.Console.WriteLine(produto2 + ", cujo preço é $ " + preco2);
           System.Console.WriteLine();
           System.Console.WriteLine("Registro: " + idade + " anos de idade, código " + codigo + " e genêro: " + genero);
           System.Console.WriteLine();
           System.Console.WriteLine("Medida com oito casas decimais: " + medida.ToString("F8"));
           System.Console.WriteLine("Arredonado (três casas decimais): " + medida.ToString("F3"));
           System.Console.WriteLine("Separador decimal invariant culture: " + medida.ToString("F3", CultureInfo.InvariantCulture));

             

        
        }
    }
}



