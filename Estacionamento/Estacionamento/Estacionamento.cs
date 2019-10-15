using System;
using System.Collections.Generic;

namespace Estacionamento
{
    public class Estacionamento
    {
        private static Estacionamento _estacionamento;
        private static BancoDeDadosEstacionamento _tabelaEstacionamento;
        public static Estacionamento GetInstancia => 
            _estacionamento ?? (_estacionamento = new Estacionamento());
        private Estacionamento() {
            _tabelaEstacionamento = new BancoDeDadosEstacionamento();
            _tabelaEstacionamento.CriaTabela();
        }
        public override string ToString() => "Estacionamento";    
        public void Entrada(Veiculo veiculo)
        {
            veiculo.SetDataEntrada();
            _tabelaEstacionamento.AdicionaVeiculo(veiculo);
        }
        public void Entrada(List<Veiculo> listaVeiculo)
        {
            listaVeiculo.ForEach(veiculo => Entrada(veiculo));
        }
        public void Saida(Veiculo veiculo)
        {
            veiculo.SetDataSaida();
            _tabelaEstacionamento.AdicionaOcorrencia(veiculo);
        }
        public void Saida(List<Veiculo> listaVeiculo)
        {
            listaVeiculo.ForEach(veiculo => Saida(veiculo));
        }
        public void Relatorio()
        {
            foreach (var tipo in _tabelaEstacionamento._tabela)
            {
                Console.WriteLine("Tipo " + tipo.Key );
                foreach (var veiculo in tipo.Value)
                {
                    Console.WriteLine(veiculo.Key + ":");
                    veiculo.Value.ForEach(x => Console.WriteLine(x));
                }
                Console.WriteLine();
            }
        }
    }
}
