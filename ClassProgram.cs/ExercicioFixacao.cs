using System;
using System.Globalization;

namespace Class7 {
    class ContaBancaria {

        public int Numero { get; private set; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numero, string titular) {
            Numero = numero;
            Titular = titular;   
        }

        public ContaBancaria(int numero, string titular, double saldo) : this(numero, titular) {
            Saldo = saldo;  
        }

        public void Deposito(double quantia){
            Saldo += quantia;
        }
         public void Saque(double quantia){
            Saldo -= quantia;
            Saldo -= 5.0;
        }


        public override string ToString() {
            return "Conta " + Numero
             + ", Titular: " + Titular 
             + ", Saldo: $ " + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }
    }

    class Program {
        static void Main(string[] args) {

            ContaBancaria conta;

            System.Console.Write("Entre o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            System.Console.Write("Entre o titular da conta: ");
            string titular = Console.ReadLine();

            System.Console.Write("Havera deposito inicial (s/n)? ");
            char resposta = char.Parse(Console.ReadLine());
            
            if (resposta == 's' || resposta == 'S') {
                System.Console.Write("Entre o valor de deposito inicial: ");
                double depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta = new ContaBancaria(numero, titular, depositoInicial);
            }
            else {
                conta = new ContaBancaria(numero, titular);
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Dados da conta:");
            System.Console.WriteLine(conta);
            
            System.Console.WriteLine();
            System.Console.Write("Entre um valor para deposito: ");
            double quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            conta.Deposito(quantia);
            System.Console.WriteLine("Dados da conta atualizados: ");
            System.Console.WriteLine(conta);

            System.Console.WriteLine();
            System.Console.Write("Entre um valor para saque: ");
            quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            conta.Saque(quantia);
            System.Console.WriteLine("Dados da conta atualizados: ");
            System.Console.WriteLine(conta);


        }
    }
}