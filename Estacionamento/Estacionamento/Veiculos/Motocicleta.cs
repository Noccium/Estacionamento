namespace Estacionamento.Veiculos
{
    public class Motocicleta : Veiculo
    {
        public override double ValorBaseHora => 1;
        public override double ValorPorHora => 1.5;
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
