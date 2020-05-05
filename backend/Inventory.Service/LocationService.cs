using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using Inventory.Entity;
using Inventory.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UtilsCore.EFCore;
using UtilsCore.Filter.Json;
using UtilsCore.Helper;
using UtilsCore.Interfaces;
using UtilsCore.Pagination;
using UtilsCore.Pagination.Interfaces;
using UtilsCore.Sort;

namespace Inventory.Service
{
    public class LocationService : ICrudRepository<Location>
    {
        private readonly EntityDbContext _db;

        public LocationService(EntityDbContext context)
        {
            _db = context;
        }

        public Location Requery(IdentityValue identity)
        {
            return Find(f => f.LocationId == identity.ToInt);
        }

        public Location Save(Location model)
        {
            _db.ExecuteStrategy(() =>
            {
                var isNew = model.LocationId == 0;

                _db.Location
                    .PrepareModel(model)
                    .ToUpper(u => new {u.Name})
                    .SaveChanges();


                if (isNew)
                {
                }

                _db.SaveChanges();
            });

            return Find(f => f.LocationId == model.LocationId);
        }

        public Location Find(Expression<Func<Location, bool>> predicate)
        {
            return Query().Where(predicate).FirstOrDefault();
        }

        public bool Delete(IdentityValue identity)
        {
            var entity =
                _db.Location.FirstOrDefault(f =>
                    f.LocationId == identity.ToInt);

            if (entity == null) throw new ApplicationException("Registro no encontrado");

            _db.Entry(entity).State = EntityState.Deleted;

            return _db.SaveChanges() > 0;
        }

        public IList GetPage(IPageParameter input)
        {
            return Query()
                .AddJsonFilters(input.Filters)
                .AddOrderByRange(input.Sorts)
                .ToPagedList(input.Page);
        }

        public IQueryable<Location> Query()
        {
            return _db.Location;
        }

        public object GetDefaultData(IPageParameter input)
        {
            return new
            {
                CountryId = Country.REPUBLICA_DOMINICANA,
                StateId = State.SANTO_DOMINGO
            };
        }
    }
}