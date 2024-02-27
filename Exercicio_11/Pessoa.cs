using System;

namespace Exercicio_11
{
    internal class Pessoa
    {
        private string _nome;
        private int _idade;
        private string _profissao;
        public Pessoa(string nome, int idade, string profissao)
        {
            _nome = nome;
            _idade = idade;
            _profissao = profissao;
        }

        public int CalcularIdadeBissextos()
        {
            int anosBissextos = 0;

            for (int ano = DateTime.Now.Year - _idade; ano <= DateTime.Now.Year; ano++)
            {
                if (DateTime.IsLeapYear(ano))
                {
                    anosBissextos++;
                }
            }

            return anosBissextos;
        }
        public override string ToString() => $"Nome: {_nome}{Environment.NewLine}" +
                                             $"Idade: {_idade}{Environment.NewLine}" +
                                             $"Profissão: {_profissao}{Environment.NewLine}" +
                                             $"Idade em anos bissextos: {CalcularIdadeBissextos()}";
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome da pessoa");
            string nome = Console.ReadLine();
            
            int idade;
            Console.WriteLine("Digite a idade");
            while(!int.TryParse(Console.ReadLine(), out idade))
            {
                Console.WriteLine("Valor inválido, digite um número inteiro");
            }
            
            Console.WriteLine("Digite a profissão da pessoa");
            string profissao = Console.ReadLine();
            
            Pessoa pessoa = new Pessoa(nome, idade, profissao);
            
            Console.Clear();
            Console.WriteLine(pessoa);
        }
    }
}