namespace Exercicios_13
{
    public class Contato
    {
        public string Nome;
        public string NumeroTelefone;
        
        public Contato(string nome, string numeroTelefone)
        {
            Nome = nome;
            NumeroTelefone = numeroTelefone;
        }

        public Contato()
        {
            
        }

        public override string ToString() => $"Nome: {Nome}, Telefone: {NumeroTelefone}";
    }
}