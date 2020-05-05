using Inventory.Backend.Controllers.Abstract;
using Inventory.Entity;
using Inventory.Service;

namespace Inventory.Backend.Controllers
{
    public class ItemController : MasterController<Item, ItemService>
    {
    }
}