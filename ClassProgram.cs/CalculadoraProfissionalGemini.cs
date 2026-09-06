using System;

namespace Project {

    // 1. Uso de Enum para eliminar "números mágicos"
    public enum TipoOperacao {
        Soma = 1,
        Subtracao = 2,
        Multiplicacao = 3,
        Divisao = 4,
        Potenciacao = 5,
        RaizQuadrada = 6,
        RestoDivisao = 7
    }

    // 2. Classe de Cálculo pura (Sem Console.WriteLine dentro dela)
    public class Calculadora {
        public double Calcular(TipoOperacao operacao, double x, double y = 0) {
            return operacao switch {
                TipoOperacao.Soma => x + y,
                TipoOperacao.Subtracao => x - y,
                TipoOperacao.Multiplicacao => x * y,
                TipoOperacao.Divisao => y != 0 ? x / y : throw new DivideByZeroException("Não é possível dividir por zero."),
                TipoOperacao.Potenciacao => Math.Pow(x, y),
                TipoOperacao.RaizQuadrada => x >= 0 ? Math.Sqrt(x) : throw new ArgumentException("Não existe raiz quadrada real de número negativo."),
                TipoOperacao.RestoDivisao => y != 0 ? x % y : throw new DivideByZeroException("Não é possível calcular resto de divisão por zero."),
                _ => throw new InvalidOperationException("Operação não reconhecida.")
            };
        }
    }

    class Program {
        static void Main(string[] args) {
            Calculadora calc = new Calculadora();
            bool continuar = true;

            Console.WriteLine("=================================");
            Console.WriteLine("   CALCULADORA PROFISSIONAL C#   ");
            Console.WriteLine("=================================");

            // 3. Menu com laço de repetição
            while (continuar) {
                ExibirMenu();
                int opcao = LerInteiro("\nEscolha a operação desejada (0 para sair): ");

                if (opcao == 0) {
                    continuar = false;
                    Console.WriteLine("\nSaindo... Obrigado por usar a calculadora!");
                    break;
                }

                if (!Enum.IsDefined(typeof(TipoOperacao), opcao)) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n[Aviso] Opção inválida! Escolha um número do menu.");
                    Console.ResetColor();
                    continue;
                }

                TipoOperacao operacao = (TipoOperacao)opcao;

                try {
                    double resultado;

                    // Operações de 1 número (como Raiz Quadrada)
                    if (operacao == TipoOperacao.RaizQuadrada) {
                        double numero = LerDouble("Digite o número para calcular a Raiz Quadrada: ");
                        resultado = calc.Calcular(operacao, numero);
                    }
                    // Operações de 2 números
                    else {
                        double x = LerDouble("Digite o primeiro número: ");
                        double y = LerDouble("Digite o segundo número: ");
                        resultado = calc.Calcular(operacao, x, y);
                    }

                    // Exibição formatada do resultado
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n>>> Resultado da operação ({operacao}): {resultado}");
                    Console.ResetColor();

                } catch (Exception ex) {
                    // Tratamento amigável de erros lançados pela Calculadora
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[Erro]: {ex.Message}");
                    Console.ResetColor();
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        // --- Métodos Auxiliares para Leitura Segura de Dados (TryParse) ---

        static void ExibirMenu() {
            Console.WriteLine("\nOpções Disponíveis:");
            Console.WriteLine(" 1 - Soma (+)");
            Console.WriteLine(" 2 - Subtração (-)");
            Console.WriteLine(" 3 - Multiplicação (*)");
            Console.WriteLine(" 4 - Divisão (/)");
            Console.WriteLine(" 5 - Potenciação (X^Y)");
            Console.WriteLine(" 6 - Raiz Quadrada (√X)");
            Console.WriteLine(" 7 - Resto da Divisão (%)");
            Console.WriteLine(" 0 - Sair");
        }

        static int LerInteiro(string mensagem) {
            int valor;
            Console.Write(mensagem);
            while (!int.TryParse(Console.ReadLine(), out valor)) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Por favor, digite um número inteiro válido: ");
                Console.ResetColor();
            }
            return valor;
        }

        static double LerDouble(string mensagem) {
            double valor;
            Console.Write(mensagem);
            while (!double.TryParse(Console.ReadLine(), out valor)) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Por favor, digite um número válido: ");
                Console.ResetColor();
            }
            return valor;
        }
    }
}