﻿using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = servico.BuildServiceProvider();

            _clienteRepositorio = provedor.GetService<IClienteRepositorio>() ?? throw new ArgumentException(nameof(_clienteRepositorio));
        }

        [Fact]
        public void TestaObterTodos()
        {
            //Arrange
            //Act 
            List<Cliente> clientes = _clienteRepositorio.ObterTodos();

            var temClientes = clientes.Count > 1;

            //Assert
            Assert.NotNull(clientes);
            Assert.Equal(temClientes, clientes.Any());
        }
    }
}
