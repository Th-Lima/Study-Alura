using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTests : IDisposable
    {
        private Veiculo _veiculo;
        public ITestOutputHelper ConsoleTest;

        public VeiculoTests(ITestOutputHelper consoleTest)
        {
            ConsoleTest = consoleTest;
            ConsoleTest.WriteLine("Construtor Invocado");

            _veiculo = new Veiculo();
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            _veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, _veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            _veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, _veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            _veiculo.Proprietario = "Carlos Silva";
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Placa = "ZAP-7419";
            _veiculo.Cor = "Verde";
            _veiculo.Modelo = "Fox";

            //Act
            string dados = _veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veiculo:", dados);
        }

        public void Dispose()
        {
            ConsoleTest.WriteLine("Dispose Invocado");
        }
    }
}