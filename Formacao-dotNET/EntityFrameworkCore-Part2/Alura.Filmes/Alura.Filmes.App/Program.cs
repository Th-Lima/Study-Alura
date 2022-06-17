using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {

                var filme = new Filme()
                {
                    Titulo = "Cassino Royale",
                    Duracao = 120,
                    AnoLancamento = "2000",
                    Classificacao = ClassificacaoEnum.MaioresQue14Anos,
                    IdiomaFalado = contexto.Idiomas.First()
                };

                contexto.Entry(filme).Property("last_update").CurrentValue = DateTime.Now;

                contexto.Filmes.Add(filme);
                contexto.SaveChanges();

                var filemInserido = contexto.Filmes.First(x => x.Titulo == "Cassino Royale");

                Console.WriteLine(filemInserido.Classificacao);
            }
        }
    }
}