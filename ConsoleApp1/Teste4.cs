using System;
using System.Globalization;

namespace QuartoProjeto{
    class Program4{
         static void Main4(string[] args){

            int senha = int.Parse(Console.ReadLine());

            while (senha != 2002) {
                
                Console.WriteLine("Senha Invalida");
                
                senha = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Acesso Permitido");
        }


            }

        }
