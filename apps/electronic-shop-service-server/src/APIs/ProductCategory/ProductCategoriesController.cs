using Microsoft.AspNetCore.Mvc;

namespace ElectronicShopService.APIs;

[ApiController()]
public class ProductCategoriesController : ProductCategoriesControllerBase
{
    public ProductCategoriesController(IProductCategoriesService service)
        : base(service) { }
}
