using ElectronicShopService.APIs.Common;
using ElectronicShopService.APIs.Dtos;

namespace ElectronicShopService.APIs;

public interface IStocksService
{
    /// <summary>
    /// Create one Stock
    /// </summary>
    public Task<Stock> CreateStock(StockCreateInput stock);

    /// <summary>
    /// Delete one Stock
    /// </summary>
    public Task DeleteStock(StockWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Stocks
    /// </summary>
    public Task<List<Stock>> Stocks(StockFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Stock records
    /// </summary>
    public Task<MetadataDto> StocksMeta(StockFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Stock
    /// </summary>
    public Task<Stock> Stock(StockWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Stock
    /// </summary>
    public Task UpdateStock(StockWhereUniqueInput uniqueId, StockUpdateInput updateDto);
}
