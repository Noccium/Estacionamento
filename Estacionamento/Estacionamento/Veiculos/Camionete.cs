namespace Estacionamento.Veiculos
{
    public class Camionete : Veiculo
    {
        public override double ValorBaseHora => 3;
        public override double ValorPorHora => 5;
        public Camionete(string placa) : base(placa)
        {
        }
        public override EnumTipoVeiculo GetTipoVeiculo()
        {
            return EnumTipoVeiculo.Camionete;
        }
        public override string ToString()
        {
            return "Camionete " + GetPlaca();
        }
    }
}
