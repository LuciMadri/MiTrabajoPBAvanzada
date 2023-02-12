using Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class ShippersModel
    {

        public int ShipperId { get; set; }
        [Required]
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }

    }
}
