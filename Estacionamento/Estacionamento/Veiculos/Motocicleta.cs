using Estacionamento;
using ProjetoEstacionamento.Veiculos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoEstacionamento.Veiculos
{
    public class Motocicleta : Veiculo
    {
        public Motocicleta(string placa) : base(placa)
        {
        }
        public override EnumTipoVeiculo GetTipoVeiculo()
        {
            return EnumTipoVeiculo.Motocicleta;
        }
        public override string ToString()
        {
            return "Motocicleta " + this.GetPlaca();
        }
    }
}
