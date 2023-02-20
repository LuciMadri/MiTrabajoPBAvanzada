using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ShipperViewModel
    {

        public int ShipperId { get; set; }
        [Display(Name = "Shipper")]
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
