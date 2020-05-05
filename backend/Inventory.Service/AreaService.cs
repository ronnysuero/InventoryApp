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
    public class AreaService : ICrudRepository<Area>
    {
        private readonly EntityDbContext _db;

        public AreaService(EntityDbContext context)
        {
            _db = context;
        }

        public Area Requery(IdentityValue identity)
        {
            return Find(f => f.AreaId == identity.ToInt);
        }

        public Area Save(Area model)
        {
            _db.Area
                .PrepareModel(model)
                .ToUpper(u => new {u.Name})
                .SaveChanges();

            return Find(f => f.AreaId == model.AreaId);
        }

        public Area Find(Expression<Func<Area, bool>> predicate)
        {
            return Query().Where(predicate).FirstOrDefault();
        }

        public bool Delete(IdentityValue identity)
        {
            var entity = _db.Area.FirstOrDefault(f => f.AreaId == identity.ToInt);

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

        public IQueryable<Area> Query()
        {
            return _db.Area;
        }
    }
}