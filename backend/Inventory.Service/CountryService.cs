using System.Collections;
using Inventory.EntityFrameworkCore;
using UtilsCore.Filter.Json;
using UtilsCore.Pagination;
using UtilsCore.Pagination.Interfaces;
using UtilsCore.Sort;

namespace Inventory.Service
{
    public class CountryService : IPagedData
    {
        private readonly EntityDbContext _db;

        public CountryService(EntityDbContext context)
        {
            _db = context;
        }

        public IList GetPage(IPageParameter input)
        {
            return _db.Country
                .AddJsonFilters(input.Filters)
                .AddOrderByRange(input.Sorts)
                .ToPagedList(input.Page);
        }
    }
}