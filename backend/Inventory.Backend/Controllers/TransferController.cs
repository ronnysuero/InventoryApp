using System;
using Inventory.Backend.Controllers.Abstract;
using Inventory.Entity;
using Inventory.Service;
using Microsoft.AspNetCore.Mvc;
using Security.Core.Authorization;
using UtilsCore.Crud;
using UtilsCore.Interfaces;
using UtilsCore.Mvc;

namespace Inventory.Backend.Controllers
{
    public class TransferController : GetPageController<TransferService>
    {
        [HttpPost("[action]")]
        [AuthorizeAccess(CrudAction.Create)]
        public IActionResult Add([FromBody] Transaction model)
        {
            if (model is IUserInfo info)
            {
                info.UIN = AuthUser.UserName;
                info.FIN = DateTime.Now;
            }

            return new JsonActionResult(Service.Save(model));
        }
    }
}