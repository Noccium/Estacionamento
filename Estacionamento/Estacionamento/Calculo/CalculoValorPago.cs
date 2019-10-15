using ProjetoEstacionamento.CalculoValorPago;
using ProjetoEstacionamento.Veiculos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estacionamento.Calculo
{
    public class CalculoValorPago : CalculoValorPagoAvulso
    {
        public delegate double CalculaValorVeiculo(Veiculo veiculo, BancoDeDadosEstacionamento bancoDeDados );
        public double CalculaValor(Carro carro, BancoDeDadosEstacionamento bancoDeDados)
        {
            ValorBaseHora = 3;
            ValorPorHora = 1.5;
            return Calcula(carro, bancoDeDados);  
        }
        public double CalculaValor(Camionete camionete, BancoDeDadosEstacionamento bancoDeDados)
        {
            ValorBaseHora = 3;
            ValorPorHora = 1.5;
            return Calcula(camionete, bancoDeDados);
        }
        public double CalculaValor(Motocicleta motocicleta, BancoDeDadosEstacionamento bancoDeDados)
        {
            ValorBaseHora = 1;
            ValorPorHora = 1.5;
            return Calcula(motocicleta, bancoDeDados);
        }
    }
}
