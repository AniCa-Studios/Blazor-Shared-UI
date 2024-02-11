using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.IRepositories
{
    public interface IDatabase
    {
        Task<List<string>> RunQuery(string SQLType, string Server, string Database, string User, string Password, string Table, string Column);
    }
}
