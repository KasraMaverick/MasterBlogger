using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _0_Framework.Infrastructure
{
    public class BaseRepository<Tkey, T> : IRepository<Tkey, T> where T : DomainBase<Tkey>
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public T Get(Tkey id)
        {
            return _context.Find<T>();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
