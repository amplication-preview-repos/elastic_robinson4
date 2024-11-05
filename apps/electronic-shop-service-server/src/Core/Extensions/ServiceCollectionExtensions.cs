using ElectronicShopService.APIs;

namespace ElectronicShopService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IClientsService, ClientsService>();
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<IInventoriesService, InventoriesService>();
        services.AddScoped<IOrdersService, OrdersService>();
        services.AddScoped<IOrderItemsService, OrderItemsService>();
        services.AddScoped<IProductsService, ProductsService>();
        services.AddScoped<IProductCategoriesService, ProductCategoriesService>();
        services.AddScoped<IStocksService, StocksService>();
    }
}
