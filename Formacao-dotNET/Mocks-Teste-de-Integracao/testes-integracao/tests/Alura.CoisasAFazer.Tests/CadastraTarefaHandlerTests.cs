using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Services.Handlers;
using FluentAssertions;

namespace Alura.CoisasAFazer.Tests
{
    public class CadastraTarefaHandlerTests
    {
        [Fact]
        public void DadaTarefaComInfoValidaDeveIncluirNoBD()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar xUnit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var repo = new RepositorioFake();

            var handler = new CadastraTarefaHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            var tarefa = repo.ObtemTarefas(x => x.Titulo == "Estudar xUnit").FirstOrDefault();

            tarefa.Should().NotBeNull();
        }
    }
}