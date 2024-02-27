using System;

namespace Exercicio_10
{
    internal class Livro
    {
        private string _titulo;
        private string _autor;
        private int _numeroPaginas;
        private bool _disponivel = true;
        public Livro(string titulo, string autor, int numeroPaginas)
        {
            _titulo = titulo;
            _autor = autor;
            _numeroPaginas = numeroPaginas;
        }

        public void EmprestarLivro() => _disponivel = false;
        public void DevolverLivro() => _disponivel = true;
        public bool VerificarDisponibilidade() => _disponivel;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome do título");
            string titulo = Console.ReadLine();
            
            Console.WriteLine("Digite o nome do autor");
            string autor = Console.ReadLine();

            Console.WriteLine("Digite o número de páginas");
            int numeroPaginas = int.Parse(Console.ReadLine());

            Livro livro = new Livro(titulo, autor, numeroPaginas);
            
            Console.Clear();
            Console.WriteLine($"O livro está disponível? {livro.VerificarDisponibilidade()}");
            Console.WriteLine("Emprestando livro...");
            livro.EmprestarLivro();
            Console.WriteLine($"O livro está disponível? {livro.VerificarDisponibilidade()}");
            Console.WriteLine("Devolvendo livro...");
            livro.DevolverLivro();
            Console.WriteLine($"O livro está disponível? {livro.VerificarDisponibilidade()}");
        }
    }
}