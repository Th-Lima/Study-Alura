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
                Console.WriteLine("CLIENTE");
                foreach (var cliente in contexto.Clientes)
                {
                    Console.WriteLine(cliente);
                }

                Console.WriteLine("\n FUNCIONARIO");
                foreach (var funcionario in contexto.Funcionarios)
                {
                    Console.WriteLine(funcionario);
                }
            }
        }
    }
}