using Estacionamento.Veiculos;
using Estacionamento.BancoDeDados;
using System;

namespace Estacionamento.Calculo
{
    public static class CalculoValorPago
    {
        private const int _ocorrenciaAtualQueAindaNaoFoiAdicionada = 1;
        private const int _quantidadeDeOcorrenciasParaValorPagoReceberZero = 4;
        private const int _minutosMaximosParaValorPagoReceberValorBase = 15;
        private const int _primeiraHora = 1;

        public static double CalculaValorPago(Veiculo veiculo, BancoDeDadosEstacionamento bancoDeDados)
        {
            double valorPago;
            if (VeiculoUtilizouEstacionamentoTresVezes(veiculo, bancoDeDados))
            {
                valorPago = 0;
            }
            else if (VeiculoFicouMenosDe15Minutos(veiculo))
            {
                valorPago = veiculo.ValorBaseHora;
            }
            else
            {
                valorPago = veiculo.ValorBaseHora +
                veiculo.ValorPorHora * (GetTotalHours(veiculo) - _primeiraHora);
            }
            return valorPago;
        }
        private static bool VeiculoUtilizouEstacionamentoTresVezes(Veiculo veiculo, BancoDeDadosEstacionamento bancoDeDados)
        {
            return (bancoDeDados.ListaDeOcorrencias(veiculo).Count + _ocorrenciaAtualQueAindaNaoFoiAdicionada) %
                            _quantidadeDeOcorrenciasParaValorPagoReceberZero == 0;
        }

        private static bool VeiculoFicouMenosDe15Minutos(Veiculo veiculo)
        {
            return (veiculo.GetDataSaida() - veiculo.GetDataEntrada()).TotalMinutes < _minutosMaximosParaValorPagoReceberValorBase;
        }

        private static double GetTotalHours(Veiculo veiculo)
        {
            //Ceiling arredonda horas para cima
            return Math.Ceiling((veiculo.GetDataSaida() - veiculo.GetDataEntrada()).TotalHours);
        }
    }
}
