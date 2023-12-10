
using PharmacyConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PharmacyConsoleApp.Controllers
{
    public class WarehouseContriller : BaseController<Warehouse>
    {
        public WarehouseContriller(string connection) : base(connection) 
        {
            Columns = new Dictionary<string, string> { { "ID", "Код" }, { "Name", "Название" }, { "PharmacyId", "Код аптеки" } };
        }
        public override string RegisterName => "Склады";
        public override async Task Create()
        {
            try
            {
                Warehouse warehouse = new Warehouse();
                Console.WriteLine("Создание Склада:");
                Console.Write("Наименование - ");
                warehouse.Name = Console.ReadLine();
                Console.Write("Код аптеки - ");
                warehouse.PharmacyId = int.Parse(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(_sqlConnection))
                {
                    await connection.OpenAsync();
                    var query = $"INSERT INTO Warehouse (Name, PharmacyId) VALUES ('{warehouse.Name}', {warehouse.PharmacyId})";
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
                    var query = $"DELETE FROM Warehouse WHERE ID = {id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch { }
        }
    }
}
