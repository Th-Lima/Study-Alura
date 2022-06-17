using Alura.Filmes.App.Dados;
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
                var ator1 = new Ator { PrimeiroNome = "Emma", UltimoNome = "Watson" };
                var ator2 = new Ator { PrimeiroNome = "Emma", UltimoNome = "Watson" };
                contexto.AddRange(ator1, ator2);

                contexto.SaveChanges();

                var emmaWatson = contexto.Atores.Where(x => x.PrimeiroNome == "Emma" && x.UltimoNome == "Watson");
                Console.WriteLine($"Quantidade de atores com esse nome encontrados: {emmaWatson.Count()}");
            }
        }
    }
}