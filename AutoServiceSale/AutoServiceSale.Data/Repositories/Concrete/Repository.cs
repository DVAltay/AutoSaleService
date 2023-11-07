using AutoServiceSale.Data.Context;
using AutoServiceSale.Data.Repositories.Abstract;
using AutoServiceSale.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AutoServiceSale.Data.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : class ,IEntity,new()
    {
        internal  ApplicationContext _context;
        internal  DbSet<T> _dbSet;
        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet=_context.Set<T>();
        }

       
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Find(int id)
        {
          return _dbSet.Find(id); 
        }

        public async Task<T> FindAsync(int id)
        {
          return await _dbSet.FindAsync(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll(string? includeprops = null, string? includeprops2 = null)
        {
            
            IQueryable<T> query = _dbSet;
            if (!string.IsNullOrEmpty(includeprops))
            {
                foreach (var includeprop in includeprops.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }

            }
            if (!string.IsNullOrEmpty(includeprops2))
            {
                foreach (var includeprop2 in includeprops2.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop2);
                }
            }

            return query.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {

            return _dbSet.Where(expression).ToList();
        }

        public async Task<List<T>> GetAllAsync(string? includeprops = null,string? includeprops2=null)
        {
            IQueryable<T> query = _dbSet;
            if (!string.IsNullOrEmpty(includeprops))
            {
                foreach (var includeprop in includeprops.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
                
            }
            if (!string.IsNullOrEmpty(includeprops2))
            {
                foreach (var includeprop2 in includeprops2.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop2);
                }
            }
                return await query.ToListAsync();
        }




        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
           _dbSet.Update(entity);
        }
    }
}
