using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using static CasaDoCodigo.Repositories.ProdutoRepository;

namespace CasaDoCodigo
{
    class DataService : IDataService
    {
        private readonly AplicationContext context;
        private readonly IProdutoRepository _produtoRepository;

        public DataService(AplicationContext context, IProdutoRepository produtoRepository)
        {
            this.context = context;
            _produtoRepository = produtoRepository;
        }

        public void InicializaDb()
        {
            this.context.Database.EnsureCreated();

            List<Livro> livros = GetLivros();

            _produtoRepository.SaveProdutos(livros);
        }

        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");

            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            
            return livros;
        }
    }

   
}
