using _0_Framework.Domain;
using System.Linq.Expressions;

namespace _0_Framework.Infrastructure
{
    public interface IRepository<Tkey, T> where T : DomainBase<Tkey>
    {
        void Create(T entity);
        T Get(Tkey id);
        List<T> GetAll();
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
