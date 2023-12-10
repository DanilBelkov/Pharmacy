
using System.ComponentModel.DataAnnotations;

namespace PharmacyConsoleApp.Models
{
    public class BaseName : Base
    {
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
