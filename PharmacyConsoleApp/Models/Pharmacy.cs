
using System.ComponentModel.DataAnnotations;

namespace PharmacyConsoleApp.Models
{
    public class Pharmacy : BaseName
    {
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
    }
}
