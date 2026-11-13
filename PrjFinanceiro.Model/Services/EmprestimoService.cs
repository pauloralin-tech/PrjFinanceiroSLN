namespace PrjFinanceiro.Model.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        public decimal CalcularJurosSimples(decimal valor, double taxa)
        {
            if (valor < 0)
                throw new ArgumentOutOfRangeException(nameof(valor), "O valor não pode ser negativo.");
            if (taxa < 0)
                throw new ArgumentOutOfRangeException(nameof(taxa), "A taxa não pode ser negativa.");

            decimal juros = valor * (decimal)taxa;
            return valor + juros;
        }
       
        public decimal CalcularJurosCompostos(decimal valor, double taxaMensal, int meses)
        {
            if (valor < 0)
                throw new ArgumentOutOfRangeException(nameof(valor), "O valor não pode ser negativo.");
            if (taxaMensal < 0)
                throw new ArgumentOutOfRangeException(nameof(taxaMensal), "A taxa não pode ser negativa.");
            if (meses < 0)
                throw new ArgumentOutOfRangeException(nameof(meses), "O número de meses não pode ser negativo.");

            // M = P * (1 + i)^n
            double montante = (double)valor * Math.Pow(1 + taxaMensal, meses);

            return Math.Round((decimal)montante, 2);
        }
    }
}
