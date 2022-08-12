using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ContaCorrenteRepositorioTestes
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public ContaCorrenteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
            var provedor = servico.BuildServiceProvider();

            _contaCorrenteRepositorio = provedor.GetService<IContaCorrenteRepositorio>() ?? throw new ArgumentException(nameof(_contaCorrenteRepositorio));
        }

        [Fact]
        public void TestaObterTodos()
        {
            //Arrange
            //Act 
            List<ContaCorrente> contaCorrentes = _contaCorrenteRepositorio.ObterTodos();

            var temContasCorrentes = contaCorrentes.Count > 1;

            //Assert
            Assert.NotNull(contaCorrentes);
            Assert.Equal(temContasCorrentes, contaCorrentes.Any());
        }

        [Fact]
        public void TestaObterContaCorrentePorId()
        {
            //Arrange
            //Act
            var contaCorrente = _contaCorrenteRepositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(contaCorrente);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterContaCorrentePorVariosIds(int id)
        {
            //Arrange
            //Act
            var contaCorrente = _contaCorrenteRepositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(contaCorrente);
        }

        [Fact]
        public void TestaAtualizaSaldoDeterminadaConta()
        {
            //Arrange
            var conta = _contaCorrenteRepositorio.ObterPorId(1);
            double saldoNovo = 15;
            conta.Saldo = saldoNovo;

            //Act
            var atualizado = _contaCorrenteRepositorio.Atualizar(1, conta);

            //Assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaInseriUmaNovaContaCorrenteNoBancoDeDados()
        {
            //Arrange
            var contaCorrente = new ContaCorrente()
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente
                {
                    Nome = "Kent Nelson",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Bancário",
                    Id = 1
                },
                Agencia = new Agencia
                {
                    Nome = "Agencia Central Coast City",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Rua das Flores 25",
                    Numero = 174
                }
            };

            //Act
            var retorno = _contaCorrenteRepositorio.Adicionar(contaCorrente);

            //Assert
            Assert.True(retorno);
        }
    }
}
