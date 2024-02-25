
using PharmacyConsoleApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PharmacyConsoleApp.Controllers
{
    public class BatchController : BaseController<Batch>
    {
        public BatchController(string connection) : base(connection) 
        {
            Columns = new Dictionary<string, string> { { "ID", "Код" }, { "ProductId", "Код продукта" }, { "WarehouseId", "Код склада" }, { "ProductCount", "Количество продуктов" } };
        }
        public override string RegisterName => "Партии";
        public override async Task Create()
        {
            try
            {
                Batch batch = new Batch();
                Console.WriteLine("Создание партии:");
                Console.Write("Код товара - ");
                batch.ProductId = int.Parse(Console.ReadLine());
                Console.Write("Код склада - ");
                batch.WarehouseId = int.Parse(Console.ReadLine());
                Console.Write("Количество товара - ");
                batch.ProductCount = int.Parse(Console.ReadLine());

                var query = $"INSERT INTO Batch (ProductId, WarehouseId, ProductCount) VALUES ('{batch.ProductId}', {batch.WarehouseId}, {batch.ProductCount})";
                await DbConnectionController.ExecuteQueryAsync(query);
            }
            catch { throw new Exception("Error about create Batch"); }

        }

        public override async Task Delete(int id)
        {
            try
            {
                var query = $"DELETE FROM Batch WHERE ID = {id}";
                await DbConnectionController.ExecuteQueryAsync(query);
            }
            catch { throw new Exception("Error about delete Batch"); }
        }
    }
}
