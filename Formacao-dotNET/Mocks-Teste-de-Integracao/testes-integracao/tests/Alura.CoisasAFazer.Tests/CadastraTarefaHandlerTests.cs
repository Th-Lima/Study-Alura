using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services;
using Alura.CoisasAFazer.Services.Handlers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Alura.CoisasAFazer.Tests
{
    public class CadastraTarefaHandlerTests
    {
        [Fact]
        public void DadaTarefaComInfoValidaDeveIncluirNoBD()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar xUnit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;

            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto);

            var handler = new CadastraTarefaHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            var tarefa = repo.ObtemTarefas(x => x.Titulo == "Estudar xUnit").FirstOrDefault();

            tarefa.Should().NotBeNull();
        }

        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalso()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar xUnit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new Exception("Houve um erro ao incluir as tarefas"));

            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo);

            //act
            CommandResult resultado = handler.Execute(comando);

            //Assert
            resultado.IsSuccess.Should().BeFalse();
        }
    }
}