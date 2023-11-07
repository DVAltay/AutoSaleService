using AutoServiceSale.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace AutoServiceSale.Entities.Concrete
{
    public class Service : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime InServiceDate { get; set; }
        public DateTime OutServiceDate { get; set; }
        public string AutoTrouble { get; set; }
        public decimal ServicePrice { get; set; }
        public string DoneProcess { get; set; }
        public bool InWarranty { get; set; }
        public string AutoNumberPlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string BanType { get; set; }
        public string BanNo { get; set; }
        public string Notes { get; set; }
    }
}
