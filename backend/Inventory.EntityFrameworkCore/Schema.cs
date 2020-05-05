using Inventory.Entity;
using Microsoft.EntityFrameworkCore;

namespace Inventory.EntityFrameworkCore
{
    public static class Schema
    {
        public static void SetSchema(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity => entity.HasIndex(i => new {i.Name, i.UniqueIdentifier}).IsUnique());

            modelBuilder.Entity<Country>(entity => entity.HasIndex(i => new {i.Name}).IsUnique());

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.SKU).IsRequired();
                entity.HasIndex(e => new {e.Name, e.UniqueIdentifier}).IsUnique();
                entity.HasIndex(e => new {e.SKU, e.UniqueIdentifier}).IsUnique();
            });

            modelBuilder.Entity<ItemLocation>(entity =>
            {
                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ItemLocation)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemLocation)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasIndex(e => new {e.ItemId, e.LocationId}).IsUnique();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasOne(d => d.State)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasIndex(i => new {i.Name, i.UniqueIdentifier}).IsUnique();
            });

            modelBuilder.Entity<Manufacturer>(entity =>
                entity.HasIndex(i => new {i.Name, i.UniqueIdentifier}
                ).IsUnique());

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasIndex(i => new {i.Name}).IsUnique();
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TransactionType>(entity => entity.HasIndex(i => new {i.Name}).IsUnique());
        }
    }
}