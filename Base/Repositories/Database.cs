using Base.IRepositories;
using Dapper;
using MySqlConnector;
using System.Data.SqlClient;

namespace Base.Repositories
{
    public class Database : IDatabase
    {
        public async Task<List<string>> RunQuery(string SQLType, string Server, string Database, string User, string Password, string Table, string Column)
        {
            if (SQLType.Equals("mssql"))
            {
                string connectionString = $"Server={Server}; User ID={User}; Password={Password}; Database={Database}";
                string sql = $"SELECT TOP 10 {Column} FROM {Table}; ";
                try
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        await connection.OpenAsync();
                        IEnumerable<string> result = await connection.QueryAsync<string>(sql);
                        await connection.CloseAsync();
                        return result.AsList();
                    }
                }
                catch (Exception ex)
                {
                    return [ex.Message];
                }

            }
            else if (SQLType.Equals("mysql"))
            {
                string connectionString = $"Server={Server}; User ID={User}; Password={Password}; Database={Database}";
                string sql = $"SELECT {Column} FROM {Table} LIMIT 10; ";
                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        await connection.OpenAsync();
                        IEnumerable<string> result = await connection.QueryAsync<string>(sql);
                        await connection.CloseAsync();
                        return result.AsList();
                    }
                }
                catch (Exception ex)
                {
                    return [ex.Message];
                }
            }
            else
            {
                return ["SQL Type is not a valid option."];
            }
        }
    }
}
