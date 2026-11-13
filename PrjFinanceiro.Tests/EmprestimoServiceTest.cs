using PrjFinanceiro.Model.Services;
using Xunit;

namespace PrjFinanceiro.Tests
{
    public class EmprestimoServiceTest
    {
        // ---------- R1: Juros simples ----------

        [Fact]
        public void CalcularJurosSimples_1000Com10Porcento_Retorna1100()
        {
            // Arrange
            IEmprestimoService service = new EmprestimoService();
            decimal valor = 1000m;
            double taxa = 0.10;

            // Act
            decimal resultado = service.CalcularJurosSimples(valor, taxa);

            // Assert
            Assert.Equal(1100m, resultado);
        }

        [Fact]
        public void CalcularJurosSimples_ValorNegativo_LancaExcecao()
        {
            var service = new EmprestimoService();
            Assert.Throws<ArgumentOutOfRangeException>(() => service.CalcularJurosSimples(-1m, 0.10));
        }

        [Theory]
        [InlineData(500, 0.05, 525)]
        [InlineData(1000, 0, 1000)]
        [InlineData(2000, 0.5, 3000)]
        public void CalcularJurosSimples_VariosCenarios(decimal valor, double taxa, decimal esperado)
        {
            var service = new EmprestimoService();
            Assert.Equal(esperado, service.CalcularJurosSimples(valor, taxa));
        }

        // ---------- R2: Juros compostos ----------

        [Fact]
        public void CalcularJurosCompostos_1000Com2PorCentoPor12Meses_Retorna1268_24()
        {
            // Arrange
            IEmprestimoService service = new EmprestimoService();
            decimal valor = 1000m;
            double taxaMensal = 0.02;
            int meses = 12;

            // Act
            decimal resultado = service.CalcularJurosCompostos(valor, taxaMensal, meses);

            // Assert
            Assert.Equal(1268.24m, resultado);
        }

        [Fact]
        public void CalcularJurosCompostos_ValorNegativo_LancaExcecao()
        {
            var service = new EmprestimoService();
            Assert.Throws<ArgumentOutOfRangeException>(() => service.CalcularJurosCompostos(-1m, 0.02, 12));
        }

        [Theory]
        [InlineData(1000, 0.02, 0, 1000)]
        [InlineData(1000, 0, 12, 1000)]
        [InlineData(1000, 0.10, 2, 1210)]
        public void CalcularJurosCompostos_VariosCenarios(decimal valor, double taxa, int meses, decimal esperado)
        {
            var service = new EmprestimoService();
            Assert.Equal(esperado, service.CalcularJurosCompostos(valor, taxa, meses));
        }
    }
}
