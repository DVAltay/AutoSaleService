using AutoServiceSale.Entities.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoServiceSale.Entities.Concrete
{
    public class User:IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage ="{0} can not be blank")]
        public string Name { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "{0} can not be blank")]
        [DisplayName("Surname")]
        public string LastName { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "{0} can not be blank")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [StringLength(15)]
        [Required(ErrorMessage = "{0} can not be blank")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "{0} can not be blank")]
        [DisplayName("Username")]
        public string UserName { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "{0} can not be blank")]
        public string Password { get; set; }
        [DisplayName("Active User?")]
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public Guid? UserGuid { get; set; } = Guid.NewGuid();
       
        
        [Required(ErrorMessage = "{0} can not be blank")]
        [DisplayName("Role")]
        public int RoleId { get; set; }



        public virtual Role? Role { get; set; }  
    }
}
