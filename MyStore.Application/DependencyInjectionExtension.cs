using Microsoft.Extensions.DependencyInjection;
using MyStore.Application.UseCases.Product.Create;
using MyStore.Application.UseCases.Product.GetAll;
using MyStore.Application.UseCases.Product.GetById;

namespace MyStore.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
    }
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
        services.AddScoped<IGetAllProductsUseCase, GetAllProductsUseCase>();
        services.AddScoped<IGetProductByIdUseCase, GetProductByIdUseCase>();
    }
}
