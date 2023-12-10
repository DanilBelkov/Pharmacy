
using PharmacyConsoleApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyConsoleApp.Controllers
{
    public abstract class BaseController<T> : IBaseController
        where T : Base  
    {
        public BaseController(string connection)
        {
            _sqlConnection = connection;
        }

        protected string _sqlConnection;
        public string EntityName => typeof(T).Name;
        public virtual string RegisterName { get; }
        public Dictionary<string, string> Columns { get; set; }

        public abstract Task Create();

        public abstract Task Delete(int id);
    }
}
