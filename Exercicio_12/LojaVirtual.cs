using System;
using System.Collections.Generic;

namespace Exercicio_12
{
    internal class LojaVirtual
    {
        private Produto[] _produtos;

        public LojaVirtual(Produto[] produtos)
        {
            _produtos = produtos;
        }
        
        public void GerarCarrinhoCompras()
        {
            foreach (Produto produto in _produtos)
            {
                Console.WriteLine(produto);
            }
        }

        public double AplicarDesconto(double descontoPorcentagem) => CalcularValorCompra() - CalcularValorCompra() * (descontoPorcentagem/ 100);
        
        public double CalcularValorCompra()
        {
            double total = 0;

            foreach (Produto produto in _produtos)
            {
                total += produto._preco * produto._qtdEstoque;
            }

            return total;
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Digite a quantidade de produtos para serem adicionados ao carrinho");
            int qtdProdutos;
            while (!int.TryParse(Console.ReadLine(), out qtdProdutos))
            {
                Console.WriteLine("A quantidade de produtos deve ser um valor inteiro");
            }

            Produto[] produtos = new Produto[qtdProdutos];

            for (int i = 0; i < produtos.Length; i++)
            {
                Console.WriteLine($"Digite o nome do produto {i+1}");
                string nome = Console.ReadLine();

                Console.WriteLine($"Digite o preço do produto {i+1}");
                double preco;
                while (!double.TryParse(Console.ReadLine(), out preco))
                {
                    Console.WriteLine("O preço deve ser um número");
                }
                
                Console.WriteLine($"Digite a quantidade em estoque do produto {i+1}");
                int qtdEstoque;
                while (!int.TryParse(Console.ReadLine(), out qtdEstoque))
                {
                    Console.WriteLine("A quantidade de produtos deve ser um valor inteiro");
                }

                Produto produto = new Produto(nome, preco, qtdEstoque);
                
                produtos[i] = produto;
            }

            LojaVirtual loja = new LojaVirtual(produtos);

            Console.Clear();
            loja.GerarCarrinhoCompras();
            Console.WriteLine($"Valor total das compras: R${loja.CalcularValorCompra()}");
            
            Console.WriteLine("Existem algum cupom de desconto disponível? Digite o número da porcentagem");
            double descontoPorcentagem;
            while (!double.TryParse(Console.ReadLine(), out descontoPorcentagem))
            {
                Console.WriteLine("O valor deve ser um número");
            }

            Console.WriteLine($"Valor após o desconto: R${loja.AplicarDesconto(descontoPorcentagem)}");
            

        }
    }
}