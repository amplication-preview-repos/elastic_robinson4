using ElectronicShopService.Infrastructure;

namespace ElectronicShopService.APIs;

public class ProductsService : ProductsServiceBase
{
    public ProductsService(ElectronicShopServiceDbContext context)
        : base(context) { }
}
