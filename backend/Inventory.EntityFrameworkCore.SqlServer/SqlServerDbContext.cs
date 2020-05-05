using Microsoft.EntityFrameworkCore;

namespace Inventory.EntityFrameworkCore.SqlServer
{
    public class SqlServerDbContext : EntityDbContext
    {
        public SqlServerDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}