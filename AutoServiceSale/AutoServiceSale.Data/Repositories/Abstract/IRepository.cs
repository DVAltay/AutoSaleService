using System.Linq.Expressions;

namespace AutoServiceSale.Data.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(string? includeprops = null, string includeprops2 = null);
        List<T> GetAll(Expression<Func<T,bool>> expression);

        T Get(Expression<Func<T, bool>> expression);
        T Find(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Save();
        
        //Async methods
        Task<int> SaveAsync();
        Task AddAsync(T entity);
        Task<T> FindAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> GetAllAsync(string? includeprops = null, string includeprops2 = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
    }
}
