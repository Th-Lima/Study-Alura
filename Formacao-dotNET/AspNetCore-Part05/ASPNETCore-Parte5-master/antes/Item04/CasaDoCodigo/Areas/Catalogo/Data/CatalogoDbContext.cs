using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CasaDoCodigo.Areas.Catalogo.Data
{
    public class CatalogoDbContext : DbContext
    {
        public CatalogoDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var produtos = GetProdutos();
            var categorias = produtos.Select(x => x.Categoria).Distinct();


            modelBuilder.Entity<Categoria>(builder =>
            {
                builder.HasKey(t => t.Id);
                builder.HasData(categorias); //PROPAGAÇÃO DE DADOS - SEEDING DATA
            });

            modelBuilder.Entity<Produto>(builder =>
            {
                builder.HasKey(t => t.Id);
                builder.HasData(produtos.Select(x => new
                {
                    x.Id,
                    x.Codigo,
                    x.Nome,
                    x.Preco,
                    CategoriaId = x.Categoria.Id
                })); //PROPAGAÇÃO DE DADOS - SEEDING DATA
            });
        }

        private List<Livro> GetLivros()
        {
            var json = File.ReadAllText("data/livros.json");

            return JsonConvert.DeserializeObject<List<Livro>>(json);
        }

        private List<Produto> GetProdutos()
        {
            var livros = GetLivros();

            var categorias = livros
                .Select(x => x.Categoria) // PROJECÃO / TRANSFORMAÇÃO DE DADOS
                .Distinct()
                .Select((nomeCategoria, index) =>
                {
                    var categoria = new Categoria(nomeCategoria);

                    categoria.Id = index + 1;

                    return categoria;
                });

            var produtos = (from livro in livros
                            join categoria in categorias
                            on livro.Categoria equals categoria.Nome
                            select new Produto(livro.Codigo, livro.Nome, livro.Preco, categoria))
                            .Select((produto, i) =>
                            {
                                produto.Id = i + 1;
                                return produto;
                            })
                            .ToList();

            return produtos;
        }
    }
}
