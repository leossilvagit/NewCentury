using Exercicio5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Exercicio5.Web.Controllers
{
    public class JogoController : Controller
    {
        private static Jogador jogador = new();
        private static int numeroSecreto;
        private static int tentativasRestantes;
        private static HashSet<int> tentativasFeitas = new();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Iniciar(string nome, Dificuldade dificuldade)
        {
            jogador = new Jogador { Nome = nome };
            tentativasRestantes = (int)dificuldade;
            numeroSecreto = new Random().Next(1, 101);
            tentativasFeitas.Clear();
            return RedirectToAction("Jogar");
        }

        public IActionResult Jogar() => View();

        [HttpPost]
        public IActionResult Jogar(int tentativa)
        {
            if (tentativasFeitas.Contains(tentativa))
            {
                ViewBag.Mensagem = "Voc ja tentou esse número!";
                return View();
            }

            tentativasFeitas.Add(tentativa);
            var resultado = tentativa == numeroSecreto ? ResultadoTentativa.SUCCESS : ResultadoTentativa.WRONG;

            jogador.Historico.Add(new Tentativa
            {
                Numero = tentativa,
                Resultado = resultado,
                DataHora = DateTime.Now
            });

            tentativasRestantes--;

            if (resultado == ResultadoTentativa.SUCCESS)
            {
                jogador.Vitorias++;
                ViewBag.Mensagem = "voce acertou!";
            }
            else if (tentativasRestantes == 0)
            {
                jogador.Derrotas++;
                ViewBag.Mensagem = $"Voce perdeu. O numero era {numeroSecreto}.";
            }
            else
            {
                ViewBag.Mensagem = "Errado!";
            }

            ViewBag.Restantes = tentativasRestantes;
            ViewBag.Rank = jogador.Rank;
            return View();
        }

        public IActionResult Historico() => View(jogador);
    }
}
