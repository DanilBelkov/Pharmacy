
using PharmacyConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PharmacyConsoleApp.Controllers
{
    public class PharmacyController : BaseController<Pharmacy>
    {
        public PharmacyController(string connection) : base(connection)
        {
            Columns = new Dictionary<string, string> { { "ID", "Код" }, { "Name", "Название" }, { "Address", "Адрес" }, { "PhoneNumber", "Телефон" } };
        }
        public override string RegisterName => "Аптеки";
        public override async Task Create()
        {
            try
            {
                Pharmacy pharmacy = new Pharmacy();
                Console.WriteLine("Создание Аптеки:");
                Console.Write("Наименование - ");
                pharmacy.Name = Console.ReadLine();
                Console.Write("Адрес - ");
                pharmacy.Address = Console.ReadLine();
                Console.Write("Телефон - ");
                pharmacy.PhoneNumber = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(_sqlConnection))
                {
                    await connection.OpenAsync();
                    var query = $"INSERT INTO Pharmacy (Name, Address, PhoneNumber) VALUES ('{pharmacy.Name}', '{pharmacy.Address}', '{pharmacy.PhoneNumber}')";
                    SqlCommand command = new SqlCommand(query, connection);
                    await command.ExecuteNonQueryAsync();
                }

            }
            catch { throw new Exception("Error about create Pharmacy"); }
        }

        public override async Task Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_sqlConnection))
                {
                    await connection.OpenAsync();
                    var query = $"DELETE FROM Pharmacy WHERE ID = {id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch { throw new Exception("Error about delete Pharmacy"); }
        }
    }
}
