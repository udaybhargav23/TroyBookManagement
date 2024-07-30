using System.Linq.Expressions;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
            _db.Products.Include(u=>u.Category).Include(u=>u.CategoryId);

        }

        public void Add(T entity){
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T,bool>> filter, string? includeProperties=null){
            IQueryable<T> query = dbSet; //obtain the datasource
            query = query.Where(filter); //create the query
            if (!string.IsNullOrEmpty(includeProperties)){
                foreach(var includeProp in includeProperties
                            .Split(new char[] {','}, 
                            StringSplitOptions.RemoveEmptyEntries)){
                                query = query.Include(includeProp);
                            }
            }
            return query.FirstOrDefault(); //execute the query
        }

        public IEnumerable<T> GetAll(string? includeProperties=null){
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties)){
                foreach(var includeProp in includeProperties
                            .Split(new char[] {','}, 
                            StringSplitOptions.RemoveEmptyEntries)){
                                query = query.Include(includeProp);
                            }
            }
            return query.ToList();
        }

        public void Remove(T entity){
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity){
            dbSet.RemoveRange(entity);
        }

    }
}