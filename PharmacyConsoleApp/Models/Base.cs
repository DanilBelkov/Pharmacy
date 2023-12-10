
using System.ComponentModel.DataAnnotations;

namespace PharmacyConsoleApp.Models
{
    public class Base
    {
        [Display(Name = "Код")]
        public int Id { get; set; }
    }
}
