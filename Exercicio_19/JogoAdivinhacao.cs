using System;

namespace Exercicio_19
{
    internal class JogoAdivinhacao
    {
        private int _numeroAleatorio;
        Random random = new Random();
        
        public JogoAdivinhacao()
        {
            _numeroAleatorio = random.Next(0, 101);
        }
        
        public static void Main(string[] args)
        {
            JogoAdivinhacao jogo = new JogoAdivinhacao();

            Console.WriteLine($"Tente descobrir o número aleatório entre 0 e 100");
            while (true)
            {
                string input = Console.ReadLine();
                int tentativa;

                if (!int.TryParse(input, out tentativa))
                {
                    Console.WriteLine("Insira um número válido");
                    continue;
                }
                
                if (tentativa < 0 || tentativa > 100)
                {
                    Console.WriteLine("Insira um número entre 0 e 100");
                    continue;
                }

                if (jogo._numeroAleatorio > tentativa)
                {
                    Console.WriteLine($"O número é maior que {tentativa}, tente novamente");
                }
                else if (jogo._numeroAleatorio < tentativa)
                {
                    Console.WriteLine($"O número é menor que {tentativa}, tente novamente");
                }
                else
                {
                    Console.WriteLine("Você descobriu o número correto");
                    break;
                }
            }
        }
    }
}