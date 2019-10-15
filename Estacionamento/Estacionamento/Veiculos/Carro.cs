using System;
using System.Collections.Generic;
using System.Text;

namespace Estacionamento
{
    public class Carro : Veiculo
    {
        public Carro(string placa) : base(placa)
        {
        }
        public override EnumTipoVeiculo GetTipoVeiculo()
        {
            return EnumTipoVeiculo.Carro;
        }
        public override string ToString()
        {
            return "Carro " + this.GetPlaca();
        }
    }
}
