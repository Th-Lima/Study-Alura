using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services;
using Alura.CoisasAFazer.Services.Handlers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;

namespace Alura.CoisasAFazer.Tests
{
    public class CadastraTarefaHandlerTests
    {
        private readonly AutoMocker _mocker;

        public CadastraTarefaHandlerTests()
        {
            _mocker = new AutoMocker();
        }

        [Fact]
        public void DadaTarefaComInfoValidaDeveIncluirNoBD()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar xUnit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var mock = new Mock<ILogger<CadastraTarefaHandler>>();
            var logger = mock.Object;

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;

            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto);

            var handler = new CadastraTarefaHandler(repo, logger);

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

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new Exception("Houve um erro ao incluir as tarefas"));

            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            //act
            CommandResult resultado = handler.Execute(comando);

            //Assert
            resultado.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void QuandoExceptionForLancadaDeveLogarAMensagemDaExcecao()
        {
            //Arrange
            var exceptionMessage = "Houve um erro ao incluir as tarefas";
            var expectedException = new Exception(exceptionMessage);

            var comando = new CadastraTarefa("Estudar xUnit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var mockLogger = _mocker.GetMock<ILogger<CadastraTarefaHandler>>();

            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new Exception(exceptionMessage));

            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            //Act
            CommandResult resultado = handler.Execute(comando);

            //Assert
            mockLogger.Verify(x => x.Log(
                    LogLevel.Error, //nível do log
                    It.IsAny<EventId>(), //identificador do evento
                    It.IsAny<object>(), //objeto que será logado
                    expectedException, //exceção que será logada
                    It.IsAny<Func<object, Exception, string>>() //função que converte objeto+exceção >> string
                ),  
                Times.Once());
        }

        delegate void CapturaMensagemDeLog(LogLevel logLevel, EventId eventId, object state, Exception exception, Func<object, Exception, string> function);

        [Fact]
        public void DadaTarefaComInfoValidaDeveLogar()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar xUnit", new Categoria("Estudo"), new DateTime(2019, 12, 31));
            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            string mensagemCapturada = string.Empty;
            CapturaMensagemDeLog captura = (level, eventId, state, exception, func) =>
            {
                mensagemCapturada = func(state, exception);
            };
      
            mockLogger.Setup(l => l.Log(
                    It.IsAny<LogLevel>(), //nível do log
                    It.IsAny<EventId>(), //identificador do evento
                    It.IsAny<object>(), //objeto que será logado
                    It.IsAny<Exception>(), //exceção que será logada
                    It.IsAny<Func<object, Exception, string>>())).Callback(captura);

            var mock = new Mock<IRepositorioTarefas>();

            var handler = new CadastraTarefaHandler(mock.Object, mockLogger.Object);

            //act
            handler.Execute(comando);

            //assert
            Assert.Equal("Persistindo a tarefa...", mensagemCapturada);
        }
    }
}