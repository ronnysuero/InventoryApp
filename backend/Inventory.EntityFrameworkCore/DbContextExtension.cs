using System;
using UtilsCore.EFCore;

namespace Inventory.EntityFrameworkCore
{
    public static class DbContextExtension
    {
        public static TEntity SaveChanges<TEntity>(this IModelPreparation<TEntity> preparation) where TEntity : class
        {
            return preparation.SaveChanges(null);
        }

        private static TEntity SaveChanges<TEntity>(
            this IModelPreparation<TEntity> preparation,
            Action<TEntity> afterSave,
            bool saveOnes = false
        ) where TEntity : class
        {
            preparation.SetState();
            preparation.UnMappedProperties();

            if (!saveOnes) preparation.Db.SaveChanges();

            //cualquier otro codigo que deseemos manejar en esta transaccion
            afterSave?.Invoke(preparation.Entity);

            if (preparation.Db.ChangeTracker.HasChanges()) preparation.Db.SaveChanges();

            return preparation.Entity;
        }
    }
}