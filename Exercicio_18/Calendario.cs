using System;

namespace Exercicio_18
{
    internal class Calendario
    {
        public void ExibirCalendarioMes(int mes, int ano)
        {
            DateTime data = new DateTime(ano, mes, 1);

            Console.WriteLine($"Calendário para {data:MMMM yyyy}");
            Console.WriteLine("Dom Seg Ter Qua Qui Sex Sáb");

            int diaSemanaInicial = (int)data.DayOfWeek;

            for (int i = 0; i < diaSemanaInicial; i++)
            {
                Console.Write("    ");
            }

            for (int i = 1; i <= DateTime.DaysInMonth(ano, mes); i++)
            {
                Console.Write($"{i,3}");

                if ((diaSemanaInicial + i) % 7 == 0 || i == DateTime.DaysInMonth(ano, mes))
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }

        // public bool VerificarDataFeriado()
        // {
        //     return false;
        // }
        
        public int CalcularDiferencaDias(DateTime dataInicio, DateTime dataFim)
        {
            TimeSpan diferencaDias = dataFim - dataInicio;

            return (int)diferencaDias.TotalDays;
        }
        
        public static void Main(string[] args)
        {
            Calendario calendario = new Calendario();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Digite uma das opções ou 'q' para sair");
                Console.WriteLine("(1) Verificar calendário de um mês");
                Console.WriteLine("(2) Calcular diferença de dias entre duas datas");
                // Console.WriteLine("(3) Verificar se é feriado");

                string input = Console.ReadLine();

                if (input.ToLower() == "q") break;

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Digite o mês (1-12):");
                        int mes = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o ano:");
                        int ano = int.Parse(Console.ReadLine());
                        calendario.ExibirCalendarioMes(mes, ano);
                        break;
                    case "2":
                        Console.WriteLine("Digite a primeira data (formato: dd-MM-yyyy):");
                        DateTime dataInicio = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                        Console.WriteLine("Digite a segunda data (formato: dd-MM-yyyy):");
                        DateTime dataFim = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                        int diferencaDias = calendario.CalcularDiferencaDias(dataInicio, dataFim);
                        Console.WriteLine($"Diferença em dias: {diferencaDias}");
                        break;
                    // case "3":
                    //     break;
                    case "q":
                        return;
                }
                
                Console.WriteLine($"{Environment.NewLine}Pressione Enter para continuar...");
                Console.ReadLine();
            }
        }
    }
}