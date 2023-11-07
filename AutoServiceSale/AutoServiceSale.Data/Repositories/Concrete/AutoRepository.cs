using AutoServiceSale.Data.Context;
using AutoServiceSale.Data.Repositories.Abstract;
using AutoServiceSale.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutoServiceSale.Data.Repositories.Concrete
{
    public class AutoRepository : Repository<Auto>, IAutoRepository
    {
        public AutoRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Auto> FindtCustomAutoAsync(int id)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Brand).FirstOrDefaultAsync(a => a.Id==id);
        }

        public async Task<List<Auto>> GetAllCustomAutoAsync(Expression<Func<Auto, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Brand).ToListAsync();
        }

        public async Task<List<Auto>> GetAllCustomAutoAsync()
        {
            return await _dbSet.AsNoTracking().Include(x => x.Brand).ToListAsync();
        }
    }
}
