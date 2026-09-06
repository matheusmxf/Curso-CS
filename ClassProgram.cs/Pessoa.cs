using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Class1 {
    class Pessoa {

        public string Nome;
        public int Idade;
        }

        class Program {
        static void Main(string[] args) {

        Pessoa p1 = new Pessoa();
        Pessoa p2 = new Pessoa();


            System.Console.WriteLine("Entre com os dados da primeira pessoa: ");
            System.Console.Write("Nome: ");
            p1.Nome = Console.ReadLine();
            System.Console.Write("Idade: ");
            p1.Idade = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Entre com os dados da segunda pessoa: ");
            System.Console.Write("Nome: ");
            p2.Nome = Console.ReadLine();
            System.Console.Write("Idade: ");
            p2.Idade = int.Parse(Console.ReadLine());

            if (p1.Idade > p2.Idade){
                    
                    System.Console.WriteLine("A pessoa mais velha é: " + p1.Nome);

                }
                else{
                    
                    System.Console.WriteLine("A pessoa mais velha é: " + p2.Nome);
                }


                
        }
       



        
    }
    }
     
