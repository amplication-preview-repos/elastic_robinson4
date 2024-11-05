using ElectronicShopService.Infrastructure;

namespace ElectronicShopService.APIs;

public class StocksService : StocksServiceBase
{
    public StocksService(ElectronicShopServiceDbContext context)
        : base(context) { }
}
