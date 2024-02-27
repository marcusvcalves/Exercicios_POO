using System;

namespace Hotel
{
    public class Reserva
    {
        private int _reservaId;
        private Pessoa _pessoa;
        private Suite _suite;
        private DateTime _dataInicio;
        private DateTime _dataFim;

        public Reserva(int reservaId, Pessoa pessoa, Suite suite, DateTime dataInicio, DateTime dataFim)
        {
            _reservaId = reservaId;
            _pessoa = pessoa;
            _suite = suite;
            _dataInicio = dataInicio;
            _dataFim = dataFim;
        }

        public int GetReservaId() => _reservaId;

        public override string ToString() => $"ID da Reserva: {_reservaId}" +
                                             $"{Environment.NewLine}CPF do hóspede: {_pessoa.GetCpf()}" +
                                             $"{Environment.NewLine}Número da suíte: {_suite.GetNumeroSuite()}" +
                                             $"{Environment.NewLine}Data de início: {_dataInicio}" +
                                             $"{Environment.NewLine}Data de término: {_dataFim}{Environment.NewLine}";
    }
}