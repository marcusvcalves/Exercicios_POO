using System;

namespace Exercicio_7
{
    internal class Triangulo
    {
        private double _a;
        private double _b;
        private double _c;
        public Triangulo(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }
        
        public bool VerificarTrianguloValido() => (_a + _b > _c) && (_a + _c > _b) && (_b + _c > _a);

        public double CalcularArea()
        {
            double s = (_a + _b + _c) / 2;
            
            return Math.Sqrt(s * (s - _a) * (s - _b) * (s - _c));
        }

        public static void Main(string[] args)
        {
            double a;
            Console.WriteLine("Digite o valor do lado A do triângulo");
            while (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }
            
            double b;
            Console.WriteLine("Digite o valor do lado B do triângulo");
            while (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }
            
            double c;
            Console.WriteLine("Digite o valor do lado C do triângulo");
            while (!double.TryParse(Console.ReadLine(), out c))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }
            
            Triangulo triangulo = new Triangulo(a, b, c);

            bool trianguloValido = triangulo.VerificarTrianguloValido();

            Console.Clear();
            Console.WriteLine($"O triângulo é válido? {trianguloValido}");
            
            if (trianguloValido) Console.WriteLine($"A área do triângulo é: {triangulo.CalcularArea()}");                
            
        }
    }
}