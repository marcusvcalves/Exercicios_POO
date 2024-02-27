using System;
using System.Collections.Generic;

namespace Exercicio_17
{
    internal class Biblioteca
    {
        private List<Livro> _livros;

        public Biblioteca()
        {
            _livros = new List<Livro>();
        }

        public void CadastrarLivro()
        {
            try
            {
                Console.WriteLine("Digite o nome do livro");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite o autor do livro");
                string autor = Console.ReadLine();

                Livro livro = new Livro(nome, autor);

                _livros.Add(livro);
                Console.WriteLine("Livro cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar livro. {ex.Message}");
            }
        }

        public void EmprestarLivro()
        {
            Livro livro = VerificarDisponibilidade();

            if (livro.Disponivel)
            {
                livro.Disponivel = false;
                Console.WriteLine("Livro emprestado com sucesso!");
            }
            else
            {
                Console.WriteLine("O livro já foi emprestado!");
            }
        }

        public void DevolverLivro()
        {
            Livro livro = VerificarDisponibilidade();

            if (!livro.Disponivel)
            {
                livro.Disponivel = true;
                Console.WriteLine("Livro devolvido com sucesso!");
            }
            else
            {
                Console.WriteLine("O livro já foi devolvido!");
            }
            
        }

        public Livro VerificarDisponibilidade()
        {
            try
            {
                Console.WriteLine("Digite o nome do livro");
                string nomeLivro = Console.ReadLine();

                return _livros.Find(l => l.Nome.ToLower() == nomeLivro.ToLower());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar pelo livro: {ex.Message}");
                return null;
            }

        }
        public static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();

            while (true)
            {
                Console.Clear();
                
                Console.WriteLine("Digite uma das opções ou 'q' para sair");
                Console.WriteLine("(1) Cadastrar livro");
                Console.WriteLine("(2) Verificar disponibilidade de um livro");
                Console.WriteLine("(3) Emprestar livro");
                Console.WriteLine("(4) Devolver livro");

                string input = Console.ReadLine();

                if (input.ToLower() == "q") break;
                
                switch (input)
                {
                    case "1":
                        biblioteca.CadastrarLivro();
                        break;
                    case "2":
                        Livro livro = biblioteca.VerificarDisponibilidade();
                        Console.WriteLine(livro);
                        break;
                    case "3":
                        biblioteca.EmprestarLivro();
                        break;
                    case "4":
                        biblioteca.DevolverLivro();
                        break;
                    case "q":
                        break;
                }
                
                Console.WriteLine($"{Environment.NewLine}Pressione Enter para continuar...");
                Console.ReadLine();
            }
        }
    }
}