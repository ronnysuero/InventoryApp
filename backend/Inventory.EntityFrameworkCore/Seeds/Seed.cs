using Microsoft.EntityFrameworkCore;

namespace Inventory.EntityFrameworkCore.Seeds
{
    public static partial class Seed
    {
        public static void GlobalSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedTransactionType();
            modelBuilder.SeedMenu();
            modelBuilder.SeedCountry();
            modelBuilder.SeedState();
        }
    }
}