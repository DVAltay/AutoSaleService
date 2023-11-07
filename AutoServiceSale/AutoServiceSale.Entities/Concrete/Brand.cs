using AutoServiceSale.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceSale.Entities.Concrete
{
    public class Brand:IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public ICollection<Auto> Autos { get; set; }
    }
}
