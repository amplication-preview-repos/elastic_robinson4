using ElectronicShopService.APIs;
using ElectronicShopService.APIs.Common;
using ElectronicShopService.APIs.Dtos;
using ElectronicShopService.APIs.Errors;
using ElectronicShopService.APIs.Extensions;
using ElectronicShopService.Infrastructure;
using ElectronicShopService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicShopService.APIs;

public abstract class ProductCategoriesServiceBase : IProductCategoriesService
{
    protected readonly ElectronicShopServiceDbContext _context;

    public ProductCategoriesServiceBase(ElectronicShopServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one ProductCategory
    /// </summary>
    public async Task<ProductCategory> CreateProductCategory(ProductCategoryCreateInput createDto)
    {
        var productCategory = new ProductCategoryDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            productCategory.Id = createDto.Id;
        }

        _context.ProductCategories.Add(productCategory);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ProductCategoryDbModel>(productCategory.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ProductCategory
    /// </summary>
    public async Task DeleteProductCategory(ProductCategoryWhereUniqueInput uniqueId)
    {
        var productCategory = await _context.ProductCategories.FindAsync(uniqueId.Id);
        if (productCategory == null)
        {
            throw new NotFoundException();
        }

        _context.ProductCategories.Remove(productCategory);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ProductCategories
    /// </summary>
    public async Task<List<ProductCategory>> ProductCategories(
        ProductCategoryFindManyArgs findManyArgs
    )
    {
        var productCategories = await _context
            .ProductCategories.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return productCategories.ConvertAll(productCategory => productCategory.ToDto());
    }

    /// <summary>
    /// Meta data about ProductCategory records
    /// </summary>
    public async Task<MetadataDto> ProductCategoriesMeta(ProductCategoryFindManyArgs findManyArgs)
    {
        var count = await _context.ProductCategories.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one ProductCategory
    /// </summary>
    public async Task<ProductCategory> ProductCategory(ProductCategoryWhereUniqueInput uniqueId)
    {
        var productCategories = await this.ProductCategories(
            new ProductCategoryFindManyArgs
            {
                Where = new ProductCategoryWhereInput { Id = uniqueId.Id }
            }
        );
        var productCategory = productCategories.FirstOrDefault();
        if (productCategory == null)
        {
            throw new NotFoundException();
        }

        return productCategory;
    }

    /// <summary>
    /// Update one ProductCategory
    /// </summary>
    public async Task UpdateProductCategory(
        ProductCategoryWhereUniqueInput uniqueId,
        ProductCategoryUpdateInput updateDto
    )
    {
        var productCategory = updateDto.ToModel(uniqueId);

        _context.Entry(productCategory).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ProductCategories.Any(e => e.Id == productCategory.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
