using AutoServiceSale.Entities.Concrete;

namespace AutoServiceSale.WebUI.Models
{
    public class HomePageModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Auto> Autos { get; set; }
    }
}
