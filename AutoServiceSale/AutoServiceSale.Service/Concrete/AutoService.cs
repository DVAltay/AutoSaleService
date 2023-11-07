using AutoServiceSale.Data.Context;
using AutoServiceSale.Data.Repositories.Concrete;
using AutoServiceSale.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceSale.Service.Concrete
{
    public class AutoService : AutoRepository, IAutoService
    {
        public AutoService(ApplicationContext context) : base(context)
        {
        }
    }
}
