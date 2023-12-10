using PharmacyConsoleApp.Controllers;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PharmacyConsoleApp
{
    public class PharmacyConsoleApp
    {
        private static string _connectionString;
        public static async Task Main(string[] args)
        {
            _connectionString = "Server=DESKTOP-NUJ7UH6\\SQLEXPRESS;Database=Pharmacy;Trusted_Connection=True;";

            MainMenu();

            Console.ReadKey();
        }

        private static void ShowRegister(IBaseController controller)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var command = new SqlCommand($"SELECT * FROM {controller.EntityName}", connection);
                    var reader = command.ExecuteReader();
                    var count = reader.GetColumnSchema().Count;
                    string columns = "|";
                    for (int i = 0; i < count; i++)
                    { 
                        if(controller.Columns.TryGetValue(reader.GetName(i), out string value))
                            columns += String.Format("{0, 25}", value + "|");
                    }
                    Console.WriteLine(columns);

                    while (reader.Read())
                    {
                        string line = "|";
                        for (int i = 0; i < count; i++)
                            line += String.Format("{0, 25}", reader.GetValue(i) + "|");
                        Console.WriteLine(line);
                    }

                }
            }
            catch (Exception ex) { }
        }
        private static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\tРеестры");
            Console.WriteLine("1 - Товары");
            Console.WriteLine("2 - Аптеки");
            Console.WriteLine("3 - Склады");
            Console.WriteLine("4 - Партии");
            Console.WriteLine("\n0 - Выход");

            switch(Console.ReadLine())
            {
                case "1": RegisterMenu(new ProductController(_connectionString)); break;
                case "2": RegisterMenu(new PharmacyController(_connectionString)); break;
                case "3": RegisterMenu(new WarehouseContriller(_connectionString)); break;
                case "4": RegisterMenu(new BatchController(_connectionString)); break;
                case "0": Environment.Exit(0); break;
                default: MainMenu(); break;
            }
        }
        private static async void RegisterMenu(IBaseController controller)
        {
            Console.Clear();
            Console.WriteLine("\t\t" + controller.RegisterName);
            Console.WriteLine("1 - Создать");
            Console.WriteLine("2 - Удалить");
            Console.WriteLine("\n0 - Назад\n");

            ShowRegister(controller);

            switch (Console.ReadLine())
            {
                case "1":
                    controller.Create().Wait();
                    RegisterMenu(controller); break;
                case "2":
                    Console.WriteLine("Вы уверены, что хотите удалить запись?");
                    Console.WriteLine("1 - да\n2 - нет");
                    if (Console.ReadLine() == "2")
                    {
                        RegisterMenu(controller);
                        break;
                    }
                    Console.WriteLine("\nВведите Код записи для удаления");
                    controller.Delete(int.Parse(Console.ReadLine())).Wait();
                    RegisterMenu(controller); break;

                case "0": MainMenu(); break;
                default: RegisterMenu(controller); break;
            }
        }
    }
}