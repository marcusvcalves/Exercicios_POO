using System;
using System.Collections.Generic;
using System.Globalization;

namespace Hotel
{
    internal class Hotel
    {
        private List<Pessoa> _hospedes;
        private List<Suite> _suites;
        private List<Reserva> _reservas;

        public Hotel()
        {
            _hospedes = new List<Pessoa>();
            _suites = new List<Suite>();
            _reservas = new List<Reserva>();
        }

        public void ExibirMenuPrincipal()
        {
            Console.WriteLine("Digite uma das opções ou 'q' para sair");
            Console.WriteLine("(1) Cadastrar");
            Console.WriteLine("(2) Consultar");
            Console.WriteLine("(3) Listar");
            Console.WriteLine("(q) Sair");
        }

        public void ExibirMenu(string verbo, string opcao1, string opcao2, string opcao3)
        {
            Console.WriteLine($"O que você gostaria de {verbo}?");
            Console.WriteLine($"(1) {opcao1}");
            Console.WriteLine($"(2) {opcao2}");
            Console.WriteLine($"(3) {opcao3}");
        }

        public void CadastrarHospede()
        {
            try
            {
                Console.WriteLine("Digite o nome do hóspede");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite a idade do hóspede");
                int idade;
                while (!int.TryParse(Console.ReadLine(), out idade))
                {
                    Console.WriteLine("Insira um valor inteiro válido");
                }

                Console.WriteLine("Digite o CPF do hóspede");
                string cpf = Console.ReadLine();

                Console.WriteLine("Selecione o gênero do hóspede");
                Console.WriteLine("(1) Masculino");
                Console.WriteLine("(2) Feminino");
                Console.WriteLine("(3) Outro");

                Genero genero;
                while (true)
                {
                    Console.WriteLine("Selecione o gênero do hóspede");
                    Console.WriteLine("(1) Masculino");
                    Console.WriteLine("(2) Feminino");
                    Console.WriteLine("(3) Outro");

                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            genero = Genero.Masculino;
                            break;
                        case "2":
                            genero = Genero.Feminino;
                            break;
                        case "3":
                            genero = Genero.Outro;
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            continue;
                    }

                    break;
                }

                Console.WriteLine("Digite a profissão do hóspede");
                string profissao = Console.ReadLine();

                Pessoa pessoa = new Pessoa(nome, cpf, idade, genero, profissao);

                _hospedes.Add(pessoa);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar hóspede: {ex.Message}");
            }
        }

        public void CadastrarSuite()
        {
            try
            {
                Console.WriteLine("Digite o número da suíte");
                string numeroSuite = Console.ReadLine();

                Console.WriteLine("Qual a capacidade da suíte?");
                int capacidade;
                while (!int.TryParse(Console.ReadLine(), out capacidade))
                {
                    Console.WriteLine("Digite um número inteiro");
                }

                Console.WriteLine("Qual o valor da diária?");
                double valorDiaria;
                while (!double.TryParse(Console.ReadLine(), out valorDiaria))
                {
                    Console.WriteLine("Digite um número válido");
                }

                Suite suite = new Suite(numeroSuite, capacidade, valorDiaria);

                _suites.Add(suite);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar suíte: {ex.Message}");
            }
        }

        public Pessoa BuscarHospede()
        {
            try
            {
                Console.WriteLine("Digite o CPF do hóspede");
                string cpf = Console.ReadLine();
                Pessoa hospede = _hospedes.Find(p => p.GetCpf() == cpf);

                if (hospede != null)
                {
                    return hospede;
                }
                
                Console.WriteLine("Hóspede não encontrado");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar hóspede: {ex.Message}");
                return null;
            }
        }

        public Suite BuscarSuite()
        {
            try
            {
                Console.WriteLine("Digite o número da suíte");
                string numeroSuite = Console.ReadLine();
                
                Suite suite =  _suites.Find(s => s.GetNumeroSuite() == numeroSuite);

                if (suite != null)
                {
                    return suite;
                }

                Console.WriteLine("Suíte não encontrada");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar suíte: {ex.Message}");
                return null;
            }
        }

