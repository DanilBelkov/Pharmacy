
using PharmacyConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PharmacyConsoleApp.Controllers
{
    public class ProductController : BaseController<Product>
    {
        public ProductController(string connection) : base(connection) 
        {
            Columns = new Dictionary<string, string> { {"ID", "Код" }, {"Name", "Название" }, { "Cost", "Цена" } };
        }
        public override string RegisterName => "Товары";
        public override async Task Create()
        {
            try
            {
                Product product = new Product();
                Console.WriteLine("Создание товара:");
                Console.Write("Наименование - ");
                product.Name = Console.ReadLine();
                Console.Write("Цена - ");
                var cost = Console.ReadLine();
                product.Cost = !string.IsNullOrEmpty(cost) ? decimal.Parse(cost) : 0;

                var query = $"INSERT INTO Product (Name, Cost) VALUES ('{product.Name}', {product.Cost.ToString()?.Replace(',', '.')})";

                await DbConnectionController.ExecuteQueryAsync(query);
               
            }
            catch { throw new Exception("Error about create product"); }
        }

        public override async Task Delete(int id)
        {
            try
            {
                var query = $"DELETE FROM Product WHERE ID = {id}";
                await DbConnectionController.ExecuteQueryAsync(query);
            }
            catch { throw new Exception("Error about delete product"); }
        }
    }
}
