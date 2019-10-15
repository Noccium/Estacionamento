using System;
using System.Collections.Generic;
using System.Text;

namespace Estacionamento
{
    public abstract class Veiculo
    {
        private string _placa;
        private DateTime _dataEntrada;
        private DateTime _dataSaida;
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
                placa : throw new Exception("Placa Inválida! Exemplo Placa Válida: ABC1234");
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