        public void CadastrarReserva()
        {
            try
            {
                Console.WriteLine("Digite o ID para cadastro da reserva");
                int reservaId;
                while (!int.TryParse(Console.ReadLine(), out reservaId))
                {
                    Console.WriteLine("Digite um número inteiro");
                }

                Pessoa pessoa;
                while (true)
                {
                    Console.WriteLine("Digite o CPF do hóspede");
                    string cpf = Console.ReadLine();
                    pessoa = _hospedes.Find(p => p.GetCpf() == cpf);

                    if (pessoa != null)
                    {
                        break;
                    }
            
                    Console.WriteLine("Hóspede não encontrado. Digite um CPF válido.");
                }

                Suite suite;
                while (true)
                {
                    Console.WriteLine("Digite o número da suíte");
                    string numeroSuite = Console.ReadLine();
                    suite = _suites.Find(s => s.GetNumeroSuite() == numeroSuite);

                    if (suite != null)
                    {
                        break;
                    }

                    Console.WriteLine("Suíte não encontrada. Digite um número de suíte válido.");
                }

                Console.WriteLine("Qual a data de início da reserva? (dd-MM-yyyy)");
                DateTime dataInicio;
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                        out dataInicio))
                {
                    Console.WriteLine("Formato de data inválido. Use o formato dd-MM-yyyy.");
                }

                Console.WriteLine("Qual a data final da reserva? (dd-MM-yyyy)");
                DateTime dataFim;
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                        out dataFim))
                {
                    Console.WriteLine("Formato de data inválido. Use o formato dd-MM-yyyy.");
                }

                Reserva reserva = new Reserva(reservaId, pessoa, suite, dataInicio, dataFim);
                _reservas.Add(reserva);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar reserva: {ex.Message}");
            }
        }

        public Reserva BuscarReserva()
        {
            try
            {
                Console.WriteLine("Digite o ID da reserva");
                int reservaId;
                while (!int.TryParse(Console.ReadLine(), out reservaId))
                {
                    Console.WriteLine("Digite um número inteiro");
                }

                Reserva reserva = _reservas.Find(r => r.GetReservaId() == reservaId);

                if (reserva != null)
                {
                    return reserva;
                }

                Console.WriteLine("Reserva não encontrada");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar reserva: {ex.Message}");
                return null;
            }
        }

        public void Cadastrar()
        {
            ExibirMenu("cadastrar", "Hóspede", "Suíte", "Reserva");

            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1":
                    CadastrarHospede();
                    break;
                case "2":
                    CadastrarSuite();
                    break;
                case "3":
                    CadastrarReserva();
                    break;
            }
        }

        public void Consultar()
        {
            ExibirMenu("consultar", "Hóspede", "Suíte", "Reserva");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Pessoa pessoa = BuscarHospede();
                    Console.WriteLine(pessoa);
                    break;
                case "2":
                    Suite suite = BuscarSuite();
                    Console.WriteLine(suite);
                    break;
                case "3":
                    Reserva reserva = BuscarReserva();
                    Console.WriteLine(reserva);
                    break;
            }
        }

        public void ListarHospedes() => _hospedes.ForEach(p => Console.WriteLine(p));

        public void ListarSuites() => _suites.ForEach(s => Console.WriteLine(s));

        public void ListarReservas() => _reservas.ForEach(r => Console.WriteLine(r));
        
        public void Listar()
        {
            ExibirMenu("listar", "Hóspede", "Suíte", "Reserva");
            
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1":
                    ListarHospedes();
                    break;
                case "2":
                    ListarSuites();
                    break;
                case "3":
                    ListarReservas();
                    break;
            }
        }
        
        public static void Main(string[] args)
        {
            Hotel hotel = new Hotel();
            
            while (true)
            {
                Console.Clear();
            
                hotel.ExibirMenuPrincipal();

                string input = Console.ReadLine();

                if (input.ToLower() == "q") break;
                
                switch (input)
                {
                    case "1":
                        hotel.Cadastrar();
                        break;
                    case "2":
                        hotel.Consultar();
                        break;
                    case "3":
                        hotel.Listar();
                        break;
                }

                Console.WriteLine($"{Environment.NewLine}Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }

        }
    }
}