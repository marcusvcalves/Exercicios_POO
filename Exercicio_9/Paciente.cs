using System;
using System.Collections.Generic;

namespace Exercicio_9
{
    internal class Paciente
    {
        private string _nome;
        private int _idade;
        private List<string> _consultas;
        public Paciente(string nome, int idade, List<string> consultas)
        {
            _nome = nome;
            _idade = idade;
            _consultas = consultas;
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome do paciente");
            string nome = Console.ReadLine();

            int idade;
            Console.WriteLine("Digite quantos anos o paciente tem");
            while (!int.TryParse(Console.ReadLine(), out idade))
            {
                Console.WriteLine("Valor inválido, digite um número");
            }

            List<string> consultas = new List<string>();
            while (true)
            {
                Console.WriteLine("Adicione uma consulta ou 'q' para sair");
                string input = Console.ReadLine();

                if (input.ToLower() == "q") break;
                
                consultas.Add(input);
            }
            
            Paciente paciente = new Paciente(nome, idade, consultas);

            Console.Clear();
            Console.WriteLine($"O paciente {paciente._nome} tem {paciente._idade} anos");
            if (paciente._consultas.Count > 0)
            {
                Console.WriteLine("Consultas agendadas:");
                foreach (string consulta in paciente._consultas)
                {
                    Console.WriteLine(consulta);
                }
            }
            
        }
    }
}