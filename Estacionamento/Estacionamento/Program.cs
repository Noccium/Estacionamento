using ProjetoEstacionamento.Veiculos;
using System;


namespace Estacionamento
{
    class Program
    {
        static void Main(string[] args)
        {
            var placaCarro = "ABC1234";          
            var placaCamionete = "JKS5843";
            var placaMotocicleta= "OKS1478";

            var estacionamento = Estacionamento.GetInstancia;

            Carro carro = new Carro(placaCarro);
            Camionete camionete = new Camionete(placaCamionete);
            Motocicleta motocicleta = new Motocicleta(placaMotocicleta);

            estacionamento.Entrada(carro);
            estacionamento.Entrada(camionete);
            estacionamento.Entrada(motocicleta);

            estacionamento.Saida(carro);
            estacionamento.Saida(camionete);
            estacionamento.Saida(motocicleta);

            estacionamento.Entrada(carro);
            estacionamento.Saida(carro);

            estacionamento.Relatorio();
        }
    }
}
