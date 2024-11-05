using Microsoft.AspNetCore.Mvc;

namespace ElectronicShopService.APIs;

[ApiController()]
public class OrdersController : OrdersControllerBase
{
    public OrdersController(IOrdersService service)
        : base(service) { }
}
