using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTests
    {
        [Fact(DisplayName = "Teste número 1")]
        [Trait("Funcionalide", "Acelerar")]
        public void TestVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste número 2")]
        [Trait("Funcionalide", "Frear")]
        public void TestVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste número 3", Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {

        }
    }
}