using Base.IRepositories;
using Base.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services
{
    public class Service : IService
    {
        private IDatabase _database;
        public Service(IDatabase database)
        {
            _database = database;
        }

        public async Task<List<string>> FetchSQL(string SQLType, string Server, string Database, string User, string Password, string Table, string Column)
        {
            if (string.IsNullOrWhiteSpace(Server) || string.IsNullOrWhiteSpace(Database) || string.IsNullOrWhiteSpace(User) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Table) || string.IsNullOrWhiteSpace(Column))
            {
                return ["One of the fields is empty, please ensure they are all filled out."];
            }
            List<string> list = await _database.RunQuery(SQLType, Server, Database, User, Password, Table, Column);
            return list;
        }

        public int FetchTemperature(DateTime date)
        {
            return (int)((date.Day - date.Month) * 5 / 2);
        }
    }
}
