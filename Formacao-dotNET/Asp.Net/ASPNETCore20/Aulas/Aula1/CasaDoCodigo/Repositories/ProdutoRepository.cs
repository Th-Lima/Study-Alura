using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AplicationContext context) : base(context) { }
        
        public IList<Produto> GetProdutos()
        {
            var produtos = _dbSet.ToList();
            
            return produtos;
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                if (!_dbSet.Where(x => x.Codigo == livro.Codigo).Any())
                {
                    _dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }

            _context.SaveChanges();
        }

        public class Livro
        {
            public string Codigo { get; set; }

            public string Nome { get; set; }

            public decimal Preco { get; set; }
        }
    }
}
