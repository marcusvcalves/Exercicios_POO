using System;

namespace Exercicio_5
{
    internal class Funcionario
    {
        private string _nome;
        private string _cargo;
        private double _salario;
        public Funcionario(string nome, string cargo, double salario)
        {
            _nome = nome;
            _cargo = cargo;
            _salario = salario;
        }

        public double CalcularSalarioLiquido(double porcentagemImposto, double reaisBeneficio) =>
            _salario - (_salario * porcentagemImposto / 100) + reaisBeneficio;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome do funcionário");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o cargo do funcionário");
            string cargo = Console.ReadLine();

            double salario;
            Console.WriteLine("Digite o salário do funcionário");
            while (!double.TryParse(Console.ReadLine(), out salario))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }

            Funcionario func = new Funcionario(nome, cargo, salario);

            double porcentagemImposto;
            Console.WriteLine("Digite a porcentagem do imposto");
            while (!double.TryParse(Console.ReadLine(), out porcentagemImposto))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }
            
            double reaisBeneficio;
            Console.WriteLine("Digite os benefícios em reais");
            while (!double.TryParse(Console.ReadLine(), out reaisBeneficio))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }
            
            Console.Clear();
            Console.WriteLine($"O salário líquido de {func._nome}, com o cargo de {func._cargo}, foi de R${func.CalcularSalarioLiquido(porcentagemImposto, reaisBeneficio)}");
            
        }
    }
}