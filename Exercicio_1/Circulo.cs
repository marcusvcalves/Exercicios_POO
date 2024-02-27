using System;

namespace Exercicio_1
{
    internal class Circulo
    {
        private readonly double _raio;
        public Circulo(double raio)
        {
            _raio = raio;
        }

        public double CalcularArea() => Math.PI * Math.Pow(_raio, 2);
        public double CalcularPerimetro() => 2 * Math.PI * _raio;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Digite um valor para o raio (separado por ',')");

            double raio;
            while (!double.TryParse(Console.ReadLine(), out raio))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }
            Circulo circulo = new Circulo(raio);

            Console.Clear();
            Console.WriteLine($"O valor da área do círculo é: {circulo.CalcularArea().ToString("F2")}");
            Console.WriteLine($"O valor do perímetro do círculo é: {circulo.CalcularPerimetro().ToString("F2")}");
        }
    }
}