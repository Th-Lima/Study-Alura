﻿using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.WebApp.Controllers;
using Alura.CoisasAFazer.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Alura.CoisasAFazer.Tests
{
    public class TarefasControllerTests
    {
        [Fact]
        public void DadaTarefaComInformacoesValidasDeveRetornar200()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;

            var contexto = new DbTarefasContext(options);
           
            contexto.Categorias.Add(new Categoria(20, "Estudo"));
            contexto.SaveChanges();

            var categoriaId = contexto.Categorias.Where(c => c.Id == 20).First().Id;
            
            var repo = new RepositorioTarefa(contexto);
            
            var controller = new TarefasController(repo, mockLogger.Object);
            var model = new CadastraTarefaVM()
            {
                IdCategoria = categoriaId,
                Titulo = "Estudar xUnit",
                Prazo = new DateTime(2022, 12, 31)
            };

            //Act
            var result = controller.EndpointCadastraTarefa(model);

            //Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
