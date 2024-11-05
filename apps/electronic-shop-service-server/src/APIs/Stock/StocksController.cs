using Microsoft.AspNetCore.Mvc;

namespace ElectronicShopService.APIs;

[ApiController()]
public class StocksController : StocksControllerBase
{
    public StocksController(IStocksService service)
        : base(service) { }
}
