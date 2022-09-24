using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

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
    }
}