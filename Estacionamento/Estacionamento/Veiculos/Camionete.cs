using Estacionamento;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoEstacionamento.Veiculos
{
    public class Camionete : Veiculo
    {
        public Camionete(string placa) : base(placa)
        {
        }
        public override EnumTipoVeiculo GetTipoVeiculo()
        {
            return EnumTipoVeiculo.Camionete;
        }
        public override string ToString()
        {
            return "Camionete " + this.GetPlaca();
        }
    }
}
