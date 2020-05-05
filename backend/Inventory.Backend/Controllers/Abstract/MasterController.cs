using Security.Core.Controller.Crud;
using UtilsCore.Interfaces;

namespace Inventory.Backend.Controllers.Abstract
{
    public abstract class MasterController<TModel, TService> : CrudController<TModel, TService>
        where TService : ICrudRepository<TModel>
        where TModel : class
    {
    }
}