using Inventory.Backend.Controllers.Abstract;
using Inventory.Entity.Models;
using Inventory.Service;
using Microsoft.AspNetCore.Mvc;
using Security.Core.Authorization;
using UtilsCore.Crud;
using UtilsCore.Mvc;

namespace Inventory.Backend.Controllers
{
    public class ReportController : GetPageController<ReportService>
    {
        [HttpPost("[action]")]
        [AuthorizeAccess(CrudAction.Read)]
        public virtual IActionResult GetData([FromBody] ReportParams model)
        {
            var data = Service.GetData(model);

            return new JsonActionResult(
                data,
                data?.Count
            );
        }
    }
}