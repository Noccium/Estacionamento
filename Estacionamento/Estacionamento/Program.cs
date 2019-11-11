using Estacionamento.Veiculos;
using System;

namespace Estacionamento
{
    class Program
    {
        static void Main(string[] args)
        {
            var placaCarro = "ABC1234";
            var placaCarro2 = "JBL0000";
            var placaCamionete = "JKS5843";
            var placaMotocicleta = "OKS1478";
            var placaMotocicleta2 = "BLZ1478";

            var estacionamento = Estacionamento.GetInstancia;

            Carro carro = new Carro(placaCarro);
            Carro carro2 = new Carro(placaCarro2);
            Camionete camionete = new Camionete(placaCamionete);
            Motocicleta motocicleta = new Motocicleta(placaMotocicleta);
            Motocicleta motocicleta2 = new Motocicleta(placaMotocicleta2);

            camionete._dataEntrada = DateTime.Now;
            carro._dataEntrada = DateTime.Now;
            motocicleta._dataEntrada = DateTime.Now;

            estacionamento.Entrada(camionete);
            camionete._dataSaida = camionete._dataEntrada.AddHours(3);
            estacionamento.Saida(camionete);

            estacionamento.Entrada(motocicleta);  
            motocicleta._dataSaida = motocicleta._dataEntrada.AddHours(4);
            estacionamento.Saida(motocicleta);

            estacionamento.Entrada(carro);
            carro._dataSaida = carro._dataEntrada.AddHours(1);
            estacionamento.Saida(carro);

            estacionamento.Entrada(carro2);
            carro2._dataSaida = carro2._dataEntrada.AddHours(5);
            estacionamento.Saida(carro2);

            carro._dataEntrada = DateTime.Now.AddDays(7);
            estacionamento.Entrada(carro);
            carro._dataSaida = carro._dataEntrada.AddHours(3);
            estacionamento.Saida(carro);

            carro._dataEntrada = DateTime.Now.AddDays(14);
            estacionamento.Entrada(carro);
            carro._dataSaida = carro._dataEntrada.AddHours(2);
            estacionamento.Saida(carro);

            carro._dataEntrada = DateTime.Now.AddDays(21);
            estacionamento.Entrada(carro);
            carro._dataSaida = carro._dataEntrada.AddHours(1);
            estacionamento.Saida(carro);

            camionete._dataEntrada = DateTime.Now.AddDays(7);
            estacionamento.Entrada(camionete);
            camionete._dataSaida = camionete._dataEntrada.AddHours(2);
            estacionamento.Saida(camionete);

            motocicleta2._dataEntrada = DateTime.Now.AddDays(2);
            estacionamento.Entrada(motocicleta2);
            motocicleta2._dataSaida = motocicleta2._dataEntrada.AddHours(2);
            estacionamento.Saida(motocicleta2);

            estacionamento.Relatorio();
            estacionamento.RelatorioDeterminadaData(DateTime.Now);
            estacionamento.RelatorioOrdenadoPorTipoEPlaca();
            estacionamento.RelatorioAgrupadoPorQuantidadeVeiculosDataDeUso(DateTime.Now);
            estacionamento.RelatorioAgrupadoPorQuantidadeVeiculosDataDeUso(new DateTime());
            estacionamento.RelatorioAgrupadoPorQuantidadeVeiculosDataDeUso(DateTime.Now.AddDays(2));
            estacionamento.RelatorioTempoMedioDeCadaTipoDeVeiculo();
        }
    }
}
