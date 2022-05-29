using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using System;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //SELECT * FROM actor

            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                foreach (var item in contexto.Atores)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}