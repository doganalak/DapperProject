using System.Data;

namespace DapperProject.Data.Context
{
    public class DbContext
    {
        private IDbStrategy _dbStrategy;

        public DbContext SetStrategy()
        {
            _dbStrategy = new SqlServerStrategy();
            return this;
        }

        public IDbConnection GetDbContext(string connectionString)
        {
            return _dbStrategy.GetConnection(connectionString);
        }
    }
}
