using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {
        [Fact]
        public void TestaObterTodos()
        {
            //Arrange
            var _repositorio = new ClienteRepositorio();

            //Act 
            List<Cliente> clientes = _repositorio.ObterTodos();

            var temClientes = clientes.Count > 1;

            //Assert
            Assert.NotNull(clientes);
            Assert.Equal(temClientes, clientes.Any());
        }
    }
}
