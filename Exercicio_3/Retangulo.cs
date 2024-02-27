using System;

namespace Exercicio_3
{
    internal class Retangulo
    {
        private double _largura;
        private double _altura;

        public Retangulo(double largura, double altura)
        {
            _largura = largura;
            _altura = altura;
        }

        public double CalcularArea() => _largura * _altura;
        public double CalcularPerimetro() => 2 * _largura + 2 * _altura;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Digite um valor para a largura do retângulo");
            double largura;
            while (!double.TryParse(Console.ReadLine(), out largura))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }
            
            Console.WriteLine("Digite um valor para a altura do retângulo");
            double altura;
            while (!double.TryParse(Console.ReadLine(), out altura))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }
            
            Retangulo retangulo = new Retangulo(largura, altura);

            Console.Clear();
            Console.WriteLine($"Área do retângulo {retangulo.CalcularArea()}");
            Console.WriteLine($"Perímetro do retângulo {retangulo.CalcularPerimetro()}");
        }
    }
}