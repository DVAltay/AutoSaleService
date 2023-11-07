using AutoServiceSale.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceSale.Entities.Concrete
{
    public class Slider : IEntity
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Header { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        [StringLength(30)]
        public string? Picture { get; set; }
        
        public string? URL { get; set; }

    }
}
