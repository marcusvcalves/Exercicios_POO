using System;
using System.Collections.Generic;

namespace Exercicios_13
{
    internal class Agenda
    {
        private List<Contato> _contatos;

        public Agenda()
        {
            _contatos = new List<Contato>();
        }

        public void AdicionarContato()
        {
            try
            {
                Console.WriteLine("Digite o nome do contato");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite o telefone do contato");
                string telefone = Console.ReadLine();

                if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(telefone))
                {
                    throw new ArgumentException("Nome e telefone não podem ser vazios");
                }

                Contato contato = new Contato(nome, telefone);

                _contatos.Add(contato);
                Console.WriteLine("Contato adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar contato: {ex.Message}");
            }
        }
        public Contato BuscarContato()
        {
            try
            {
                Console.WriteLine("Digite o número ou telefone do contato");
                string input = Console.ReadLine();

                Contato contato = _contatos.Find(c => c.Nome.ToLower() == input.ToLower() || c.NumeroTelefone.ToLower() == input.ToLower());

                if (contato == null)
                {
                    throw new InvalidOperationException("Contato não encontrado");
                }

                return contato;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar contato: {ex.Message}");
                return null;
            }
        }
        public void EditarContato()
        {
            try
            {
                Contato contato = BuscarContato();

                Console.WriteLine("O que você deseja alterar?");
                Console.WriteLine("(1) - Nome");
                Console.WriteLine("(2) - Telefone");
                Console.WriteLine("(c) - Cancelar");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Digite o novo nome");
                        string nome = Console.ReadLine();
                        contato.Nome = nome;
                        break;
                    case "2":
                        Console.WriteLine("Digite o novo telefone");
                        string numeroTelefone = Console.ReadLine();
                        contato.NumeroTelefone = numeroTelefone;
                        break;
                    case "c":
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao editar contato: {ex.Message}");
            }
        }

        public void RemoverContato()
        {
            try
            {
                Contato contato = BuscarContato();
                _contatos.Remove(contato);
                Console.WriteLine("Contato removido com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover contato: {ex.Message}");
            }
        }
        
        public void MostrarContatos() => _contatos.ForEach(c => Console.WriteLine(c));
        
        public static void Main(string[] args)
        {
            Agenda agenda = new Agenda();
            
            while (true)
            {
                Console.Clear();

                Console.WriteLine("O que você deseja fazer? Digite uma das opções");
                Console.WriteLine("(1) Adicionar contato");
                Console.WriteLine("(2) Editar contato");
                Console.WriteLine("(3) Excluir contato");
                Console.WriteLine("(4) Buscar contato por nome ou telefone");
                Console.WriteLine("(5) Mostrar todos contatos");
                Console.WriteLine("(q) Sair");
                
                string input = Console.ReadLine();

                if (input.ToLower() == "q") break;

                switch (input)
                {
                    case "1":
                        agenda.AdicionarContato();
                        break;
                    case "2":
                        agenda.EditarContato();
                        break;
                    case "3":
                        agenda.RemoverContato();
                        break;
                    case "4":
                        Contato contato = agenda.BuscarContato();
                        Console.WriteLine(contato);
                        break;
                    case "5":
                        agenda.MostrarContatos();
                        break;
                }
                
                Console.WriteLine($"{Environment.NewLine}Pressione Enter para continuar...");
                Console.ReadLine();
            }
        }
    }
}