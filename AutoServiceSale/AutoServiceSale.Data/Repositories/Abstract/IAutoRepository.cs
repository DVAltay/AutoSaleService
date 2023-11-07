using AutoServiceSale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceSale.Data.Repositories.Abstract
{
    public interface IAutoRepository:IRepository<Auto>
    {
        public Task<Auto>FindtCustomAutoAsync(int id);

        public Task<List<Auto>> GetAllCustomAutoAsync(Expression<Func<Auto, bool>> expression);
        public Task<List<Auto>> GetAllCustomAutoAsync();

    }
}
