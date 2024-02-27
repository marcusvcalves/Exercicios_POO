using System;

namespace Hotel
{
    public enum Genero
    {
        Masculino,
        Feminino,
        Outro
    }
    public class Pessoa
    {
        private string _nome;
        private string _cpf;
        private int _idade;
        private Genero _genero;
        private string _profissao;

        public Pessoa(string nome, string cpf, int idade, Genero genero, string profissao)
        {
            _nome = nome;
            _cpf = cpf;
            _idade = idade;
            _genero = genero;
            _profissao = profissao;
        }

        public string GetCpf() => _cpf;

        public override string ToString() => $"Nome: {_nome}" +
                                             $"{Environment.NewLine}Cpf: {_cpf}" +
                                             $"{Environment.NewLine}Idade: {_idade}" +
                                             $"{Environment.NewLine}Gênero: {_genero}" +
                                             $"{Environment.NewLine}Profissão: {_profissao}{Environment.NewLine}";
    }
}