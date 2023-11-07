using AutoServiceSale.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceSale.Entities.Concrete
{
    public class Role:IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "{0} can not be blank")]
        public string Name { get; set; }
    }
}
