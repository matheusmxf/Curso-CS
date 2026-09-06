using System;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;

namespace SegundoProjeto {
    class Program2 {
        static void Main2 (string[] args) {

           string nomeCompleto = Console.ReadLine()!;
           int quarto = int.Parse(Console.ReadLine()!);
           double preco = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

           string[] vet = Console.ReadLine()!.Split(' ');
           string nome = vet[0];
           int idade = int.Parse(vet[1]);
           double altura = double.Parse(vet[2], CultureInfo.InvariantCulture);

           System.Console.WriteLine("Entre com seu nome completo: ");
           System.Console.WriteLine(nomeCompleto);
           System.Console.WriteLine("Quantos quartos tem na sua casa? ");
           System.Console.WriteLine(quarto);
           System.Console.WriteLine("Entre com o preço de um peoduto: ");
           System.Console.WriteLine(preco.ToString("F2", CultureInfo.InvariantCulture));
           System.Console.WriteLine("Entre com seu ultimo nome, sua idade, e sua altura: ");
           System.Console.WriteLine(nome);
           System.Console.WriteLine(idade);
           System.Console.WriteLine(altura.ToString("F2", CultureInfo.InvariantCulture));



        
             

        
        }
    }
}



