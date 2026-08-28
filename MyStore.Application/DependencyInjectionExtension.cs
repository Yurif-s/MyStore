using Microsoft.Extensions.DependencyInjection;
using MyStore.Application.UseCases.Auth.Login;
using MyStore.Application.UseCases.Auth.Register;
using MyStore.Application.UseCases.Category.Create;
using MyStore.Application.UseCases.Category.Delete;
using MyStore.Application.UseCases.Category.GetAll;
using MyStore.Application.UseCases.Category.GetBySlug;
using MyStore.Application.UseCases.Category.Update;
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

        services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
        services.AddScoped<IGetAllCategoriesUseCase, GetAllCategoriesUseCase>();
        services.AddScoped<IGetCategoryBySlugUseCase, GetCategoryBySlugUseCase>();
        services.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
        services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();

        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<ILoginUserUseCase, LoginUserUseCase>();
    }
}
