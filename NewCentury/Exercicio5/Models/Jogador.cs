using System.Collections.Generic;
using System.Linq;
using Exercicio5.Models;

namespace Exercicio5.Models
{
    public class Jogador
    {
        public string Nome { get; set; }
        public List<Tentativa> Historico { get; set; } = new();
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }

        public string Rank
        {
            get
            {
                int total = Vitorias + Derrotas;
                if (total == 0) return "Sem Rank";

                int pct = Vitorias * 100 / total;

                return pct switch
                {
                    100 => "S",
                    >= 90 => "A",
                    >= 80 => "B",
                    >= 70 => "C",
                    >= 50 => "D",
                    _ => "E"
                };
            }
        }
    }
}
