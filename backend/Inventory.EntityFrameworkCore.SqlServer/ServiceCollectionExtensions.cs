using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Inventory.EntityFrameworkCore.SqlServer
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSqlServer(this DbContextOptionsBuilder options, string connectionString)
        {
            options.UseSqlServer(connectionString);
        }

        public static void UseSqlServerAutoMigrations(this IApplicationBuilder app, string connectionString)
        {
            var builder = new DbContextOptionsBuilder<SqlServerDbContext>();
            builder.UseSqlServer(connectionString);

            var context = new SqlServerDbContext(builder.Options);
            context.Database.Migrate();
        }
    }
}