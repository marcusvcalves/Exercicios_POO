using System;

namespace Exercicio_8
{
    internal class Carro
    {
        private string _marca;
        private string _modelo;
        private double _velocidadeAtual;
        public Carro(string marca, string modelo, double velocidadeAtual)
        {
            _marca = marca;
            _modelo = modelo;
            _velocidadeAtual = velocidadeAtual;
        }

        public void Acelerar(double velocidade) => _velocidadeAtual += velocidade;
        public void Frear(double velocidade) => _velocidadeAtual -= velocidade;
        public string ExibirVelocidade() => $"A velocidade atual do {_marca} {_modelo} é de {_velocidadeAtual}km/h";
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Digite a marca do carro");
            string marca = Console.ReadLine();
            
            Console.WriteLine("Digite o modelo do carro");
            string modelo = Console.ReadLine();

            double velocidadeAtual;
            Console.WriteLine("Digite a velocidade atual do carro");
            while (!double.TryParse(Console.ReadLine(), out velocidadeAtual))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }

            Carro carro = new Carro(marca, modelo, velocidadeAtual);
            
            double aumentarVelocidade;
            Console.WriteLine("Digite quantos km/h o carro deve acelerar");
            while (!double.TryParse(Console.ReadLine(), out aumentarVelocidade))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }
            carro.Acelerar(aumentarVelocidade);
            
            double diminuirVelocidade;
            Console.WriteLine("Digite quantos km/h o carro deve frear");
            while (!double.TryParse(Console.ReadLine(), out diminuirVelocidade))
            {
                Console.WriteLine("Valor inválido, digite um número inteiro");
            }
            carro.Frear(diminuirVelocidade);
            
            Console.Clear();
            Console.WriteLine(carro.ExibirVelocidade());
            
        }
    }
}