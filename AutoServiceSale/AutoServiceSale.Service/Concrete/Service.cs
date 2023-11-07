using AutoServiceSale.Data.Context;
using AutoServiceSale.Data.Repositories.Abstract;
using AutoServiceSale.Data.Repositories.Concrete;
using AutoServiceSale.Entities.Abstract;
using AutoServiceSale.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceSale.Service.Concrete
{
    public class Service<T> : Repository<T>,IService<T> where T : class, IEntity, new()
    {
        public Service(ApplicationContext context) : base(context)
        {
        }
    }
}
