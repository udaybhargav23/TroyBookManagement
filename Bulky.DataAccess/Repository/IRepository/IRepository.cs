using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T Get(Expression<Func<T,bool>> filter, string? includeProperties=null);
        IEnumerable<T> GetAll(string? includeProperties=null);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);

    }
}