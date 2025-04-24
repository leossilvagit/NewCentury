using System;
using System.Collections.Generic;

namespace Exercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] faixaSalarios = new int[9];
            List<decimal> salariosCalculados = new List<decimal>();

            Console.WriteLine("Digite o valor das vendas brutas dos vendedores.");
            Console.WriteLine("Digite -1 para encerrar.\n");

            while (true)
            {
                Console.Write("Vendas brutas: $");
                string entrada = Console.ReadLine();

                if (!decimal.TryParse(entrada, out decimal vendas) || vendas < -1)
                {
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }

                if (vendas == -1)
                    break;

                decimal salario = 200m + (vendas * 0.09m);
                salariosCalculados.Add(salario);

                int indice = CalcularIndiceFaixa(salario);
                faixaSalarios[indice]++;
            }

            Console.WriteLine("\nDistribuição de salários:");
            for (int i = 0; i < faixaSalarios.Length; i++)
            {
                string faixa;
                if (i == 8)
                    faixa = "$1000 ou mais";
                else
                    faixa = $"${200 + (i * 100)} - ${299 + (i * 100)}";

                Console.WriteLine($"{faixa,-15}: {faixaSalarios[i]} vendedor(es)");
            }
        }

        static int CalcularIndiceFaixa(decimal salario)
        {
            int indice = (int)((salario - 200) / 100);
            return Math.Min(indice, 8);
        }
    }
}
