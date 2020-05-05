using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Service
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<AreaService>();
            services.AddScoped<CountryService>();
            services.AddScoped<ItemService>();
            services.AddScoped<LocationService>();
            services.AddScoped<ManufacturerService>();
            services.AddScoped<StateService>();
            services.AddScoped<TransactionTypeService>();
            services.AddScoped<TransactionService>();
            services.AddScoped<TransferService>();
            services.AddScoped<ReportService>();
        }
    }
}