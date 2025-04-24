using System;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nInforme o salario do colaborador:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal salarioAtual))
                {
                    Console.WriteLine("Valor inválido. Tente novamente.");
                    continue;
                }

                decimal percentual = PercentualReajuste(salarioAtual);
                decimal valorAumento = salarioAtual * percentual;
                decimal novoSalario = salarioAtual + valorAumento;

                Console.WriteLine($"\nsalario antes do reajuste: R$ {salarioAtual:F2}");
                Console.WriteLine($"Percentual de aumento aplicado: {percentual * 100}%");
                Console.WriteLine($"Valor do aumento: R$ {valorAumento:F2}");
                Console.WriteLine($"Novo salario aps o reajuste: R$ {novoSalario:F2}");

                Console.WriteLine("\nDeseja calcular outro salário? (s/n)");
                string resposta = Console.ReadLine().Trim().ToLower();

                if (resposta != "s")
                {
                    Console.WriteLine("Encerrando...");
                    break;
                }

                Console.Clear();
            }
        }

        static decimal PercentualReajuste(decimal salario)
        {
            if (salario <= 280.00m)
                return 0.20m;
            else if (salario <= 700.00m)
                return 0.15m;
            else if (salario <= 1500.00m)
                return 0.10m;
            else
                return 0.05m;
        }
    }
}
