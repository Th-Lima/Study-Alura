using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Moq;

namespace Alura.CoisasAFazer.Tests
{
    public class ObtemCategoriaPorIdTests
    {
        [Fact]
        public void QuandoOIdForExistenteDeveChamarObtemCategoriaPorIdUmaUnicaVez()
        {
            //Arrange
            var idCategoria = 20;
            var comando = new ObtemCategoriaPorId(idCategoria);
            var mock = new Mock<IRepositorioTarefas>();

            var repo = mock.Object;

            var handler = new ObtemCategoriaPorIdHandler(repo);

            //Act
            handler.Execute(comando);

            //Assert
            mock.Verify(r => r.ObtemCategoriaPorId(idCategoria), Times.Once);
        }
    }
}
