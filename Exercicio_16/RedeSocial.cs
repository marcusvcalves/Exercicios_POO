using System;
using System.Collections.Generic;

namespace Exercicio_16
{
    internal class RedeSocial
    {
        private Dictionary<string, List<string>> _amigos;
        private Dictionary<string, List<string>> _mensagens;
        private Dictionary<string, List<string>> _comentarios;

        public RedeSocial()
        {
            _amigos = new Dictionary<string, List<string>>();
            _mensagens = new Dictionary<string, List<string>>();
            _comentarios = new Dictionary<string, List<string>>();
        }
        
        public void AdicionarAmigo(string usuario, string amigo)
        {
            if (!_amigos.ContainsKey(usuario))
            {
                _amigos[usuario] = new List<string>();
            }
            _amigos[usuario].Add(amigo);
        }

        public void PublicarMensagem(string usuario, string mensagem)
        {
            if (!_mensagens.ContainsKey(usuario))
            {
                _mensagens[usuario] = new List<string>();
            }
            _mensagens[usuario].Add(mensagem);
        }

        public void ComentarPost(string usuario, string mensagem, string comentario)
        {
            string post = $"{usuario}: {mensagem}";
            if (!_comentarios.ContainsKey(post))
            {
                _comentarios[post] = new List<string>();
            }
            _comentarios[post].Add(comentario);
        }

        public List<string> BuscarAmigos(string usuario)
        {
            if (_amigos.ContainsKey(usuario))
            {
                return _amigos[usuario];
            }
            else
            {
                return new List<string>();
            }
        }
        
        public static void Main(string[] args)
        {
            RedeSocial redeSocial = new RedeSocial();

            redeSocial.AdicionarAmigo("Marcus", "Lucas");
            redeSocial.AdicionarAmigo("Pedro", "Daniel");
            redeSocial.AdicionarAmigo("Paula", "Letícia");

            redeSocial.PublicarMensagem("Marcus", "Olá, amigos!");
            redeSocial.PublicarMensagem("Pedro", "Bom dia!");

            redeSocial.ComentarPost("Marcus", "Olá, amigos!", "Que legal!");

            List<string> amigosMarcus = redeSocial.BuscarAmigos("Marcus");
            List<string> amigosPedro = redeSocial.BuscarAmigos("Pedro");

            Console.WriteLine("Amigos do Marcus:");
            foreach (string amigo in amigosMarcus)
            {
                Console.WriteLine(amigo);
            }

            Console.WriteLine("Amigos do Pedro:");
            foreach (string amigo in amigosPedro)
            {
                Console.WriteLine(amigo);
            }
            
            foreach (var mensagem in redeSocial._mensagens)
            {
                foreach (var msg in mensagem.Value)
                {
                    Console.WriteLine($"Mensagem do usuário {mensagem.Key}: {msg}");
                }
            }
        }
    }
}
