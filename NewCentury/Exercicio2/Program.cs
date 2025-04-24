using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio2
{
    enum SistemaOperacional
    {
        Nenhum = 0,
        WindowsServer = 1,
        Unix = 2,
        Linux = 3,
        Netware = 4,
        MacOS = 5,
        Outro = 6
    }

    class Program
    {
        static void Main(string[] args)
        {
            var votos = new Dictionary<SistemaOperacional, int>();
            foreach (SistemaOperacional so in Enum.GetValues(typeof(SistemaOperacional)))
            {
                if (so != SistemaOperacional.Nenhum)
                    votos[so] = 0;
            }

            Console.WriteLine("Qual o melhor Sistema Operacional para uso em servidores?");
            Console.WriteLine("1 - Windows Server\n2 - Unix\n3 - Linux\n4 - Netware\n5 - Mac OS\n6 - Outro");
            Console.WriteLine("Digite 0 para encerrar a votação.\n");

            while (true)
            {
                Console.Write("Digite seu voto (1 a 6): ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int voto))
                {
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }

                if (voto == 0)
                    break;

                if (voto < 1 || voto > 6)
                {
                    Console.WriteLine("Opção inválida.");
                    continue;
                }

                votos[(SistemaOperacional)voto]++;
            }

            int total = votos.Values.Sum();
            if (total == 0)
            {
                Console.WriteLine("\nNenhum voto registrado.");
                return;
            }

            Console.WriteLine("\nSistema Operacional     Votos   %");

            SistemaOperacional vencedor = SistemaOperacional.Nenhum;
            int maxVotos = 0;

            foreach (var item in votos)
            {
                double percentual = (double)item.Value / total * 100;
                Console.WriteLine($"{item.Key,-22} {item.Value,6}   {percentual,4:F1}%");

                if (item.Value > maxVotos)
                {
                    maxVotos = item.Value;
                    vencedor = item.Key;
                }
            }

            Console.WriteLine($"Total                     {total,6}");
            Console.WriteLine($"\nO Sistema Operacional mais votado foi o **{vencedor}**, com {maxVotos} votos ({(double)maxVotos / total * 100:F1}%).");
        }
    }
}
