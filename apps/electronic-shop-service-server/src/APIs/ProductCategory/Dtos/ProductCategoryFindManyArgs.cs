using ElectronicShopService.APIs.Common;
using ElectronicShopService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicShopService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ProductCategoryFindManyArgs
    : FindManyInput<ProductCategory, ProductCategoryWhereInput> { }
