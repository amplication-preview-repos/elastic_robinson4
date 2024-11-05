using ElectronicShopService.APIs;
using ElectronicShopService.APIs.Common;
using ElectronicShopService.APIs.Dtos;
using ElectronicShopService.APIs.Errors;
using ElectronicShopService.APIs.Extensions;
using ElectronicShopService.Infrastructure;
using ElectronicShopService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicShopService.APIs;

public abstract class StocksServiceBase : IStocksService
{
    protected readonly ElectronicShopServiceDbContext _context;

    public StocksServiceBase(ElectronicShopServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Stock
    /// </summary>
    public async Task<Stock> CreateStock(StockCreateInput createDto)
    {
        var stock = new StockDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            stock.Id = createDto.Id;
        }

        _context.Stocks.Add(stock);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<StockDbModel>(stock.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Stock
    /// </summary>
    public async Task DeleteStock(StockWhereUniqueInput uniqueId)
    {
        var stock = await _context.Stocks.FindAsync(uniqueId.Id);
        if (stock == null)
        {
            throw new NotFoundException();
        }

        _context.Stocks.Remove(stock);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Stocks
    /// </summary>
    public async Task<List<Stock>> Stocks(StockFindManyArgs findManyArgs)
    {
        var stocks = await _context
            .Stocks.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return stocks.ConvertAll(stock => stock.ToDto());
    }

    /// <summary>
    /// Meta data about Stock records
    /// </summary>
    public async Task<MetadataDto> StocksMeta(StockFindManyArgs findManyArgs)
    {
        var count = await _context.Stocks.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Stock
    /// </summary>
    public async Task<Stock> Stock(StockWhereUniqueInput uniqueId)
    {
        var stocks = await this.Stocks(
            new StockFindManyArgs { Where = new StockWhereInput { Id = uniqueId.Id } }
        );
        var stock = stocks.FirstOrDefault();
        if (stock == null)
        {
            throw new NotFoundException();
        }

        return stock;
    }

    /// <summary>
    /// Update one Stock
    /// </summary>
    public async Task UpdateStock(StockWhereUniqueInput uniqueId, StockUpdateInput updateDto)
    {
        var stock = updateDto.ToModel(uniqueId);

        _context.Entry(stock).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Stocks.Any(e => e.Id == stock.Id))
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
