using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.IServices
{
    public interface IService
    {
        int FetchTemperature(DateTime date);
        Task<List<string>> FetchSQL(string SQLType, string Server, string Database, string User, string Password, string Table, string Column);
    }
}
