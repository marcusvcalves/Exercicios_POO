using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Exercicio_14
{
    internal class MaquinaVenda
    {
        private List<Produto> _produtos;
        private double _saldo;
        
        public MaquinaVenda()
        {
            _produtos = new List<Produto>();
        }
        
        public void CadastrarProduto()
        {
            try
            {
                Console.WriteLine("Digite o nome do produto");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite o preço do produto");
                double preco;
                while (!double.TryParse(Console.ReadLine(), out preco))
                {
                    Console.WriteLine("Digite um número válido");
                }

                Console.WriteLine("Digite a quantidade de produtos em estoque");
                int qtdEstoque;
                while (!int.TryParse(Console.ReadLine(), out qtdEstoque))
                {
                    Console.WriteLine("Digite um número inteiro válido");
                }

                Produto produto = new Produto(nome, preco, qtdEstoque);
            
                _produtos.Add(produto);
                Console.WriteLine("Produto adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar produto: {ex.Message}");
            }
        }

        public void ComprarProduto()
        {
            try
            {
                Console.WriteLine("Digite o nome do produto para busca");
                string nomeProduto = Console.ReadLine();

                Produto produto = _produtos.Find(p => p.Nome.ToLower() == nomeProduto.ToLower());
                

                if (produto == null)
                {
                    throw new InvalidOperationException("Produto não encontrado");
                }

                if (produto.QtdEstoque > 0)
                {
                    produto.QtdEstoque -= 1;
                    _saldo += produto.Preco;
                    Console.WriteLine($"Produto {produto.Nome} comprado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Quantidade em estoque indisponível");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comprar produto: {ex.Message}");
            }

        }
        
        public void InserirDinheiro()
        {
            Console.WriteLine("Qual valor deve ser inserido na máquina?");
            double dinheiro;
            while (!double.TryParse(Console.ReadLine(), out dinheiro))
            {
                Console.WriteLine("Digite um número");
            }
            
            _saldo += dinheiro;
        }

        public void RetornarTroco()
        {
            Console.WriteLine("Qual valor deve ser retornado da máquina?");
            double dinheiro;
            while (!double.TryParse(Console.ReadLine(), out dinheiro))
            {
                Console.WriteLine("Digite um número");
            }
            
            if (_saldo > dinheiro) _saldo -= dinheiro;
            else
            {
                Console.WriteLine("Não é possível retornar troco porque a máquina não possui saldo");
            }
            
        }

        public void ExibirEstoque()
        {
            Console.WriteLine($"Saldo da máquina: R${_saldo}");
            _produtos.ForEach(p => Console.WriteLine(p));
        }

        public static void Main(string[] args)
        {
            MaquinaVenda maquina = new MaquinaVenda();
            
            while (true)
            {
                Console.Clear();

                Console.WriteLine("O que você deseja fazer? Digite uma das opções");
                Console.WriteLine("(1) Cadastrar produto");
                Console.WriteLine("(2) Comprar produto");
                Console.WriteLine("(3) Inserir dinheiro");
                Console.WriteLine("(4) Retornar troco");
                Console.WriteLine("(5) Exibir estoque");
                Console.WriteLine("(q) Sair");
                
                string input = Console.ReadLine();

                if (input.ToLower() == "q") break;

                switch (input)
                {
                    case "1":
                        maquina.CadastrarProduto();
                        break;
                    case "2":
                        maquina.ComprarProduto();
                        break;
                    case "3":
                        maquina.InserirDinheiro();
                        break;
                    case "4":
                        maquina.RetornarTroco();
                        break;
                    case "5":
                        maquina.ExibirEstoque();
                        break;
                }
                
                Console.WriteLine($"{Environment.NewLine}Pressione Enter para continuar...");
                Console.ReadLine();
            }
        }
    }
}