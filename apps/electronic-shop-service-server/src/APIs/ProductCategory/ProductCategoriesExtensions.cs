using ElectronicShopService.APIs.Dtos;
using ElectronicShopService.Infrastructure.Models;

namespace ElectronicShopService.APIs.Extensions;

public static class ProductCategoriesExtensions
{
    public static ProductCategory ToDto(this ProductCategoryDbModel model)
    {
        return new ProductCategory
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ProductCategoryDbModel ToModel(
        this ProductCategoryUpdateInput updateDto,
        ProductCategoryWhereUniqueInput uniqueId
    )
    {
        var productCategory = new ProductCategoryDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            productCategory.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            productCategory.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return productCategory;
    }
}
