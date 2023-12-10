
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyConsoleApp.Controllers
{
    public interface IBaseController
    {
        public string EntityName { get; }
        public string RegisterName { get; }
        public Dictionary<string, string> Columns { get; set; }
        public Task Create();

        public Task Delete(int id);
    }
}
