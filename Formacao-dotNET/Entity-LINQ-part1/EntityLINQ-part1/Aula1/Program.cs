using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Genero> generos = new List<Genero>()
            {
                new Genero { Id = 1, Name = "Rock"},
                new Genero { Id = 2, Name =  "Reggae"},
                new Genero { Id = 3, Name =  "Rock Progressivo"},
                new Genero { Id = 4, Name =  "Punk"},
                new Genero { Id = 5, Name =  "Clássica"}
            };

            var musicas = new List<Musica>()
            {
                new Musica { Id = 1, Name = "Sweet Child O'Mine", GeneroId = 1 },
                new Musica { Id = 2, Name = "I Shoot The Sheriff", GeneroId = 2},
                new Musica { Id = 3, Name = "Danúbio Azul", GeneroId = 5},
            };


            //Listar os genêros rock
            //var generosRock = generos.Where(x => x.Name.Contains("Rock")); Também pode ser feito desta maneira !
            var generosRock =
                from g in generos
                where g.Name.Contains("Rock")
                select g;

            Console.WriteLine();
            Console.WriteLine("Listar os genêros rock");
            Console.WriteLine();
            foreach (var genero in generosRock)
            {
                Console.WriteLine("{0}\t{1}", genero.Id, genero.Name);
            }




            //Selecionar todas a músicas junto com os nomes dos generos
            var musicaQuery =
                from m in musicas
                join g in generos on m.GeneroId equals g.Id
                select new { m, g };

            Console.WriteLine();
            Console.WriteLine("Selecionar todas a músicas junto com os nomes dos generos");
            Console.WriteLine();
            foreach (var musica in musicaQuery)
            {
                Console.WriteLine("{0}\t{1}\t{2}", musica.m.Id, musica.m.Name, musica.g.Name);
            }


            // Crie uma consulta para listar os nomes das músicas cujo gênero tenha o nome "Reggae".
            var query =
                from m in musicas
                join g in generos on m.GeneroId equals g.Id
                where g.Name == "Reggae"
                select m.Name;

            Console.WriteLine();
            Console.WriteLine("Crie uma consulta para listar os nomes das músicas cujo gênero tenha o nome 'Reggae'");
            Console.WriteLine();
            foreach (var musica in query)
            {
                Console.WriteLine(musica);
            }
        }
    }
}
