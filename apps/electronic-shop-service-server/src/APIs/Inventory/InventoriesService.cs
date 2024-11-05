using ElectronicShopService.Infrastructure;

namespace ElectronicShopService.APIs;

public class InventoriesService : InventoriesServiceBase
{
    public InventoriesService(ElectronicShopServiceDbContext context)
        : base(context) { }
}
