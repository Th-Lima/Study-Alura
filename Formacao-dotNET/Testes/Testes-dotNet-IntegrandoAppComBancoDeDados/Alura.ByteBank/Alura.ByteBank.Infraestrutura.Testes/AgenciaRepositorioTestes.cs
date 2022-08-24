using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servicos;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _agenciaRepositorio;

        public AgenciaRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = servico.BuildServiceProvider();

            _agenciaRepositorio = provedor.GetService<IAgenciaRepositorio>() ?? throw new ArgumentException(nameof(_agenciaRepositorio));
        }

        [Fact]
        public void TestaObterTodos()
        {
            //Arrange
            //Act 
            List<Agencia> agencias = _agenciaRepositorio.ObterTodos();

            var temAgencias = agencias.Count > 1;

            //Assert
            Assert.NotNull(agencias);
            Assert.Equal(temAgencias, agencias.Any());
        }

        [Fact]
        public void TestaObterAgenciaPorId()
        {
            //Arrange
            //Act
            var agencia = _agenciaRepositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(agencia);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterAgenciaPorVariosIds(int id)
        {
            //Arrange
            //Act
            var agencia = _agenciaRepositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(agencia);
        }

        [Fact]
        public void TestaExcecaoConsultaPorAgenciaId()
        {
            //Act
            //Assert
            Assert.Throws<FormatException>(
                () => _agenciaRepositorio.ObterPorId(33)
            );
        }

        [Fact]
        public void TestaAdicionarAgenciaMock()
        {
            //Arrange
            var agencia = new Agencia()
            {
                Nome = "Agencia Nacional",
                Identificador = Guid.NewGuid(),
                Id = 4,
                Endereco = "Rua Arthur Costa",
                Numero = 6668
            };

            var repositorioMock = new ByteBankRepositorio();

            //Act
            var adicionado = repositorioMock.AdicionarAgencia(agencia);

            //Assert
            Assert.True(adicionado);
        }

        [Fact]
        public void TestaObterAgenciasMock()
        {
            //Arrange
            var byteBankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = byteBankRepositorioMock.Object;

            //Act
            mock.BuscarAgencias();

            //Assert
            byteBankRepositorioMock.Verify(b => b.BuscarAgencias());
        }
    }
}
