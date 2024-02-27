using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio_4
{
    internal class Aluno
    {
        private string _nome;
        private string _matricula;
        private List<double> _notas;
        public Aluno(string nome, string matricula, List<double> notas)
        {
            _nome = nome;
            _matricula = matricula;
            _notas = notas;
        }
        public string CalcularMedia()
        {
            double media = _notas.Sum() / _notas.Count;
            
            return $"A média do aluno {_nome}, que possui matrícula {_matricula}, foi {media}, e o aluno está {(media > 6 ? "aprovado" : "reprovado")}";

        }
        public static void Main(string[] args)
        {
            List<double> notas = new List<double>();
            
            Console.WriteLine("Digite o nome do aluno");
            string nomeAluno = Console.ReadLine();
            
            Console.WriteLine("Digite a matrícula do aluno");
            string matricula = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Adicione uma nota (separada por ',') ou 'q' para sair");
                string input = Console.ReadLine();

                if (input.ToLower() == "q") break;

                double nota;
                while (!double.TryParse(input, out nota))
                {
                    Console.WriteLine("Valor inválido, digite um número");
                }
                notas.Add(nota);
            }
            
            Aluno aluno = new Aluno(nomeAluno, "209582", notas);
            
            Console.Clear();
            Console.WriteLine(aluno.CalcularMedia());
        }
    }
}