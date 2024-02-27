using System;
using System.Collections.Generic;

namespace Exercicio_15
{
    internal class JogoCartas
    {
        private List<string> _baralho;
        private List<string> _numeros;
        private List<string> _naipes;
        private Random _random;

        public JogoCartas()
        {
            _baralho = new List<string>();
            _numeros = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "J", "Q", "K" };
            _naipes = new List<string>() { "Paus", "Ouros", "Copas", "Espadas" };
            _random = new Random();

            CriarBaralho();
        }

        public void CriarBaralho()
        {
            foreach (string naipe in _naipes)
            {
                foreach (string numero in _numeros)
                {
                    _baralho.Add($"{numero} de {naipe}");
                }
            }
        }

        public void Embaralhar()
        {
            int n = _baralho.Count;
            while (n>1)
            {
                n--;
                int k = _random.Next(n + 1);
                string carta = _baralho[k];
                _baralho[k] = _baralho[n];
                _baralho[n] = carta;
            }
        }

        public void DistribuirCartas(List<List<string>> jogadores, int numCartasPorJogador)
        {
            foreach (List<string> jogador in jogadores)
            {
                for (int i = 0; i < numCartasPorJogador; i++)
                {
                    if (_baralho.Count > 0)
                    {
                        string carta = _baralho[0];
                        jogador.Add(carta);
                        _baralho.RemoveAt(0);
                    }
                    else
                    {
                        Console.WriteLine("Não há cartas suficientes no baralho para distribuir.");
                        return;
                    }
                }
            }
        }

        public void MostrarMaoJogadores(List<List<string>> jogadores)
        {
            for (int i=0; i<jogadores.Count; i++)
            {
                Console.WriteLine($"Mão do Jogador {i+1}:");
                foreach (string carta in jogadores[i])
                {
                    Console.WriteLine(carta);
                }
                Console.WriteLine();
            }
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            JogoCartas jogoCartas = new JogoCartas();

            jogoCartas.Embaralhar();

            List<List<string>> jogadores = new List<List<string>>();
            jogadores.Add(new List<string>());
            jogadores.Add(new List<string>());
            jogadores.Add(new List<string>());

            jogoCartas.DistribuirCartas(jogadores, 5);

            jogoCartas.MostrarMaoJogadores(jogadores);

            Console.ReadLine();
        }
    }
}
