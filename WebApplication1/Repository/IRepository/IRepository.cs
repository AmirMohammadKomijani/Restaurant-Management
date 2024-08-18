using System.Linq.Expressions;

namespace WebApplication1.Repository.IRepository
{
        public interface IRepository<T> where T : class
        {
            Task<List<T>> getAll(Expression<Func<T, bool>>? filter = null);
            Task<T> getOne(Expression<Func<T, bool>>? filter = null, bool tracked = true);
            Task Create(T entity);
            Task Remove(T entity);
            Task Save();
        }
}
