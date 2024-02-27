using System;

namespace Exercicio_14
{
    public class Produto
    {
        public string Nome;
        public double Preco;
        public int QtdEstoque;

        public Produto()
        {
            
        }
        
        public Produto(string nome, double preco, int qtdEstoque)
        {
            Nome = nome;
            Preco = preco;
            QtdEstoque = qtdEstoque;
        }

        public override string ToString() => $"Nome: {Nome}, " +
                                             $"Preço: R${Preco}, " +
                                             $"Quantidade em Estoque: {QtdEstoque}{Environment.NewLine}";
    }
}