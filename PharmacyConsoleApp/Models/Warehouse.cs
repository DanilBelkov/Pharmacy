
using System.ComponentModel.DataAnnotations;

namespace PharmacyConsoleApp.Models
{
    public class Warehouse : BaseName
    {
        [Display(Name = "Код аптеки")]
        public int PharmacyId { get; set; }

        public bool IsValid => PharmacyId != 0;
    }
}
