﻿using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Tests
{
    public class PatioTests
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = "Thales",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Preto",
                Modelo = "Civic",
                Placa = "AWD-5236"
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-9999", "preto", "Gol", TipoVeiculo.Automovel)]
        [InlineData("Thales Lima", "CVG-9851", "prata", "Civic", TipoVeiculo.Automovel)]
        [InlineData("João dos Santos", "LOJ-4201", "preto", "Faze", TipoVeiculo.Motocicleta)]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, 
                                                            string placa, 
                                                            string cor, 
                                                            string modelo,
                                                            TipoVeiculo tipo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Tipo = tipo,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            if(tipo == TipoVeiculo.Automovel)
                Assert.Equal(2, faturamento);
            else
                Assert.Equal(1, faturamento);
        }
    }
}
