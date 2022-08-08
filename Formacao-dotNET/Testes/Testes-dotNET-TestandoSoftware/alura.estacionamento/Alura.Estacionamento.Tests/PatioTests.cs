using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests
{
    public class PatioTests : IDisposable
    {
        private Veiculo _veiculo;
        private Patio _patio;
        public ITestOutputHelper ConsoleTest;

        public PatioTests(ITestOutputHelper consoleTest)
        {
            ConsoleTest = consoleTest;
            ConsoleTest.WriteLine("Construtor Invocado");

            _veiculo = new Veiculo();
            _patio = new Patio();
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            _veiculo.Proprietario = "Thales";
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Cor = "Preto";
            _veiculo.Modelo = "Civic";
            _veiculo.Placa = "AWD-5236";

            _patio.RegistrarEntradaVeiculo(_veiculo);
            _patio.RegistrarSaidaVeiculo(_veiculo.Placa);

            //Act
            double faturamento = _patio.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-9999", "preto", "Gol", TipoVeiculo.Automovel)]
        [InlineData("Thales Lima", "CVG-9851", "prata", "Civic", TipoVeiculo.Automovel)]
        [InlineData("João dos Santos", "LOJ-4201", "preto", "Faze", TipoVeiculo.Motocicleta)]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario,
                                                            string placa,
                                                            string cor,
                                                            string modelo,
                                                            TipoVeiculo tipo)
        {
            //Arrange
            _veiculo.Proprietario = proprietario;
            _veiculo.Tipo = tipo;
            _veiculo.Cor = cor;
            _veiculo.Modelo = modelo;
            _veiculo.Placa = placa;

            _patio.RegistrarEntradaVeiculo(_veiculo);
            _patio.RegistrarSaidaVeiculo(_veiculo.Placa);

            //Act
            double faturamento = _patio.TotalFaturado();

            //Assert
            if (tipo == TipoVeiculo.Automovel)
                Assert.Equal(2, faturamento);
            else
                Assert.Equal(1, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-9999", "preto", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string proprietario,
                                                string placa,
                                                string cor,
                                                string modelo)
        {
            //Arrange
            _veiculo.Proprietario = proprietario;
            _veiculo.Cor = cor;
            _veiculo.Modelo = modelo;
            _veiculo.Placa = placa;

            _patio.RegistrarEntradaVeiculo(_veiculo);

            //Act
            var consultado = _patio.PesquisaVeiculo(_veiculo.IdTicket);

            //Assert
            Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
        }

        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            //Arrange
            _veiculo.Proprietario = "Thales";
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Cor = "Preto";
            _veiculo.Modelo = "Civic";
            _veiculo.Placa = "AWD-5236";

            _patio.RegistrarEntradaVeiculo(_veiculo);

            var veiculoAlterado = new Veiculo
            {
                Proprietario = "Thales",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Prata", //Alterado
                Modelo = "Civic",
                Placa = "AWD-5236"
            };

            //Act
            Veiculo alterado = _patio.AlteraDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            ConsoleTest.WriteLine("Dispose Invocado");
        }
    }
}
