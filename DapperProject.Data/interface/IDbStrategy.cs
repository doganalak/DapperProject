using System.Data;

namespace DapperProject.Data
{
    public interface IDbStrategy
    {
        IDbConnection GetConnection(string connectionString);
    }
}
