using System;

namespace Exercicio_6
{
    internal class Produto
    {
        private string _nome;
        private double _preco;
        private double _quantidade;
        public Produto(string nome, double preco, double quantidade)
        {
            _nome = nome;
            _preco = preco;
            _quantidade = quantidade;
        }

        public double ValorTotalEstoque() => _preco * _quantidade;
        
        public bool ProdutoDisponivel()
        {
            if (_quantidade > 0) return true;

            return false;
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome do produto");
            string nome = Console.ReadLine();
            
            double preco;
            Console.WriteLine("Digite o preço do produto");
            while (!double.TryParse(Console.ReadLine(), out preco))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }
            
            double quantidade;
            Console.WriteLine("Digite a quantidade de produtos disponíveis");
            while (!double.TryParse(Console.ReadLine(), out quantidade))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }
            Console.Clear();
            
            Produto produto = new Produto(nome, preco, quantidade);
            
            Console.WriteLine($"O produto {produto._nome} {(produto.ProdutoDisponivel() ? $"tem {produto._quantidade} unidades disponíveis" : "não tem unidades disponíveis")}");

            Console.WriteLine($"O valor total em estoque é de R${produto.ValorTotalEstoque()}");
        }
    }
}