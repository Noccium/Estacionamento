using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Estacionamento
{
    public class BancoDeDadosEstacionamento : IBancoDeDadosEstacionamento
    {
        public Dictionary<EnumTipoVeiculo, Dictionary<string, List<Tuple<DateTime, DateTime, double>>>> _tabela;
        public Dictionary<string, List<(DateTime, DateTime, double)>> _veiculo;
        public void CriaTabela()
        {
           _tabela = new Dictionary<EnumTipoVeiculo, Dictionary<string, List<Tuple<DateTime, DateTime, double>>>>();
        }
        public void AdicionaTipoVeiculo(EnumTipoVeiculo enumTipo)
        {
            _tabela.Add(enumTipo, new Dictionary<string, List<Tuple<DateTime, DateTime, double>>>());
        }
        public void AdicionaVeiculo(Veiculo veiculo)
        {
            if (!TipoVeiculoExiste(veiculo))
                AdicionaTipoVeiculo(veiculo.GetTipoVeiculo());
            if (!VeiculoExiste(veiculo))
                _tabela[veiculo.GetTipoVeiculo()].Add(veiculo.GetPlaca(), new List<Tuple<DateTime, DateTime, double>>());
        }
        public void AdicionaOcorrencia(Veiculo veiculo)
        {
            Tuple<DateTime, DateTime, double> ocorrencia = 
                new Tuple<DateTime, DateTime, double>(veiculo.GetDataEntrada(), veiculo.GetDataSaida(), 0.0);

            if (!TipoVeiculoExiste(veiculo))
                AdicionaTipoVeiculo(veiculo.GetTipoVeiculo());

            if (!VeiculoExiste(veiculo))
                AdicionaVeiculo(veiculo);
             
            ListaDeOcorrencias(veiculo).Add(ocorrencia);
        }
        public List<Tuple<DateTime, DateTime, double>> ListaDeOcorrencias(Veiculo veiculo)
        {
            return _tabela[veiculo.GetTipoVeiculo()][veiculo.GetPlaca()];
        }
        public void RemoveVeiculo(Veiculo veiculo)
        {
            if (VeiculoExiste(veiculo))
                _tabela[veiculo.GetTipoVeiculo()][veiculo.GetPlaca()].Clear();
            else throw new ArgumentNullException();
        }
        public bool VeiculoExiste(Veiculo veiculo)
        {
            return  _tabela[veiculo.GetTipoVeiculo()].ContainsKey(veiculo.GetPlaca());
        }
        public bool TipoVeiculoExiste(Veiculo veiculo)
        {
            return _tabela.ContainsKey(veiculo.GetTipoVeiculo());
        }
    }
}
