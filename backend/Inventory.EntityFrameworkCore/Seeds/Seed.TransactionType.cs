using Inventory.Entity;
using Microsoft.EntityFrameworkCore;

namespace Inventory.EntityFrameworkCore.Seeds
{
    public static partial class Seed
    {
        private static void SeedTransactionType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionType>(e =>
                {
                    e.HasData(
                        new TransactionType
                        {
                            TransactionTypeId = ETransactionType.NewStock,
                            Name = "Nuevo stock"
                        },
                        new TransactionType
                        {
                            TransactionTypeId = ETransactionType.UnusableReturn,
                            Name = "Devolución - inutilizable"
                        },
                        new TransactionType
                        {
                            TransactionTypeId = ETransactionType.UsableReturn,
                            Name = "Devolución - utilizable"
                        },
                        new TransactionType
                        {
                            TransactionTypeId = ETransactionType.TransferIn,
                            Name = "Transferencia entrante",
                            Hide = true
                        },
                        new TransactionType
                        {
                            TransactionTypeId = ETransactionType.TransferOut,
                            Name = "Transferencia saliente",
                            Hide = true
                        },
                        new TransactionType
                        {
                            TransactionTypeId = ETransactionType.CustomerSale,
                            Name = "Venta al cliente",
                            Hide = true
                        },
                        new TransactionType
                        {
                            TransactionTypeId = ETransactionType.DamagedStock,
                            Name = "Stock dañado",
                            Hide = true
                        }
                    );
                }
            );
        }
    }
}