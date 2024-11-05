using ElectronicShopService.APIs;
using ElectronicShopService.APIs.Common;
using ElectronicShopService.APIs.Dtos;
using ElectronicShopService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicShopService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ProductCategoriesControllerBase : ControllerBase
{
    protected readonly IProductCategoriesService _service;

    public ProductCategoriesControllerBase(IProductCategoriesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one ProductCategory
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ProductCategory>> CreateProductCategory(
        ProductCategoryCreateInput input
    )
    {
        var productCategory = await _service.CreateProductCategory(input);

        return CreatedAtAction(
            nameof(ProductCategory),
            new { id = productCategory.Id },
            productCategory
        );
    }

    /// <summary>
    /// Delete one ProductCategory
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteProductCategory(
        [FromRoute()] ProductCategoryWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteProductCategory(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ProductCategories
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ProductCategory>>> ProductCategories(
        [FromQuery()] ProductCategoryFindManyArgs filter
    )
    {
        return Ok(await _service.ProductCategories(filter));
    }

    /// <summary>
    /// Meta data about ProductCategory records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ProductCategoriesMeta(
        [FromQuery()] ProductCategoryFindManyArgs filter
    )
    {
        return Ok(await _service.ProductCategoriesMeta(filter));
    }

    /// <summary>
    /// Get one ProductCategory
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ProductCategory>> ProductCategory(
        [FromRoute()] ProductCategoryWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ProductCategory(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one ProductCategory
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateProductCategory(
        [FromRoute()] ProductCategoryWhereUniqueInput uniqueId,
        [FromQuery()] ProductCategoryUpdateInput productCategoryUpdateDto
    )
    {
        try
        {
            await _service.UpdateProductCategory(uniqueId, productCategoryUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
