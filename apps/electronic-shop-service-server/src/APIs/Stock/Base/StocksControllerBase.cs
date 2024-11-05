using ElectronicShopService.APIs;
using ElectronicShopService.APIs.Common;
using ElectronicShopService.APIs.Dtos;
using ElectronicShopService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicShopService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class StocksControllerBase : ControllerBase
{
    protected readonly IStocksService _service;

    public StocksControllerBase(IStocksService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Stock
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Stock>> CreateStock(StockCreateInput input)
    {
        var stock = await _service.CreateStock(input);

        return CreatedAtAction(nameof(Stock), new { id = stock.Id }, stock);
    }

    /// <summary>
    /// Delete one Stock
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteStock([FromRoute()] StockWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteStock(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Stocks
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Stock>>> Stocks([FromQuery()] StockFindManyArgs filter)
    {
        return Ok(await _service.Stocks(filter));
    }

    /// <summary>
    /// Meta data about Stock records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> StocksMeta([FromQuery()] StockFindManyArgs filter)
    {
        return Ok(await _service.StocksMeta(filter));
    }

    /// <summary>
    /// Get one Stock
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Stock>> Stock([FromRoute()] StockWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Stock(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Stock
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateStock(
        [FromRoute()] StockWhereUniqueInput uniqueId,
        [FromQuery()] StockUpdateInput stockUpdateDto
    )
    {
        try
        {
            await _service.UpdateStock(uniqueId, stockUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
