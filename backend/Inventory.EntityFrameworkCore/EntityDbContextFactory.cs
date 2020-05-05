using System;
using Microsoft.EntityFrameworkCore;
using Security.Core;
using Security.Core.Interfaces;

namespace Inventory.EntityFrameworkCore
{
    public class EntityDbContextFactory : ISecurityCoreDbContextFactory
    {
        private readonly DbContextOptions _options;

        public EntityDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public SecurityCoreDbContext Build()
        {
            return new EntityDbContext(_options);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}