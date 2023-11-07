using AutoServiceSale.Entities.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoServiceSale.Entities.Concrete
{
    public class Customer:IEntity
    {
        [Key]
        public int Id { get; set; }
        
        public int AutoId { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "{0} can not be blank")]
     
        public string Name { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "{0} can not be blank")]
        public string LastName { get; set; }
        [StringLength(12)]
        [Required(ErrorMessage = "{0} can not be blank")]
        public string PassportNo { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "{0} can not be blank")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} can not be blank")]
        public string Adress { get; set; }
        [StringLength(15)]
        [Required(ErrorMessage = "{0} can not be blank")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "{0} can not be blank")]
        public string Notes { get; set; }
        public virtual Auto? Auto { get; set; }
    }
}
