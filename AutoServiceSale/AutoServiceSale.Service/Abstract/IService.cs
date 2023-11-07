using AutoServiceSale.Data.Repositories.Abstract;
using AutoServiceSale.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceSale.Service.Abstract
{
    public interface IService<T>:IRepository<T> where T : class,IEntity, new()    
    {
    }
}
