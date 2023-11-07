using AutoServiceSale.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace AutoServiceSale.Entities.Concrete
{
    public class Auto : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        public int BrandId { get; set; }
        [StringLength(20)]
        public string Color { get; set; }
        
        public decimal Price { get; set; }
        [StringLength(20)]
        public string Model { get; set; }
        [StringLength(20)]
        public string NumberPlate { get; set; }
        [StringLength(20)]
        public string BanType { get; set; }
        public int ModelYear { get; set; }
        public bool IsOnSale { get; set; }
        public bool IsHomePage { get; set; }
        public string Notes { get; set; }
        [StringLength(50)]
        public string? Picture1URL { get; set; }
        [StringLength(50)]
        public string? Picture2URL { get; set; }
        [StringLength(50)]
        public string? Picture3URL { get; set; }
        public virtual  Brand? Brand { get; set; }
        
    }
}
