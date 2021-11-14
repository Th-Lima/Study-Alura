using CasaDoCodigo.Models;
using System;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public interface ICadastroRepository
    {
        Cadastro Update(int cadastroId, Cadastro novoCadastro);
    }

    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(AplicationContext context) : base(context)
        {
        }

        public Cadastro Update(int cadastroId, Cadastro novoCadastro)
        {
            var cadastroDb = _dbSet.Where(x => x.Id == cadastroId).SingleOrDefault();

            if(cadastroDb == null)
            {
                throw new ArgumentNullException("Cadastro");
            }

            cadastroDb.Uptade(novoCadastro);
           
            _context.SaveChanges();
            return cadastroDb;
        }
    }
}
