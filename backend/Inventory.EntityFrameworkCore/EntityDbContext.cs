using Inventory.Entity;
using Inventory.EntityFrameworkCore.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Core;
using Security.Core.Entities;
using IdentityRole = Security.Core.Entities.IdentityRole;
using IdentityUser = Security.Core.Entities.IdentityUser;

namespace Inventory.EntityFrameworkCore
{
    public class EntityDbContext : SecurityCoreDbContext
    {
        public EntityDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void SeedForms(ModelBuilder modelBuilder)
        {
        }

        protected override void SeedMenus(ModelBuilder modelBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // it should be placed here, otherwise it will rewrite the following settings!
            base.OnModelCreating(modelBuilder);

            modelBuilder.SetSchema();
            modelBuilder.GlobalSeed();
        }

        #region IDENTITY CONFIGURATION

        protected override void ConfigureIdentityForm(EntityTypeBuilder<IdentityForm> builder)
        {
        }

        protected override void ConfigureIdentityUserForm(EntityTypeBuilder<IdentityUserForm> builder)
        {
        }

        protected override void ConfigureIdentityRoleForm(EntityTypeBuilder<IdentityRoleForm> builder)
        {
        }

        protected override void ConfigureIdentityRole(EntityTypeBuilder<IdentityRole> builder)
        {
        }

        protected override void ConfigureIdentityUser(EntityTypeBuilder<IdentityUser> builder)
        {
        }

        protected override void ConfigureIdentityUserRole(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
        }

        protected override void ConfigureIdentityUserToken(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
        }

        protected override void ConfigureIdentityMenu(EntityTypeBuilder<IdentityMenu> builder)
        {
        }

        protected override void ConfigureIdentityRoleMenu(EntityTypeBuilder<IdentityRoleMenu> builder)
        {
        }

        protected override void ConfigureIdentityUserMenu(EntityTypeBuilder<IdentityUserMenu> builder)
        {
        }

        #endregion

        public DbSet<Area> Area { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemLocation> ItemLocation { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}