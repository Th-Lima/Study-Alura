using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                var categoria = "Action";

                var paramCategoria = new SqlParameter("category_name", categoria);
                
                var paramTotal = new SqlParameter
                {
                    ParameterName = @"total_actors",
                    Size = 4,
                    Direction = ParameterDirection.Output
                };

                contexto.Database
                    .ExecuteSqlCommand(
                    "total_actors_from_given_category @category_name, @total_actors OUT", 
                    paramCategoria, 
                    paramTotal);

                Console.WriteLine($"O Total de atores na categoria {categoria} é de {paramTotal.Value}");
            }
        }
    }
}