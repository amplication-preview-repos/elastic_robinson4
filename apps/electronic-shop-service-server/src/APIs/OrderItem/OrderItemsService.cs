using ElectronicShopService.Infrastructure;

namespace ElectronicShopService.APIs;

public class OrderItemsService : OrderItemsServiceBase
{
    public OrderItemsService(ElectronicShopServiceDbContext context)
        : base(context) { }
}
