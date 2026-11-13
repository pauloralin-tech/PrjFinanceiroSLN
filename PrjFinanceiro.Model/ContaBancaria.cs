namespace PrjFinanceiro.Model
{
    public class ContaBancaria
    {
        public string NumeroConta { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
        public Cliente Cliente { get; set; } = new Cliente();
        public Agencia Agencia { get; set; } = new Agencia();
    }
}
