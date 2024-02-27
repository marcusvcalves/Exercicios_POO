using System;

namespace Hotel
{
    public class Suite
    {
        private string _numeroSuite;
        private int _capacidade;
        private double _valorDiaria;

        public Suite(string numeroSuite, int capacidade, double valorDiaria)
        {
            _numeroSuite = numeroSuite;
            _capacidade = capacidade;
            _valorDiaria = valorDiaria;
        }

        public string GetNumeroSuite() => _numeroSuite;
        
        public override string ToString() => $"Número da suíte: {_numeroSuite}" +
                                             $"{Environment.NewLine}Capacidade: {_capacidade}" +
                                             $"{Environment.NewLine}Valor diária: R${_valorDiaria}{Environment.NewLine}";
    }
}