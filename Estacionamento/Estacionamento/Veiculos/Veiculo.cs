using System;
namespace Estacionamento.Veiculos
{
    public abstract class Veiculo
    {
        private string _placa;
        public DateTime _dataEntrada;
        public DateTime _dataSaida;
        public abstract double ValorBaseHora { get; }
        public abstract double ValorPorHora { get; }
        public Veiculo(string placa)
        {
            SetPlaca(placa);
        }
        public string GetPlaca()
        {
            return _placa;
        }
        public void SetPlaca(string placa)
        {
            _placa = Uteis.ValidaPlaca(placa) ?
                placa : throw new Exception("\nPlaca Inválida! Exemplo Placa Válida: ABC1234\n");
        }
        public DateTime GetDataEntrada()
        {
            return _dataEntrada;
        }
        public void SetDataEntrada()
        {
            _dataEntrada = DateTime.Now;
        }
        public DateTime GetDataSaida()
        {
            return _dataSaida;
        }
        public void SetDataSaida()
        {
            _dataSaida = DateTime.Now;
        }
        public abstract EnumTipoVeiculo GetTipoVeiculo();
    }
}
