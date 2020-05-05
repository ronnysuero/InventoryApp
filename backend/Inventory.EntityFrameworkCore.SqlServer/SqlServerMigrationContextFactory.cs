using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Inventory.EntityFrameworkCore.SqlServer
{
    public class SqlServerMigrationContextFactory : IDesignTimeDbContextFactory<SqlServerDbContext>
    {
        public SqlServerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqlServerDbContext>();
            builder.UseSqlServer(@"Server=.;Database=DbInventory;Trusted_Connection=True;");

            return new SqlServerDbContext(builder.Options);
        }
    }
}