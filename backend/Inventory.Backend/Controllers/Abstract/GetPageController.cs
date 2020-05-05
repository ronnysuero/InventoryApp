using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Security.Core.Authorization;
using Security.Core.Controller.Crud;
using UtilsCore.Crud;
using UtilsCore.Filter;
using UtilsCore.Mvc;
using UtilsCore.Pagination.Interfaces;
using UtilsCore.Response;

namespace Inventory.Backend.Controllers.Abstract
{
    public abstract class GetPageController<TService> : SecurityBaseController
        where TService : IPagedData
    {
        protected TService Service => HttpContext.RequestServices.GetRequiredService<TService>();

        [HttpPost("[action]")]
        [AuthorizeAccess(CrudAction.Read)]
        public virtual IActionResult Get([FromBody] RequestSetting requestSetting)
        {
            if (requestSetting == null) requestSetting = new RequestSetting();
            else if (!string.IsNullOrEmpty(requestSetting.FilterText))
            {
                IsFilterServiceInjected();

                requestSetting.Filters = AdvanceFilterQuery.GetDefaultFilter(
                    Filters.GetFilters(ControllerName),
                    requestSetting.FilterText
                );
            }

            var data = Service.GetPage(requestSetting);

            var result = new JsonActionResult(
                data,
                InternalSetting(requestSetting),
                requestSetting.Page?.RowCount ?? data?.Count
            );

            return result;
        }
    }
}