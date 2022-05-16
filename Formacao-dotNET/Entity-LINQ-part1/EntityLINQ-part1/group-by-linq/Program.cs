using System;
using System.Collections.Generic;
using System.Linq;

namespace group_by_linq
{

    class Program
    {
        static void Main(string[] args)
        {
            var listaDeProdutos = new List<Produto>()
            {
                new Produto { Id = 9, CategoriaId = 1, Nome = "Geladeira", Status = true, Valor = 1200},
                new Produto { Id = 10, CategoriaId = 3, Nome = "Blusa", Status = true, Valor = 1200},
                new Produto { Id = 11, CategoriaId = 1, Nome = "Celular", Status = true, Valor = 1200},
                new Produto { Id = 12, CategoriaId = 2, Nome = "Arroz", Status = true, Valor = 1200},
                new Produto { Id = 13, CategoriaId = 2, Nome = "Feijão", Status = true, Valor = 1200},
                new Produto { Id = 14, CategoriaId = 3, Nome = "Bermuda", Status = true, Valor = 1200},
                new Produto { Id = 15, CategoriaId = 1, Nome = "Headset", Status = true, Valor = 1200},
                new Produto { Id = 16, CategoriaId = 1, Nome = "Tv", Status = true, Valor = 1200},
                new Produto { Id = 17, CategoriaId = 1, Nome = "PS4", Status = true, Valor = 1200},
                new Produto { Id = 18, CategoriaId = 3, Nome = "Jaqueta", Status = true, Valor = 1200}
            };

            var listaDeCategorias = new List<Categoria>()
            {
                new Categoria { Id = 1, Nome = "Eletrônicos", Status = true},
                new Categoria { Id = 2, Nome = "Alimentos", Status = true},
                new Categoria { Id = 3, Nome = "Vestuário", Status = true}
            };

            var query =
                from p in listaDeProdutos
                join c in listaDeCategorias on p.CategoriaId equals c.Id
                orderby c.Nome
                group p by new
                {
                    Categoria = c.Nome
                };

            foreach (var item in query)
            {
                Console.WriteLine(item.Key);

                foreach (var prod in item)
                {
                    Console.WriteLine($"Produto: {prod.Nome}");
                }

                Console.WriteLine();
            }
        }
    }

    public class Produto
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public decimal Valor { get; set; }
    }

    public class Categoria
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Nome { get; set; }
    }
}
