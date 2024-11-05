using ElectronicShopService.APIs.Common;
using ElectronicShopService.APIs.Dtos;

namespace ElectronicShopService.APIs;

public interface IProductCategoriesService
{
    /// <summary>
    /// Create one ProductCategory
    /// </summary>
    public Task<ProductCategory> CreateProductCategory(ProductCategoryCreateInput productcategory);

    /// <summary>
    /// Delete one ProductCategory
    /// </summary>
    public Task DeleteProductCategory(ProductCategoryWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ProductCategories
    /// </summary>
    public Task<List<ProductCategory>> ProductCategories(ProductCategoryFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about ProductCategory records
    /// </summary>
    public Task<MetadataDto> ProductCategoriesMeta(ProductCategoryFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ProductCategory
    /// </summary>
    public Task<ProductCategory> ProductCategory(ProductCategoryWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one ProductCategory
    /// </summary>
    public Task UpdateProductCategory(
        ProductCategoryWhereUniqueInput uniqueId,
        ProductCategoryUpdateInput updateDto
    );
}
