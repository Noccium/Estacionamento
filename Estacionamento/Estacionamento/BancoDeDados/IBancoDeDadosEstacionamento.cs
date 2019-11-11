using Estacionamento.Veiculos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estacionamento
{
    interface IBancoDeDadosEstacionamento
    {
        void CriaTabela();
        void AdicionaTipoVeiculo(EnumTipoVeiculo enumTipo);
        void AdicionaVeiculo(Veiculo veiculo);
        void AdicionaOcorrencia(Veiculo veiculo);
        List<Tuple<DateTime, DateTime, double>> ListaDeOcorrencias(Veiculo veiculo);
        void RemoveVeiculo(Veiculo veiculo);
        bool VeiculoExiste(Veiculo veiculo);
        bool TipoVeiculoExiste(Veiculo veiculo);
    }
}
