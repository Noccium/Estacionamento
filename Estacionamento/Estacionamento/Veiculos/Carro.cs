namespace Estacionamento.Veiculos
{
    public class Carro : Veiculo
    {
        public override double ValorBaseHora => 3;
        public override double ValorPorHora => 1.5;
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
