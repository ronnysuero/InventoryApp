using System.Collections;
using System.Linq;
using Inventory.EntityFrameworkCore;
using UtilsCore.Filter.Json;
using UtilsCore.Pagination;
using UtilsCore.Pagination.Interfaces;
using UtilsCore.Sort;

namespace Inventory.Service
{
    public class TransactionTypeService : IPagedData
    {
        private readonly EntityDbContext _db;

        public TransactionTypeService(EntityDbContext context)
        {
            _db = context;
        }

        public IList GetPage(IPageParameter input)
        {
            return _db.TransactionType
                .Where(w => !w.Hide)
                .AddJsonFilters(input.Filters)
                .AddOrderByRange(input.Sorts)
                .ToPagedList(input.Page);
        }
    }
}