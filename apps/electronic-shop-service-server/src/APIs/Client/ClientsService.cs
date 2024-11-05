using ElectronicShopService.Infrastructure;

namespace ElectronicShopService.APIs;

public class ClientsService : ClientsServiceBase
{
    public ClientsService(ElectronicShopServiceDbContext context)
        : base(context) { }
}
