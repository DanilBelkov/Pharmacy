
using System.ComponentModel.DataAnnotations;

namespace PharmacyConsoleApp.Models
{
    public class Product : BaseName
    {
        [Display(Name = "Цена")]
        public decimal? Cost { get; set; }
    }
}
