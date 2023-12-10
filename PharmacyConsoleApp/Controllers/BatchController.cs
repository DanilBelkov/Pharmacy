
using PharmacyConsoleApp.Models;
using System;
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

                using (SqlConnection connection = new SqlConnection(_sqlConnection))
                {
                    await connection.OpenAsync();
                    var query = $"INSERT INTO Batch (ProductId, WarehouseId, ProductCount) VALUES ('{batch.ProductId}', {batch.WarehouseId}, {batch.ProductCount})";
                    SqlCommand command = new SqlCommand(query, connection);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch { }

        }

        public override async Task Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_sqlConnection))
                {
                    await connection.OpenAsync();
                    var query = $"DELETE FROM Batch WHERE ID = {id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch { }
        }
    }
}
