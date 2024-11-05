using ElectronicShopService.Infrastructure;

namespace ElectronicShopService.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(ElectronicShopServiceDbContext context)
        : base(context) { }
}
