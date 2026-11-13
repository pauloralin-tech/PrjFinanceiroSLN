namespace PrjFinanceiro.Model.Services
{
    public interface IEmprestimoService
    {
        // R1: ValorFinal = ValorBase + (ValorBase * Taxa)
        decimal CalcularJurosSimples(decimal valor, double taxa);

        // R2: M = P * (1 + i)^n
        decimal CalcularJurosCompostos(decimal valor, double taxaMensal, int meses);
    }
}
