using ElectronicShopService.Infrastructure;

namespace ElectronicShopService.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(ElectronicShopServiceDbContext context)
        : base(context) { }
}
