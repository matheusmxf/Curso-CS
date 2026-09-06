using System;

namespace Project{
    class Calculadora{

        public double Operacao(int n, double x, double y){
    
            if(n == 1){
                return x + y;
            }
            else if( n == 2){
                return x - y;
            }
            else if( n == 3){
                return x * y;
            }
            else if( n == 4){
               if(x == 0){
                System.Console.WriteLine("Nenhum número pode ser dividido por zero"); 
                return 0;    
                    }   
                return x / y;
            }
            else{
                System.Console.WriteLine("Essa opção não está disponivel no momento");
                return 0;
                
            }
        }
    }

    class Program{
        static void Main(string[] args){
            Calculadora calc = new Calculadora();

            System.Console.WriteLine("Digite um número referente ao tipo de operação que deseja realizar ");
            System.Console.WriteLine("Soma = 1");
            System.Console.WriteLine("Subtração = 2");
            System.Console.WriteLine("Multiplicação = 3");
            System.Console.WriteLine("Divisão = 4");

            int n = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o primeiro número com o qual deseja fazer a operação: ");
            double x = double.Parse(Console.ReadLine());

            System.Console.Write("Digite o segundo número: ");
            double y = double.Parse(Console.ReadLine());

            double resultado = calc.Operacao(n, x, y);
            System.Console.Write("O resultado da operação é: " + resultado);
            
        }   
    } 
}