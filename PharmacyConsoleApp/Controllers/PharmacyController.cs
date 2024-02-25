
using PharmacyConsoleApp.Models;
using System;
using System.Collections;
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

                var query = $"INSERT INTO Pharmacy (Name, Address, PhoneNumber) VALUES ('{pharmacy.Name}', '{pharmacy.Address}', '{pharmacy.PhoneNumber}')";
               
                await DbConnectionController.ExecuteQueryAsync(query);
            }
            catch { throw new Exception("Error about create Pharmacy"); }
        }

        public override async Task Delete(int id)
        {
            try
            {
                var query = $"DELETE FROM Pharmacy WHERE ID = {id}";
                await DbConnectionController.ExecuteQueryAsync(query);
            }
            catch { throw new Exception("Error about delete Pharmacy"); }
        }
    }
}
