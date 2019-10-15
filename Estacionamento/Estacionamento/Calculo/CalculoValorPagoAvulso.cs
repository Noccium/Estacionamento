using Estacionamento;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoEstacionamento.CalculoValorPago
{
    public abstract class CalculoValorPagoAvulso
    {
        public double ValorBaseHora { get; set; }
        public double ValorPorHora { get; set; }
        public double Calcula(Veiculo veiculo, BancoDeDadosEstacionamento bancoDeDados)
        {
            double valorPago = 0;
            if (bancoDeDados.ListaDeOcorrencias(veiculo).Count % 3 == 0)
            {
                valorPago = 0;
            }
            else if ((veiculo.GetDataSaida() - veiculo.GetDataEntrada()).TotalMinutes < 15)
            {
                valorPago = ValorBaseHora;
            }
            else
            {
                valorPago = (ValorBaseHora +
                ValorPorHora * (veiculo.GetDataSaida() - veiculo.GetDataEntrada()).TotalHours - 1);
            }
            //arredonda para cima
            valorPago = Math.Ceiling(valorPago);
            return valorPago;
        }
    }
}
