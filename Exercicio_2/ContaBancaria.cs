using System;

namespace Exercicio_2
{
    internal class ContaBancaria
    {
        private readonly string _numeroConta;
        private readonly string _nomeTitular;
        private double _saldo;
        public ContaBancaria(string numeroConta, string nomeTitular, double saldo)
        {
            _numeroConta = numeroConta;
            _nomeTitular = nomeTitular;
            _saldo = saldo;
        }

        public void Deposito(double valor) => _saldo += valor;

        public void Saque(double valor) => _saldo -= valor;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Digite o número da conta");
            string numeroConta = Console.ReadLine();

            Console.WriteLine("Digite o nome do titular");
            string nomeTitular = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial");
            double saldoInicial;
            while (!double.TryParse(Console.ReadLine(), out saldoInicial))
            {
                Console.WriteLine("Digite um número válido");
            }
            
            ContaBancaria conta = new ContaBancaria(numeroConta, nomeTitular, saldoInicial);

            Console.WriteLine("Digite um valor para depósito");
            double valorDeposito;
            while (!double.TryParse(Console.ReadLine(), out valorDeposito))
            {
                Console.WriteLine("Digite um número válido");
            }
            conta.Deposito(valorDeposito);

            Console.WriteLine("Digite um valor para saque");
            double valorSaque;
            while (!double.TryParse(Console.ReadLine(), out valorSaque))
            {
                Console.WriteLine("Digite um número válido");
            }
            conta.Saque(valorSaque);
            
            Console.Clear();
            Console.WriteLine($"Saldo em conta: R${conta._saldo}");    
            
        }
    }
}