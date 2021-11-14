using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class ProdutoDAOEntity : IProdutoDAO, IDisposable
    {
        private LojaContext _context;

        public ProdutoDAOEntity()
        {
            this._context = new LojaContext();
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IList<Produto> Produtos()
        {
            var produtos = _context.Produtos.ToList();

            return produtos;
        }

        public void Remover(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }
    }
}
