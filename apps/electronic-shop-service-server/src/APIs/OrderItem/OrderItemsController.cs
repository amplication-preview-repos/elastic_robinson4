using Microsoft.AspNetCore.Mvc;

namespace ElectronicShopService.APIs;

[ApiController()]
public class OrderItemsController : OrderItemsControllerBase
{
    public OrderItemsController(IOrderItemsService service)
        : base(service) { }
}
