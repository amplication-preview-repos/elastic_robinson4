using ElectronicShopService.APIs.Dtos;
using ElectronicShopService.Infrastructure.Models;

namespace ElectronicShopService.APIs.Extensions;

public static class StocksExtensions
{
    public static Stock ToDto(this StockDbModel model)
    {
        return new Stock
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static StockDbModel ToModel(
        this StockUpdateInput updateDto,
        StockWhereUniqueInput uniqueId
    )
    {
        var stock = new StockDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            stock.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            stock.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return stock;
    }
}
