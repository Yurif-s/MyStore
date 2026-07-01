using Microsoft.Extensions.DependencyInjection;
using MyStore.Application.UseCases.Product.Activate;
using MyStore.Application.UseCases.Product.Create;
using MyStore.Application.UseCases.Product.GetAll;
using MyStore.Application.UseCases.Product.GetById;
using MyStore.Application.UseCases.Product.Update;

namespace MyStore.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
        return services;
    }
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
        services.AddScoped<IGetAllProductsUseCase, GetAllProductsUseCase>();
        services.AddScoped<IGetProductByIdUseCase, GetProductByIdUseCase>();
        services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();
        services.AddScoped<IUpdateStockUseCase, UpdateStockUseCase>();
        services.AddScoped<IActivateProductUseCase, ActivateProductUseCase>();
        services.AddScoped<IDeactivateProductUseCase, DeactivateProductUseCase>();
    }
}
