using System;

namespace Exercicio_12
{
    public class Produto
    {
        public string _nome;
        public double _preco;
        public int _qtdEstoque;

        public Produto(string nome, double preco, int qtdEstoque)
        {
            _nome = nome;
            _preco = preco;
            _qtdEstoque = qtdEstoque;
        }

        public override string ToString() => $"Nome: {_nome}," +
                                             $" Preço: {_preco}," +
                                             $" Quantidade em estoque: {_qtdEstoque}";
    }
}