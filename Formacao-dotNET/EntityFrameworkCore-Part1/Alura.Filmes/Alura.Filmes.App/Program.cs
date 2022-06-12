using Alura.Filmes.App.Dados;
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
                var idiomas = contexto.Idiomas
                    .Include(f => f.FilmesFalados);

                foreach (var idioma in idiomas)
                {
                    Console.WriteLine(idioma);

                    foreach (var filme in idioma.FilmesFalados)
                    {
                        Console.WriteLine(filme);
                    }
                    Console.WriteLine("\n");
                }
            }
        }
    }
}