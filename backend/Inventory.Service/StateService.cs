using System.Collections;
using System.Linq;
using Inventory.Entity;
using Inventory.EntityFrameworkCore;
using UtilsCore.Filter.Json;
using UtilsCore.Pagination;
using UtilsCore.Pagination.Interfaces;
using UtilsCore.Sort;

namespace Inventory.Service
{
    public class StateService : IPagedData
    {
        private readonly EntityDbContext _db;

        public StateService(EntityDbContext context)
        {
            _db = context;
        }

        public IList GetPage(IPageParameter input)
        {
            return _db.State
                .AddJsonFilters(input.Filters)
                .AddOrderByRange(input.Sorts)
                .ToPagedList(input.Page);
        }

        public IList GetStatesRD(IPageParameter input)
        {
            return _db.State.Where(w => w.CountryId == Country.REPUBLICA_DOMINICANA).ToList();
        }
    }
}