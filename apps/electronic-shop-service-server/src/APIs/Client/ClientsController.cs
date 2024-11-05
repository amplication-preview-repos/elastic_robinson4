using Microsoft.AspNetCore.Mvc;

namespace ElectronicShopService.APIs;

[ApiController()]
public class ClientsController : ClientsControllerBase
{
    public ClientsController(IClientsService service)
        : base(service) { }
}
