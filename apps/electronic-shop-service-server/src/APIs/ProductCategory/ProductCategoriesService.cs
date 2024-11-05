using ElectronicShopService.Infrastructure;

namespace ElectronicShopService.APIs;

public class ProductCategoriesService : ProductCategoriesServiceBase
{
    public ProductCategoriesService(ElectronicShopServiceDbContext context)
        : base(context) { }
}
