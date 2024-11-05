using Microsoft.AspNetCore.Mvc;

namespace ElectronicShopService.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
