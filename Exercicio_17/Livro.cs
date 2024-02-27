using System;

namespace Exercicio_17
{
    public class Livro
    {
        public string Nome;
        public string Autor;
        public bool Disponivel = true;
        
        public Livro(string nome, string autor)
        {
            Nome = nome;
            Autor = autor;
        }

        public override string ToString() => $"Nome: {Nome}" +
                                             $"{Environment.NewLine}Autor: {Autor}" +
                                             $"{Environment.NewLine}Disponível: {(Disponivel? "sim" : "não")}";
    }
}