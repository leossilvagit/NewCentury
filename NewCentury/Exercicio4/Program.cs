using System;
using System.Globalization;

namespace Exercicio4
{
    enum TipoCarne
    {
        FileDuplo = 1,
        Alcatra = 2,
        Picanha = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tipos de carne disponíveis:");
            Console.WriteLine("1 - Filé Duplo");
            Console.WriteLine("2 - Alcatra");
            Console.WriteLine("3 - Picanha");

            Console.Write("\nEscolha o tipo de carne (1 a 3): ");
            if (!int.TryParse(Console.ReadLine(), out int tipoInt) || tipoInt < 1 || tipoInt > 3)
            {
                Console.WriteLine("Tipo inválido.");
                return;
            }

            TipoCarne tipo = (TipoCarne)tipoInt;

            Console.Write("Informe a quantidade em Kg: ");
            if (!decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida.");
                return;
            }

            Console.Write("Pagamento com Cartão Tabajara? (s/n): ");
            string resposta = Console.ReadLine().Trim().ToLower();
            bool cartaoTabajara = resposta == "s";

            decimal precoKg = ObterPrecoKg(tipo, quantidade);
            decimal precoTotal = precoKg * quantidade;
            decimal desconto = cartaoTabajara ? precoTotal * 0.05m : 0;
            decimal valorFinal = precoTotal - desconto;

            Console.WriteLine("\n CUPOM FISCAL ");
            Console.WriteLine($"Tipo de carne: {tipo}");
            Console.WriteLine($"Quantidade: {quantidade} Kg");
            Console.WriteLine($"Preço total: R$ {precoTotal:F2}");
            Console.WriteLine($"Tipo de pagamento: {(cartaoTabajara ? "Cartão Tabajara" : "Outro")}");
            Console.WriteLine($"Desconto: R$ {desconto:F2}");
            Console.WriteLine($"Valor a pagar: R$ {valorFinal:F2}");
        }

        static decimal ObterPrecoKg(TipoCarne tipo, decimal quantidade)
        {
            bool acimaDe5Kg = quantidade > 5;

            return tipo switch
            {
                TipoCarne.FileDuplo => acimaDe5Kg ? 5.80m : 4.90m,
                TipoCarne.Alcatra => acimaDe5Kg ? 6.80m : 5.90m,
                TipoCarne.Picanha => acimaDe5Kg ? 7.80m : 6.90m,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
