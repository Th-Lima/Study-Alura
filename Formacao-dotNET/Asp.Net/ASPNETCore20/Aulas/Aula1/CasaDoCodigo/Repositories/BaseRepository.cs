using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly AplicationContext _context;
        protected readonly DbSet<T> _dbSet;

        protected BaseRepository(AplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
    }
}
