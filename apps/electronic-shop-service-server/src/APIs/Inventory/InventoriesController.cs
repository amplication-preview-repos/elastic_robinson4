using Microsoft.AspNetCore.Mvc;

namespace ElectronicShopService.APIs;

[ApiController()]
public class InventoriesController : InventoriesControllerBase
{
    public InventoriesController(IInventoriesService service)
        : base(service) { }
}
