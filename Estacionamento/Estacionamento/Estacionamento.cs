using Estacionamento.BancoDeDados;
using Estacionamento.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamento
{
    public class Estacionamento
    {
        private static Estacionamento _estacionamento;
        public static BancoDeDadosEstacionamento _tabelaEstacionamento;
        public static Estacionamento GetInstancia =>
            _estacionamento ?? (_estacionamento = new Estacionamento());
        private Estacionamento() {
            _tabelaEstacionamento = new BancoDeDadosEstacionamento();
            _tabelaEstacionamento.CriaTabela();
        }
        public override string ToString() => "Estacionamento";
        public void Entrada(Veiculo veiculo)
        {
            //veiculo.SetDataEntrada();
            _tabelaEstacionamento.AdicionaVeiculo(veiculo);
        }
        public void Entrada(List<Veiculo> listaVeiculo)
        {
            listaVeiculo.ForEach(veiculo => Entrada(veiculo));
        }
        public void Saida(Veiculo veiculo)
        {
            //veiculo.SetDataSaida();
            _tabelaEstacionamento.AdicionaOcorrencia(veiculo);
        }
        public void Saida(List<Veiculo> listaVeiculo)
        {
            listaVeiculo.ForEach(veiculo => Saida(veiculo));
        }
        public void Relatorio()
        {
            Console.WriteLine("Relatório Geral");
            foreach (var tipo in _tabelaEstacionamento._tabela)
            {
                Console.WriteLine("Tipo " + tipo.Key);
                foreach (var veiculo in tipo.Value)
                {
                    Console.WriteLine(veiculo.Key + ":");
                    veiculo.Value.ForEach(x => Console.WriteLine(x));
                    Console.WriteLine();
                }
            }
            Console.WriteLine("-------------------------------------------------------");
        }

        public void RelatorioDeterminadaData(DateTime data)
        {
            Console.WriteLine("Relatório Determinada Data");
            foreach (var tipo in _tabelaEstacionamento._tabela)
            {
                Console.WriteLine("Tipo " + tipo.Key);
                foreach (var veiculo in tipo.Value)
                {
                    if (veiculo.Value.Any(x => x.Item1.Date == data.Date))
                    {
                        Console.WriteLine(veiculo.Key);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------");
        }

        public void RelatorioOrdenadoPorTipoEPlaca()
        {
            Console.WriteLine("Relatório Ordenado por Tipo e Placa");
            foreach (var tipo in _tabelaEstacionamento._tabela.OrderBy(tipo => tipo.Key))
            {
                Console.WriteLine("Tipo: " + tipo.Key);
                foreach (var veiculo in tipo.Value.OrderBy(veiculo => veiculo.Key))
                {
                    Console.WriteLine(veiculo.Key + ":");
                    veiculo.Value.ForEach(x => Console.WriteLine(x));
                    Console.WriteLine();
                }             
            }
            Console.WriteLine("-------------------------------------------------------");
        }
        public void RelatorioAgrupadoPorQuantidadeVeiculosDataDeUso(DateTime dataDeUso)
        {
            Console.WriteLine("Relatorio Agrupado Por Quantidade Veiculos Data De Uso");
            var quantidade = 0;
            Console.Write(dataDeUso.Date.ToString("d") + " - ");
            foreach (var tipo in _tabelaEstacionamento._tabela)
            {
                quantidade = 0;

                foreach (var veiculo in tipo.Value)
                {
                    if (veiculo.Value.Any(x => x.Item1.Date == dataDeUso.Date))
                        quantidade++;
                }
                Console.Write(tipo.Key + ": " + quantidade + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("-------------------------------------------------------");
           
        }

        public void RelatorioTempoMedioDeCadaTipoDeVeiculo()
        {
            double tempoEmMinutosVeiculo = 0;
            double quantidadeVeiculos = 0;
            double tempoMedioTipoVeiculo = 0;

            Console.WriteLine("Relatorio Tempo Medio De Cada Tipo De Veiculo");
            foreach (var tipo in _tabelaEstacionamento._tabela)
            {
                tempoEmMinutosVeiculo = 0;
                foreach (var veiculo in tipo.Value)
                {
                    veiculo.Value.ForEach(x => {
                        tempoEmMinutosVeiculo += (x.Item2 - x.Item1).TotalMinutes;
                    });
                }
                quantidadeVeiculos = tipo.Value.Count;
                tempoMedioTipoVeiculo = tempoEmMinutosVeiculo / quantidadeVeiculos;

                Console.WriteLine(tipo.Key + "\nTempo Médio: " + tempoMedioTipoVeiculo + " minutos | " +
                    tempoMedioTipoVeiculo / 60 + " horas\n");
            }
            Console.WriteLine("-------------------------------------------------------");
        }
    }
}
