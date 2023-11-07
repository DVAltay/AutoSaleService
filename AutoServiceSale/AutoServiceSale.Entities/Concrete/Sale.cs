using AutoServiceSale.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceSale.Entities.Concrete
{
    public class Sale : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} can not be blank")]
        public int AutoId { get; set; }
        [Required(ErrorMessage = "{0} can not be blank")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "{0} can not be blank")]
        public decimal SalePrice { get; set; }
        [Required(ErrorMessage = "{0} can not be blank")]
        public DateTime SaleDate { get; set; }
        public virtual Auto? Auto { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
