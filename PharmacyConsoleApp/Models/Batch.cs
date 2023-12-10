
using System.ComponentModel.DataAnnotations;

namespace PharmacyConsoleApp.Models
{
    public class Batch : Base
    {
        [Display(Name = "Код продукта")]
        public int ProductId { get; set; }
        [Display(Name = "Код склада")]
        public int WarehouseId { get; set; }
        [Display(Name = "Количество продуктов")]
        public int ProductCount { get; set; }

        public bool IsValid => ProductId != 0 && WarehouseId != 0;
    }
}
